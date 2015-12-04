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
        public string inicio = "";
        public string fin = "";
        public DataTable vuelos;
        public CancelarVuelos(DataTable tabla)
        {
            InitializeComponent();
            this.vuelos = tabla;
        }

        public CancelarVuelos(string tipo, string idVuelo,string i,string f,DataTable vuelosEnPeriodo)
        {
            InitializeComponent();
            textBoxTipo.Text = tipo;
            textBoxTipoIdAero.Text = idVuelo;
            inicio = i;
            fin = f;
            this.vuelos = vuelosEnPeriodo;
        }

        public void actualizarAeronave()
        {
            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + @".updateAeronave",
        funcionesComunes.generarListaParaProcedure("@id", "@fechaInicio", "@fechaFin"),
        this.textBoxTipoIdAero.Text, inicio, fin);
            if (resultado)
            {
                MessageBox.Show("La aeronave se actualizo exitosamente");
                funcionesComunes.volverAMenuPrincipal();
            }
        }

        private void botonBajaTodos_Click(object sender, EventArgs e)
        {   
            //Si es igual a 0 significa que vino de cuando modificamos la aeronave y la dejamos deshabilitada por un periodo 
            //y eligio dar de baja todos los vuelos de ese periodo de esa aeronave
            if (this.textBoxTipo.Text == "0")
            {
                this.botonBajaTodos.Enabled = false;
                this.buttonReprogramar.Enabled = false;
                MessageBox.Show("Realizando la operacion, aguarde un momento ... ");
                foreach(DataRow vuelo in vuelos.Rows)
                {
                    funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
                }
                actualizarAeronave();
                this.botonBajaTodos.Enabled = true;
                this.buttonReprogramar.Enabled = true;
           
            }
            else 
            {
                this.botonBajaTodos.Enabled = false;
                this.buttonReprogramar.Enabled = false;
                MessageBox.Show("Realizando la operacion, aguarde un momento ... ");
                foreach (DataRow vuelo in vuelos.Rows)
                {
                    funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
                }
                this.botonBajaTodos.Enabled = true;
                this.buttonReprogramar.Enabled = true;
                funcionesComunes.darDeBajaAeronave(this.textBoxTipoIdAero.Text);
            }
            funcionesComunes.volverAMenuPrincipal();   
        }

        private void buttonReprogramar_Click(object sender, EventArgs e)
        {
            if (textBoxTipo.Text == "0") {
                Form vuelosARemplazar = new CancelarReprogramarVuelos.VuelosARemplazar(this.textBoxTipoIdAero.Text,inicio,fin, "0");
                funcionesComunes.deshabilitarVentanaYAbrirNueva(vuelosARemplazar);
            }
            else
            {
                Form vuelosARemplazar = new CancelarReprogramarVuelos.VuelosARemplazar(this.textBoxTipoIdAero.Text,"1");
                funcionesComunes.deshabilitarVentanaYAbrirNueva(vuelosARemplazar);
            }
             
            
        }


    }
}
