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
            this.dataGridListadoVuelos = new System.Windows.Forms.DataGridView();
            this.groupBoxVuelos = new System.Windows.Forms.GroupBox();
            this.botonRemplazar = new System.Windows.Forms.Button();
            this.buttonTerminar = new System.Windows.Forms.Button();
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
            this.dataGridListadoVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoVuelos.Location = new System.Drawing.Point(6, 21);
            this.dataGridListadoVuelos.MultiSelect = false;
            this.dataGridListadoVuelos.Name = "dataGridListadoVuelos";
            this.dataGridListadoVuelos.ReadOnly = true;
            this.dataGridListadoVuelos.RowHeadersVisible = false;
            this.dataGridListadoVuelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoVuelos.Size = new System.Drawing.Size(861, 358);
            this.dataGridListadoVuelos.TabIndex = 27;
            // 
            // groupBoxVuelos
            // 
            this.groupBoxVuelos.Controls.Add(this.dataGridListadoVuelos);
            this.groupBoxVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxVuelos.Location = new System.Drawing.Point(12, 2);
            this.groupBoxVuelos.Name = "groupBoxVuelos";
            this.groupBoxVuelos.Size = new System.Drawing.Size(873, 385);
            this.groupBoxVuelos.TabIndex = 28;
            this.groupBoxVuelos.TabStop = false;
            this.groupBoxVuelos.Text = "Vuelos A Remplazar";
            // 
            // botonRemplazar
            // 
            this.botonRemplazar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonRemplazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRemplazar.Location = new System.Drawing.Point(592, 393);
            this.botonRemplazar.Name = "botonRemplazar";
            this.botonRemplazar.Size = new System.Drawing.Size(117, 46);
            this.botonRemplazar.TabIndex = 29;
            this.botonRemplazar.Text = "Remplazar Aeronave";
            this.botonRemplazar.UseVisualStyleBackColor = true;
            // 
            // buttonTerminar
            // 
            this.buttonTerminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerminar.Location = new System.Drawing.Point(226, 393);
            this.buttonTerminar.Name = "buttonTerminar";
            this.buttonTerminar.Size = new System.Drawing.Size(117, 46);
            this.buttonTerminar.TabIndex = 30;
            this.buttonTerminar.Text = "Terminar";
            this.buttonTerminar.UseVisualStyleBackColor = true;
            // 
            // VuelosAReprogramar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 451);
            this.ControlBox = false;
            this.Controls.Add(this.buttonTerminar);
            this.Controls.Add(this.botonRemplazar);
            this.Controls.Add(this.groupBoxVuelos);
            this.Name = "VuelosAReprogramar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vuelos A Remplazar";
            this.Load += new System.EventHandler(this.cargaVentana_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoVuelos)).EndInit();
            this.groupBoxVuelos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridListadoVuelos;
        private System.Windows.Forms.GroupBox groupBoxVuelos;
        private System.Windows.Forms.Button botonRemplazar;
        private System.Windows.Forms.Button buttonTerminar;
    }
}