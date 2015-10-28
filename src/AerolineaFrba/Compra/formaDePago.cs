using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class formaDePago : Form
    {
        public DataGridView pasajes;
        public DataGridView encomiendas;
        public formaDePago(DataGridView tablaPasajes,DataGridView tablaEncomiendas)
        {
            InitializeComponent();
            this.pasajes = tablaPasajes;
            this.encomiendas = tablaEncomiendas;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void buttonTarjeta_Click(object sender, EventArgs e)
        {
            Form porTarjeta = new Compra.registrarPagoTarjeta(this.pasajes, this.encomiendas);
            ((TextBox)porTarjeta.Controls["textBoxIDVuelo"]).Text = this.textBoxIDVuelo.Text;
            funcionesComunes.deshabilitarVentanaYAbrirNueva(porTarjeta);
        }

        private void botonEfectivo_Click(object sender, EventArgs e)
        {
            Form porEfectivo = new Compra.registrarPagoEfectivo(this.pasajes, this.encomiendas);
            ((TextBox)porEfectivo.Controls["textBoxIDVuelo"]).Text = this.textBoxIDVuelo.Text;
            funcionesComunes.deshabilitarVentanaYAbrirNueva(porEfectivo);
        }
    }
}
