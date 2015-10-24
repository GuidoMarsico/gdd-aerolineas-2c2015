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
            if (this.textBoxTipo.Text == "0")
            {
                foreach(DataRow vuelo in vuelos.Rows)
                {
                    funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
                }
                
            }
            else 
            {
                foreach (DataRow vuelo in vuelos.Rows)
                {
                    funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
                }
                funcionesComunes.darDeBajaAeronave(this.textBoxTipoIdAero.Text);

            }
            funcionesComunes.volverAMenuPrincipal();
            
        }

       

       

        private void buttonReprogramar_Click(object sender, EventArgs e)
        {
            Form vuelosARemplazar = new CancelarReprogramarVuelos.VuelosARemplazar();
            ((TextBox)vuelosARemplazar.Controls["textBoxTipoIdAero"]).Text = this.textBoxTipoIdAero.Text;
            ((TextBox)vuelosARemplazar.Controls["textBoxTipo"]).Text = this.textBoxTipo.Text;
            funcionesComunes.deshabilitarVentanaYAbrirNueva(vuelosARemplazar);
        }
    }
}
