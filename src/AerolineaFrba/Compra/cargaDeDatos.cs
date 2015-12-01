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
        Double cantidadKg = 0;
        Double kgAcumulados=0;
        Double precioBasePasaje;
        Double precioBaseKg;
        string fechaSalida;
        string fechaLlegada;
        string origen;
        string destino;

        public cargaDeDatos(string fechaS,string fechaL,string origen,string destino,string cantPas, string idVuelo, string kgEncom)
        {
            InitializeComponent();
            this.origen = origen;
            this.fechaSalida = fechaS;
            this.fechaLlegada = fechaL;
            this.destino = destino;
            textBoxCantPasajes.Text = cantPas;
            textBoxIDVuelo.Text = idVuelo;
            textBoxKgEncomiendas.Text = kgEncom;
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
                if (funcionesComunes.containsAdmin())
                {
                    Form tipoPago = new Compra.formaDePago(this.dataGridPasaje,this.dataGridEnco,this.fechaSalida,this.origen,this.destino);
                    ((TextBox)tipoPago.Controls["textBoxIDVuelo"]).Text = idVuelo;
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(tipoPago);
                }
                else
                {
                    Form porTarjeta = new Compra.registrarPagoTarjeta(this.dataGridPasaje,this.dataGridEnco,this.fechaSalida,this.origen,this.destino);
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
                            this.timePickerNacimiento.Text = ((DateTime)row["Fecha de Nacimiento"]).ToShortDateString();
                            this.textBoxDniPas.Enabled = false;

                            if (viajaEnOtroVuelo())
                            {
                                limpiarDatosPasajero();
                            }
               
                        }
                        
                    }else{
                        DialogResult dialogResult = MessageBox.Show("Debe dar de alta el cliente con ese DNI, ¿esta seguro?", "Dni de Cliente Inexistente", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes){
                            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente(2,"Alta de Cliente",dni);
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
            if (this.textBoxIdCliente.Text != "")
                this.setCliente();
            this.cantidadKg = Double.Parse(this.textBoxKgEncomiendas.Text);
            this.resetearComboBox();
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
            this.textBoxDniPas.Enabled = false;
        }

        private void butonDesElegir_Click(object sender, EventArgs e)
        {
            this.limpiarDatosPasajero();
        }


        private void limpiarDatosPasajero()
        {
            this.textBoxDniPas.Clear();
            this.textBoxIdCliente.Clear();
            this.textBoxDniPas.Enabled = true;
            this.textBoxApellido.Text = "";
            this.textBoxDireccion.Text = "";
            this.textBoxMail.Text = "";
            this.textBoxNombre.Text = "";
            this.textBoxTelefono.Text = "";
            this.timePickerNacimiento.Text = "";
        }

        private void settearUbicacion(object sender, EventArgs e)
        {
            DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT b.TIPO as tipo
               FROM " + SqlConnector.getSchema() + @".butacas_por_vuelo bxv join " + SqlConnector.getSchema() + @".butacas b on b.ID = bxv.BUTACA_ID 
                where bxv.VUELO_ID = " + this.textBoxIDVuelo.Text + "AND b.ID = "+ comboBoxNumeroButaca.SelectedValue.ToString());
            this.textBoxUbicacion.Text= tabla.Rows[0].ItemArray[0].ToString();
        }

        private void botonCargarPas_Click(object sender, EventArgs e)
        {
            if (validarCargaPasaje()){
                this.cargarPasaje();
               
            }else{
                MessageBox.Show("Debe completar los campos requeridos");
            }
        }

        private void cargarPasaje()
        {
            /*le agrego 1 porque si es = no te deberia dejar agregar otro pasaje*/
            if (dataGridPasaje.Rows.Count +1 <= Convert.ToInt32(textBoxCantPasajes.Text))
            {
                if (!existeButacaCargada())
                {
                    if (!existePasajeroCargado())
                    {
                        int index = this.dataGridPasaje.Rows.Add(1);
                        this.dataGridPasaje.Rows[index].Selected = true;
                        this.dataGridPasaje.SelectedCells[0].Value = this.textBoxIdCliente.Text;
                        this.dataGridPasaje.SelectedCells[1].Value = this.textBoxNombre.Text;
                        this.dataGridPasaje.SelectedCells[2].Value = this.textBoxApellido.Text;
                        this.dataGridPasaje.SelectedCells[3].Value = this.textBoxDniPas.Text;
                        this.dataGridPasaje.SelectedCells[4].Value = this.comboBoxNumeroButaca.Text;
                        this.dataGridPasaje.SelectedCells[5].Value = this.textBoxUbicacion.Text;
                        this.dataGridPasaje.SelectedCells[6].Value = this.precioBasePasaje;
                        this.dataGridPasaje.SelectedCells[7].Value = this.textBoxTelefono.Text;
                        this.dataGridPasaje.SelectedCells[8].Value = this.textBoxDireccion.Text;
                        this.dataGridPasaje.SelectedCells[9].Value = this.textBoxMail.Text;
                        this.dataGridPasaje.SelectedCells[10].Value = this.timePickerNacimiento.Text;
                        this.dataGridPasaje.SelectedCells[11].Value = this.comboBoxNumeroButaca.SelectedValue;
                        MessageBox.Show("Cantidad de pasajes restantes " + (Int32.Parse(this.textBoxCantPasajes.Text) - this.dataGridPasaje.Rows.Count));
                        this.limpiarPasaje();
                    }
                    else
                    {
                        MessageBox.Show("El pasajero ya fue ingresado, no puede cargarse de nuevo");
                        this.limpiarPasaje();
                    }
                }
                else
                {
                    MessageBox.Show("La butaca elegida ya fue cargada, elija otra");
                    this.resetearComboBox();
                }
            }
            else
            {
                MessageBox.Show("No se pueden comprar mas pasajes de los seleccionados");
                limpiarPasaje();
            }
        }

        private bool existeButacaCargada()
        {
            foreach(DataGridViewRow row in this.dataGridPasaje.Rows){
                if (this.comboBoxNumeroButaca.Text.Equals(row.Cells[4].Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private bool existePasajeroCargado()
        {
            foreach (DataGridViewRow row in this.dataGridPasaje.Rows)
            {
                if (this.textBoxIdCliente.Text.Equals(row.Cells[0].Value.ToString()))
                {
                    return true;
                }
            }
            return false;
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
                b.NUMERO FROM " + SqlConnector.getSchema() + @".butacas_por_vuelo bxv join " + SqlConnector.getSchema() + @".butacas b on b.ID = bxv.BUTACA_ID 
                where bxv.VUELO_ID = " + this.textBoxIDVuelo.Text + @"AND bxv.ESTADO = 'LIBRE' 
                order by 2");
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

        private bool viajaEnOtroVuelo()
        {
            DataTable otrosVuelosEnMismoHorario = SqlConnector.obtenerTablaSegunConsultaString(@"select * from " + SqlConnector.getSchema() +
            @".pasajes p inner join " + SqlConnector.getSchema() + @".vuelos v on p.VUELO_ID = v.ID where 
            p.INVALIDO = 0 and p.CANCELACION_ID IS NULL and p.CLIENTE_ID =" + Int32.Parse(this.textBoxIdCliente.Text) + @" and 
            (v.FECHA_SALIDA  >= convert(datetime, '" + fechaSalida + @"',109) and (v.FECHA_SALIDA <=
            convert(datetime, '" + fechaLlegada + @"',109)) or v.FECHA_LLEGADA >=
            convert(datetime, '" + fechaSalida + @"',109) and v.FECHA_LLEGADA <= convert(datetime, '" +
            fechaLlegada + @"',109) or v.FECHA_LLEGADA_ESTIMADA >= 
            convert(datetime, '" + fechaSalida + @"',109) and v.FECHA_LLEGADA_ESTIMADA <= convert(datetime, '" +
            fechaLlegada + @"',109))");
            if (otrosVuelosEnMismoHorario.Rows.Count > 0)
            {
                MessageBox.Show("El pasajero ya tiene asignado otro vuelo en el mismo horario");
                return true;
            }
            return false;
        }

        private bool seleccionButaca()
        {
            if (this.comboBoxNumeroButaca.SelectedValue != null)
                return this.comboBoxNumeroButaca.SelectedValue.ToString() != "";
            return false;
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
                 r.PRECIO_BASE_PASAJE,t.PORCENTAJE FROM " + SqlConnector.getSchema() + @".vuelos v 
                join " + SqlConnector.getSchema() + @".rutas r on r.ID = v.RUTA_ID
                join " + SqlConnector.getSchema() + @".servicios_por_ruta servxruta on servxruta.RUTAS_ID = r.ID 
                join " + SqlConnector.getSchema() + @".tipos_de_servicio t on t.ID= servxruta.TIPOS_DE_SERVICIO_ID
                WHERE v.ID = " + this.textBoxIDVuelo.Text);
            Double porcentaje = Double.Parse(tabla.Rows[0].ItemArray[2].ToString());
            precioBaseKg = Double.Parse(tabla.Rows[0].ItemArray[0].ToString());
            precioBaseKg = precioBaseKg + (precioBaseKg * porcentaje);
            precioBasePasaje = Double.Parse(tabla.Rows[0].ItemArray[1].ToString());
            precioBasePasaje = precioBasePasaje + (precioBasePasaje * porcentaje);
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
                this.dataGridPasaje.Rows.Remove(this.dataGridPasaje.SelectedRows[0]);
                MessageBox.Show("Cantidad de pasajes restantes " + (Int32.Parse(this.textBoxCantPasajes.Text) - this.dataGridPasaje.Rows.Count));
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

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (this.textBoxIdCliente.Text != "")
            {
                string id = this.textBoxIdCliente.Text;
                string nombre = this.textBoxNombre.Text;
                string apellido = this.textBoxApellido.Text;
                string dni = this.textBoxDniPas.Text;
                string direccion = this.textBoxDireccion.Text;
                string telefono = this.textBoxTelefono.Text;
                string mail = this.textBoxMail.Text;
                DateTime fecha = Convert.ToDateTime(timePickerNacimiento.Text);
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
