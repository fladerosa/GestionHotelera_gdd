﻿using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FrbaHotel.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>
    {
        override public Usuario getById(int idUsuario)
        {
            //Elementos del usuario a devolver
            Usuario usuario;
            Boolean activo = false;
            int idIdentidad = 0;
            Identidad identidad = null;
            RepositorioIdentidad repoIdentidad = new RepositorioIdentidad();
            String username = "";
            String password = "";
            int intentosFallidosLogin = 0; 
            List<Rol> roles = new List<Rol>();
            List<Hotel> hoteles = new List<Hotel>();

            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Usuario WHERE idUsuario = @idUsuario";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                username = reader.GetString(reader.GetOrdinal("Username"));
                password = reader.GetString(reader.GetOrdinal("Password"));
                activo = reader.GetBoolean(reader.GetOrdinal("Activo"));
                intentosFallidosLogin = reader.GetInt32(reader.GetOrdinal("IntentosFallidosLogin"));
                idIdentidad = reader.GetInt32(reader.GetOrdinal("idIdentidad"));
                identidad = repoIdentidad.getById(idIdentidad);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (username.Equals("")) throw new NoExisteIDException("No existe usuario con el ID asociado");

            //Segunda Consulta para llenar los roles
            sqlCommand.CommandText = @"
                SELECT r.idRol
                FROM LOS_BORBOTONES.Rol_X_Usuario ru
                INNER JOIN LOS_BORBOTONES.Rol r ON r.idRol = ru.idRol
                WHERE ru.idUsuario = @idUsuario
            ";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            //Colecto los roles
            while (reader.Read())
            {
                //lleno el rol con el getbyID
                int idRol = reader.GetInt32(reader.GetOrdinal("idRol"));
                RepositorioRol repoRol = new RepositorioRol();
                roles.Add(repoRol.getById(idRol));
            }

            sqlConnection.Close();

            //Tercera Consulta para llenar los hoteles
            sqlCommand.CommandText = @"
                SELECT h.idHotel
                FROM LOS_BORBOTONES.Hotel_X_Usuario hu
                INNER JOIN LOS_BORBOTONES.Hotel h ON h.idHotel = hu.idHotel
                WHERE hu.idUsuario = @idUsuario
            ";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            //Colecto los hoteles
            while (reader.Read())
            {
                //lleno el hotel con el getbyID                
                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                //RepositorioHotel repoHotel = new RepositorioHotel();
                //hoteles.Add(repoHotel.getById(idHotel));         
            }

            sqlConnection.Close();
    
            //Armo el usuario completo
            usuario = new Usuario(idUsuario, identidad, username, password, intentosFallidosLogin, activo, roles, hoteles);

            return usuario;
        }

        override public List<Usuario> getAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idUsuario FROM LOS_BORBOTONES.Usuario";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idUsuario"))));
            }

            sqlConnection.Close();

            return usuarios;
        }

        override public int create(Usuario usuario)
        {
            int idUsuario = 0;
            if (this.exists(usuario))
            {
                //aca valido que el username sea unico
                throw new ElementoYaExisteException("Ya existe el usuario que intenta crear");
            }
            else
            {
                //llamo a crear la identidad y traigo el IdIdentidad
                RepositorioIdentidad repoIdentidad = new RepositorioIdentidad();
                int idIdentidad = repoIdentidad.create(usuario.getIdentidad());

                //llamo a crear la direccion y traigo el IdDireccion, le seteo el idIdentidad que lo necesita
                usuario.getIdentidad().getDireccion().setIdIdentidad(idIdentidad);
                RepositorioDireccion repoDireccion = new RepositorioDireccion();
                int idDireccion= repoDireccion.create(usuario.getIdentidad().getDireccion());

                //ahora ya tengo todo para crear el usuario

                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

                //encripto clave
                string passwordEncriptada = this.EncriptarSHA256(usuario.getPassword());
        
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@Username", usuario.getUsername());
                sqlCommand.Parameters.AddWithValue("@Activo", usuario.getActivo());
                sqlCommand.Parameters.AddWithValue("@Password", passwordEncriptada);
                sqlCommand.Parameters.AddWithValue("@IntentosFallidosLogin", usuario.getIntentosFallidosLogin());
                sqlCommand.Parameters.AddWithValue("@idIdentidad", idIdentidad);

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO LOS_BORBOTONES.Usuario(Username,Password,IntentosFallidosLogin,Activo,idIdentidad)
                    OUTPUT INSERTED.idUsuario
                    VALUES(@Username,@Password,@IntentosFallidosLogin,@Activo,@idIdentidad);

                    DECLARE @idUsuario int;
                    SET @idUsuario = SCOPE_IDENTITY();
                ");

                //AGREGO DINAMICAMENTE LOS ROLES A LA CONSULTA
                int i = 1;
                foreach (Rol r in usuario.getRoles())
                {
                    String paramName = "@idRol" + i.ToString();
                    sqlBuilder.AppendFormat("INSERT INTO LOS_BORBOTONES.Rol_X_Usuario(idRol,idUsuario) VALUES ({0}, @idUsuario)", paramName);
                    sqlCommand.Parameters.AddWithValue(paramName, r.getIdRol());
                    i++;
                }
                //AGREGO DINAMICAMENTE LOS HOTELES A LA CONSULTA
                int k = 1;
                foreach (Hotel h in usuario.getHoteles())
                {
                    String paramName = "@idHotel" + k.ToString();
                    sqlBuilder.AppendFormat("INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario(idHotel,idUsuario) VALUES ({0}, @idUsuario)", paramName);
                    sqlCommand.Parameters.AddWithValue(paramName, h.getIdHotel());
                    k++;
                }

                sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

                sqlCommand.CommandText = sqlBuilder.ToString();
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario"));
                }

                sqlConnection.Close();
            }

            return idUsuario;
        }

        override public void update(Usuario usuario)
        {
            if (this.exists(usuario))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Usuario usuario)
        {
            if (this.exists(usuario))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public void bajaLogica(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        override public Boolean exists(Usuario usuario)
        {
            int idUsuario = 0;
            String username = "";

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idUsuario", usuario.getIdUsuario());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE idUsuario = @idUsuario";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario"));
            }

            sqlConnection.Close();

            sqlCommand.Parameters.AddWithValue("@Username", usuario.getUsername());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT username FROM LOS_BORBOTONES.Usuario WHERE username = @Username";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                username = reader.GetString(reader.GetOrdinal("username"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el username coincide
            return idUsuario != 0 || usuario.getUsername().ToUpper().Equals(username.ToUpper());
        }

        public Usuario getByUsername(String username)
        {
            int idUsuario = 0;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@Username", username);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE username = @Username";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario"));
            }

            sqlConnection.Close();

            //Si no encuentro elemento con ese username tiro una excepción
            if (idUsuario.Equals(0)) throw new NoExisteNombreException("No existe usuario con el Username asociado");

            return getById(idUsuario);
        }
        //getByQuery que va a filtrar por lo que desee buscar el administrador en el listado
        // despues agregar el nombre y el apellido de la identidad

        public List<Usuario> getByQuery(String username, KeyValuePair<String, Boolean> estado, Hotel hotel, Rol rol)
        {
            List<Usuario> usuarios = new List<Usuario>();
            String query = "SELECT u.idUsuario FROM LOS_BORBOTONES.Usuario u";

            //Consulta SIN FILTRO
            if (username.Equals("") && estado.Key == null && hotel == null && rol == null)
            {
                usuarios = this.getAll();
            }
            else
            {
                //Consulta CON FILTROS
                //PREPARO TODO PARA HACER LA CONSULTA
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                //Booleano que uso para armar bien la consulta
                Boolean primerCriterioWhere = true;

                //Consulta por Hotel
                //Va primero porque el JOIN va antes que el WHERE
                if (hotel != null)
                {
                    sqlCommand.Parameters.AddWithValue("@Nombre", hotel.getNombre());
                    query = query + " INNER JOIN LOS_BORBOTONES.Hotel_X_Usuario hxu ON u.idUsuario = hxu.idUsuario INNER JOIN LOS_BORBOTONES.Hotel h ON h.idHotel = hxu.idHotel WHERE h.Nombre = @Nombre";
                    primerCriterioWhere = false;
                }
                //Consulta por Rol
                //Va primero porque el JOIN va antes que el WHERE
                if (rol != null)
                {
                    sqlCommand.Parameters.AddWithValue("@nombreRol", rol.getNombre());
                    query = query + " INNER JOIN LOS_BORBOTONES.Rol_X_Usuario rxu ON u.idUsuario = rxu.idUsuario INNER JOIN LOS_BORBOTONES.Rol r ON r.idRol = rxu.idRol WHERE r.Nombre = @nombreRol";
                    primerCriterioWhere = false;
                }

                //AGREGO FILTRO NOMBRE
                if (!username.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE u.Username LIKE @Nombre";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND u.Username LIKE @Nombre";
                    }
                    sqlCommand.Parameters.AddWithValue("@Nombre", "%" + username + "%");
                }

                //AGREGO FILTRO ESTADO
                if (estado.Key != null)
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE u.Activo = @Estado";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND u.Activo = @Estado";
                    }
                    sqlCommand.Parameters.AddWithValue("@Estado", Convert.ToInt32(estado.Value));
                }

                //HAGO LA CONSULTA
                sqlCommand.CommandText = query;
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                //ARMAR USUARIOS
                while (reader.Read())
                {
                    usuarios.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idUsuario"))));
                }

                sqlConnection.Close();
            }

            return usuarios;
        }

        public string EncriptarSHA256(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public Usuario AutenticarUsuario(String username, String password)
        {
            string passwordEncriptada = this.EncriptarSHA256(password);
            Usuario usuario = null;

            //VALIDO SI EXISTE PRIMERO EL USUARIO
            if (this.getAll().Exists(usr => usr.getUsername().ToUpper().Equals(username.ToUpper())))
            {
                usuario = this.getByUsername(username);

                //SI LA PASSWORD ESTA BIEN Y EL USUARIO NO ESTA BLOQUEADO
                if (usuario.getPassword().Equals(passwordEncriptada) && usuario.getIntentosFallidosLogin() < 3 && usuario.getActivo())
                {
                    return usuario;
                }
                else
                {
                    //SI HUBO UN ERROR DE CREDENCIALES Y EL USUARIO TODAVIA NO ESTA BLOQUEADO
                    if (!usuario.getPassword().Equals(passwordEncriptada) && usuario.getIntentosFallidosLogin() < 3 && usuario.getActivo())
                    {
                        //ESTO FALTA DESARROLLARLO
                        /*
                        usuario.incrementarIntentosFallidosLogin();
                        
                        if (usuario.getIntentosFallidosLogin() >= 3)
                        {
                            usuario.setActivo(false);
                        }
                        
                        repositorioUsuario.update(usuario); //GRABA LOS CAMBIOS EN LA BASE
                        */

                        throw new ErrorDeAutenticacionException("Las credenciales son incorrectas");
                    }
                    //LUEGO SI EL USUARIO ESTA BLOQUEADO
                    else if (usuario.getIntentosFallidosLogin() >= 3 || !usuario.getActivo())
                    {
                        throw new UsuarioBloqueadoException("El usuario esta bloqueado o deshabilitado");
                    }
                }
            }
            else
            {
                //EL USUARIO NO EXISTE
                throw new ErrorDeAutenticacionException("Las credenciales son incorrectas");
            }

            return usuario;
        }
    }
}
