﻿using System;
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
    public partial class registrarPagoTarjeta : Form
    {
        public registrarPagoTarjeta()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso());
        }
    }
}
