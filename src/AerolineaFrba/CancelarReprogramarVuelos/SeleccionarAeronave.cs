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
    public partial class SeleccionarAeronave : Form
    {
        DataTable aeronavesDisponibles;
        public SeleccionarAeronave(DataTable tabla)
        {
            InitializeComponent();
            this.aeronavesDisponibles = tabla;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {

            //Se tiene que hacer el update
            funcionesComunes.habilitarAnterior();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }
    }
}
