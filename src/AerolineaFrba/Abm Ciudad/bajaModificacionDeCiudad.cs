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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class bajaModificacionDeCiudad : Form
    {
        public bajaModificacionDeCiudad()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeCiudad_Load(object sender, EventArgs e)
        {
            mostrarListadoCiudades();
        }

        private void mostrarListadoCiudades()
        {
            DataTable listado;
            listado = SqlConnector.obtenerTablaSegunConsultaString("select ID as Id, NOMBRE as Ciudad from AERO.CIUDADES");
            dataGridListadoCiudades.DataSource = listado;
            dataGridListadoCiudades.Columns[0].Visible = false;

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxBusqueda.Clear();
            mostrarListadoCiudades();

        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            if (dataGridListadoCiudades.SelectedRows.Count > 0)
            {
                bool resultado = SqlConnector.executeProcedure("AERO.bajaCiudad",
                    funcionesComunes.generarListaParaProcedure("@id"), 
                    dataGridListadoCiudades.SelectedCells[0].Value.ToString());
                if (resultado)
                {
                    MessageBox.Show("La ciudad se dio de baja exitosamente");
                }

                mostrarListadoCiudades();
            }
            else
            {
                MessageBox.Show("Seleccione una ciudad para ser eliminada");
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxBusqueda.Text != "")
            {
                DataTable tablaAeronaves = (DataTable)dataGridListadoCiudades.DataSource;
                tablaAeronaves.DefaultView.RowFilter = "Ciudad LIKE '%" + textBoxBusqueda.Text + "%'";
                dataGridListadoCiudades.DataSource = tablaAeronaves;
            }
            else
            {
                mostrarListadoCiudades();
                MessageBox.Show("Ingrese una ciudad para buscar");
            }
        }

        private void textBoxBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void botonVolver_Click_1(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }
    }
}
