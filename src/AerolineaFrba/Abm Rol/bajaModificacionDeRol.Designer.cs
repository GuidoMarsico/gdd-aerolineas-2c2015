namespace AerolineaFrba.Abm_Rol
{
    partial class bajaModificacionDeRol
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
            this.botonBuscar = new System.Windows.Forms.Button();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textRol = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.dataGridListadoRoles = new System.Windows.Forms.DataGridView();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonModificacion = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonAlta = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRoles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textEstado);
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textRol);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 96);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBuscar.BackColor = System.Drawing.Color.Olive;
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.ForeColor = System.Drawing.Color.White;
            this.botonBuscar.Location = new System.Drawing.Point(281, 60);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(96, 30);
            this.botonBuscar.TabIndex = 19;
            this.botonBuscar.Text = "Filtrar";
            this.botonBuscar.UseVisualStyleBackColor = false;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // textEstado
            // 
            this.textEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEstado.Location = new System.Drawing.Point(385, 21);
            this.textEstado.Name = "textEstado";
            this.textEstado.Size = new System.Drawing.Size(148, 26);
            this.textEstado.TabIndex = 13;
            this.textEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEstado_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Estado";
            // 
            // textRol
            // 
            this.textRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRol.Location = new System.Drawing.Point(139, 21);
            this.textRol.Name = "textRol";
            this.textRol.Size = new System.Drawing.Size(148, 26);
            this.textRol.TabIndex = 9;
            this.textRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRol_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(104, 27);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(29, 16);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Rol";
            // 
            // dataGridListadoRoles
            // 
            this.dataGridListadoRoles.AllowUserToAddRows = false;
            this.dataGridListadoRoles.AllowUserToDeleteRows = false;
            this.dataGridListadoRoles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridListadoRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoRoles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListadoRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoRoles.GridColor = System.Drawing.Color.White;
            this.dataGridListadoRoles.Location = new System.Drawing.Point(6, 11);
            this.dataGridListadoRoles.MultiSelect = false;
            this.dataGridListadoRoles.Name = "dataGridListadoRoles";
            this.dataGridListadoRoles.ReadOnly = true;
            this.dataGridListadoRoles.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Olive;
            this.dataGridListadoRoles.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridListadoRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoRoles.Size = new System.Drawing.Size(654, 145);
            this.dataGridListadoRoles.TabIndex = 28;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.Olive;
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(543, 174);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(117, 46);
            this.botonLimpiar.TabIndex = 34;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonModificacion
            // 
            this.botonModificacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonModificacion.BackColor = System.Drawing.Color.Olive;
            this.botonModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonModificacion.ForeColor = System.Drawing.Color.White;
            this.botonModificacion.Location = new System.Drawing.Point(421, 174);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(117, 46);
            this.botonModificacion.TabIndex = 33;
            this.botonModificacion.Text = "Modificar";
            this.botonModificacion.UseVisualStyleBackColor = false;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.Olive;
            this.botonVolver.Location = new System.Drawing.Point(293, 388);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(96, 46);
            this.botonVolver.TabIndex = 32;
            this.botonVolver.Text = "Regresar";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBaja.BackColor = System.Drawing.Color.Olive;
            this.botonBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBaja.ForeColor = System.Drawing.Color.White;
            this.botonBaja.Location = new System.Drawing.Point(129, 174);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(117, 46);
            this.botonBaja.TabIndex = 31;
            this.botonBaja.Text = "Desactivar";
            this.botonBaja.UseVisualStyleBackColor = false;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonAlta.BackColor = System.Drawing.Color.Olive;
            this.botonAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAlta.ForeColor = System.Drawing.Color.White;
            this.botonAlta.Location = new System.Drawing.Point(6, 174);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(117, 46);
            this.botonAlta.TabIndex = 35;
            this.botonAlta.Text = "Activar";
            this.botonAlta.UseVisualStyleBackColor = false;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.Olive;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-6, -3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(701, 54);
            this.label16.TabIndex = 58;
            this.label16.Text = "Roles";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridListadoRoles);
            this.groupBox2.Controls.Add(this.botonAlta);
            this.groupBox2.Controls.Add(this.botonLimpiar);
            this.groupBox2.Controls.Add(this.botonBaja);
            this.groupBox2.Controls.Add(this.botonModificacion);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(666, 226);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // bajaModificacionDeRol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(690, 445);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "bajaModificacionDeRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.bajaModificacionDeRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRoles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.TextBox textEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRol;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.DataGridView dataGridListadoRoles;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonModificacion;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Button botonAlta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}