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

namespace AerolineaFrba.Compra
{
    public partial class procesoCompraExitoso : Form
    {
        public procesoCompraExitoso(string codigoBoleto,DataGridView pasajes,DataGridView encomiendas,string fechaSalida,string origen,string destino )
        {
            InitializeComponent();
            this.labelCodigo.Text = codigoBoleto;
            if (pasajes.RowCount != 0)
            {
                this.label5.Visible = true;
                this.labelCantidadPasajes.Visible = true;
                this.labelCantidadPasajes.Text = pasajes.RowCount.ToString();
            }
            if (encomiendas.RowCount != 0)
            {
                this.label4.Visible = true;
                this.label7.Visible = true;
                this.label7.Text = encomiendas.RowCount.ToString();
            }
            this.labelFecha.Text = fechaSalida;
            this.labelOrigen.Text = origen;
            this.labelDestino.Text = destino;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            funcionesComunes.volverAMenuPrincipal();
        }
    }
}
