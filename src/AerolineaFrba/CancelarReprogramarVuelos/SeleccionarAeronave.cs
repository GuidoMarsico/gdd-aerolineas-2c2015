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
        String idAeronaveRemplazada="";
        String inicio="";
        String fin = "";
        String tipoForm = "";
        public SeleccionarAeronave(String idAeroVieja, String tipo, DataTable tabla, DataTable v)
        {
            InitializeComponent();
            this.dataGridListadoAeronaves.DataSource = tabla;
            this.dataGridListadoAeronaves.Columns[0].Visible = false;
            this.vuelos = v;
            this.idAeronaveRemplazada = idAeroVieja;
            this.tipoForm = tipo;
        }
        public SeleccionarAeronave(String idAeroVieja, String tipo, DataTable tabla, DataTable v,String inicioIntervalo,String finIntervalo)
        {
            InitializeComponent();
            this.dataGridListadoAeronaves.DataSource = tabla;
            this.dataGridListadoAeronaves.Columns[0].Visible = false;
            this.vuelos = v;
            this.idAeronaveRemplazada = idAeroVieja;
            this.tipoForm = tipo;
            this.inicio = inicioIntervalo;
            this.fin = finIntervalo;
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
            MessageBox.Show("Se reemplazo correctamente");
            if (tipoForm == "0")
                this.actualizarAeronave();
            else
                funcionesComunes.darDeBajaAeronave(this.idAeronaveRemplazada);
            funcionesComunes.habilitarAnterior();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        public void actualizarAeronave()
        {
            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + @".updateAeronave",
        funcionesComunes.generarListaParaProcedure("@id", "@fechaInicio", "@fechaFin"),
        idAeronaveRemplazada, inicio, fin);
            if (resultado)
            {
                MessageBox.Show("La aeronave se actualizo exitosamente");
                funcionesComunes.volverAMenuPrincipal();
            }
        }
    }
}
