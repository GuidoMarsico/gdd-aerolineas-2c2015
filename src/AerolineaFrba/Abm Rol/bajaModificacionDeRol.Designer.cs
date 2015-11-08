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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.textEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textRol);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(186, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 118);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.Location = new System.Drawing.Point(194, 66);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(96, 46);
            this.botonBuscar.TabIndex = 19;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // textEstado
            // 
            this.textEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEstado.Location = new System.Drawing.Point(9, 79);
            this.textEstado.Name = "textEstado";
            this.textEstado.Size = new System.Drawing.Size(148, 26);
            this.textEstado.TabIndex = 13;
            this.textEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEstado_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Estado";
            // 
            // textRol
            // 
            this.textRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRol.Location = new System.Drawing.Point(9, 34);
            this.textRol.Name = "textRol";
            this.textRol.Size = new System.Drawing.Size(148, 26);
            this.textRol.TabIndex = 9;
            this.textRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRol_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(6, 18);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(29, 16);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Rol";
            // 
            // dataGridListadoRoles
            // 
            this.dataGridListadoRoles.AllowUserToAddRows = false;
            this.dataGridListadoRoles.AllowUserToDeleteRows = false;
            this.dataGridListadoRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoRoles.Location = new System.Drawing.Point(33, 138);
            this.dataGridListadoRoles.MultiSelect = false;
            this.dataGridListadoRoles.Name = "dataGridListadoRoles";
            this.dataGridListadoRoles.ReadOnly = true;
            this.dataGridListadoRoles.RowHeadersVisible = false;
            this.dataGridListadoRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoRoles.Size = new System.Drawing.Size(622, 248);
            this.dataGridListadoRoles.TabIndex = 28;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.Location = new System.Drawing.Point(538, 401);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(117, 46);
            this.botonLimpiar.TabIndex = 34;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonModificacion
            // 
            this.botonModificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonModificacion.Location = new System.Drawing.Point(416, 401);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(117, 46);
            this.botonModificacion.TabIndex = 33;
            this.botonModificacion.Text = "Modificación";
            this.botonModificacion.UseVisualStyleBackColor = true;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(293, 401);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(117, 46);
            this.botonVolver.TabIndex = 32;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBaja.Location = new System.Drawing.Point(170, 401);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(117, 46);
            this.botonBaja.TabIndex = 31;
            this.botonBaja.Text = "Desactivar";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAlta.Location = new System.Drawing.Point(47, 401);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(117, 46);
            this.botonAlta.TabIndex = 35;
            this.botonAlta.Text = "Activar";
            this.botonAlta.UseVisualStyleBackColor = true;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // bajaModificacionDeRol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(690, 459);
            this.ControlBox = false;
            this.Controls.Add(this.botonAlta);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonModificacion);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridListadoRoles);
            this.Name = "bajaModificacionDeRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Roles y Funcionalidades";
            this.Load += new System.EventHandler(this.bajaModificacionDeRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoRoles)).EndInit();
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
    }
}