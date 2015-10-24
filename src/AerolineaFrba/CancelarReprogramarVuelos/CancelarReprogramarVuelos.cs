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
    public partial class CancelarReprogramarVuelos : Form
    {
        public CancelarReprogramarVuelos()
        {
            InitializeComponent();
        }

        private void botonBajaTodos_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
            //TODO 
        }
    }
}
