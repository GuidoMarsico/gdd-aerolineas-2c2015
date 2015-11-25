namespace AerolineaFrba.CancelarReprogramarVuelos
{
    partial class VuelosARemplazar
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
            this.dataGridListadoVuelos = new System.Windows.Forms.DataGridView();
            this.groupBoxVuelos = new System.Windows.Forms.GroupBox();
            this.botonRemplazar = new System.Windows.Forms.Button();
            this.buttonTerminar = new System.Windows.Forms.Button();
            this.textBoxTipoIdAero = new System.Windows.Forms.TextBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoVuelos)).BeginInit();
            this.groupBoxVuelos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridListadoVuelos
            // 
            this.dataGridListadoVuelos.AllowUserToAddRows = false;
            this.dataGridListadoVuelos.AllowUserToDeleteRows = false;
            this.dataGridListadoVuelos.AllowUserToResizeColumns = false;
            this.dataGridListadoVuelos.AllowUserToResizeRows = false;
            this.dataGridListadoVuelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoVuelos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListadoVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoVuelos.GridColor = System.Drawing.Color.White;
            this.dataGridListadoVuelos.Location = new System.Drawing.Point(6, 12);
            this.dataGridListadoVuelos.MultiSelect = false;
            this.dataGridListadoVuelos.Name = "dataGridListadoVuelos";
            this.dataGridListadoVuelos.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridListadoVuelos.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridListadoVuelos.RowHeadersVisible = false;
            this.dataGridListadoVuelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoVuelos.Size = new System.Drawing.Size(760, 262);
            this.dataGridListadoVuelos.TabIndex = 27;
            // 
            // groupBoxVuelos
            // 
            this.groupBoxVuelos.Controls.Add(this.dataGridListadoVuelos);
            this.groupBoxVuelos.Controls.Add(this.botonRemplazar);
            this.groupBoxVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxVuelos.Location = new System.Drawing.Point(12, 44);
            this.groupBoxVuelos.Name = "groupBoxVuelos";
            this.groupBoxVuelos.Size = new System.Drawing.Size(772, 343);
            this.groupBoxVuelos.TabIndex = 28;
            this.groupBoxVuelos.TabStop = false;
            // 
            // botonRemplazar
            // 
            this.botonRemplazar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonRemplazar.BackColor = System.Drawing.Color.Maroon;
            this.botonRemplazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRemplazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRemplazar.ForeColor = System.Drawing.Color.White;
            this.botonRemplazar.Location = new System.Drawing.Point(333, 280);
            this.botonRemplazar.Name = "botonRemplazar";
            this.botonRemplazar.Size = new System.Drawing.Size(117, 46);
            this.botonRemplazar.TabIndex = 29;
            this.botonRemplazar.Text = "Remplazar Aeronave";
            this.botonRemplazar.UseVisualStyleBackColor = false;
            this.botonRemplazar.Click += new System.EventHandler(this.botonRemplazar_Click);
            // 
            // buttonTerminar
            // 
            this.buttonTerminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerminar.ForeColor = System.Drawing.Color.Maroon;
            this.buttonTerminar.Location = new System.Drawing.Point(345, 393);
            this.buttonTerminar.Name = "buttonTerminar";
            this.buttonTerminar.Size = new System.Drawing.Size(117, 46);
            this.buttonTerminar.TabIndex = 30;
            this.buttonTerminar.Text = "Finalizar";
            this.buttonTerminar.UseVisualStyleBackColor = true;
            this.buttonTerminar.Click += new System.EventHandler(this.buttonTerminar_Click);
            // 
            // textBoxTipoIdAero
            // 
            this.textBoxTipoIdAero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTipoIdAero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTipoIdAero.Location = new System.Drawing.Point(447, 413);
            this.textBoxTipoIdAero.Name = "textBoxTipoIdAero";
            this.textBoxTipoIdAero.Size = new System.Drawing.Size(0, 26);
            this.textBoxTipoIdAero.TabIndex = 79;
            this.textBoxTipoIdAero.Visible = false;
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTipo.Location = new System.Drawing.Point(521, 413);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(0, 26);
            this.textBoxTipo.TabIndex = 80;
            this.textBoxTipo.Visible = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.Maroon;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-6, -3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(813, 44);
            this.label16.TabIndex = 103;
            this.label16.Text = "Vuelos a Reemplazar";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VuelosARemplazar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 451);
            this.ControlBox = false;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxTipo);
            this.Controls.Add(this.textBoxTipoIdAero);
            this.Controls.Add(this.buttonTerminar);
            this.Controls.Add(this.groupBoxVuelos);
            this.Name = "VuelosARemplazar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.cargaVentana_load);
            this.Enter += new System.EventHandler(this.recarga_enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoVuelos)).EndInit();
            this.groupBoxVuelos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridListadoVuelos;
        private System.Windows.Forms.GroupBox groupBoxVuelos;
        private System.Windows.Forms.Button botonRemplazar;
        private System.Windows.Forms.Button buttonTerminar;
        private System.Windows.Forms.TextBox textBoxTipoIdAero;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.Label label16;
    }
}