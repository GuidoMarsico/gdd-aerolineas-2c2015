using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class bajaModificacionDeRuta : Form
    {
        DataTable listado;
        public bajaModificacionDeRuta()
        {
            InitializeComponent();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            Form modificacionRuta = new Abm_Ruta.modificacionDeRuta();
            ((TextBox)modificacionRuta.Controls["textBoxId"]).Text = dataGridListadoRutas.SelectedCells[0].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxCodigo"]).Text = dataGridListadoRutas.SelectedCells[1].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxPrecioKg"]).Text = dataGridListadoRutas.SelectedCells[2].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxPrecioPasaje"]).Text = dataGridListadoRutas.SelectedCells[3].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxOrigen"]).Text = dataGridListadoRutas.SelectedCells[4].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxDestino"]).Text = dataGridListadoRutas.SelectedCells[5].Value.ToString();
            ((ComboBox)modificacionRuta.Controls["comboBoxServicios"]).Text = dataGridListadoRutas.SelectedCells[6].Value.ToString();
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionRuta);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeRuta_Load(object sender, EventArgs e)
        {
            this.botonLimpiar.PerformClick();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
          this.dataGridListadoRutas.DataSource =  filtrarRutas(textBoxCodigo.Text, textBoxOrigen.Text, textBoxDestino.Text, textBoxServicio.Text);
        }

        private DataTable filtrarRutas(string codigo, string origen, string destino, string tipoServicio)
        {
            DataTable tablaRutas = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (codigo != "") filtrosBusqueda.Add("Codigo =" + codigo);
            if (origen != "") filtrosBusqueda.Add("Origen LIKE '%" + origen + "%'");
            if (destino != "") filtrosBusqueda.Add("Destino LIKE '%" + destino + "%'");
            if (tipoServicio != "") filtrosBusqueda.Add("Servicio LIKE '%" + tipoServicio + "%'");

            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_rol += " AND " + filtro;
                else
                {
                    final_rol += filtro;
                    posFiltro = false;
                }
            }
            if (tablaRutas != null)
                tablaRutas.DefaultView.RowFilter = final_rol;
            return tablaRutas;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodigo.Clear();
            textBoxDestino.Clear();
            textBoxOrigen.Clear();
            textBoxServicio.Clear();
            listado = funcionesComunes.consultarRutas(dataGridListadoRutas);
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            this.botonBaja.Enabled = false;
            this.botonBuscar.Enabled = false;
            this.botonLimpiar.Enabled = false;
            this.botonModificacion.Enabled = false;
            this.botonVolver.Enabled = false;
            MessageBox.Show("Realizando la operacion, aguarde un momento ... ");
            bool resultado = SqlConnector.executeProcedure("AERO.bajaRuta",
                funcionesComunes.generarListaParaProcedure("@id"),
                dataGridListadoRutas.SelectedCells[0].Value.ToString());
            this.botonBaja.Enabled = true;
            this.botonBuscar.Enabled = true;
            this.botonLimpiar.Enabled = true;
            this.botonModificacion.Enabled = true;
            this.botonVolver.Enabled = true;
            if(resultado){
                MessageBox.Show("La ruta se dio de baja exitosamente");
            }
            this.botonLimpiar.PerformClick();
        }

        private void bajaModificacionDeRuta_Enter(object sender, EventArgs e)
        {
            this.botonLimpiar.PerformClick();
        }
    }
}
