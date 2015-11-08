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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class registroDeLlegadaADestino : Form
    {
        public registroDeLlegadaADestino()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void matricula(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.martricula(this.textBoxMatricula, e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable filtradoVuelos = filtradoDeVuelos(this.textBoxMatricula.Text,this.textBoxOrigen.Text,this.textBoxDestino.Text);
            dataGridListadoVuelos.DataSource = filtradoVuelos;
            dataGridListadoVuelos.Columns[0].Visible = false;
        }

        private DataTable filtradoDeVuelos(string matricula,string origen,string destino)
        {
            DataTable tablaVuelos = funcionesComunes.consultarVuelos();
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();

            if (matricula != "") filtrosBusqueda.Add("Matricula LIKE '%" + matricula + "%'");
            if (origen != "") filtrosBusqueda.Add("Origen LIKE '%" + origen + "%'");
            if (destino != "") filtrosBusqueda.Add("Destino LIKE '%" + destino + "%'");

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
            if (tablaVuelos != null)
                tablaVuelos.DefaultView.RowFilter = final_rol;
            return tablaVuelos;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.textBoxMatricula.Clear();
            this.timePickerLlegada.ResetText();
            this.dataGridListadoVuelos.DataSource = null;
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (validarRegistro()) {
                bool resultado = SqlConnector.executeProcedure("AERO.registrarLlegada",
                    funcionesComunes.generarListaParaProcedure("@idVuelo","@fechaLlegada"),
                    dataGridListadoVuelos.SelectedCells[0].Value.ToString(), 
                    String.Format("{0:yyyyMMdd HH:mm:ss}", this.timePickerLlegada.Value));
                if (resultado)
                {
                    MessageBox.Show("Se registro exitosamente la fecha de llegada");
                    limpiar();
                    this.botonBuscar.PerformClick();
                }
            }
        }

        private bool validarRegistro()
        {        DateTime fechaSalida=Convert.ToDateTime (dataGridListadoVuelos.SelectedCells[5].Value.ToString());
             if (this.timePickerLlegada.Value < fechaSalida)
                 {
                    MessageBox.Show("No puede haber una fecha de llega antes de la de salida");
                    return false;
                 }
            if (fechaSalida.AddDays((double)1) < timePickerLlegada.Value)
                {
                     MessageBox.Show("La fecha de llegada no puede ser mayor a 24hs de la de salida");
                     return false;
                }
            return true;
        }

        private void validar(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }
    }
}
