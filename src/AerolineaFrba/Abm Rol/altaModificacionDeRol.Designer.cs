﻿namespace AerolineaFrba.Abm_Rol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textId = new System.Windows.Forms.TextBox();
            this.textTipoForm = new System.Windows.Forms.TextBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.dataGridFuncionalidades = new System.Windows.Forms.DataGridView();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.comboBoxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botonCrearRol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // textId
            // 
            this.textId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textId.Location = new System.Drawing.Point(12, 32);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(35, 26);
            this.textId.TabIndex = 32;
            this.textId.Visible = false;
            // 
            // textTipoForm
            // 
            this.textTipoForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTipoForm.Location = new System.Drawing.Point(12, 64);
            this.textTipoForm.Name = "textTipoForm";
            this.textTipoForm.Size = new System.Drawing.Size(35, 26);
            this.textTipoForm.TabIndex = 33;
            this.textTipoForm.Visible = false;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(242, 396);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(117, 46);
            this.botonVolver.TabIndex = 42;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonQuitar);
            this.groupBox1.Controls.Add(this.dataGridFuncionalidades);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(65, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 267);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades";
            // 
            // botonQuitar
            // 
            this.botonQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonQuitar.Location = new System.Drawing.Point(394, 225);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(96, 28);
            this.botonQuitar.TabIndex = 32;
            this.botonQuitar.Text = "Quitar";
            this.botonQuitar.UseVisualStyleBackColor = true;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // dataGridFuncionalidades
            // 
            this.dataGridFuncionalidades.AllowUserToAddRows = false;
            this.dataGridFuncionalidades.AllowUserToDeleteRows = false;
            this.dataGridFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFuncionalidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFuncionalidades.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFuncionalidades.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridFuncionalidades.Location = new System.Drawing.Point(23, 21);
            this.dataGridFuncionalidades.MultiSelect = false;
            this.dataGridFuncionalidades.Name = "dataGridFuncionalidades";
            this.dataGridFuncionalidades.ReadOnly = true;
            this.dataGridFuncionalidades.RowHeadersVisible = false;
            this.dataGridFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFuncionalidades.Size = new System.Drawing.Size(467, 198);
            this.dataGridFuncionalidades.TabIndex = 31;
            // 
            // botonAgregar
            // 
            this.botonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregar.Location = new System.Drawing.Point(397, 78);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(96, 28);
            this.botonAgregar.TabIndex = 40;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // comboBoxFuncionalidades
            // 
            this.comboBoxFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFuncionalidades.Location = new System.Drawing.Point(135, 78);
            this.comboBoxFuncionalidades.Name = "comboBoxFuncionalidades";
            this.comboBoxFuncionalidades.Size = new System.Drawing.Size(258, 28);
            this.comboBoxFuncionalidades.Sorted = true;
            this.comboBoxFuncionalidades.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(131, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Funcionalidades Disponibles";
            // 
            // textRol
            // 
            this.textRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRol.Location = new System.Drawing.Point(186, 26);
            this.textRol.Name = "textRol";
            this.textRol.Size = new System.Drawing.Size(207, 26);
            this.textRol.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Rol";
            // 
            // botonCrearRol
            // 
            this.botonCrearRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonCrearRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCrearRol.Location = new System.Drawing.Point(399, 24);
            this.botonCrearRol.Name = "botonCrearRol";
            this.botonCrearRol.Size = new System.Drawing.Size(75, 28);
            this.botonCrearRol.TabIndex = 47;
            this.botonCrearRol.Text = "Crear";
            this.botonCrearRol.UseVisualStyleBackColor = true;
            this.botonCrearRol.Click += new System.EventHandler(this.botonCrearRol_Click);
            // 
            // altaModificacionDeRol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 450);
            this.ControlBox = false;
            this.Controls.Add(this.botonCrearRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textRol);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.comboBoxFuncionalidades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTipoForm);
            this.Controls.Add(this.textId);
            this.Name = "altaModificacionDeRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texto";
            this.Load += new System.EventHandler(this.altaModificacionDeRol_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textTipoForm;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonQuitar;
        private System.Windows.Forms.DataGridView dataGridFuncionalidades;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.ComboBox comboBoxFuncionalidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonCrearRol;

    }
}