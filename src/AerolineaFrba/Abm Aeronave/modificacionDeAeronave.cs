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
    public partial class modificacionDeAeronave : Form
    {
        public modificacionDeAeronave(string id,string matricula,string modelo,string kg,string fabricante,string servicio,DateTime alta,string butacas)
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(comboBoxFabricante, "NOMBRE", "select ID, NOMBRE from " + SqlConnector.getSchema() + ".fabricantes");
            funcionesComunes.llenarCombobox(comboBoxServicio, "NOMBRE", "select ID, NOMBRE from " + SqlConnector.getSchema() + ".tipos_de_servicio");
            this.textBoxId.Text = id;
            this.textBoxMatricula.Text = matricula;
            this.textBoxModelo.Text = modelo;
            this.textBoxKgDisponibles.Text = kg;
            this.comboBoxFabricante.Text = fabricante;
            this.comboBoxServicio.Text = servicio;
            this.timePickerAlta.Value = alta;
            this.textBoxCantButacas.Text = butacas;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            if (this.fechaFinInactividad.Value < this.fechaInicioInactividad.Value){
                MessageBox.Show("La fecha de fin de la inactividad no puede ser menor que la de inicio");
            } else {
                string inicioInactividad =  String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaInicioInactividad.Value);
                string finInactividad = String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaFinInactividad.Value);

                DataTable vuelosEnElPeriodo = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT v.ID as Id,v.FECHA_SALIDA as 'Fecha Salida',v.FECHA_LLEGADA as 'Fecha Llegada'
                        ,v.FECHA_LLEGADA_ESTIMADA as 'Fecha Estimada',r.CODIGO as 'Codigo Ruta',t.NOMBRE as Servicio, v.AERONAVE_ID as Aeronave,v.RUTA_ID as RutaID,
                        r.TIPO_SERVICIO_ID as IdServicio
                        FROM " + SqlConnector.getSchema() + @".vuelos v
                        join " + SqlConnector.getSchema() + @".rutas r on r.ID = v.Ruta_ID
                        join " + SqlConnector.getSchema() + @".tipos_de_servicio t on t.ID = r.TIPO_SERVICIO_ID
                        where v.AERONAVE_ID = " + textBoxId.Text + @" AND (v.FECHA_SALIDA 
                > convert(datetime, '" + inicioInactividad + @"',109) and (v.FECHA_SALIDA <
                convert(datetime, '" + finInactividad + @"',109)) or v.FECHA_LLEGADA < 
                convert(datetime, '" + inicioInactividad + @"',109) and v.FECHA_LLEGADA < convert(datetime, '" +
                finInactividad + @"',109) or v.FECHA_LLEGADA_ESTIMADA > 
                convert(datetime, '" + inicioInactividad + @"',109) and v.FECHA_LLEGADA_ESTIMADA < convert(datetime, '" +
                finInactividad + @"',109)) ");
                if (vuelosEnElPeriodo.Rows.Count > 0){
                    MessageBox.Show("La aeronave tiene vuelos asignados en ese período");
                    Form vuelosARemplazar = new CancelarReprogramarVuelos.CancelarVuelos("0",textBoxId.Text, String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaInicioInactividad.Value),String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaFinInactividad.Value) );
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(vuelosARemplazar);
                } else {
                    actualizarAeronave();
                }

            }  
            limpiar();
        }

        public void actualizarAeronave()
        {
            bool resultado = SqlConnector.executeProcedure( SqlConnector.getSchema() + ".updateAeronave",
        funcionesComunes.generarListaParaProcedure("@id", "@fechaInicio", "@fechaFin"),
        this.textBoxId.Text,
        String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaInicioInactividad.Value),
        String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaFinInactividad.Value));
            if (resultado)
            {
                MessageBox.Show("La aeronave se actualizo exitosamente");
                funcionesComunes.volverAMenuPrincipal();
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar(){
            this.fechaFinInactividad.ResetText();
            this.fechaInicioInactividad.ResetText();
        }
    }
}
