using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.CancelarReprogramarVuelos
{
    public partial class SeleccionarAeronave : Form
    {
        DataTable vuelos;
        public SeleccionarAeronave(DataTable tabla, DataTable v)
        {
            InitializeComponent();
            this.dataGridListadoAeronaves.DataSource = tabla;
            this.dataGridListadoAeronaves.Columns[0].Visible = false;
            this.vuelos = v;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se estan reemplazando los vuelos...");
            foreach (DataRow vuelo in vuelos.Rows)
            {
                SqlConnector.executeProcedure(SqlConnector.getSchema() + @".cambiarAeronaveDeVuelo",
                   funcionesComunes.generarListaParaProcedure("@idVuelo", "@idAeronaveNueva"),
                   Int32.Parse(vuelo.ItemArray[0].ToString()),
                   Int32.Parse(this.dataGridListadoAeronaves.SelectedCells[0].Value.ToString()));
            }
            Form altaAeronave = funcionesComunes.getVentanaAnterior();
            ((TextBox)altaAeronave.Controls["textBoxIdAeroValida"]).Text = "2";
            funcionesComunes.habilitarAnterior();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }
    }
}
