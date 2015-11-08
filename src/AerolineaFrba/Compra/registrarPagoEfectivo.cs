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
    public partial class registrarPagoEfectivo : Form
    {
        public DataGridView pasajes;
        public DataGridView encomiendas;
        public Boolean modificarDatos = false;
        string fechaSalida;
        string origen;
        string destino;
        public registrarPagoEfectivo(DataGridView tablaPasajes,DataGridView tablaEncomiendas,string fecha,string origen,string destino)
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
            Double importe = this.importePasajes() + this.importeEncomiendas();
            this.textBoxImporte.Text = importe.ToString();
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
            Double precio =double.Parse (this.textBoxImporte.Text);
            Int32 idCliente = Int32.Parse( this.textBoxIdCliente.Text);
            if (idCliente == 0)
            {
                idCliente = this.darDeAltaCliente();
            }
            Int32 idVuelo = Int32.Parse(this.textBoxIDVuelo.Text);
            String idBoleto = funcionesComunes.crearBoleto(this.pasajes, this.encomiendas,precio , "EFECTIVO",idCliente,idVuelo);
            // Me devuelvo el id del boleto que es el codigo de compra como quedamos y se lo mandamos a la siguiente vista para mostrarlo
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso(idBoleto,pasajes,encomiendas,this.fechaSalida,this.origen,this.destino));
        }

        private int darDeAltaCliente()
        {
            string nombre = this.textBoxNombre.Text;
            string apellido = this.textBoxApellido.Text;
            long dni = long.Parse(this.textBoxDni.Text);
            long telefono = long.Parse(this.textBoxTelefono.Text);
            string direccion = this.textBoxDireccion.Text;
            string mail = this.textBoxMail.Text;
            DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT TOP 1 c.ID as id
                                                                    FROM AERO.clientes c
                                                                    order by 1 desc");
            return Convert.ToInt32(tabla.Rows[0].ItemArray[0]);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
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
                         from AERO.clientes where BAJA = 0 AND DNI = " + dni);
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
                            timePickerNacimiento.Value = (DateTime)row["Fecha de Nacimiento"];
                            textBoxImporte.Enabled = true;
                            textBoxImporte.Focus();
                            this.textBoxDni.Enabled = false;
                        }

                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Debe dar de alta el cliente con ese DNI, ¿esta seguro?", "Dni de Cliente Inexistente", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
                            int valor = 1;
                            ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = valor.ToString();
                            altaDeCliente.Text = "Alta de Cliente";
                            ((TextBox)altaDeCliente.Controls["textBoxDNI"]).Text = dni;
                            ((TextBox)altaDeCliente.Controls["textBoxDNI"]).ReadOnly = true;
                            funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);
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


        private void cargarDatosPasajero()
        {
            DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                         NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                         TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                         from AERO.clientes where BAJA = 0 AND  ID = " + this.textBoxIdCliente.Text);

            DataRow row = tablaClientes.Rows[0];
            textBoxIdCliente.Text = row["Id"].ToString();
            textBoxNombre.Text = row["Nombre"].ToString();
            textBoxApellido.Text = row["Apellido"].ToString();
            textBoxDireccion.Text = row["Dirección"].ToString();
            textBoxTelefono.Text = row["Teléfono"].ToString();
            textBoxMail.Text = row["Mail"].ToString();
            timePickerNacimiento.Value = (DateTime)row["Fecha de Nacimiento"];
            textBoxImporte.Enabled = true;
            textBoxImporte.Focus();
            this.textBoxDni.Enabled = false;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdCliente.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDni.Clear();
            textBoxDireccion.Clear();
            textBoxTelefono.Clear();
            textBoxMail.Clear();
            textBoxMail.Clear();
            textBoxImporte.Enabled = false;
            textBoxDni.Focus();
            this.textBoxDni.Enabled = true;
        }

        private void registrarPagoEfectivo_Enter(object sender, EventArgs e)
        {
            if (this.textBoxIdCliente.Text != "" && this.textBoxIdCliente.Text != "0")
                this.cargarDatosPasajero();
            if (this.textBoxIdCliente.Text == "0")
                this.textBoxDni.Enabled = false;
            if (this.modificarDatos)
            {
                this.cargarDatosPasajero();
                this.modificarDatos = false;
            }
        }

        

        private void buttonModificar_Click_1(object sender, EventArgs e)
        {
            if (this.textBoxIdCliente.Text != "" && this.textBoxIdCliente.Text != "0")
            {
                this.modificarDatos = true;
                Form modificarCliente = new Registro_de_Usuario.altaModificacionDeCliente();
                int valor = 3;
                ((Label)modificarCliente.Controls["campoRequeridoApellido"]).Visible = false;
                ((Label)modificarCliente.Controls["campoRequeridoNombre"]).Visible = false;
                ((Label)modificarCliente.Controls["campoRequeridoDNI"]).Visible = false;
                ((Label)modificarCliente.Controls["campoRequeridoNacimiento"]).Visible = false;
                ((TextBox)modificarCliente.Controls["textBoxTipoForm"]).Text = valor.ToString();
                ((TextBox)modificarCliente.Controls["textBoxId"]).Text = this.textBoxIdCliente.Text;
                ((TextBox)modificarCliente.Controls["textBoxNombre"]).Text = this.textBoxNombre.Text;
                ((TextBox)modificarCliente.Controls["textBoxApellido"]).Text = this.textBoxApellido.Text;
                ((TextBox)modificarCliente.Controls["textBoxDni"]).Text = this.textBoxDni.Text;
                ((TextBox)modificarCliente.Controls["textBoxDireccion"]).Text = this.textBoxDireccion.Text;
                ((TextBox)modificarCliente.Controls["textBoxTelefono"]).Text = this.textBoxTelefono.Text;
                ((TextBox)modificarCliente.Controls["textBoxMail"]).Text = this.textBoxMail.Text;
                ((DateTimePicker)modificarCliente.Controls["TimePickerNacimiento"]).Value = this.timePickerNacimiento.Value;
                modificarCliente.Text = "Modificación de Cliente";
                funcionesComunes.deshabilitarVentanaYAbrirNueva(modificarCliente);
            }
            else
            {
                MessageBox.Show("Debe tener un cliente dado de alta para modificar");
            }

        }

   
    }
}
