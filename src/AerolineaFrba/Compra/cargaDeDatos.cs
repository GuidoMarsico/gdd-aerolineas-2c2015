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
    public partial class cargaDeDatos : Form
    {
        Int32 cantidadPasajes = 0;
        Int32 cantidadKg = 0;
        Int32 kgAcumulados=0;

        public cargaDeDatos()
        {
            InitializeComponent();
            
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            //Abre formulario segun sea el rol
            if (funcionesComunes.getRol() == "administrador")
            {
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.formaDePago());
            }else{
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.registrarPagoTarjeta());
            }

        }

        private void valida(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.consultarContactos();
           
        }
        private void consultarContactos()
        {
            String dni = this.textBoxDniPas.Text;
            if (dni != "")
            {
                if (dni.Length >= 7)
                {
                    if (validarDni(dni))
                    {
                        //TODO Hacer que mueste un nueva vista tal vez con los resultados de clientes con ese dni para elegir uno 
                        Form listadoClientes = new Registro_de_Usuario.bajaModificacionDeCliente();
                        int valor = 1;
                       
                        ((TextBox)listadoClientes.Controls["textBoxTipoForm"]).Text = valor.ToString();
                        ((TextBox)listadoClientes.Controls["textBoxDniCompra"]).Text = dni;
                        funcionesComunes.deshabilitarVentanaYAbrirNueva(listadoClientes);
                    }
                    else
                    {
                        MessageBox.Show("Dni de cliente inexistente, debe darlo de alta para poder seguir con las operaciones");

                        Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
                        int valor = 1;
                        ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = valor.ToString();
                        altaDeCliente.Text = "Alta de Cliente";
                        ((TextBox)altaDeCliente.Controls["textBoxDNI"]).Text = dni;
                        ((TextBox)altaDeCliente.Controls["textBoxDNI"]).ReadOnly = true;
                        funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);
                    }
                }
                else
                    MessageBox.Show("Numero de documento invalido debe poseer al menos 7 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarDni(string dni)
        {
            DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                from AERO.clientes where BAJA = 0 AND DNI = "+ dni);
            return tablaClientes.Rows.Count != 0; 
        }

        private void cargaDeDatos_Enter(object sender, EventArgs e)
        {   
            // Si no eligio ninguna cantidad de pasajes a comprar
            if (this.textBoxTipoForm.Text == "0") {
                groupBox3.Enabled = false;
                this.botonLimpiarPas.Enabled = false;
                this.botonEliminarPasaje.Enabled = false;
                this.botonCargarPas.Enabled = false;
                this.dataGridPasaje.Enabled = false;
                this.comboBoxNumeroButaca.Enabled = false;
            }
            //Si no eligio ninguna cantidad de kg a enviar
            if (this.textBox1.Text == "0") {
                groupBox5.Enabled = false;
                this.botonCargarEnco.Enabled = false;
                this.botonEliminarEnco.Enabled = false;
                this.botonLimpiarEnco.Enabled = false;
                this.dataGridEnco.Enabled = false;
                
            }
            if (this.textBoxNombrePas.Text != "")
                this.textBoxDniPas.Enabled = false;
            this.cantidadPasajes = Int32.Parse(this.textBoxTipoForm.Text);
            this.cantidadKg = Int32.Parse(this.textBox1.Text);
        }

        private void butonDesElegir_Click(object sender, EventArgs e)
        {
            this.limpiarDatosPasajero();
        }

        private void limpiarDatosPasajero()
        {
            this.textBoxDniPas.Clear();
            this.textBoxDniPas.Enabled = true;
            this.textBoxApellidoPas.Clear();
            this.textBoxDireccionPas.Clear();
            this.textBoxMailPas.Clear();
            this.textBoxNombrePas.Clear();
            this.textBoxTelefonoPas.Clear();
            this.timePickerFecha.ResetText();
        }

        private void settearUbicacion(object sender, EventArgs e)
        {
            DataGridView tabla = new DataGridView();
            tabla.DataSource = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT b.TIPO as Tipo
                                         FROM AERO.butacas b where b.ID = " + this.comboBoxNumeroButaca.SelectedValue);
            this.textBoxUbicacion.Text = tabla.SelectedCells[0].Value.ToString();
        }

        private void botonCargarPas_Click(object sender, EventArgs e)
        {
            if (validarCargaPasaje())
            {
                MessageBox.Show(" Carga valida de pasaje");
                this.limpiarPasaje();
            }
            else
            {
                MessageBox.Show(" Carga invalida de pasaje");
            }
        }

        private void limpiarPasaje()
        {
            this.limpiarDatosPasajero();
            this.resetearComboBox();
        }

        private void resetearComboBox()
        {
            this.comboBoxNumeroButaca.DataSource = null;
            funcionesComunes.llenarCombobox(this.comboBoxNumeroButaca, "NUMERO", @"SELECT b.ID,b.NUMERO FROM AERO.butacas_por_vuelo bxv
            join AERO.butacas b on b.ID = bxv.BUTACA_ID where bxv.VUELO_ID = " + this.textBoxIDVuelo.Text + "AND bxv.ESTADO = 'LIBRE'");
        }

        private bool validarCargaPasaje()
        {
            if(!ingresoPasajero())
                return false;

            if (!seleccionButaca())
                return false;
            return true;
        }

        private bool seleccionButaca()
        {
            return this.comboBoxNumeroButaca.SelectedText != "";
        }

        private bool ingresoPasajero()
        {
            return this.textBoxIdCliente.Text != "";
        }

        private void botonCargarEnco_Click(object sender, EventArgs e)
        {
            if (validarCargaEncomienda())
            {
                MessageBox.Show("Carga valida encomienda");
                this.cargarEncomienda();
                this.limpiarEncomienda();
            }
            else
            {
                MessageBox.Show(" Carga invalida encomienda");
            }
        }

        private void cargarEncomienda()
        {
            this.dataGridEnco.Rows.Add(1);
            this.dataGridEnco.SelectedCells[0].Value = this.textBoxNombrePas.Text;
            MessageBox.Show(this.dataGridEnco.Columns.Count.ToString());
            //Si lo descomentan alguno tira error que supero el intervalo 
            //this.dataGridEnco.SelectedCells[1].Value =this.textBoxIdCliente.Text;
            //this.dataGridEnco.SelectedCells[2].Value = this.textBoxIdCliente.Text;
            //this.dataGridEnco.SelectedCells[3].Value = this.textBoxIdCliente;
            //this.dataGridEnco.SelectedCells[4].Value = this.textBoxIdCliente;
            // this.dataGridEnco.SelectedCells[5].Value = this.textBoxIdCliente;
            // this.dataGridEnco.SelectedCells[6].Value = this.textBoxIdCliente;
            // this.dataGridEnco.SelectedCells[7].Value = this.textBoxIdCliente;
            // this.dataGridEnco.SelectedCells[8].Value = this.textBoxIdCliente;
            // this.dataGridEnco.SelectedCells[9].Value = this.textBoxIdCliente;
            this.kgAcumulados = this.kgAcumulados + Int32.Parse(this.textBoxKg.Text);
            Int32 disponible = this.cantidadKg - this.kgAcumulados;
            MessageBox.Show("Cantidad Restante para enviar " + disponible);
        }

        private void limpiarEncomienda()
        {
            this.limpiarDatosPasajero();
            this.textBoxIdCliente.Text = "";
            this.textBoxKg.Text = "";
        }

        private bool validarCargaEncomienda()
        {
            if (!ingresoPasajero())
                return false;

            if (!seleccionKg())
                return false;
            return true;
        }

        private bool seleccionKg()
        {
            if (this.textBoxKg.Text == "") {
                MessageBox.Show("Debe ingresar una cantidad de Kg a enviar");
                return false;
            }
            Int32 cantidadElegida = Int32.Parse(this.textBoxKg.Text);
            Int32 disponible = this.cantidadKg - this.kgAcumulados;
            if(cantidadElegida > disponible){
                MessageBox.Show("No puede enviar mas de " + disponible + " Kg");
                return false;
            }
            return true;
        }       
    }

}
