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
        public SeleccionarAeronave(DataTable tabla)
        {
            InitializeComponent();
            this.dataGridListadoAeronaves.DataSource = tabla;
            this.dataGridListadoAeronaves.Columns[0].Visible = false;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            SqlConnector.executeProcedure( SqlConnector.getSchema() + @".cambiarAeronaveDeVuelo", 
                funcionesComunes.generarListaParaProcedure("@idVuelo", "@idAeronaveNueva"), 
                Int32.Parse(this.textBoxIdVuelo.Text),
                Int32.Parse(this.dataGridListadoAeronaves.SelectedCells[0].Value.ToString())); 
            funcionesComunes.habilitarAnterior();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }
    }
}
