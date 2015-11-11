namespace AerolineaFrba.Listado_Estadistico
{
    partial class listadoEstadistico
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
            this.dataGridListadoEstadistico = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxListados = new System.Windows.Forms.ComboBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonConsultar = new System.Windows.Forms.Button();
            this.pickerAño = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSemestre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoEstadistico)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridListadoEstadistico
            // 
            this.dataGridListadoEstadistico.AllowUserToAddRows = false;
            this.dataGridListadoEstadistico.AllowUserToDeleteRows = false;
            this.dataGridListadoEstadistico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoEstadistico.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListadoEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoEstadistico.GridColor = System.Drawing.Color.White;
            this.dataGridListadoEstadistico.Location = new System.Drawing.Point(6, 133);
            this.dataGridListadoEstadistico.MultiSelect = false;
            this.dataGridListadoEstadistico.Name = "dataGridListadoEstadistico";
            this.dataGridListadoEstadistico.ReadOnly = true;
            this.dataGridListadoEstadistico.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            this.dataGridListadoEstadistico.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridListadoEstadistico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoEstadistico.Size = new System.Drawing.Size(689, 221);
            this.dataGridListadoEstadistico.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tipo de Listado";
            // 
            // comboBoxListados
            // 
            this.comboBoxListados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxListados.FormattingEnabled = true;
            this.comboBoxListados.Items.AddRange(new object[] {
            "Top 5 Destinos con más pasajes comprados",
            "Top 5 Destinos con aeronaves más vacias",
            "Top 5 Clientes con más puntos acumulados a la fecha",
            "Top 5 Destinos con más pasajes cancelados",
            "Top 5 Aeronaves con mayor cantidad de dias fuera de servicio"});
            this.comboBoxListados.Location = new System.Drawing.Point(140, 19);
            this.comboBoxListados.Name = "comboBoxListados";
            this.comboBoxListados.Size = new System.Drawing.Size(481, 28);
            this.comboBoxListados.TabIndex = 29;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.ForeColor = System.Drawing.Color.LightGreen;
            this.botonVolver.Location = new System.Drawing.Point(309, 416);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(105, 52);
            this.botonVolver.TabIndex = 48;
            this.botonVolver.Text = "Regresar";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonConsultar
            // 
            this.botonConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonConsultar.BackColor = System.Drawing.Color.LightGreen;
            this.botonConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConsultar.ForeColor = System.Drawing.Color.White;
            this.botonConsultar.Location = new System.Drawing.Point(296, 90);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(105, 37);
            this.botonConsultar.TabIndex = 49;
            this.botonConsultar.Text = "Mostrar";
            this.botonConsultar.UseVisualStyleBackColor = false;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // pickerAño
            // 
            this.pickerAño.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerAño.Location = new System.Drawing.Point(140, 58);
            this.pickerAño.Name = "pickerAño";
            this.pickerAño.Size = new System.Drawing.Size(113, 26);
            this.pickerAño.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Año";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Período";
            // 
            // comboBoxSemestre
            // 
            this.comboBoxSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSemestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSemestre.FormattingEnabled = true;
            this.comboBoxSemestre.Items.AddRange(new object[] {
            "Primer Semestre (Enero a Junio)",
            "Segundo Semestre (Julio a Diciembre)"});
            this.comboBoxSemestre.Location = new System.Drawing.Point(354, 58);
            this.comboBoxSemestre.Name = "comboBoxSemestre";
            this.comboBoxSemestre.Size = new System.Drawing.Size(267, 28);
            this.comboBoxSemestre.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.LightGreen;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-7, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(741, 44);
            this.label4.TabIndex = 51;
            this.label4.Text = "Estadísticas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxListados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.botonConsultar);
            this.groupBox1.Controls.Add(this.dataGridListadoEstadistico);
            this.groupBox1.Controls.Add(this.pickerAño);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSemestre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 364);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // listadoEstadistico
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(726, 470);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonVolver);
            this.Name = "listadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoEstadistico)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridListadoEstadistico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxListados;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.DateTimePicker pickerAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSemestre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}