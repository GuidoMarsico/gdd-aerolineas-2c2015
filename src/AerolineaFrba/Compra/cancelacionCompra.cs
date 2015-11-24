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
            if (this.textBoxIdCliente.Text != "" && this.textBoxIdCliente.Text != "0")
            {
                if (this.textBoxCodigoCompra.Text != "" && this.textBoxCodigoCompra.Text != "0")
                {
                    DataTable resultadoConsultaDNIBoletoCompra = SqlConnector.obtenerTablaSegunConsultaString(@"select * from " + SqlConnector.getSchema() + @".clientes c,
                " + SqlConnector.getSchema() + @".boletos_de_compra bc where c.ID = " + this.textBoxIdCliente.Text + " and bc.CLIENTE_ID = c.ID and bc.id = " +
                    this.textBoxCodigoCompra.Text);
                    if (resultadoConsultaDNIBoletoCompra.Rows.Count > 0)
                    {
                        DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as Id, p.CODIGO as Codigo, 
                p.PRECIO as Precio, b.NUMERO as Butaca, bc.FECHA_COMPRA as 'Fecha de Compra', a1.NOMBRE as Origen, a2.NOMBRE as Destino
                from " + SqlConnector.getSchema() + @".pasajes p, " + SqlConnector.getSchema() + @".butacas b, " + SqlConnector.getSchema() + @".boletos_de_compra bc, " + SqlConnector.getSchema() + @".vuelos v, " + SqlConnector.getSchema() + @".rutas r, " + SqlConnector.getSchema() + @".ciudades a1, 
                " + SqlConnector.getSchema() + @".ciudades a2 where p.BOLETO_COMPRA_ID = " + this.textBoxCodigoCompra.Text + @" and bc.ID = p.BOLETO_COMPRA_ID 
                and b.ID = p.BUTACA_ID and p.INVALIDO = 0 and v.ID = p.VUELO_ID and v.RUTA_ID = r.ID and r.ORIGEN_ID = a1.ID and 
                r.DESTINO_ID = a2.ID and bc.INVALIDO = 0 and v.FECHA_SALIDA > convert(datetime,'"+funcionesComunes.getFecha()+"',109) and v.FECHA_LLEGADA IS NULL and p.CANCELACION_ID IS NULL");
                        this.dataGridPasaje.DataSource = tabla;
                        this.dataGridPasaje.Columns[0].Visible = false;

                        DataTable tablaPaq = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as Id, p.CODIGO as Codigo, 
                p.PRECIO as Precio, p.KG as Peso, bc.FECHA_COMPRA as 'Fecha de Compra' from " + SqlConnector.getSchema() + @".paquetes p, " + SqlConnector.getSchema() + @".boletos_de_compra bc, 
                " + SqlConnector.getSchema() + @".vuelos v where p.BOLETO_COMPRA_ID = " + this.textBoxCodigoCompra.Text + @" and bc.ID = p.BOLETO_COMPRA_ID 
                and p.INVALIDO = 0 and bc.INVALIDO = 0 and v.ID = p.VUELO_ID and v.FECHA_SALIDA > convert(datetime,'"+funcionesComunes.getFecha()+@"',109) and v.FECHA_LLEGADA IS NULL
                and p.CANCELACION_ID IS NULL");
                        this.dataGridEnco.DataSource = tablaPaq;
                        this.dataGridEnco.Columns[0].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("El codigo de compra no pertenece al comprador ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El codigo de compra es un campo requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe cargar los datos del comprador primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonCancelarPasaje_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta a punto de cancelar el pasaje seleccionado, ¿esta seguro?", "Cancelar Pasaje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.dataGridPasaje.Rows.Count > 0 && this.dataGridPasaje.SelectedCells[0].Value != null)
                {
                    SqlConnector.executeProcedure(SqlConnector.getSchema() + @".cancelarPasaje", funcionesComunes.generarListaParaProcedure("@idPasaje", "@fecha"),
                        Int32.Parse(this.dataGridPasaje.SelectedCells[0].Value.ToString()), funcionesComunes.getFecha());
                    DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as Id, p.CODIGO as Codigo, 
                p.PRECIO as Precio, b.NUMERO as Butaca, bc.FECHA_COMPRA as 'Fecha de Compra', a1.NOMBRE as Origen, a2.NOMBRE as Destino
                from " + SqlConnector.getSchema() + @".pasajes p, " + SqlConnector.getSchema() + @".butacas b, " + SqlConnector.getSchema() + @".boletos_de_compra bc, " + SqlConnector.getSchema() + @".vuelos v, " + SqlConnector.getSchema() + @".rutas r, " + SqlConnector.getSchema() + @".ciudades a1, 
                " + SqlConnector.getSchema() + @".ciudades a2 where p.BOLETO_COMPRA_ID = " + this.textBoxCodigoCompra.Text + @" and bc.ID = p.BOLETO_COMPRA_ID 
                and b.ID = p.BUTACA_ID and p.INVALIDO = 0 and v.ID = p.VUELO_ID and v.RUTA_ID = r.ID and r.ORIGEN_ID = a1.ID and 
                r.DESTINO_ID = a2.ID and bc.INVALIDO = 0 and v.FECHA_SALIDA > convert(datetime,'" + funcionesComunes.getFecha() + "',109) and v.FECHA_LLEGADA IS NULL and p.CANCELACION_ID IS NULL");
                    this.dataGridPasaje.DataSource = tabla;
                    this.dataGridPasaje.Columns[0].Visible = false;
                }
                else
                {
                    MessageBox.Show("No hay ningun pasaje seleccionado para cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void botonCancelarPaquetes_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta a punto de cancelar TODOS los paquetes, ¿esta seguro?", "Cancelar Paquetes", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.dataGridEnco.Rows.Count > 0)
                {
                    SqlConnector.executeProcedure(SqlConnector.getSchema() + @".cancelarPaquete", funcionesComunes.generarListaParaProcedure("@idBoletoCompra", "@fecha"),
                        Int32.Parse(this.textBoxCodigoCompra.Text), funcionesComunes.getFecha());
                    DataTable tablaPaq = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as Id, p.CODIGO as Codigo, 
                     p.PRECIO as Precio, p.KG as Peso, bc.FECHA_COMPRA as 'Fecha de Compra' from " + SqlConnector.getSchema() + @".paquetes p, " + SqlConnector.getSchema() + @".boletos_de_compra bc, 
                    " + SqlConnector.getSchema() + @".vuelos v where p.BOLETO_COMPRA_ID = " + this.textBoxCodigoCompra.Text + @" and bc.ID = p.BOLETO_COMPRA_ID 
                    and p.INVALIDO = 0 and bc.INVALIDO = 0 and v.ID = p.VUELO_ID and v.FECHA_SALIDA > convert(datetime,'"+funcionesComunes.getFecha()+@"',109) and v.FECHA_LLEGADA IS NULL
                     and p.CANCELACION_ID IS NULL");
                    this.dataGridEnco.DataSource = tablaPaq;
                    this.dataGridEnco.Columns[0].Visible = false;
                }
                else
                {
                    MessageBox.Show("No hay paquetes para cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarDatosComprador(object sender, EventArgs e)
        {
            if (this.textBoxIdCliente.Text != "" && this.textBoxIdCliente.Text != "0")
            {
                DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                             NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                             TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                             from " + SqlConnector.getSchema() + @".clientes where BAJA = 0 AND  ID = " + this.textBoxIdCliente.Text);
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
    }
}
