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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class bajaModificacionDeAeronave : Form
    {
        DataTable listado;
        public bajaModificacionDeAeronave()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            
            string id = dataGridListadoAeronaves.SelectedCells[0].Value.ToString();
            string matricula = dataGridListadoAeronaves.SelectedCells[1].Value.ToString();
            string modelo = dataGridListadoAeronaves.SelectedCells[2].Value.ToString();
            string kg = dataGridListadoAeronaves.SelectedCells[3].Value.ToString();
            string fabricante = dataGridListadoAeronaves.SelectedCells[4].Value.ToString();
            string servicio = dataGridListadoAeronaves.SelectedCells[5].Value.ToString();
            DateTime alta = Convert.ToDateTime(dataGridListadoAeronaves.SelectedCells[6].Value.ToString());
            string butacas = dataGridListadoAeronaves.SelectedCells[7].Value.ToString();
            Form modificacionAeronave = new Abm_Aeronave.modificacionDeAeronave(id,matricula,modelo,kg,fabricante,servicio,alta,butacas);
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionAeronave);
        }

        private void bajaModificacionDeAeronave_Load(object sender, EventArgs e)
        {
           listado = funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textFabricante.Clear();
            textMatricula.Clear();
            textModelo.Clear();
            textTipoServicio.Clear();
            funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable aeronavesFiltro = filtrarAeronave(textFabricante.Text, textMatricula.Text, textModelo.Text, textTipoServicio.Text);
            dataGridListadoAeronaves.DataSource = aeronavesFiltro;
        }

        private DataTable filtrarAeronave(string fabricante, string matricula, string modelo, string tipoServicio)
        {
            DataTable tablaAeronaves = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (fabricante != "") filtrosBusqueda.Add("Fabricante LIKE '%" + fabricante + "%'");
            if (matricula != "") filtrosBusqueda.Add("Matricula LIKE '%" + matricula + "%'");
            if (modelo != "") filtrosBusqueda.Add("Modelo LIKE '%" + modelo + "%'");
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
            if (tablaAeronaves != null)
                tablaAeronaves.DefaultView.RowFilter = final_rol;
            return tablaAeronaves;
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            if (this.dataGridListadoAeronaves.Rows.Count > 0)
            {
                bool resultado = this.cancelarVuelosVinculados();
                if (resultado)
                    funcionesComunes.darDeBajaAeronave(dataGridListadoAeronaves.SelectedCells[0].Value.ToString());
                funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
            }
            
        }

        private Boolean cancelarVuelosVinculados()
        {
            DataTable vuelos =this.vuelosVinculados();
            int cantVuelos =vuelos.Rows.Count;
            if (cantVuelos > 0)
            {
                Form opcion = new CancelarReprogramarVuelos.CancelarVuelos(vuelos);
                ((TextBox)opcion.Controls["textBoxTipoIdAero"]).Text = dataGridListadoAeronaves.SelectedCells[0].Value.ToString();
                ((TextBox)opcion.Controls["textBoxTipo"]).Text = "1";
                funcionesComunes.deshabilitarVentanaYAbrirNueva(opcion);
                return false;
            }
            return true;
        }

        private DataTable vuelosVinculados()
        {   
            String id= dataGridListadoAeronaves.SelectedCells[0].Value.ToString();
            return SqlConnector.obtenerTablaSegunConsultaString(@"SELECT v.ID as Id,v.FECHA_SALIDA as 'Fecha Salida',v.FECHA_LLEGADA as 'Fecha Llegada'
                        ,v.FECHA_LLEGADA_ESTIMADA as 'Fecha Estimada',r.CODIGO as 'Codigo Ruta',t.NOMBRE as Servicio, v.AERONAVE_ID as Aeronave,v.RUTA_ID as RutaID,
                        r.TIPO_SERVICIO_ID as IdServicio
                        FROM " + SqlConnector.getSchema() + @".vuelos v
                        join " + SqlConnector.getSchema() + @".rutas r on r.ID = v.Ruta_ID
                        join " + SqlConnector.getSchema() + @".tipos_de_servicio t on t.ID = r.TIPO_SERVICIO_ID
                        where v.AERONAVE_ID =" + id +" AND v.INVALIDO = 0 AND v.FECHA_SALIDA > CURRENT_TIMESTAMP order by 2");
        }

        private void bajaModificacionDeAeronave_Enter(object sender, EventArgs e)
        {
            funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
        }

        private void matricula(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.martricula(this.textMatricula, e);
        }
    }
}
