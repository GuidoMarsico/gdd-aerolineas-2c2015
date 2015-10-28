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
    public partial class registrarPagoTarjeta : Form
    {
        public DataGridView pasajes;
        public DataGridView encomiendas;
        public registrarPagoTarjeta(DataGridView tablaPasajes,DataGridView tablaEncomiendas)
        {
            InitializeComponent();
            this.pasajes = tablaPasajes;
            this.encomiendas = tablaEncomiendas;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (comboBoxCuotas.SelectedIndex != -1 && textBoxCodigo.Text != "")
            {
                /* Si guarda bien en boleto de compra el pago entonces muestra el procesocompraexitoso */
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso());
            }
            else
            {
                MessageBox.Show("Complete los campos requeridos");
            }
           
        }

        private void textBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void cargarFormulario(int val, string nombre)
        {
            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
            int valor = val;
            ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = val.ToString();
            ((TextBox)altaDeCliente.Controls["textBoxVolver"]).Text = "1";
            altaDeCliente.Text = nombre;
            if (val == 2)
            {
                ((TextBox)altaDeCliente.Controls["textBoxId"]).Text = textBoxIdTitular.Text;
                ((TextBox)altaDeCliente.Controls["textBoxNombre"]).Text = textBoxNombre.Text;
                ((TextBox)altaDeCliente.Controls["textBoxApellido"]).Text = textBoxApellido.Text;
                ((TextBox)altaDeCliente.Controls["textBoxDni"]).Text = textBoxDNITitular.Text;
                ((TextBox)altaDeCliente.Controls["textBoxDireccion"]).Text = textBoxDireccion.Text;
                ((TextBox)altaDeCliente.Controls["textBoxTelefono"]).Text = textBoxTelefono.Text;
                ((TextBox)altaDeCliente.Controls["textBoxMail"]).Text = textBoxMail.Text;
                ((DateTimePicker)altaDeCliente.Controls["TimePickerNacimiento"]).Value = timePickerNacimiento.Value;
            }
            funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);

        }

        private void botonLimpiarTitular_Click(object sender, EventArgs e)
        {
            textBoxApellido.Clear();
            textBoxNombre.Clear();
            textBoxDni.Clear();
            textBoxDireccion.Clear();
            textBoxIdTitular.Clear();
            textBoxMail.Clear();
            textBoxTelefono.Clear();
            timePickerNacimiento.Value = DateTime.Today;
            timePickerVencimiento.Value = DateTime.Today;
            textBoxNumero.Clear();
            textBoxCodigo.Clear();
            textBoxTipo.Clear();
            textBoxIdTarj.Clear();
            textBoxDNITitular.Clear();
            comboBoxCuotas.Items.Clear();
        }

        private void textBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxDni.TextLength >= 6)
            {
                DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                from AERO.clientes where BAJA = 0 AND DNI = " + textBoxDni.Text);
                if (tablaClientes.Rows.Count > 0)
                {

                    DataRow row = tablaClientes.Rows[0];
                    textBoxIdTitular.Text = row["Id"].ToString();
                    textBoxNombre.Text = row["Nombre"].ToString();
                    textBoxApellido.Text = row["Apellido"].ToString();
                    textBoxDireccion.Text = row["Dirección"].ToString();
                    textBoxTelefono.Text = row["Teléfono"].ToString();
                    textBoxMail.Text = row["Mail"].ToString();
                    textBoxDNITitular.Text = row["Dni"].ToString();
                    timePickerNacimiento.Value = (DateTime)row["Fecha de Nacimiento"];

                    DataTable tablaTarjetas = SqlConnector.obtenerTablaSegunConsultaString(@"select tc.ID as Id, tc.NUMERO as Número, tc.FECHA_VTO as Vencimiento, t.NOMBRE as Nombre, t.CUOTAS as cuotas
                    from AERO.tarjetas_de_credito tc inner join AERO.tipos_tarjeta t on tc.TIPO_TARJETA_ID = t.ID where tc.CLIENTE_ID =" + Convert.ToInt32(textBoxIdTitular.Text));
                    if (tablaTarjetas.Rows.Count > 0)
                    {
                        DataRow rowTarj = tablaTarjetas.Rows[0];
                        textBoxIdTarj.Text = rowTarj["Id"].ToString();
                        textBoxNumero.Text = rowTarj["Número"].ToString();
                        textBoxTipo.Text = rowTarj["Nombre"].ToString();
                        timePickerVencimiento.Value = (DateTime)rowTarj["Vencimiento"];
                        int cantCuotas = Convert.ToInt32(rowTarj["Cuotas"]);
                        for (int i = 1; i <= cantCuotas; i++)
                        {
                            comboBoxCuotas.Items.Add(i.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede encontrar una tarjeta de crédito para el cliente seleccionado");
                        botonLimpiarTitular.PerformClick();
                    }

                }
                else
                {
                    MessageBox.Show("Cliente no encontrado. Ingrese nuevamente DNI o ingrese la alta");
                    botonLimpiarTitular.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el DNI completo");
                textBoxDni.Focus();
            }
        }

        private void botonActualizacionDeDatos_Click(object sender, EventArgs e)
        {
            if (textBoxApellido.Text != "")
            {
                cargarFormulario(2, "Modificación de cliente");
            }
            else
            {
                MessageBox.Show("Busque un cliente para ser modificado");
            }
        }

        private void botonNuevoCliente_Click(object sender, EventArgs e)
        {
            cargarFormulario(0, "Alta de Cliente");
        }

        private void botonNuevaTarj_Click(object sender, EventArgs e)
        {
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Tarjeta.altaDeTarjeta());
        }

       
    }
}
