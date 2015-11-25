namespace AerolineaFrba.Compra
{
    partial class formaDePago
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
            this.botonVolver = new System.Windows.Forms.Button();
            this.buttonTarjeta = new System.Windows.Forms.Button();
            this.botonEfectivo = new System.Windows.Forms.Button();
            this.textBoxIDVuelo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonVolver.Location = new System.Drawing.Point(191, 105);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(117, 46);
            this.botonVolver.TabIndex = 63;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // buttonTarjeta
            // 
            this.buttonTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTarjeta.ForeColor = System.Drawing.Color.White;
            this.buttonTarjeta.Location = new System.Drawing.Point(247, 14);
            this.buttonTarjeta.Name = "buttonTarjeta";
            this.buttonTarjeta.Size = new System.Drawing.Size(197, 66);
            this.buttonTarjeta.TabIndex = 62;
            this.buttonTarjeta.Text = "Tarjeta";
            this.buttonTarjeta.UseVisualStyleBackColor = false;
            this.buttonTarjeta.Click += new System.EventHandler(this.buttonTarjeta_Click);
            // 
            // botonEfectivo
            // 
            this.botonEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEfectivo.ForeColor = System.Drawing.Color.White;
            this.botonEfectivo.Location = new System.Drawing.Point(44, 14);
            this.botonEfectivo.Name = "botonEfectivo";
            this.botonEfectivo.Size = new System.Drawing.Size(197, 66);
            this.botonEfectivo.TabIndex = 61;
            this.botonEfectivo.Text = "Efectivo";
            this.botonEfectivo.UseVisualStyleBackColor = false;
            this.botonEfectivo.Click += new System.EventHandler(this.botonEfectivo_Click);
            // 
            // textBoxIDVuelo
            // 
            this.textBoxIDVuelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIDVuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIDVuelo.Location = new System.Drawing.Point(411, 137);
            this.textBoxIDVuelo.Name = "textBoxIDVuelo";
            this.textBoxIDVuelo.Size = new System.Drawing.Size(33, 26);
            this.textBoxIDVuelo.TabIndex = 81;
            this.textBoxIDVuelo.Visible = false;
            // 
            // formaDePago
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 163);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxIDVuelo);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.buttonTarjeta);
            this.Controls.Add(this.botonEfectivo);
            this.Name = "formaDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button buttonTarjeta;
        private System.Windows.Forms.Button botonEfectivo;
        private System.Windows.Forms.TextBox textBoxIDVuelo;
    }
}