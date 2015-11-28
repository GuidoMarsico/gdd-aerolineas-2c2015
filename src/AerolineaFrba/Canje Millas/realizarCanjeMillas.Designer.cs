namespace AerolineaFrba.Canje_Millas
{
    partial class realizarCanjeMillas
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridCliente = new System.Windows.Forms.DataGridView();
            this.textDni = new System.Windows.Forms.TextBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonCanjear = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonVerCanjes = new System.Windows.Forms.Button();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.botonVolver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI";
            // 
            // dataGridCliente
            // 
            this.dataGridCliente.AllowUserToAddRows = false;
            this.dataGridCliente.AllowUserToDeleteRows = false;
            this.dataGridCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCliente.BackgroundColor = System.Drawing.Color.White;
            this.dataGridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCliente.GridColor = System.Drawing.Color.White;
            this.dataGridCliente.Location = new System.Drawing.Point(12, 117);
            this.dataGridCliente.MultiSelect = false;
            this.dataGridCliente.Name = "dataGridCliente";
            this.dataGridCliente.ReadOnly = true;
            this.dataGridCliente.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Indigo;
            this.dataGridCliente.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCliente.Size = new System.Drawing.Size(637, 97);
            this.dataGridCliente.TabIndex = 27;
            // 
            // textDni
            // 
            this.textDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDni.Location = new System.Drawing.Point(261, 53);
            this.textDni.MaxLength = 8;
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(148, 26);
            this.textDni.TabIndex = 28;
            this.textDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonBuscar.BackColor = System.Drawing.Color.Indigo;
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.ForeColor = System.Drawing.Color.White;
            this.botonBuscar.Location = new System.Drawing.Point(261, 85);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(148, 26);
            this.botonBuscar.TabIndex = 29;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = false;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonCanjear
            // 
            this.botonCanjear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonCanjear.BackColor = System.Drawing.Color.Indigo;
            this.botonCanjear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCanjear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCanjear.ForeColor = System.Drawing.Color.White;
            this.botonCanjear.Location = new System.Drawing.Point(305, 182);
            this.botonCanjear.Name = "botonCanjear";
            this.botonCanjear.Size = new System.Drawing.Size(92, 26);
            this.botonCanjear.TabIndex = 30;
            this.botonCanjear.Text = "Canjear";
            this.botonCanjear.UseVisualStyleBackColor = false;
            this.botonCanjear.Click += new System.EventHandler(this.botonCanjear_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLimpiar.BackColor = System.Drawing.Color.Indigo;
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.ForeColor = System.Drawing.Color.White;
            this.botonLimpiar.Location = new System.Drawing.Point(536, 53);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(113, 46);
            this.botonLimpiar.TabIndex = 31;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonVerCanjes
            // 
            this.botonVerCanjes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVerCanjes.BackColor = System.Drawing.Color.Indigo;
            this.botonVerCanjes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVerCanjes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVerCanjes.ForeColor = System.Drawing.Color.White;
            this.botonVerCanjes.Location = new System.Drawing.Point(261, 222);
            this.botonVerCanjes.Name = "botonVerCanjes";
            this.botonVerCanjes.Size = new System.Drawing.Size(148, 32);
            this.botonVerCanjes.TabIndex = 32;
            this.botonVerCanjes.Text = "Ver Canjes Disponibles";
            this.botonVerCanjes.UseVisualStyleBackColor = false;
            this.botonVerCanjes.Click += new System.EventHandler(this.botonVerCanjes_Click);
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AllowUserToAddRows = false;
            this.dataGridProductos.AllowUserToDeleteRows = false;
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProductos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.GridColor = System.Drawing.Color.White;
            this.dataGridProductos.Location = new System.Drawing.Point(6, 13);
            this.dataGridProductos.MultiSelect = false;
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.ReadOnly = true;
            this.dataGridProductos.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Indigo;
            this.dataGridProductos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(625, 163);
            this.dataGridProductos.TabIndex = 33;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.Indigo;
            this.botonVolver.Location = new System.Drawing.Point(261, 492);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(148, 46);
            this.botonVolver.TabIndex = 30;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(181, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Cantidad";
            // 
            // textCantidad
            // 
            this.textCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCantidad.Location = new System.Drawing.Point(249, 182);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(50, 26);
            this.textCantidad.TabIndex = 28;
            this.textCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.botonCanjear);
            this.groupBox1.Controls.Add(this.dataGridProductos);
            this.groupBox1.Controls.Add(this.textCantidad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 214);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Indigo;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-6, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(669, 52);
            this.label2.TabIndex = 36;
            this.label2.Text = "Canje de Millas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // realizarCanjeMillas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 540);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonVerCanjes);
            this.Controls.Add(this.dataGridCliente);
            this.Controls.Add(this.textDni);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "realizarCanjeMillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridCliente;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonCanjear;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonVerCanjes;
        private System.Windows.Forms.DataGridView dataGridProductos;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
    }
}