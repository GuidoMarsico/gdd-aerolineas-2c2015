namespace AerolineaFrba.Abm_Ruta
{
    partial class modificacionDeRuta
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPrecioPasaje = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrecioKg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxServicios = new System.Windows.Forms.ComboBox();
            this.textBoxOrigen = new System.Windows.Forms.TextBox();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.CadetBlue;
            this.label10.Location = new System.Drawing.Point(613, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 122;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.CadetBlue;
            this.label9.Location = new System.Drawing.Point(294, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 121;
            this.label9.Text = "*";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(315, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 119;
            this.label7.Text = "Precio Base Pasaje";
            // 
            // textBoxPrecioPasaje
            // 
            this.textBoxPrecioPasaje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrecioPasaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrecioPasaje.Location = new System.Drawing.Point(449, 91);
            this.textBoxPrecioPasaje.Name = "textBoxPrecioPasaje";
            this.textBoxPrecioPasaje.Size = new System.Drawing.Size(158, 26);
            this.textBoxPrecioPasaje.TabIndex = 118;
            this.textBoxPrecioPasaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validacionPasaje);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 117;
            this.label6.Text = "Precio Base KG";
            // 
            // textBoxPrecioKg
            // 
            this.textBoxPrecioKg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrecioKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrecioKg.Location = new System.Drawing.Point(127, 91);
            this.textBoxPrecioKg.Name = "textBoxPrecioKg";
            this.textBoxPrecioKg.Size = new System.Drawing.Size(161, 26);
            this.textBoxPrecioKg.TabIndex = 116;
            this.textBoxPrecioKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validacion);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(343, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 114;
            this.label5.Text = "Destino";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 112;
            this.label4.Text = "Origen";
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.CadetBlue;
            this.botonVolver.Location = new System.Drawing.Point(295, 263);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(128, 42);
            this.botonVolver.TabIndex = 107;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.CadetBlue;
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(346, 157);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(128, 42);
            this.botonLimpiar.TabIndex = 106;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonModificar.BackColor = System.Drawing.Color.CadetBlue;
            this.botonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonModificar.ForeColor = System.Drawing.Color.White;
            this.botonModificar.Location = new System.Drawing.Point(212, 157);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(128, 42);
            this.botonModificar.TabIndex = 105;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = false;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "Servicio ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 101;
            this.label1.Text = "Código Ruta";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCodigo.Enabled = false;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigo.Location = new System.Drawing.Point(403, 54);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(204, 26);
            this.textBoxCodigo.TabIndex = 100;
            // 
            // textBoxId
            // 
            this.textBoxId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxId.Location = new System.Drawing.Point(638, 19);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(26, 20);
            this.textBoxId.TabIndex = 126;
            this.textBoxId.Visible = false;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.CadetBlue;
            this.label14.Location = new System.Drawing.Point(526, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 16);
            this.label14.TabIndex = 104;
            this.label14.Text = "(*) Ingreso Obligatorio";
            // 
            // comboBoxServicios
            // 
            this.comboBoxServicios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServicios.Enabled = false;
            this.comboBoxServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxServicios.Items.AddRange(new object[] {
            "Ejecutivo",
            "Primera Clase",
            "Turista"});
            this.comboBoxServicios.Location = new System.Drawing.Point(84, 54);
            this.comboBoxServicios.Name = "comboBoxServicios";
            this.comboBoxServicios.Size = new System.Drawing.Size(204, 28);
            this.comboBoxServicios.TabIndex = 108;
            // 
            // textBoxOrigen
            // 
            this.textBoxOrigen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxOrigen.Enabled = false;
            this.textBoxOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrigen.Location = new System.Drawing.Point(84, 19);
            this.textBoxOrigen.Name = "textBoxOrigen";
            this.textBoxOrigen.Size = new System.Drawing.Size(204, 26);
            this.textBoxOrigen.TabIndex = 127;
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDestino.Enabled = false;
            this.textBoxDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestino.Location = new System.Drawing.Point(403, 19);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(204, 26);
            this.textBoxDestino.TabIndex = 128;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.CadetBlue;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-14, -9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(728, 46);
            this.label16.TabIndex = 129;
            this.label16.Text = "Modificación de Ruta";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxOrigen);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.botonLimpiar);
            this.groupBox1.Controls.Add(this.textBoxDestino);
            this.groupBox1.Controls.Add(this.botonModificar);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxPrecioPasaje);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBoxServicios);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPrecioKg);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxCodigo);
            this.groupBox1.Location = new System.Drawing.Point(13, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 205);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            // 
            // modificacionDeRuta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 317);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.botonVolver);
            this.Name = "modificacionDeRuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPrecioPasaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrecioKg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxServicios;
        private System.Windows.Forms.TextBox textBoxOrigen;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}