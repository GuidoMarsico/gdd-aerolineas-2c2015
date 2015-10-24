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
            Form modificacionAeronave = new Abm_Aeronave.modificacionDeAeronave();
            ((TextBox)modificacionAeronave.Controls["textBoxId"]).Text = dataGridListadoAeronaves.SelectedCells[0].Value.ToString();
            ((TextBox)modificacionAeronave.Controls["textBoxMatricula"]).Text = dataGridListadoAeronaves.SelectedCells[1].Value.ToString();
            ((TextBox)modificacionAeronave.Controls["textBoxModelo"]).Text = dataGridListadoAeronaves.SelectedCells[2].Value.ToString();
            ((TextBox)modificacionAeronave.Controls["textBoxKgDisponibles"]).Text = dataGridListadoAeronaves.SelectedCells[3].Value.ToString();
            ((ComboBox)modificacionAeronave.Controls["comboBoxFabricante"]).Text = dataGridListadoAeronaves.SelectedCells[4].Value.ToString();
            ((ComboBox)modificacionAeronave.Controls["comboBoxServicio"]).Text = dataGridListadoAeronaves.SelectedCells[5].Value.ToString();
            ((DateTimePicker)modificacionAeronave.Controls["timePickerAlta"]).Value = Convert.ToDateTime(dataGridListadoAeronaves.SelectedCells[6].Value.ToString());
            ((TextBox)modificacionAeronave.Controls["textBoxCantButacas"]).Text = dataGridListadoAeronaves.SelectedCells[7].Value.ToString();
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
            
           bool resultado = this.cancelarVuelosVinculados();
            if(resultado)
                this.darDeBaja();
            
        }

        private Boolean cancelarVuelosVinculados()
        {
            DataTable vuelos =this.vuelosVinculados();
            int cantVuelos =vuelos.Rows.Count;
            MessageBox.Show("cantidad de vuelos " + vuelos+ " ID de la aeronave "+ dataGridListadoAeronaves.SelectedCells[0].Value.ToString() );
            if (cantVuelos > 0)
            {
                Form opcion = new CancelarReprogramarVuelos.CancelarVuelos(vuelos);
                ((TextBox)opcion.Controls["textBoxTipoIdAero"]).Text = dataGridListadoAeronaves.SelectedCells[0].Value.ToString();
      
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
                        FROM AERO.vuelos v
                        join AERO.rutas r on r.ID = v.Ruta_ID
                        join AERO.tipos_de_servicio t on t.ID = r.TIPO_SERVICIO_ID
                        where v.AERONAVE_ID =" + id +" AND v.INVALIDO = 0 AND v.FECHA_SALIDA > CURRENT_TIMESTAMP order by 2");
        }

        private void darDeBaja()
        {
            List<string> lista = new List<string>();
            lista.Add("@id");
            bool resultado = SqlConnector.executeProcedure("AERO.bajaAeronave", lista, dataGridListadoAeronaves.SelectedCells[0].Value.ToString());
            if (resultado)
            {
                MessageBox.Show("La aeronave se dio de baja exitosamente");
            }
            funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
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
