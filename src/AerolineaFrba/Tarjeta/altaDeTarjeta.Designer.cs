namespace AerolineaFrba.Tarjeta
{
    partial class altaDeTarjeta
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.dataGridCliente = new System.Windows.Forms.DataGridView();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fechavencimiento = new System.Windows.Forms.DateTimePicker();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.comboBoxTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "DNI";
            // 
            // textBoxDni
            // 
            this.textBoxDni.AcceptsReturn = true;
            this.textBoxDni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDni.Location = new System.Drawing.Point(276, 10);
            this.textBoxDni.MaxLength = 8;
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(175, 26);
            this.textBoxDni.TabIndex = 18;
            this.textBoxDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumer);
            // 
            // dataGridCliente
            // 
            this.dataGridCliente.AllowUserToAddRows = false;
            this.dataGridCliente.AllowUserToDeleteRows = false;
            this.dataGridCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCliente.BackgroundColor = System.Drawing.Color.White;
            this.dataGridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCliente.GridColor = System.Drawing.Color.White;
            this.dataGridCliente.Location = new System.Drawing.Point(6, 79);
            this.dataGridCliente.MultiSelect = false;
            this.dataGridCliente.Name = "dataGridCliente";
            this.dataGridCliente.ReadOnly = true;
            this.dataGridCliente.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumAquamarine;
            this.dataGridCliente.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCliente.Size = new System.Drawing.Size(711, 120);
            this.dataGridCliente.TabIndex = 66;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBuscar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.ForeColor = System.Drawing.Color.White;
            this.botonBuscar.Location = new System.Drawing.Point(276, 42);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(175, 26);
            this.botonBuscar.TabIndex = 67;
            this.botonBuscar.Text = "Filtrar";
            this.botonBuscar.UseVisualStyleBackColor = false;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxDni);
            this.groupBox3.Controls.Add(this.botonLimpiar);
            this.groupBox3.Controls.Add(this.fechavencimiento);
            this.groupBox3.Controls.Add(this.botonGuardar);
            this.groupBox3.Controls.Add(this.dataGridCliente);
            this.groupBox3.Controls.Add(this.botonBuscar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBoxTipoTarjeta);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxNumero);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(723, 347);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            // 
            // fechavencimiento
            // 
            this.fechavencimiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fechavencimiento.CustomFormat = "MM/yy ";
            this.fechavencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechavencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechavencimiento.Location = new System.Drawing.Point(607, 242);
            this.fechavencimiento.Name = "fechavencimiento";
            this.fechavencimiento.Size = new System.Drawing.Size(88, 26);
            this.fechavencimiento.TabIndex = 81;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCancelar.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.botonCancelar.Location = new System.Drawing.Point(288, 404);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(175, 42);
            this.botonCancelar.TabIndex = 80;
            this.botonCancelar.Text = "Regresar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(367, 299);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(151, 42);
            this.botonLimpiar.TabIndex = 79;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonGuardar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.botonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGuardar.ForeColor = System.Drawing.Color.White;
            this.botonGuardar.Location = new System.Drawing.Point(210, 299);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(151, 42);
            this.botonGuardar.TabIndex = 78;
            this.botonGuardar.Text = "Agregar";
            this.botonGuardar.UseVisualStyleBackColor = false;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label14.Location = new System.Drawing.Point(580, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 16);
            this.label14.TabIndex = 77;
            this.label14.Text = "(*) Ingreso obligatorio";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label13.Location = new System.Drawing.Point(701, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 20);
            this.label13.TabIndex = 76;
            this.label13.Text = "*";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(519, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 75;
            this.label9.Text = "Vencimiento";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label4.Location = new System.Drawing.Point(495, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "Número";
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumero.Location = new System.Drawing.Point(64, 242);
            this.textBoxNumero.MaxLength = 16;
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(179, 26);
            this.textBoxNumero.TabIndex = 72;
            // 
            // comboBoxTipoTarjeta
            // 
            this.comboBoxTipoTarjeta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoTarjeta.Location = new System.Drawing.Point(315, 239);
            this.comboBoxTipoTarjeta.Name = "comboBoxTipoTarjeta";
            this.comboBoxTipoTarjeta.Size = new System.Drawing.Size(175, 28);
            this.comboBoxTipoTarjeta.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label2.Location = new System.Drawing.Point(249, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 69;
            this.label3.Text = "Tipo";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(-4, -6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(756, 54);
            this.lblTitulo.TabIndex = 82;
            this.lblTitulo.Text = "Agregar Nueva Tarjeta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label6.Location = new System.Drawing.Point(170, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 82;
            this.label6.Text = "(16 dígitos)";
            // 
            // altaDeTarjeta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 454);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.groupBox3);
            this.Name = "altaDeTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.DataGridView dataGridCliente;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker fechavencimiento;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.ComboBox comboBoxTipoTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitulo;
    }
}