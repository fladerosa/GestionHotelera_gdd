﻿namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadistico
    {
       
        private System.ComponentModel.IContainer components = null;

      
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoListado = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione año a consultar";
            // 
            // anio
            // 
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(168, 11);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(121, 21);
            this.anio.TabIndex = 1;
            this.anio.SelectedIndexChanged += new System.EventHandler(this.anio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre";
            // 
            // trimestre
            // 
            this.trimestre.FormattingEnabled = true;
            this.trimestre.Location = new System.Drawing.Point(392, 12);
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(121, 21);
            this.trimestre.TabIndex = 3;
            this.trimestre.SelectedIndexChanged += new System.EventHandler(this.trimestre_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de listado";
            // 
            // tipoListado
            // 
            this.tipoListado.FormattingEnabled = true;
            this.tipoListado.Location = new System.Drawing.Point(168, 51);
            this.tipoListado.Name = "tipoListado";
            this.tipoListado.Size = new System.Drawing.Size(206, 21);
            this.tipoListado.TabIndex = 5;
            this.tipoListado.SelectedIndexChanged += new System.EventHandler(this.tipoListado_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(581, 202);
            this.dataGridView1.TabIndex = 6;
            // 
            // button_cerrar
            // 
            this.button_cerrar.Location = new System.Drawing.Point(518, 298);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(75, 23);
            this.button_cerrar.TabIndex = 7;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click_1);
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(438, 51);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 8;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tipoListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anio);
            this.Controls.Add(this.label1);
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoEstadistico_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox anio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox trimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipoListado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button1;
    }
}