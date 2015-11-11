namespace AerolineaFrba.Abm_Vuelos
{
    partial class generarViaje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timePickerLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.timePickerSalida = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridListadoAeronaves = new System.Windows.Forms.DataGridView();
            this.buttonBuscarMatricula = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridListadoRutas = new System.Windows.Forms.DataGridView();
            this.botonBuscarRuta = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoAeronaves)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRutas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.timePickerLlegadaEstimada);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.timePickerSalida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // timePickerLlegadaEstimada
            // 
            this.timePickerLlegadaEstimada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timePickerLlegadaEstimada.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.timePickerLlegadaEstimada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerLlegadaEstimada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerLlegadaEstimada.Location = new System.Drawing.Point(624, 30);
            this.timePickerLlegadaEstimada.Name = "timePickerLlegadaEstimada";
            this.timePickerLlegadaEstimada.Size = new System.Drawing.Size(217, 26);
            this.timePickerLlegadaEstimada.TabIndex = 56;
            // 
            // timePickerSalida
            // 
            this.timePickerSalida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timePickerSalida.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.timePickerSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerSalida.Location = new System.Drawing.Point(193, 30);
            this.timePickerSalida.Name = "timePickerSalida";
            this.timePickerSalida.Size = new System.Drawing.Size(217, 26);
            this.timePickerSalida.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Fecha y Hora Salida";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "Fecha y Hora Llegada Estimada";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dataGridListadoAeronaves);
            this.groupBox2.Controls.Add(this.buttonBuscarMatricula);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxMatricula);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 211);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // dataGridListadoAeronaves
            // 
            this.dataGridListadoAeronaves.AllowUserToAddRows = false;
            this.dataGridListadoAeronaves.AllowUserToDeleteRows = false;
            this.dataGridListadoAeronaves.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridListadoAeronaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoAeronaves.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListadoAeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoAeronaves.GridColor = System.Drawing.Color.White;
            this.dataGridListadoAeronaves.Location = new System.Drawing.Point(6, 73);
            this.dataGridListadoAeronaves.MultiSelect = false;
            this.dataGridListadoAeronaves.Name = "dataGridListadoAeronaves";
            this.dataGridListadoAeronaves.ReadOnly = true;
            this.dataGridListadoAeronaves.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridListadoAeronaves.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridListadoAeronaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoAeronaves.Size = new System.Drawing.Size(898, 132);
            this.dataGridListadoAeronaves.TabIndex = 58;
            // 
            // buttonBuscarMatricula
            // 
            this.buttonBuscarMatricula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBuscarMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonBuscarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscarMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscarMatricula.ForeColor = System.Drawing.Color.White;
            this.buttonBuscarMatricula.Location = new System.Drawing.Point(389, 42);
            this.buttonBuscarMatricula.Name = "buttonBuscarMatricula";
            this.buttonBuscarMatricula.Size = new System.Drawing.Size(133, 25);
            this.buttonBuscarMatricula.TabIndex = 57;
            this.buttonBuscarMatricula.Text = "Filtrar";
            this.buttonBuscarMatricula.UseVisualStyleBackColor = false;
            this.buttonBuscarMatricula.Click += new System.EventHandler(this.buttonBuscarMatricula_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Matrícula";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatricula.Location = new System.Drawing.Point(389, 10);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(133, 26);
            this.textBoxMatricula.TabIndex = 52;
            this.textBoxMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMatricula_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.botonGuardar);
            this.groupBox3.Controls.Add(this.dataGridListadoRutas);
            this.groupBox3.Controls.Add(this.botonLimpiar);
            this.groupBox3.Controls.Add(this.botonBuscarRuta);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.textBoxCodigo);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 347);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(910, 260);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
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
            this.dataGridListadoRutas.Location = new System.Drawing.Point(6, 76);
            this.dataGridListadoRutas.MultiSelect = false;
            this.dataGridListadoRutas.Name = "dataGridListadoRutas";
            this.dataGridListadoRutas.ReadOnly = true;
            this.dataGridListadoRutas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridListadoRutas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridListadoRutas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoRutas.Size = new System.Drawing.Size(898, 136);
            this.dataGridListadoRutas.TabIndex = 59;
            // 
            // botonBuscarRuta
            // 
            this.botonBuscarRuta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBuscarRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.botonBuscarRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscarRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscarRuta.ForeColor = System.Drawing.Color.White;
            this.botonBuscarRuta.Location = new System.Drawing.Point(389, 43);
            this.botonBuscarRuta.Name = "botonBuscarRuta";
            this.botonBuscarRuta.Size = new System.Drawing.Size(133, 25);
            this.botonBuscarRuta.TabIndex = 58;
            this.botonBuscarRuta.Text = "Filtrar";
            this.botonBuscarRuta.UseVisualStyleBackColor = false;
            this.botonBuscarRuta.Click += new System.EventHandler(this.botonBuscarRuta_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(331, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 16);
            this.label14.TabIndex = 55;
            this.label14.Text = "Código";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigo.Location = new System.Drawing.Point(389, 11);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(133, 26);
            this.textBoxCodigo.TabIndex = 52;
            this.textBoxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.botonVolver.Location = new System.Drawing.Point(401, 613);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(133, 49);
            this.botonVolver.TabIndex = 50;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(458, 218);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(140, 36);
            this.botonLimpiar.TabIndex = 49;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.botonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGuardar.ForeColor = System.Drawing.Color.White;
            this.botonGuardar.Location = new System.Drawing.Point(312, 218);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(140, 36);
            this.botonGuardar.TabIndex = 48;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = false;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-2, -3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1003, 44);
            this.label16.TabIndex = 101;
            this.label16.Text = "Generar Viajes";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(7, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 57;
            this.label4.Text = "Horarios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(7, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 59;
            this.label5.Text = "Aeronaves";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(7, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 18);
            this.label6.TabIndex = 60;
            this.label6.Text = "Rutas";
            // 
            // generarViaje
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 674);
            this.ControlBox = false;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "generarViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoAeronaves)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRutas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.DateTimePicker timePickerSalida;
        private System.Windows.Forms.DateTimePicker timePickerLlegadaEstimada;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button buttonBuscarMatricula;
        private System.Windows.Forms.Button botonBuscarRuta;
        private System.Windows.Forms.DataGridView dataGridListadoAeronaves;
        private System.Windows.Forms.DataGridView dataGridListadoRutas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}