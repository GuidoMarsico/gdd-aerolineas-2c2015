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
    public partial class VuelosARemplazar : Form
    {
        public DataTable vuelos;
        public VuelosARemplazar(DataTable tabla)
        {
            InitializeComponent();
            this.vuelos = tabla;
        }

        private void cargaVentana_load(object sender, EventArgs e)
        {
            this.dataGridListadoVuelos.DataSource = this.vuelos;
            this.dataGridListadoVuelos.Columns[0].Visible = false;
            this.dataGridListadoVuelos.Columns[6].Visible = false;
            this.dataGridListadoVuelos.Columns[7].Visible = false;
            this.dataGridListadoVuelos.Columns[8].Visible = false;
        }
    }
}
