﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Excepciones;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioRol
    {
        [TestMethod]
        public void Test_Repo_Rol_CreacionInstancia_Rol()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getByNombre("AdminOriginal");
            Assert.AreEqual(5 , rol.getFuncionalidades().Count);

            rol = repositorioRol.getByNombre("Recepcionista");
            Assert.AreEqual(6, rol.getFuncionalidades().Count);

            rol = repositorioRol.getByNombre("Guest");
            Assert.AreEqual(1, rol.getFuncionalidades().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe rol con el ID asociado")]
        public void Test_Repo_Rol_getByIdFalla()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getById(50);
        }

        [TestMethod]
        public void Test_Repo_Rol_getAll() 
        {
            RepositorioRol repositorioRol = new RepositorioRol();

            Assert.AreEqual(5, repositorioRol.getAll().Count);

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getFuncionalidades().Exists(f => f.getDescripcion().Equals("ABMHotel"))));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getActivo().Equals(false)));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getNombre().Equals("Guest")));
        }

        [TestMethod]
        public void Test_Repo_Rol_exists()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rolAdministrador = repositorioRol.getByNombre("AdminOriginal");

            Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            Assert.IsTrue(repositorioRol.exists(rolAdministrador));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteNombreException), "No existe rol con el Nombre asociado")]
        public void Test_Repo_Rol_getByNameFalla()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getByNombre("RolFicticio");
        }

        [TestMethod]
        public void Test_Repo_Rol_getByQuery()
        {
            RepositorioRol repositorioRol = new RepositorioRol();

            //SIN FILTRO
            Assert.AreEqual(5, repositorioRol.getByQuery("", new KeyValuePair<String, Boolean>(), null).Count);

            //FILTRO NOMBRE
            Assert.AreEqual(1, repositorioRol.getByQuery("AdminOriginal", new KeyValuePair<String, Boolean>(), null).Count);

            //FILTRO ESTADO
            Assert.AreEqual(4, repositorioRol.getByQuery("", new KeyValuePair<String, Boolean>("", true), null).Count);

            //FILTRO NOMBRE Y ESTADO
            Assert.AreEqual(0, repositorioRol.getByQuery("Administrador", new KeyValuePair<String, Boolean>("", false), null).Count);

            //FALTA FILTRO FUNCIONALIDAD
        }

        [TestMethod]
        public void Test_Repo_Rol_Alta_Baja_Rol()
        {
            int idRolCreado = 0;
            RepositorioRol repositorioRol = new RepositorioRol();
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();

            //CARGA DE FUNCIONALIDADES
            funcionalidades.Add(repositorioFuncionalidad.getByDescripcion("ABMRol"));
            funcionalidades.Add(repositorioFuncionalidad.getByDescripcion("ABMUsuario"));
            funcionalidades.Add(repositorioFuncionalidad.getByDescripcion("ABMHotel"));
            funcionalidades.Add(repositorioFuncionalidad.getByDescripcion("ABMRegimenEstadia"));

            //ALTA DE ROL
            String nombreRol = "RolTest";
            Boolean activo = false;
            Rol rolTest = new Rol(0, nombreRol, activo, funcionalidades);
            idRolCreado = repositorioRol.create(rolTest);

            //RECUPERO EL ROL CREADO...
            rolTest = repositorioRol.getById(idRolCreado);

            //VALIDO
            Assert.AreEqual(6, repositorioRol.getAll().Count);
            Assert.AreEqual(nombreRol, rolTest.getNombre());
            Assert.AreEqual(activo, rolTest.getActivo());
            //Assert.AreEqual(4, rolDummy.getFuncionalidades().Count); //TENGO QUE IMPLEMENTAR LA CARGA DE FUNCIONALIDADES

            //BAJA DE ROL
            repositorioRol.delete(rolTest);

            //VALIDO
            Assert.AreEqual(5, repositorioRol.getAll().Count);
        }
    }
}
