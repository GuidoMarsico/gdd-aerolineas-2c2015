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

namespace AerolineaFrba.Abm_Vuelos
{
    public partial class generarViaje : Form
    {
        DataTable listadoAeronaves,listadoRutas;
        public generarViaje()
        {
            InitializeComponent();
            listadoAeronaves = funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
            listadoRutas = funcionesComunes.consultarRutas(dataGridListadoRutas);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void buttonBuscarMatricula_Click(object sender, EventArgs e)
        {
            DataTable aeronavesFiltrado = filtrarAeronaves(this.textBoxMatricula.Text);
            this.dataGridListadoAeronaves.DataSource = aeronavesFiltrado;
        }

        private DataTable filtrarAeronaves(string matricula)
        {
            DataTable tablaAeronaves = listadoAeronaves;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (matricula != "") filtrosBusqueda.Add("Matricula LIKE '%" + matricula + "%'");
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

        private void botonBuscarRuta_Click(object sender, EventArgs e)
        {
            DataTable rutasFiltrado = filtrarRutas(textBoxCodigo.Text);
            this.dataGridListadoRutas.DataSource = rutasFiltrado;
        }

        private DataTable filtrarRutas(string codigo)
        {
            DataTable tablaRutas = listadoRutas;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (codigo != "")filtrosBusqueda.Add("Codigo =" + codigo );
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

        private void textBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.martricula(this.textBoxMatricula,e);
        }
        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            funcionesComunes.consultarRutas(dataGridListadoRutas);
            funcionesComunes.consultarAeronaves(dataGridListadoAeronaves);
            this.textBoxCodigo.Clear();
            this.textBoxMatricula.Clear();
            this.timePickerLlegadaEstimada.ResetText();
            this.timePickerSalida.ResetText();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (this.dataGridListadoAeronaves.Rows.Count > 0 && this.dataGridListadoRutas.Rows.Count > 0)
            {
                if (this.validar())
                {
                    bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".generarViaje",
                        funcionesComunes.generarListaParaProcedure("@fechaSalida", "@fechaLlegadaEstimada",
                        "@idAeronave","@idRuta"), 
                        String.Format("{0:yyyyMMdd HH:mm:ss}",this.timePickerSalida.Value),
                        String.Format("{0:yyyyMMdd HH:mm:ss}", this.timePickerLlegadaEstimada.Value),
                        dataGridListadoAeronaves.SelectedCells[0].Value,
                        dataGridListadoRutas.SelectedCells[0].Value);
                    if (resultado == true){
                        MessageBox.Show("Se genero el viaje exitosamente");
                        funcionesComunes.habilitarAnterior();
                    }else{
                        MessageBox.Show("Ocurrió un error generando el viaje");
                    }
                }
            }
            
        }

        private bool validar() 
        {
            if (this.timePickerSalida.Value < DateTime.Today) 
            {
                MessageBox.Show("La fecha de salida no puede ser posterior a la de hoy");
                return false;
            }
            if (this.timePickerSalida.Value > this.timePickerLlegadaEstimada.Value){
                MessageBox.Show("No puede haber una fecha de salida despues de la estima");
                return false;
            }
            if (timePickerSalida.Value.AddDays((double)1) < timePickerLlegadaEstimada.Value){
                MessageBox.Show("La fecha estimada de llegada no puede ser mayor a 24hs de la de salida");
                return false;
            }
            if (dataGridListadoAeronaves.SelectedCells[5].Value.ToString() != dataGridListadoRutas.SelectedCells[6].Value.ToString()) {
                MessageBox.Show("La aeronave y la ruta elegida deben tener el mismo tipo de servicio");
                return false;
            }
            DataTable resultado = SqlConnector.obtenerTablaSegunProcedure(SqlConnector.getSchema() + ".validarVuelo",
                funcionesComunes.generarListaParaProcedure("@id", "@fechaSalida", "@fechaLlegadaEstimada"),
                dataGridListadoAeronaves.SelectedCells[0].Value, 
               String.Format("{0:yyyyMMdd HH:mm:ss}",this.timePickerSalida.Value), 
               String.Format("{0:yyyyMMdd HH:mm:ss}",this.timePickerLlegadaEstimada.Value));
            if (Int32.Parse(resultado.Rows[0].ItemArray[0].ToString()) != 0){
                MessageBox.Show("La aeronave ya tiene un vuelo programado para esas fechas, no se puede generar el vuelo");
                return false;
            }
            return true;
        }   
    }
}
