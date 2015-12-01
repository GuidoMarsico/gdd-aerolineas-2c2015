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
        double importeApagar = 0;
        string fechaSalida;
        string origen;
        string destino;
        public registrarPagoTarjeta(DataGridView tablaPasajes,DataGridView tablaEncomiendas,string fecha,string origen,string destino)
        {
            InitializeComponent();
            this.pasajes = tablaPasajes;
            this.encomiendas = tablaEncomiendas;
            this.calcularImporte();
            this.fechaSalida = fecha;
            this.origen = origen;
            this.destino = destino;
        }

        private void calcularImporte()
        {
            this.importeApagar = this.importePasajes() + this.importeEncomiendas();
        }

        private double importeEncomiendas()
        {
            if (this.encomiendas != null)
            {
                Double importe = 0;
                foreach (DataGridViewRow encomienda in this.encomiendas.Rows)
                    importe += funcionesComunes.precioEncomienda(encomienda);
                return importe;
            }
            else
                return 0;
        }

        private double importePasajes()
        {
            if (this.pasajes != null)
            {
                Double importe = 0;
                foreach (DataGridViewRow pasaje in this.pasajes.Rows)
                    importe += funcionesComunes.precioPasaje(pasaje);
                return importe;
            }
            else
                return 0;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (comboBoxCuotas.SelectedIndex != -1 && textBoxCodigo.Text != "")
            {
                Int32 idCliente = Int32.Parse(this.textBoxIdCliente.Text);
                Int32 idVuelo = Int32.Parse(this.textBoxIDVuelo.Text);
                Int32 idtarjeta = Int32.Parse(this.textBoxIdTarj.Text);
                int cantCuotas= int.Parse(comboBoxCuotas.SelectedItem.ToString());
                String idBoleto = funcionesComunes.crearBoleto(this.pasajes, this.encomiendas, this.importeApagar,idtarjeta,cantCuotas ,idCliente,idVuelo);
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso(idBoleto,pasajes,encomiendas,this.fechaSalida,this.origen,this.destino));
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

        

        private void botonLimpiarTitular_Click(object sender, EventArgs e)
        {
            textBoxApellido.Text = "";
            textBoxNombre.Text = "";
            textBoxDni.Clear();
            textBoxDni.Enabled = true;
            textBoxDireccion.Text = "";
            textBoxIdCliente.Clear();
            textBoxMail.Text = "";
            textBoxTelefono.Text = "";
            timePickerNacimiento.Text = "";
            timePickerVencimiento.Value = DateTime.Today;
            textBoxNumero.Clear();
            textBoxCodigo.Clear();
            textBoxTipo.Clear();
            textBoxIdTarj.Clear();
            comboBoxCuotas.Items.Clear();
        }

        private void textBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String dni = this.textBoxDni.Text;
            if (dni != "")
            {
                if (dni.Length >= 6)
                {
                    if (funcionesComunes.validarDni(dni))
                    {
                        DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                         NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                         TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                         from " + SqlConnector.getSchema() + @".clientes where BAJA = 0 AND DNI = " + dni);
                        if (tablaClientes.Rows.Count > 1)
                        {
                            Form listadoClientes = new Registro_de_Usuario.bajaModificacionDeCliente();
                            int valor = 1;
                            ((TextBox)listadoClientes.Controls["textBoxTipoForm"]).Text = valor.ToString();
                            ((TextBox)listadoClientes.Controls["textBoxDniCompra"]).Text = dni;
                            funcionesComunes.deshabilitarVentanaYAbrirNueva(listadoClientes);
                        }
                        else
                        {
                            DataRow row = tablaClientes.Rows[0];
                            textBoxIdCliente.Text = row["Id"].ToString();
                            textBoxNombre.Text = row["Nombre"].ToString();
                            textBoxApellido.Text = row["Apellido"].ToString();
                            textBoxDireccion.Text = row["Dirección"].ToString();
                            textBoxTelefono.Text = row["Teléfono"].ToString();
                            textBoxMail.Text = row["Mail"].ToString();
                            timePickerNacimiento.Text = ((DateTime)row["Fecha de Nacimiento"]).ToShortDateString();
                            this.textBoxDni.Enabled = false;
                        }

                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Debe dar de alta el cliente con ese DNI, ¿esta seguro?", "Dni de Cliente Inexistente", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente(2,"Alta de Cliente",dni);
                            funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);
                            this.botonLimpiar.Enabled = false;
                        }
                    }
                }
                else
                    MessageBox.Show("Numero de documento invalido, debe poseer al menos 6 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonNuevaTarj_Click(object sender, EventArgs e)
        {
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Tarjeta.altaDeTarjeta());
        }

        private void registrarPagoTarjeta_Enter(object sender, EventArgs e)
        {
            if (this.textBoxIdCliente.Text != "")
                setCliente();

        }

        private void setCliente()
        {
            DataRow row = funcionesComunes.getcliente(this.textBoxIdCliente.Text);
            this.textBoxIdCliente.Text = row["Id"].ToString();
            this.textBoxNombre.Text = row["Nombre"].ToString();
            this.textBoxApellido.Text = row["Apellido"].ToString();
            this.textBoxDireccion.Text = row["Dirección"].ToString();

            this.textBoxTelefono.Text = row["Teléfono"].ToString();
            this.textBoxMail.Text = row["Mail"].ToString();
            this.timePickerNacimiento.Text = ((DateTime)row["Fecha de Nacimiento"]).ToShortDateString();
            this.textBoxDni.Enabled = false;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdCliente.Clear();
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxDni.Clear();
            textBoxDireccion.Text = "";
            textBoxTelefono.Text = "";
            textBoxMail.Text = "";
            this.textBoxIdTarj.Clear();
            this.textBoxNumero.Clear();
            this.textBoxCodigo.Clear();
            this.textBoxTipo.Clear();
            this.textBoxDni.Enabled = true;
        }

        private void buttonModificar_Click_1(object sender, EventArgs e)
        {
            if (this.textBoxIdCliente.Text != "")
            {
                string id = this.textBoxIdCliente.Text;
                string nombre = this.textBoxNombre.Text;
                string apellido = this.textBoxApellido.Text;
                string dni = this.textBoxDni.Text;
                string direccion = this.textBoxDireccion.Text;
                string telefono = this.textBoxTelefono.Text;
                string mail = this.textBoxMail.Text;
                DateTime fecha = Convert.ToDateTime(this.timePickerNacimiento.Text);
                Form modificarCliente = new Registro_de_Usuario.altaModificacionDeCliente(3, "Modificación de Cliente", id, nombre, apellido, dni, direccion, telefono, mail, fecha);
                funcionesComunes.deshabilitarVentanaYAbrirNueva(modificarCliente);
            }
            else
            {
                MessageBox.Show("Debe tener un cliente dado de alta para modificar");
            }
        }

        private void ingresarTarjeta_Click(object sender, EventArgs e)
        {
            if (validarIngresoTarjeta()) 
            {
                DataTable tablaTarjetas = SqlConnector.obtenerTablaSegunConsultaString(@"select tc.ID as Id, tc.NUMERO as Número, tc.FECHA_VTO as Vencimiento, t.NOMBRE as Nombre, t.CUOTAS as cuotas
                from " + SqlConnector.getSchema() + @".tarjetas_de_credito tc inner join " + SqlConnector.getSchema() + 
                @".tipos_tarjeta t on tc.TIPO_TARJETA_ID = t.ID where tc.CLIENTE_ID =" + Convert.ToInt32(textBoxIdCliente.Text) +" and tc.NUMERO ="+ long.Parse(textBoxNumero.Text));
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
                    MessageBox.Show("No se puede encontrar una tarjeta de crédito valida para el cliente seleccionado, haga un alta de tarjeta para ese cliente");
                    this.textBoxNumero.Clear();
                }
            }

        }

        private bool validarIngresoTarjeta()
        {
            if (this.textBoxIdCliente.Text == "") {
                MessageBox.Show("Debe tener un cliente seleccionado para ingresar una tarjeta");
                return false;
            }
            if (this.textBoxNumero.Text == "") {
                MessageBox.Show("Debe ingresar un numero de tarjeta para buscar");
                return false;
            }
            return true;
        }
       
    }
}
