namespace AerolineaFrba.CancelarReprogramarVuelos
{
    partial class SeleccionarAeronave
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
            this.groupBoxAeronaves = new System.Windows.Forms.GroupBox();
            this.dataGridListadoAeronaves = new System.Windows.Forms.DataGridView();
            this.botonVolver = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.groupBoxAeronaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoAeronaves)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAeronaves
            // 
            this.groupBoxAeronaves.Controls.Add(this.dataGridListadoAeronaves);
            this.groupBoxAeronaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxAeronaves.Location = new System.Drawing.Point(10, 1);
            this.groupBoxAeronaves.Name = "groupBoxAeronaves";
            this.groupBoxAeronaves.Size = new System.Drawing.Size(726, 305);
            this.groupBoxAeronaves.TabIndex = 29;
            this.groupBoxAeronaves.TabStop = false;
            this.groupBoxAeronaves.Text = "Aeronaves Disponibles";
            // 
            // dataGridListadoAeronaves
            // 
            this.dataGridListadoAeronaves.AllowUserToAddRows = false;
            this.dataGridListadoAeronaves.AllowUserToDeleteRows = false;
            this.dataGridListadoAeronaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoAeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoAeronaves.Location = new System.Drawing.Point(6, 21);
            this.dataGridListadoAeronaves.MultiSelect = false;
            this.dataGridListadoAeronaves.Name = "dataGridListadoAeronaves";
            this.dataGridListadoAeronaves.ReadOnly = true;
            this.dataGridListadoAeronaves.RowHeadersVisible = false;
            this.dataGridListadoAeronaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoAeronaves.Size = new System.Drawing.Size(714, 278);
            this.dataGridListadoAeronaves.TabIndex = 27;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(456, 312);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(105, 42);
            this.botonVolver.TabIndex = 48;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptar.Location = new System.Drawing.Point(213, 312);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(105, 42);
            this.buttonAceptar.TabIndex = 49;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            // 
            // ReprogramarVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 366);
            this.ControlBox = false;
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBoxAeronaves);
            this.Name = "ReprogramarVuelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Aeronave";
            this.groupBoxAeronaves.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoAeronaves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAeronaves;
        private System.Windows.Forms.DataGridView dataGridListadoAeronaves;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button buttonAceptar;
    }
}