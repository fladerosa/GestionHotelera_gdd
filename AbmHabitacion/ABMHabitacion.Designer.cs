﻿using System.Windows.Forms;
namespace FrbaHotel.AbmHabitacion
{
    partial class ABMHabitacion
    {


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxActiva = new System.Windows.Forms.CheckBox();
            this.buttonAltaHabitacion = new System.Windows.Forms.Button();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.buttonModificarHabitacion = new System.Windows.Forms.Button();
            this.comboBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.buttonBajaHabitacion = new System.Windows.Forms.Button();
            this.buttonBbuscarHoteles = new System.Windows.Forms.Button();
            this.registroHabitaciones = new System.Windows.Forms.DataGridView();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textPiso = new System.Windows.Forms.TextBox();
            this.labelPiso = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registroHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.checkBoxActiva);
            this.groupBox2.Controls.Add(this.buttonAltaHabitacion);
            this.groupBox2.Controls.Add(this.labelTipoHabitacion);
            this.groupBox2.Controls.Add(this.buttonModificarHabitacion);
            this.groupBox2.Controls.Add(this.comboBoxTipoHabitacion);
            this.groupBox2.Controls.Add(this.buttonBajaHabitacion);
            this.groupBox2.Controls.Add(this.buttonBbuscarHoteles);
            this.groupBox2.Controls.Add(this.registroHabitaciones);
            this.groupBox2.Controls.Add(this.textNumero);
            this.groupBox2.Controls.Add(this.labelNumero);
            this.groupBox2.Controls.Add(this.textPiso);
            this.groupBox2.Controls.Add(this.labelPiso);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 575);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Hotel";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Limpiar";
            this.button1.Click += new System.EventHandler(this.limpiarBusquedaYResultados);
            // 
            // checkBoxActiva
            // 
            this.checkBoxActiva.AutoSize = true;
            this.checkBoxActiva.Checked = true;
            this.checkBoxActiva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActiva.Location = new System.Drawing.Point(19, 74);
            this.checkBoxActiva.Name = "checkBoxActiva";
            this.checkBoxActiva.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActiva.TabIndex = 5;
            this.checkBoxActiva.Text = "Activa";
            this.checkBoxActiva.UseVisualStyleBackColor = true;
            // 
            // buttonAltaHabitacion
            // 
            this.buttonAltaHabitacion.Location = new System.Drawing.Point(114, 516);
            this.buttonAltaHabitacion.Name = "buttonAltaHabitacion";
            this.buttonAltaHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonAltaHabitacion.TabIndex = 9;
            this.buttonAltaHabitacion.Text = "Crear Habitacion";
            this.buttonAltaHabitacion.UseVisualStyleBackColor = true;
            this.buttonAltaHabitacion.Click += new System.EventHandler(this.buttonCrearHabitacion_Click);
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Location = new System.Drawing.Point(397, 33);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(34, 13);
            this.labelTipoHabitacion.TabIndex = 31;
            this.labelTipoHabitacion.Text = "Tipo: ";
            // 
            // buttonModificarHabitacion
            // 
            this.buttonModificarHabitacion.Enabled = false;
            this.buttonModificarHabitacion.Location = new System.Drawing.Point(239, 516);
            this.buttonModificarHabitacion.Name = "buttonModificarHabitacion";
            this.buttonModificarHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonModificarHabitacion.TabIndex = 10;
            this.buttonModificarHabitacion.Text = "Modificar Habitacion";
            this.buttonModificarHabitacion.UseVisualStyleBackColor = true;
            this.buttonModificarHabitacion.Click += new System.EventHandler(this.buttonModificarHabitacion_Click);
            // 
            // comboBoxTipoHabitacion
            // 
            this.comboBoxTipoHabitacion.Location = new System.Drawing.Point(459, 29);
            this.comboBoxTipoHabitacion.Name = "comboBoxTipoHabitacion";
            this.comboBoxTipoHabitacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoHabitacion.TabIndex = 3;
            // 
            // buttonBajaHabitacion
            // 
            this.buttonBajaHabitacion.Enabled = false;
            this.buttonBajaHabitacion.Location = new System.Drawing.Point(359, 516);
            this.buttonBajaHabitacion.Name = "buttonBajaHabitacion";
            this.buttonBajaHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonBajaHabitacion.TabIndex = 11;
            this.buttonBajaHabitacion.Text = "Baja Habitacion";
            this.buttonBajaHabitacion.UseVisualStyleBackColor = true;
            this.buttonBajaHabitacion.Click += new System.EventHandler(this.buttonBajaHabitacion_Click);
            // 
            // buttonBbuscarHoteles
            // 
            this.buttonBbuscarHoteles.Location = new System.Drawing.Point(223, 70);
            this.buttonBbuscarHoteles.Name = "buttonBbuscarHoteles";
            this.buttonBbuscarHoteles.Size = new System.Drawing.Size(161, 23);
            this.buttonBbuscarHoteles.TabIndex = 6;
            this.buttonBbuscarHoteles.Text = "Buscar";
            this.buttonBbuscarHoteles.Click += new System.EventHandler(this.buttonBbuscarHoteles_Click);
            // 
            // registroHabitaciones
            // 
            this.registroHabitaciones.AllowUserToAddRows = false;
            this.registroHabitaciones.AllowUserToDeleteRows = false;
            this.registroHabitaciones.AllowUserToOrderColumns = true;
            this.registroHabitaciones.AllowUserToResizeRows = false;
            this.registroHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.registroHabitaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.registroHabitaciones.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.registroHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registroHabitaciones.Location = new System.Drawing.Point(6, 111);
            this.registroHabitaciones.MultiSelect = false;
            this.registroHabitaciones.Name = "registroHabitaciones";
            this.registroHabitaciones.ReadOnly = true;
            this.registroHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.registroHabitaciones.Size = new System.Drawing.Size(566, 379);
            this.registroHabitaciones.TabIndex = 8;
            this.registroHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.registroHabitacion_CellClick);
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(67, 30);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(71, 20);
            this.textNumero.TabIndex = 1;
            this.textNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyNumeric);
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(16, 33);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(50, 13);
            this.labelNumero.TabIndex = 21;
            this.labelNumero.Text = "Numero: ";
            // 
            // textPiso
            // 
            this.textPiso.Location = new System.Drawing.Point(253, 30);
            this.textPiso.Name = "textPiso";
            this.textPiso.Size = new System.Drawing.Size(78, 20);
            this.textPiso.TabIndex = 2;
            this.textPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyNumeric);
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Location = new System.Drawing.Point(220, 32);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(33, 13);
            this.labelPiso.TabIndex = 23;
            this.labelPiso.Text = "Piso: ";
            // 
            // ABMHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 601);
            this.Controls.Add(this.groupBox2);
            this.Name = "ABMHabitacion";
            this.Text = "ABM Habitación";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registroHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }



        private void onlyNumeric(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        private GroupBox groupBox2;
        private Button buttonAltaHabitacion;
        private Button buttonModificarHabitacion;
        private Button buttonBajaHabitacion;
        private Button buttonBbuscarHoteles;
        private DataGridView registroHabitaciones;
        private CheckBox checkBoxActiva;
        private Label labelTipoHabitacion;
        private ComboBox comboBoxTipoHabitacion;
        private TextBox textNumero;
        private Label labelNumero;
        private TextBox textPiso;
        private Label labelPiso;
        private Button button1;

    }
}