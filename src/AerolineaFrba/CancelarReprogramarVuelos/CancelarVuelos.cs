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
    public partial class CancelarVuelos : Form
    {
        public DataTable vuelos;
        public CancelarVuelos(DataTable tabla)
        {
            InitializeComponent();
            this.vuelos = tabla;
        }

        private void botonBajaTodos_Click(object sender, EventArgs e)
        {   
            //Si es igual a 0 significa que vino de cuando modificamos la aeronave y la dejamos deshabilitada por un periodo 
            //y eligio dar de baja todos los vuelos de ese periodo de esa aeronave
            if (this.textBoxTipoIdAero.Text == "0")
            {
                //dar de baja solo los vuelos
            }
            else 
            {
                MessageBox.Show("Cantidad de vuelos asociados " + this.vuelos.Rows.Count);
                this.darDeBaja();

            }
            funcionesComunes.habilitarAnterior();
            
        }

        private void darDeBaja()
        {
            List<string> lista = new List<string>();
            lista.Add("@id");
            bool resultado = SqlConnector.executeProcedure("AERO.bajaAeronave", lista, this.textBoxTipoIdAero.Text);
            if (resultado)
            {
                MessageBox.Show("La aeronave se dio de baja exitosamente");
            }
        }

        private void buttonReprogramar_Click(object sender, EventArgs e)
        {
            Form vuelosARemplazar = new CancelarReprogramarVuelos.VuelosARemplazar(this.vuelos);
            funcionesComunes.deshabilitarVentanaYAbrirNueva(vuelosARemplazar);
        }
    }
}
