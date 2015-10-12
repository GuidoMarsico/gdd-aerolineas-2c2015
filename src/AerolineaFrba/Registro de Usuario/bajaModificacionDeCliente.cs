﻿using System;
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
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeCliente_Load(object sender, EventArgs e)
        {
            consultarClientes();
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
            consultarClientes();
            textNombre.Text = "";
            textApellido.Text = "";
            textMail.Text = "";
            textDni.Text = "";
            textTelefono.Text = "";
            textDireccion.Text = "";
        }

        private void consultarClientes()
        {
            listado = SqlConnector.obtenerTablaSegunConsultaString("select ID as Id,NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' from AERO.clientes where BAJA = 0");
            dataGridListadoClientes.DataSource = listado;
            dataGridListadoClientes.Columns[0].Visible = false;
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            Form modificarCliente = new Registro_de_Usuario.altaModificacionDeCliente();
            int valor = 1;
            ((Label)modificarCliente.Controls["campoRequeridoApellido"]).Visible= false;
            ((Label)modificarCliente.Controls["campoRequeridoNombre"]).Visible = false;
            ((Label)modificarCliente.Controls["campoRequeridoDNI"]).Visible = false;
            ((Label)modificarCliente.Controls["campoRequeridoNacimiento"]).Visible = false;
            ((TextBox)modificarCliente.Controls["textBoxTipoForm"]).Text = valor.ToString();
            ((TextBox)modificarCliente.Controls["textBoxId"]).Text = dataGridListadoClientes.SelectedCells[0].Value.ToString();
            ((TextBox)modificarCliente.Controls["textBoxNombre"]).Text = dataGridListadoClientes.SelectedCells[1].Value.ToString();
            ((TextBox)modificarCliente.Controls["textBoxApellido"]).Text = dataGridListadoClientes.SelectedCells[2].Value.ToString();
            ((TextBox)modificarCliente.Controls["textBoxDni"]).Text = dataGridListadoClientes.SelectedCells[3].Value.ToString();
            ((TextBox)modificarCliente.Controls["textBoxDireccion"]).Text = dataGridListadoClientes.SelectedCells[4].Value.ToString();
            ((TextBox)modificarCliente.Controls["textBoxTelefono"]).Text = dataGridListadoClientes.SelectedCells[5].Value.ToString();
            ((TextBox)modificarCliente.Controls["textBoxMail"]).Text = dataGridListadoClientes.SelectedCells[6].Value.ToString();
            ((DateTimePicker)modificarCliente.Controls["TimePickerNacimiento"]).Value = Convert.ToDateTime(dataGridListadoClientes.SelectedCells[7].Value.ToString());
            modificarCliente.Text = "Modificación de Cliente";
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificarCliente);
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add("@id");
            bool resultado = SqlConnector.executeProcedure("AERO.bajaCliente", lista, dataGridListadoClientes.SelectedCells[0].Value.ToString());
            if (resultado)
            {
                MessageBox.Show("El cliente se dio de baja exitosamente");
            }
            consultarClientes();
        }


        private void bajaModificacionDeCliente_Enter(object sender, EventArgs e)
        {
            limpiar();
        }

    }
}
