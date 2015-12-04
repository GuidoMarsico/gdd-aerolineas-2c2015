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
    public partial class altaDeRuta : Form
    {
        public altaDeRuta()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(this.comboBoxOrigen, "NOMBRE", "select ID,NOMBRE from " + SqlConnector.getSchema() + ".ciudades");
            funcionesComunes.llenarCombobox(this.comboBoxDestino, "NOMBRE", "select ID,NOMBRE from " + SqlConnector.getSchema() + ".ciudades");
            funcionesComunes.llenarCombobox(this.comboBoxServicios, "NOMBRE", "select ID, NOMBRE from " + SqlConnector.getSchema() + ".tipos_de_servicio");
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            this.comboBoxDestino.SelectedIndex = -1;
            this.comboBoxOrigen.SelectedIndex = -1;
            this.comboBoxServicios.SelectedIndex = -1;
        }

        private void limpiar()
        {
            this.textBoxCodigo.Clear();
            this.textBoxPrecioKg.Clear();
            this.textBoxPrecioPasaje.Clear();
            this.comboBoxDestino.SelectedIndex = -1;
            this.comboBoxOrigen.SelectedIndex = -1;
            this.comboBoxServicios.SelectedIndex = -1;
        }

        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void validacion(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxPrecioKg, e);
        }

        private void validacionPasaje(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxPrecioPasaje, e);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (this.validarInputs())
            {
                Int32 codigo = Int32.Parse(textBoxCodigo.Text);
                Double precioKg = Math.Round(Double.Parse(textBoxPrecioKg.Text), 2);
                Double precioPasaje = Math.Round(Double.Parse(textBoxPrecioPasaje.Text), 2);
                Int32 origen = (Int32)comboBoxOrigen.SelectedValue;
                Int32 destino = (Int32)comboBoxDestino.SelectedValue;
                Int32 servicio = (Int32)comboBoxServicios.SelectedValue;
                if (this.validarCampos(origen, destino, precioKg, precioPasaje, codigo))
                {
                    bool resultado = SqlConnector.executeProcedure( SqlConnector.getSchema() + ".agregarRuta",
                        funcionesComunes.generarListaParaProcedure("@codigo", "@precioKg", "@precioPasaje",
                        "@origen", "@destino", "@servicio"), codigo, precioKg, precioPasaje,
                        origen, destino, servicio);
                    if (resultado)
                    {
                        MessageBox.Show("Se guardo exitosamente");
                        limpiar();
                        this.comboBoxDestino.SelectedIndex = -1;
                        this.comboBoxOrigen.SelectedIndex = -1;
                        this.comboBoxServicios.SelectedIndex = -1;
                    }
                }
            }
        }

        private bool validarInputs()
        {
            if (this.textBoxCodigo.Text.Trim() == "")
                return false;
            if (this.textBoxPrecioKg.Text.Trim() == "")
                return false;
            if (this.textBoxPrecioPasaje.Text.Trim() == "")
                return false;
            if (this.comboBoxDestino.SelectedIndex == -1)
                return false;
            if (this.comboBoxOrigen.SelectedIndex == -1)
                return false;
            if (this.comboBoxServicios.SelectedIndex == -1)
                return false;
            DataTable rutas = new DataTable();
            rutas = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT * FROM " + SqlConnector.getSchema() + ".rutas R WHERE R.origen_id = "
                     + this.comboBoxOrigen.SelectedValue + " and R.destino_id = " + this.comboBoxDestino.SelectedValue);
            if (rutas.Rows.Count != 0) 
            {
                MessageBox.Show("Ya existe una ruta con ese origen y destino");
                return false;
            }
            return true;
        }

        private bool validarCampos(int origen, int destino, double precioKg, double precioPasaje,int codigo)
        {
            if (origen == destino) {
                MessageBox.Show("No se puede tener como destino el mismo lugar de origen");
                this.comboBoxDestino.SelectedIndex = -1;
                return false;
            }
            if ((precioKg == 0) || (precioPasaje == 0)) {
                MessageBox.Show("El valor de los precios no puede ser 0");
                if (precioKg == 0)
                    this.textBoxPrecioKg.Clear();
                else
                    this.textBoxPrecioPasaje.Clear();
                return false;
            }
            if (codigo == 0) {
                MessageBox.Show("El codigo de ruta no puede ser 0");
                this.textBoxCodigo.Clear();
                return false;
            }
            return true;
        }

        
    }
}
