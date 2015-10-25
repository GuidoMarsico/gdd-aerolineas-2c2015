using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class listadoEstadistico : Form
    {
        public listadoEstadistico()
        {
            InitializeComponent();
            pickerAño.Format = DateTimePickerFormat.Custom;
            pickerAño.CustomFormat = "yyyy";
            pickerAño.ShowUpDown = true;
            comboBoxSemestre.SelectedIndex = 0;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Int32 mesInicio;
            Int32 mesFin;
            if (comboBoxSemestre.SelectedIndex == 0){
                mesInicio = 1;
                mesFin = 6;
            }else{
                mesInicio = 7;
                mesFin = 12;
            }
            //Creo las fechas de inicio y fin dependiendo del año y el semestre elegido
            DateTime fechaInicio = new DateTime(Int32.Parse(pickerAño.Text), mesInicio, 1);
            DateTime fechaFin = new DateTime(Int32.Parse(pickerAño.Text), mesFin, 1);
            List<string> lista = funcionesComunes.generarListaParaProcedure("@fechaFrom", "@fechaTo")
            switch ((String)this.comboBoxListados.SelectedItem){
                case "Top 5 Destinos con más pasajes comprados":
                    dt = SqlConnector.obtenerTablaSegunProcedure("AERO.top5DestinosConPasajes", 
                        lista, String.Format("{0:yyyyMMdd HH:mm:ss}",fechaInicio), String.Format("{0:yyyyMMdd HH:mm:ss}",fechaFin));
                    break;
                case "Top 5 Destinos con aeronaves más vacias":
                    dt = SqlConnector.obtenerTablaSegunProcedure("AERO.top5DestinosAeronavesVacias", 
                        lista, String.Format("{0:yyyyMMdd HH:mm:ss}",fechaInicio),String.Format("{0:yyyyMMdd HH:mm:ss}",fechaFin));
                    break;
                case "Top 5 Clientes con más puntos acumulados a la fecha":
                    dt = SqlConnector.obtenerTablaSegunProcedure("AERO.top5ClientesMillas", lista, 
                        String.Format("{0:yyyyMMdd HH:mm:ss}",fechaInicio), String.Format("{0:yyyyMMdd HH:mm:ss}",fechaFin));
                    break;
                case "Top 5 Destinos con más pasajes cancelados":
                    dt = SqlConnector.obtenerTablaSegunProcedure("AERO.top5DestinosCancelados", 
                        lista, String.Format("{0:yyyyMMdd HH:mm:ss}",fechaInicio), String.Format("{0:yyyyMMdd HH:mm:ss}",fechaFin));
                    break;
                case "Top 5 Aeronaves con mayor cantidad de dias fuera de servicio":
                    dt = SqlConnector.obtenerTablaSegunProcedure("AERO.top5AeronavesFueraDeServicio",
                        lista, String.Format("{0:yyyyMMdd HH:mm:ss}",fechaInicio), String.Format("{0:yyyyMMdd HH:mm:ss}",fechaFin));
                    break;
            }
            this.dataGridListadoEstadistico.DataSource = dt;
        }
    }
}
