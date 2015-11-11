namespace AerolineaFrba.Abm_Ruta
{
    partial class bajaModificacionDeRuta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.dataGridListadoRutas = new System.Windows.Forms.DataGridView();
            this.botonModificacion = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxServicio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOrigen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRutas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.CadetBlue;
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(545, 215);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(135, 46);
            this.botonLimpiar.TabIndex = 17;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // dataGridListadoRutas
            // 
            this.dataGridListadoRutas.AllowUserToAddRows = false;
            this.dataGridListadoRutas.AllowUserToDeleteRows = false;
            this.dataGridListadoRutas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridListadoRutas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoRutas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListadoRutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoRutas.GridColor = System.Drawing.Color.White;
            this.dataGridListadoRutas.Location = new System.Drawing.Point(6, 10);
            this.dataGridListadoRutas.MultiSelect = false;
            this.dataGridListadoRutas.Name = "dataGridListadoRutas";
            this.dataGridListadoRutas.ReadOnly = true;
            this.dataGridListadoRutas.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGridListadoRutas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridListadoRutas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoRutas.Size = new System.Drawing.Size(928, 199);
            this.dataGridListadoRutas.TabIndex = 16;
            // 
            // botonModificacion
            // 
            this.botonModificacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonModificacion.BackColor = System.Drawing.Color.CadetBlue;
            this.botonModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonModificacion.ForeColor = System.Drawing.Color.White;
            this.botonModificacion.Location = new System.Drawing.Point(404, 215);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(135, 46);
            this.botonModificacion.TabIndex = 15;
            this.botonModificacion.Text = "Modificar";
            this.botonModificacion.UseVisualStyleBackColor = false;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.CadetBlue;
            this.botonVolver.Location = new System.Drawing.Point(417, 428);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(135, 46);
            this.botonVolver.TabIndex = 14;
            this.botonVolver.Text = "Regresar";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBaja.BackColor = System.Drawing.Color.CadetBlue;
            this.botonBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBaja.ForeColor = System.Drawing.Color.White;
            this.botonBaja.Location = new System.Drawing.Point(263, 215);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(135, 46);
            this.botonBaja.TabIndex = 12;
            this.botonBaja.Text = "Baja";
            this.botonBaja.UseVisualStyleBackColor = false;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxServicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDestino);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxOrigen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 104);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBuscar.BackColor = System.Drawing.Color.CadetBlue;
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.ForeColor = System.Drawing.Color.White;
            this.botonBuscar.Location = new System.Drawing.Point(405, 65);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(135, 30);
            this.botonBuscar.TabIndex = 18;
            this.botonBuscar.Text = "Filtrar";
            this.botonBuscar.UseVisualStyleBackColor = false;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(689, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 55;
            this.label4.Text = "Servicio";
            // 
            // textBoxServicio
            // 
            this.textBoxServicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServicio.Location = new System.Drawing.Point(752, 23);
            this.textBoxServicio.Name = "textBoxServicio";
            this.textBoxServicio.Size = new System.Drawing.Size(153, 26);
            this.textBoxServicio.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(453, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Destino";
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestino.Location = new System.Drawing.Point(513, 23);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(153, 26);
            this.textBoxDestino.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "Origen";
            // 
            // textBoxOrigen
            // 
            this.textBoxOrigen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrigen.Location = new System.Drawing.Point(286, 23);
            this.textBoxOrigen.Name = "textBoxOrigen";
            this.textBoxOrigen.Size = new System.Drawing.Size(153, 26);
            this.textBoxOrigen.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Código";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigo.Location = new System.Drawing.Point(106, 23);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(114, 26);
            this.textBoxCodigo.TabIndex = 52;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.CadetBlue;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-9, -3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1003, 44);
            this.label16.TabIndex = 100;
            this.label16.Text = "Rutas";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridListadoRutas);
            this.groupBox2.Controls.Add(this.botonModificacion);
            this.groupBox2.Controls.Add(this.botonLimpiar);
            this.groupBox2.Controls.Add(this.botonBaja);
            this.groupBox2.Location = new System.Drawing.Point(13, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 267);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            // 
            // bajaModificacionDeRuta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(965, 488);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "bajaModificacionDeRuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.bajaModificacionDeRuta_Load);
            this.Enter += new System.EventHandler(this.bajaModificacionDeRuta_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRutas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.DataGridView dataGridListadoRutas;
        private System.Windows.Forms.Button botonModificacion;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOrigen;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}