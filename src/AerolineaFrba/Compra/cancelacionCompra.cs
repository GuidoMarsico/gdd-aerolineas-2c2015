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
    public partial class cancelacionCompra : Form
    {
        public cancelacionCompra()
        {
            InitializeComponent();
        }

        private void noSeleccion(object sender, EventArgs e)
        {
            this.dataGridEnco.ClearSelection();
        }

        private void botonBuscarCli_Click(object sender, EventArgs e)
        {
            this.consultarContactos();
        }

        private void consultarContactos()
        {
            String dni = this.textBoxDniPas.Text;
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
                            this.textBoxIdCliente.Text = row["Id"].ToString();
                            this.textBoxNombre.Text = row["Nombre"].ToString();
                            this.textBoxApellido.Text = row["Apellido"].ToString();
                            this.textBoxDireccion.Text = row["Dirección"].ToString();
                            this.textBoxTelefono.Text = row["Teléfono"].ToString();
                            this.textBoxMail.Text = row["Mail"].ToString();
                            this.timePickerNacimiento.Value = (DateTime)row["Fecha de Nacimiento"];
                            this.textBoxDniPas.Enabled = false;
                        }

                    }
                    else
                        MessageBox.Show("Numero de documento inexistente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Numero de documento invalido, debe poseer al menos 6 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDniPas.Clear();
            this.textBoxIdCliente.Clear();
            this.textBoxDniPas.Enabled = true;
            this.textBoxApellido.Clear();
            this.textBoxDireccion.Clear();
            this.textBoxMail.Clear();
            this.textBoxNombre.Clear();
            this.textBoxTelefono.Clear();
            this.timePickerNacimiento.ResetText();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonBuscarCompra_Click(object sender, EventArgs e)
        {
            DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as Id, p.CODIGO as Codigo, 
                p.PRECIO as Precio, b.NUMERO as Butaca, bc.FECHA_COMPRA as 'Fecha de Compra', a1.NOMBRE as Origen, a2.NOMBRE as Destino
                from AERO.pasajes p, AERO.butacas b, AERO.boletos_de_compra bc, AERO.vuelos v, AERO.rutas r, AERO.aeropuertos a1, 
                AERO.aeropuertos a2, AERO.clientes c where p.BOLETO_COMPRA_ID = " + this.textBoxCodigoCompra.Text + @" and bc.ID = p.BOLETO_COMPRA_ID 
                and b.ID = p.BUTACA_ID and p.INVALIDO = 0 and v.ID = bc.VUELO_ID and v.RUTA_ID = r.ID and r.ORIGEN_ID = a1.ID and 
                r.DESTINO_ID = a2.ID and bc.INVALIDO = 0 and c.ID = " + this.textBoxIdCliente.Text);
            this.dataGridPasaje.DataSource = tabla;
            this.dataGridPasaje.Columns[0].Visible = false;

            DataTable tablaPaq = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as Id, p.CODIGO as Codigo, 
                p.PRECIO as Precio, p.KG as Peso, bc.FECHA_COMPRA as 'Fecha de Compra' from AERO.paquetes p, AERO.boletos_de_compra bc, 
                AERO.clientes c where p.BOLETO_COMPRA_ID = " + this.textBoxCodigoCompra.Text + @" and bc.ID = p.BOLETO_COMPRA_ID 
                and p.INVALIDO = 0 and bc.INVALIDO = 0 and c.ID = " + this.textBoxIdCliente.Text);
            this.dataGridEnco.DataSource = tablaPaq;
            this.dataGridPasaje.Columns[0].Visible = false;
        }
    }
}
