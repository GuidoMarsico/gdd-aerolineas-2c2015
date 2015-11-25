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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class modificacionDeRuta : Form
    {
        public modificacionDeRuta(string id, string codigo, string precioKg, string precioPasaje, string origen, string destino, string servicio)
        {
            InitializeComponent();
            llenarCombobox();
            textBoxId.Text = id;
            textBoxCodigo.Text = codigo;
            textBoxPrecioKg.Text = precioKg;
            textBoxPrecioPasaje.Text = precioPasaje;
            textBoxOrigen.Text = origen;
            textBoxDestino.Text = destino;
            comboBoxServicios.Text = servicio;
        }

        private void llenarCombobox()
        {
              funcionesComunes.llenarCombobox(this.comboBoxServicios, "NOMBRE", @"select ID, NOMBRE 
                from " + SqlConnector.getSchema() + ".tipos_de_servicio");
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.textBoxPrecioKg.Clear();
            this.textBoxPrecioPasaje.Clear();
        }

        private void validacion(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxPrecioKg, e);
        }

        private void validacionPasaje(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxPrecioPasaje, e);
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            Double precioKg = Math.Round(Double.Parse(textBoxPrecioKg.Text), 2);
            Double precioPasaje = Math.Round(Double.Parse(textBoxPrecioPasaje.Text), 2);
            Int32 servicio = -1;
            if (this.comboBoxServicios.Enabled == true)
                servicio = (Int32)comboBoxServicios.SelectedValue;
            if (this.validarPrecios(precioKg, precioPasaje))
            {
                bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".updateRuta",
                    funcionesComunes.generarListaParaProcedure("@id", "@precioKg", "@precioPasaje"), this.textBoxId.Text, precioKg,
                    precioPasaje);
                bool resultado2 = true;
                if (this.comboBoxServicios.Enabled == true)
                    resultado2 = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".agregarServicioARuta",
                        funcionesComunes.generarListaParaProcedure("@idRuta", "@idServicio"), this.textBoxId.Text, servicio);
                if (resultado && resultado2)
                {
                    MessageBox.Show("La ruta se actualizo exitosamente");
                    funcionesComunes.habilitarAnterior();
                }
            }
        }

        private bool validarPrecios(double precioKg, double precioPasaje)
        {
            if ((precioKg == 0) || (precioPasaje == 0))
            {
                MessageBox.Show("El valor de los precios no puede ser 0");
                if ((precioKg == 0) && (precioPasaje == 0))
                {
                    this.textBoxPrecioKg.Clear();
                    this.textBoxPrecioPasaje.Clear();
                    return false;
                }
                else {
                    if (precioKg == 0)
                        this.textBoxPrecioKg.Clear();
                    else
                        this.textBoxPrecioPasaje.Clear();
                    return false;
                }
            }
            return true;
        }

        private void buttonAgregarServicio_Click(object sender, EventArgs e)
        {
            this.comboBoxServicios.DataSource = null;
            funcionesComunes.llenarCombobox(this.comboBoxServicios, "NOMBRE", @"select ID, NOMBRE 
            from " + SqlConnector.getSchema() + ".tipos_de_servicio where ID not in (select TIPOS_DE_SERVICIO_ID from " + SqlConnector.getSchema() +
            ".servicios_por_ruta where RUTAS_ID = " + this.textBoxId.Text + ")");
            this.comboBoxServicios.Enabled = true;
        }
    }
}
