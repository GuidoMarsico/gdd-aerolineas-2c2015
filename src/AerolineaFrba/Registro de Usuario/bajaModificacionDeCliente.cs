using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class bajaModificacionDeCliente : Form
    {
        DataTable listado;
        public bajaModificacionDeCliente()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            if (this.textBoxTipoForm.Text == "1") {
                this.setearParaCompras();
            }
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeCliente_Load(object sender, EventArgs e)
        {
            listado = funcionesComunes.consultarClientes(dataGridListadoClientes);
            
            if (this.textBoxTipoForm.Text == "1")
            {
                
                this.textDni.Text = this.textBoxDniCompra.Text;
                this.botonBaja.Visible = false;
                this.botonLimpiar.Visible = false;
                this.botonVolver.Text = "Seleccionar";

                this.botonBuscar.PerformClick();
                this.groupBox1.Visible = false;
            }
            
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable clientesFiltro = filtrarCliente(textNombre.Text, textApellido.Text, textMail.Text, textDni.Text, textTelefono.Text, textDireccion.Text);
            dataGridListadoClientes.DataSource = clientesFiltro;
        }

        private DataTable filtrarCliente(string nombre, string apellido, string mail, string dni, string telefono, string direccion)
        {
            DataTable tablaClientes = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (nombre != "") filtrosBusqueda.Add("Nombre LIKE '%" + nombre + "%'");
            if (apellido != "") filtrosBusqueda.Add("Apellido LIKE '%" + apellido + "%'");
            if (mail != "") filtrosBusqueda.Add("Mail LIKE '%" + mail + "%'");
            if (dni != "") filtrosBusqueda.Add("Dni = " + dni);
            if (telefono != "") filtrosBusqueda.Add("Teléfono = " + telefono);
            if (direccion != "") filtrosBusqueda.Add("Dirección LIKE '%" + direccion + "%'");
   
            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_rol += " AND " + filtro;
                else
                {
                    final_rol += filtro;
                    posFiltro = false;
                }
            }
            if (tablaClientes != null)
                tablaClientes.DefaultView.RowFilter = final_rol;
            return tablaClientes;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            dataGridListadoClientes.DataSource = null;
            listado =  funcionesComunes.consultarClientes(dataGridListadoClientes);
            textNombre.Text = "";
            textApellido.Text = "";
            textMail.Text = "";
            textDni.Text = "";
            textTelefono.Text = "";
            textDireccion.Text = "";
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            string id = dataGridListadoClientes.SelectedCells[0].Value.ToString();
            string nombre = dataGridListadoClientes.SelectedCells[1].Value.ToString();
            string apellido = dataGridListadoClientes.SelectedCells[2].Value.ToString();
            string dni = dataGridListadoClientes.SelectedCells[3].Value.ToString();
            string direccion = dataGridListadoClientes.SelectedCells[4].Value.ToString();
            string telefono = dataGridListadoClientes.SelectedCells[5].Value.ToString();
            string mail = dataGridListadoClientes.SelectedCells[6].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dataGridListadoClientes.SelectedCells[7].Value.ToString());

            Form modificarCliente = new Registro_de_Usuario.altaModificacionDeCliente(3, "Modificación de Cliente", id, nombre, apellido, dni, direccion, telefono, mail, fecha);
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificarCliente);
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".bajaCliente",
                funcionesComunes.generarListaParaProcedure("@id"), 
                dataGridListadoClientes.SelectedCells[0].Value.ToString());
            if (resultado)
            {
                MessageBox.Show("El cliente se dio de baja exitosamente");
            }
               listado = funcionesComunes.consultarClientes(dataGridListadoClientes);
        }

        private void bajaModificacionDeCliente_Enter(object sender, EventArgs e)
        {
            limpiar();
            if (this.textBoxTipoForm.Text == "1") {
                this.groupBox1.Visible = true;
                this.textDni.Text = this.textBoxDniCompra.Text;
                this.botonBuscar.PerformClick();
                this.groupBox1.Visible = false;  
            }
        }
        private void setearParaCompras()
        {
            Form anterior = funcionesComunes.getVentanaAnterior();
            string id = dataGridListadoClientes.SelectedCells[0].Value.ToString();
            ((TextBox)anterior.Controls["textBoxIdCliente"]).Text = id;
        }
    }
}
