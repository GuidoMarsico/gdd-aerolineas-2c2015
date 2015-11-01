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
        Double cantidadKg = 0;
        Double kgAcumulados=0;
        Double precioBasePasaje;
        Double precioBaseKg;

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
            if (!this.compraInvalida())
            {
                this.validoComprar();
            }
        }

        private bool compraInvalida()
        {
            if (this.textBoxCantPasajes.Text != "0" && this.dataGridPasaje.RowCount < Int32.Parse(this.textBoxCantPasajes.Text))
            {
                MessageBox.Show("Debe cargar " + this.textBoxCantPasajes.Text + " pasajes para poder seguir con la siguiente etapa de compra");
                return true;
            }
            if (this.textBoxKgEncomiendas.Text != "0" && this.kgAcumulados < this.cantidadKg) 
            {
                MessageBox.Show("Debe cargar " + this.textBoxKgEncomiendas.Text + " kg en encomiendas y solo cargo "+ this.kgAcumulados.ToString()+" kg");
                return true;
            }
            return false;
        }
        private void validoComprar() 
        {
            //Abre formulario segun sea el rol

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que quiere realizar la compra?", "Realizar Compra", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                   
                string idVuelo = this.textBoxIDVuelo.Text;
                if (funcionesComunes.getRol() == "administrador")
                {
                    Form tipoPago = new Compra.formaDePago(this.dataGridPasaje,this.dataGridEnco);
                    ((TextBox)tipoPago.Controls["textBoxIDVuelo"]).Text = idVuelo;
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(tipoPago);
                }
                else
                {
                    Form porTarjeta = new Compra.registrarPagoTarjeta(this.dataGridPasaje,this.dataGridEnco);
                    ((TextBox)porTarjeta.Controls["textBoxIDVuelo"]).Text = idVuelo;
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(porTarjeta);
                }
            }
            this.limpiarDatos();
        }

        private void limpiarDatos()
        {
            this.limpiarDatosPasajero();
            this.limpiarEncomienda();
            this.limpiarEncomienda();
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
            if (dni != ""){
                if (dni.Length >= 6){
                    if (funcionesComunes.validarDni(dni)){
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
                        
                    }else{
                        DialogResult dialogResult = MessageBox.Show("Debe dar de alta el cliente con ese DNI, ¿esta seguro?", "Dni de Cliente Inexistente", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes){
                            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
                            int valor = 1;
                            ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = valor.ToString();
                            altaDeCliente.Text = "Alta de Cliente";
                            ((TextBox)altaDeCliente.Controls["textBoxDNI"]).Text = dni;
                            ((TextBox)altaDeCliente.Controls["textBoxDNI"]).ReadOnly = true;
                            funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);
                        }
                    }
                }else
                    MessageBox.Show("Numero de documento invalido, debe poseer al menos 6 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void cargaDeDatos_Enter(object sender, EventArgs e)
        {   
            // Si no eligio ninguna cantidad de pasajes a comprar
            if (this.textBoxCantPasajes.Text == "0") {
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                this.botonLimpiarPas.Enabled = false;
                this.botonEliminarPasaje.Enabled = false;
                this.botonCargarPas.Enabled = false;
                this.dataGridPasaje.Enabled = false;
                this.comboBoxNumeroButaca.Enabled = false;
            }
            //Si no eligio ninguna cantidad de kg a enviar
            if (this.textBoxKgEncomiendas.Text == "0") {
                groupBox5.Enabled = false;
                this.botonCargarEnco.Enabled = false;
                this.botonEliminarEnco.Enabled = false;
                this.botonLimpiarEnco.Enabled = false;
                this.dataGridEnco.Enabled = false;
                
            }
            if (this.textBoxIdCliente.Text != "" && this.textBoxIdCliente.Text != "0")
                this.cargarDatosPasajero();
            if (this.textBoxIdCliente.Text == "0")
                this.textBoxDniPas.Enabled = false;
            this.cantidadPasajes = Int32.Parse(this.textBoxCantPasajes.Text);
            this.cantidadKg = Double.Parse(this.textBoxKgEncomiendas.Text);
            this.resetearComboBox();
        }

        private void cargarDatosPasajero()
        {
            DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                         NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                         TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                         from AERO.clientes where BAJA = 0 AND  ID = "+this.textBoxIdCliente.Text);
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

        private void butonDesElegir_Click(object sender, EventArgs e)
        {
            this.limpiarDatosPasajero();
        }


        private void limpiarDatosPasajero()
        {
            this.textBoxDniPas.Clear();
            this.textBoxDniPas.Enabled = true;
            this.textBoxApellido.Clear();
            this.textBoxDireccion.Clear();
            this.textBoxMail.Clear();
            this.textBoxNombre.Clear();
            this.textBoxTelefono.Clear();
            this.timePickerNacimiento.ResetText();
        }

        private void settearUbicacion(object sender, EventArgs e)
        {
            DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT b.TIPO as tipo
               FROM AERO.butacas_por_vuelo bxv join AERO.butacas b on b.ID = bxv.BUTACA_ID 
                where bxv.VUELO_ID = " + this.textBoxIDVuelo.Text + "AND b.ID = "+ comboBoxNumeroButaca.SelectedValue.ToString());
            this.textBoxUbicacion.Text= tabla.Rows[0].ItemArray[0].ToString();
        }

        private void botonCargarPas_Click(object sender, EventArgs e)
        {
            if (validarCargaPasaje()){
                this.cargarPasaje();
                this.limpiarPasaje();
            }else{
                MessageBox.Show("Debe completar los campos requeridos");
            }
        }

        private void cargarPasaje()
        {
            if (dataGridPasaje.Rows.Count <= Convert.ToInt32(textBoxCantPasajes.Text))
            {
                int index = this.dataGridPasaje.Rows.Add(1);
                this.dataGridPasaje.Rows[index].Selected = true;
                this.dataGridPasaje.SelectedCells[0].Value = this.textBoxIdCliente.Text;
                this.dataGridPasaje.SelectedCells[1].Value = this.textBoxNombre.Text;
                this.dataGridPasaje.SelectedCells[2].Value = this.textBoxApellido.Text;
                this.dataGridPasaje.SelectedCells[3].Value = this.textBoxDniPas.Text;
                this.dataGridPasaje.SelectedCells[4].Value = this.comboBoxNumeroButaca.SelectedValue;
                this.dataGridPasaje.SelectedCells[5].Value = this.textBoxUbicacion.Text;
                this.dataGridPasaje.SelectedCells[6].Value = this.precioBasePasaje;
                this.dataGridPasaje.SelectedCells[7].Value = this.textBoxTelefono.Text;
                this.dataGridPasaje.SelectedCells[8].Value= this.textBoxDireccion.Text;
                this.dataGridPasaje.SelectedCells[9].Value=this.textBoxMail.Text;
                this.dataGridPasaje.SelectedCells[10].Value = this.timePickerNacimiento.Value.ToString();
                this.dataGridPasaje.SelectedCells[11].Value = this.comboBoxNumeroButaca.SelectedValue;
                this.cantidadPasajes = this.cantidadPasajes - 1;
                MessageBox.Show("Cantidad de pasajes restantes " + this.cantidadPasajes);
            }
            else
            {
                MessageBox.Show("No se pueden comprar mas pasajes de los seleccionados");
                limpiarPasaje();
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
            funcionesComunes.llenarCombobox(this.comboBoxNumeroButaca, "NUMERO", @"SELECT b.ID,
                b.NUMERO FROM AERO.butacas_por_vuelo bxv join AERO.butacas b on b.ID = bxv.BUTACA_ID 
                where bxv.VUELO_ID = " + this.textBoxIDVuelo.Text + "AND bxv.ESTADO = 'LIBRE'");
            this.textBoxUbicacion.Clear();
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
            return this.comboBoxNumeroButaca.SelectedValue.ToString() != "";
        }

        private bool ingresoPasajero()
        {
            return this.textBoxIdCliente.Text != "";
        }

        private void botonCargarEnco_Click(object sender, EventArgs e)
        {
            if (validarCargaEncomienda()){
                this.cargarEncomienda();
                this.limpiarEncomienda();
            }
        }

        private void buscarPreciosDeRuta()
        {
            DataTable tabla = new DataTable();
            tabla = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT r.PRECIO_BASE_KG, 
                r.PRECIO_BASE_PASAJE FROM AERO.vuelos v join AERO.rutas r on r.ID = v.RUTA_ID WHERE 
                v.ID = " + this.textBoxIDVuelo.Text);
            precioBaseKg = Double.Parse(tabla.Rows[0].ItemArray[0].ToString());
            precioBasePasaje = Double.Parse(tabla.Rows[0].ItemArray[1].ToString());
        }

        private void cargarEncomienda()
        {
            int index= this.dataGridEnco.Rows.Add(1);
            this.dataGridEnco.Rows[index].Selected = true;
            this.dataGridEnco.SelectedCells[4].Value = this.textBoxKg.Text;
            this.dataGridEnco.SelectedCells[5].Value = this.precioBaseKg * Double.Parse(this.textBoxKg.Text);
            this.kgAcumulados = this.kgAcumulados + Double.Parse(this.textBoxKg.Text);
            Double disponible = this.cantidadKg - this.kgAcumulados;
            MessageBox.Show("Cantidad restante para enviar " + disponible);
        }

        private void limpiarEncomienda()
        {
            this.textBoxKg.Text = "";
        }

        private bool validarCargaEncomienda()
        {
            if (!seleccionKg())
                return false;
            return true;
        }

        private bool seleccionKg()
        {
            if (this.textBoxKg.Text == "") {
                MessageBox.Show("Debe ingresar una cantidad de Kg a enviar via encomienda");
                return false;
            }
            Double cantidadElegida = Double.Parse(this.textBoxKg.Text);
            Double disponible = this.cantidadKg - this.kgAcumulados;
            if(cantidadElegida > disponible){
                MessageBox.Show("No puede enviar mas de " + disponible + " Kg");
                return false;
            }
            return true;
        }

        private void botonEliminarEnco_Click(object sender, EventArgs e)
        {
            if (this.dataGridEnco.Rows.Count > 0){
                this.kgAcumulados = this.kgAcumulados - Double.Parse(this.dataGridEnco.SelectedCells[4].Value.ToString());
                Double disponible = this.cantidadKg - this.kgAcumulados;
                MessageBox.Show("Cantidad restante para enviar " + disponible);
                this.dataGridEnco.Rows.Remove(this.dataGridEnco.SelectedRows[0]); 
            }else{
                MessageBox.Show("Tabla vacia, no hay nada que eliminar");
            }
        }

        private void validadorInput(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxKg, e);
        }

        private void botonEliminarPasaje_Click(object sender, EventArgs e)
        {
            if (this.dataGridPasaje.Rows.Count > 0){
                this.cantidadPasajes = this.cantidadPasajes + 1;
                MessageBox.Show("Cantidad de pasajes restantes " + this.cantidadPasajes);
                this.dataGridPasaje.Rows.Remove(this.dataGridPasaje.SelectedRows[0]);
            }else{
                MessageBox.Show("Tabla vacia, no hay nada que eliminar");
            }
        }

        private void botonLimpiarPas_Click(object sender, EventArgs e)
        {
            this.textBoxUbicacion.Clear();
            this.comboBoxNumeroButaca.SelectedIndex = -1;
        }

        private void botonLimpiarEnco_Click(object sender, EventArgs e)
        {
            this.textBoxKg.Clear();
        }

        private void cargar(object sender, EventArgs e)
        {
            this.buscarPreciosDeRuta();
        }
    }

}
