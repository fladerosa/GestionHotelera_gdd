﻿using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using FrbaHotel.Commons;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class CrearHabitacion : Form
    {
        private Hotel hotel = null;

        public CrearHabitacion(Hotel hotel)
        {
            InitializeComponent();

            this.hotel = hotel;

            this.limpiarDatos();
        }

        public void limpiarDatos()
        {
            RepositorioTipoHabitacion repositorioTipoHab = new RepositorioTipoHabitacion();
            comboBoxTipoHabitacion.DataSource = repositorioTipoHab.getAll();
            comboBoxTipoHabitacion.DisplayMember = "Descripcion";
            comboBoxTipoHabitacion.SelectedIndex = -1;

            comboBoxUbicacion.DataSource = new[] { "Vista al exterior", "Interior" };
            comboBoxUbicacion.SelectedIndex = -1;

            checkBoxActiva.Checked = false;

            textNumero.Text = "";
            textPiso.Text = "";
        }

        private void buttonCrearHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = Utils.validateIntField(textNumero.Text, "Numero");
                int piso = Utils.validateIntField(textPiso.Text, "Piso");
                Hotel hotel = this.hotel;
                String ubicacion = Utils.validateStringFields((String)comboBoxUbicacion.SelectedItem, "Ubicacion");
                TipoHabitacion tipoHabitacion = (TipoHabitacion)Utils.validateFields(comboBoxTipoHabitacion.SelectedItem, "Tipo");
                RepositorioHabitacion repositorioHabitacion = new RepositorioHabitacion();
                bool activa= checkBoxActiva.Checked;
                Habitacion habitacion = new Habitacion(0, activa, numero, piso, ubicacion);
                habitacion.setHotel(hotel);
                habitacion.setTipoHabitacion(tipoHabitacion);
                repositorioHabitacion.create(habitacion);
                MessageBox.Show("Habitacion creada", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");

                this.limpiarDatos();

            }
            catch (RequestInvalidoException exception)
            {
                MessageBox.Show(exception.Message,"Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
            }
        }

        //CIERRO LA VENTANA CON ESCAPE
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }     
    }
}
