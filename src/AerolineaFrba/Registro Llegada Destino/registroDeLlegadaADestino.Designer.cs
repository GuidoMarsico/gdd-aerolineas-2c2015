namespace AerolineaFrba.Registro_Llegada_Destino
{
    partial class registroDeLlegadaADestino
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.timePickerLlegada = new System.Windows.Forms.DateTimePicker();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.textBoxOrigen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridListadoVuelos = new System.Windows.Forms.DataGridView();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoVuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDestino);
            this.groupBox1.Controls.Add(this.timePickerLlegada);
            this.groupBox1.Controls.Add(this.botonLimpiar);
            this.groupBox1.Controls.Add(this.textBoxOrigen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.botonRegistrar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridListadoVuelos);
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMatricula);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 403);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestino.Location = new System.Drawing.Point(610, 11);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(163, 26);
            this.textBoxDestino.TabIndex = 68;
            this.textBoxDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validar);
            // 
            // timePickerLlegada
            // 
            this.timePickerLlegada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timePickerLlegada.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.timePickerLlegada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerLlegada.Location = new System.Drawing.Point(319, 321);
            this.timePickerLlegada.Name = "timePickerLlegada";
            this.timePickerLlegada.Size = new System.Drawing.Size(176, 22);
            this.timePickerLlegada.TabIndex = 64;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(409, 349);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(137, 48);
            this.botonLimpiar.TabIndex = 55;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // textBoxOrigen
            // 
            this.textBoxOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrigen.Location = new System.Drawing.Point(319, 12);
            this.textBoxOrigen.Name = "textBoxOrigen";
            this.textBoxOrigen.Size = new System.Drawing.Size(176, 26);
            this.textBoxOrigen.TabIndex = 67;
            this.textBoxOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validar);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "Fecha y Hora de Llegada";
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.botonRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRegistrar.ForeColor = System.Drawing.Color.White;
            this.botonRegistrar.Location = new System.Drawing.Point(266, 349);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(137, 48);
            this.botonRegistrar.TabIndex = 59;
            this.botonRegistrar.Text = "Registrar";
            this.botonRegistrar.UseVisualStyleBackColor = false;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(220, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 66;
            this.label4.Text = "Ciudad Origen";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(508, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "Ciudad Destino";
            // 
            // dataGridListadoVuelos
            // 
            this.dataGridListadoVuelos.AllowUserToAddRows = false;
            this.dataGridListadoVuelos.AllowUserToDeleteRows = false;
            this.dataGridListadoVuelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoVuelos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListadoVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoVuelos.GridColor = System.Drawing.Color.White;
            this.dataGridListadoVuelos.Location = new System.Drawing.Point(6, 85);
            this.dataGridListadoVuelos.MultiSelect = false;
            this.dataGridListadoVuelos.Name = "dataGridListadoVuelos";
            this.dataGridListadoVuelos.ReadOnly = true;
            this.dataGridListadoVuelos.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridListadoVuelos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridListadoVuelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoVuelos.Size = new System.Drawing.Size(767, 226);
            this.dataGridListadoVuelos.TabIndex = 64;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.ForeColor = System.Drawing.Color.White;
            this.botonBuscar.Location = new System.Drawing.Point(319, 44);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(176, 26);
            this.botonBuscar.TabIndex = 63;
            this.botonBuscar.Text = "Filtrar";
            this.botonBuscar.UseVisualStyleBackColor = false;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Matrícula";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatricula.Location = new System.Drawing.Point(78, 11);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(117, 26);
            this.textBoxMatricula.TabIndex = 61;
            this.textBoxMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.matricula);
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.botonVolver.Location = new System.Drawing.Point(331, 461);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(176, 49);
            this.botonVolver.TabIndex = 56;
            this.botonVolver.Text = "Regresar";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(-13, -5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(823, 54);
            this.lblTitulo.TabIndex = 81;
            this.lblTitulo.Text = "Registrar Llegadas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registroDeLlegadaADestino
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 522);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "registroDeLlegadaADestino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoVuelos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.DataGridView dataGridListadoVuelos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker timePickerLlegada;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.TextBox textBoxOrigen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
    }
}