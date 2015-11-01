﻿using System;
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
        public registrarPagoEfectivo(DataGridView tablaPasajes,DataGridView tablaEncomiendas)
        {
            InitializeComponent();
            this.pasajes = tablaPasajes;
            this.encomiendas = tablaEncomiendas;
            this.calcularImporte();
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
            if (idCliente == 0) ;
                //dar de alta al comprador
            Int32 idVuelo = Int32.Parse(this.textBoxIDVuelo.Text);
            String idBoleto = funcionesComunes.crearBoleto(this.pasajes, this.encomiendas,precio , "EFECTIVO",idCliente,idVuelo);
            // Me devuelvo el id del boleto que es el codigo de compra como quedamos y se lo mandamos a la siguiente vista para mostrarlo
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso());
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
        }

   
    }
}
