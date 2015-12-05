namespace AerolineaFrba.CancelarReprogramarVuelos
{
    partial class CancelarVuelos
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
            this.botonBajaTodos = new System.Windows.Forms.Button();
            this.buttonReprogramar = new System.Windows.Forms.Button();
            this.textBoxTipoIdAero = new System.Windows.Forms.TextBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.textBoxIdAeroValida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // botonBajaTodos
            // 
            this.botonBajaTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonBajaTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBajaTodos.Location = new System.Drawing.Point(22, 40);
            this.botonBajaTodos.Name = "botonBajaTodos";
            this.botonBajaTodos.Size = new System.Drawing.Size(189, 66);
            this.botonBajaTodos.TabIndex = 62;
            this.botonBajaTodos.Text = "Cancelar Vuelos";
            this.botonBajaTodos.UseVisualStyleBackColor = true;
            this.botonBajaTodos.Click += new System.EventHandler(this.botonBajaTodos_Click);
            // 
            // buttonReprogramar
            // 
            this.buttonReprogramar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReprogramar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprogramar.Location = new System.Drawing.Point(254, 40);
            this.buttonReprogramar.Name = "buttonReprogramar";
            this.buttonReprogramar.Size = new System.Drawing.Size(183, 66);
            this.buttonReprogramar.TabIndex = 63;
            this.buttonReprogramar.Text = "Remplazar Aeronave";
            this.buttonReprogramar.UseVisualStyleBackColor = true;
            this.buttonReprogramar.Click += new System.EventHandler(this.buttonReprogramar_Click);
            // 
            // textBoxTipoIdAero
            // 
            this.textBoxTipoIdAero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTipoIdAero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTipoIdAero.Location = new System.Drawing.Point(155, 8);
            this.textBoxTipoIdAero.Name = "textBoxTipoIdAero";
            this.textBoxTipoIdAero.Size = new System.Drawing.Size(33, 26);
            this.textBoxTipoIdAero.TabIndex = 78;
            this.textBoxTipoIdAero.Visible = false;
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTipo.Location = new System.Drawing.Point(254, 8);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(33, 26);
            this.textBoxTipo.TabIndex = 79;
            this.textBoxTipo.Visible = false;
            // 
            // textBoxIdAeroValida
            // 
            this.textBoxIdAeroValida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdAeroValida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdAeroValida.Location = new System.Drawing.Point(215, 62);
            this.textBoxIdAeroValida.Name = "textBoxIdAeroValida";
            this.textBoxIdAeroValida.Size = new System.Drawing.Size(33, 26);
            this.textBoxIdAeroValida.TabIndex = 80;
            this.textBoxIdAeroValida.Visible = false;
            // 
            // CancelarVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 124);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxIdAeroValida);
            this.Controls.Add(this.textBoxTipo);
            this.Controls.Add(this.textBoxTipoIdAero);
            this.Controls.Add(this.buttonReprogramar);
            this.Controls.Add(this.botonBajaTodos);
            this.Name = "CancelarVuelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar / Reprogramar";
            this.Enter += new System.EventHandler(this.enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonBajaTodos;
        private System.Windows.Forms.Button buttonReprogramar;
        private System.Windows.Forms.TextBox textBoxTipoIdAero;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.TextBox textBoxIdAeroValida;
    }
}