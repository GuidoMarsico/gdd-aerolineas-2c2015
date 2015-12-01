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
            Int32 idVuelo = Int32.Parse(this.textBoxIDVuelo.Text);
            String idBoleto = funcionesComunes.crearBoleto(this.pasajes, this.encomiendas,precio ,0,0,idCliente,idVuelo);
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso(idBoleto,pasajes,encomiendas,this.fechaSalida,this.origen,this.destino));
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
                            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente(2,"Alta de Cliente",dni);
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

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdCliente.Clear();
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxDni.Clear();
            textBoxDireccion.Text = "";
            textBoxTelefono.Text = "";
            textBoxMail.Text = "";
            textBoxMail.Text = "";
            textBoxImporte.Enabled = false;
            textBoxDni.Focus();
            this.textBoxDni.Enabled = true;
        }

        private void registrarPagoEfectivo_Enter(object sender, EventArgs e)
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

   
    }
}
