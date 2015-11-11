namespace AerolineaFrba.Abm_Rol
{
    partial class altaModificacionDeRol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textId = new System.Windows.Forms.TextBox();
            this.textTipoForm = new System.Windows.Forms.TextBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.dataGridFuncionalidades = new System.Windows.Forms.DataGridView();
            this.textRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botonCrearRol = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.botonAsignar = new System.Windows.Forms.Button();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncionalidades)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textId
            // 
            this.textId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textId.Location = new System.Drawing.Point(47, 17);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(35, 26);
            this.textId.TabIndex = 32;
            this.textId.Visible = false;
            // 
            // textTipoForm
            // 
            this.textTipoForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textTipoForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTipoForm.Location = new System.Drawing.Point(6, 17);
            this.textTipoForm.Name = "textTipoForm";
            this.textTipoForm.Size = new System.Drawing.Size(35, 26);
            this.textTipoForm.TabIndex = 33;
            this.textTipoForm.Visible = false;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.Olive;
            this.botonVolver.Location = new System.Drawing.Point(314, 500);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(102, 51);
            this.botonVolver.TabIndex = 42;
            this.botonVolver.Text = "Regresar";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.botonQuitar);
            this.groupBox1.Controls.Add(this.dataGridFuncionalidades);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 289);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // botonQuitar
            // 
            this.botonQuitar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonQuitar.BackColor = System.Drawing.Color.Olive;
            this.botonQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonQuitar.ForeColor = System.Drawing.Color.White;
            this.botonQuitar.Location = new System.Drawing.Point(282, 222);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(102, 52);
            this.botonQuitar.TabIndex = 32;
            this.botonQuitar.Text = "Quitar";
            this.botonQuitar.UseVisualStyleBackColor = false;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // dataGridFuncionalidades
            // 
            this.dataGridFuncionalidades.AllowUserToAddRows = false;
            this.dataGridFuncionalidades.AllowUserToDeleteRows = false;
            this.dataGridFuncionalidades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridFuncionalidades.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFuncionalidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFuncionalidades.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFuncionalidades.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridFuncionalidades.GridColor = System.Drawing.Color.White;
            this.dataGridFuncionalidades.Location = new System.Drawing.Point(6, 42);
            this.dataGridFuncionalidades.MultiSelect = false;
            this.dataGridFuncionalidades.Name = "dataGridFuncionalidades";
            this.dataGridFuncionalidades.ReadOnly = true;
            this.dataGridFuncionalidades.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Olive;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridFuncionalidades.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFuncionalidades.Size = new System.Drawing.Size(657, 174);
            this.dataGridFuncionalidades.TabIndex = 31;
            // 
            // textRol
            // 
            this.textRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRol.Location = new System.Drawing.Point(195, 21);
            this.textRol.Name = "textRol";
            this.textRol.Size = new System.Drawing.Size(207, 26);
            this.textRol.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Nombre Rol";
            // 
            // botonCrearRol
            // 
            this.botonCrearRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonCrearRol.BackColor = System.Drawing.Color.Olive;
            this.botonCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCrearRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCrearRol.ForeColor = System.Drawing.Color.White;
            this.botonCrearRol.Location = new System.Drawing.Point(409, 21);
            this.botonCrearRol.Name = "botonCrearRol";
            this.botonCrearRol.Size = new System.Drawing.Size(148, 26);
            this.botonCrearRol.TabIndex = 47;
            this.botonCrearRol.Text = "Crear Rol";
            this.botonCrearRol.UseVisualStyleBackColor = false;
            this.botonCrearRol.Click += new System.EventHandler(this.botonCrearRol_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Funcionalidades Disponibles";
            // 
            // comboBoxFuncionalidades
            // 
            this.comboBoxFuncionalidades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFuncionalidades.Location = new System.Drawing.Point(195, 61);
            this.comboBoxFuncionalidades.Name = "comboBoxFuncionalidades";
            this.comboBoxFuncionalidades.Size = new System.Drawing.Size(207, 28);
            this.comboBoxFuncionalidades.Sorted = true;
            this.comboBoxFuncionalidades.TabIndex = 39;
            // 
            // botonAgregar
            // 
            this.botonAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonAgregar.BackColor = System.Drawing.Color.Olive;
            this.botonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregar.ForeColor = System.Drawing.Color.White;
            this.botonAgregar.Location = new System.Drawing.Point(409, 61);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(148, 28);
            this.botonAgregar.TabIndex = 40;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = false;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // botonAsignar
            // 
            this.botonAsignar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonAsignar.BackColor = System.Drawing.Color.Olive;
            this.botonAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAsignar.ForeColor = System.Drawing.Color.White;
            this.botonAsignar.Location = new System.Drawing.Point(409, 102);
            this.botonAsignar.Name = "botonAsignar";
            this.botonAsignar.Size = new System.Drawing.Size(148, 28);
            this.botonAsignar.TabIndex = 50;
            this.botonAsignar.Text = "Asignar Rol";
            this.botonAsignar.UseVisualStyleBackColor = false;
            this.botonAsignar.Click += new System.EventHandler(this.botonAsignar_Click);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsers.Location = new System.Drawing.Point(195, 102);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(207, 28);
            this.comboBoxUsers.Sorted = true;
            this.comboBoxUsers.TabIndex = 49;
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(127, 108);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(62, 16);
            this.labelUsuario.TabIndex = 48;
            this.labelUsuario.Text = "Usuarios";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.Olive;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(-3, -4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(744, 54);
            this.lblTitulo.TabIndex = 59;
            this.lblTitulo.Text = "Alta/Modificación de Rol";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textRol);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.botonAsignar);
            this.groupBox2.Controls.Add(this.botonAgregar);
            this.groupBox2.Controls.Add(this.textId);
            this.groupBox2.Controls.Add(this.textTipoForm);
            this.groupBox2.Controls.Add(this.botonCrearRol);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxUsers);
            this.groupBox2.Controls.Add(this.comboBoxFuncionalidades);
            this.groupBox2.Controls.Add(this.labelUsuario);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(32, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 137);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Funcionalidades Asignadas";
            // 
            // altaModificacionDeRol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 554);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "altaModificacionDeRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.altaModificacionDeRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncionalidades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textTipoForm;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonQuitar;
        private System.Windows.Forms.DataGridView dataGridFuncionalidades;
        private System.Windows.Forms.TextBox textRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonCrearRol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFuncionalidades;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Button botonAsignar;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}