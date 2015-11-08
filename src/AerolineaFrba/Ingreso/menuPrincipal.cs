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
using System.Data.SqlClient;

namespace AerolineaFrba.Ingreso
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {
            InitializeComponent();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            //Habria que cargar la lista de funcionalidades de la DB antes de hacer esto
            //Solucion provisoria
            String eleccionUsuario = (String)comboBoxFuncionalidad.SelectedItem;
            if (eleccionUsuario != null)
                abrirFormulario(eleccionUsuario);
            else MessageBox.Show("Seleccione funcionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Abre formulario segun funcionalidad elegida en combobox
        private void abrirFormulario(String eleccionUsuario)
        {
            switch (eleccionUsuario)
            {
                case "Consultar Millas":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Consulta_Millas.consultaMillas());
                    break;
                case "Alta de Cliente":
                    Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
                    int valor = 0;
                    ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = valor.ToString() ;
                    altaDeCliente.Text = "Alta de Cliente";
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);
                    break;
                case "Alta de Aeronave":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.altaDeAeronave());
                    break;
                case "Alta de Tarjeta de Crédito":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Tarjeta.altaDeTarjeta());
                    break;
                case "Baja de Aeronave":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.bajaModificacionDeAeronave());
                    break;
                case "Baja de Ciudad":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ciudad.bajaModificacionDeCiudad());
                    break;
                case "Baja de Cliente":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_de_Usuario.bajaModificacionDeCliente());
                    break;
                case "Modificacion de Aeronave":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.bajaModificacionDeAeronave());
                    break;
                case "Modificacion de Cliente":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_de_Usuario.bajaModificacionDeCliente());
                    break;
                case "Realizar Canje":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Canje_Millas.realizarCanjeMillas());
                    break;
                case "Alta de Rol":
                    Form altaDeRol = new Abm_Rol.altaModificacionDeRol();
                    int val = 0;
                    ((TextBox)altaDeRol.Controls["textTipoForm"]).Text = val.ToString() ;
                    altaDeRol.Text = "Alta de Rol";
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeRol);
                    break;
                case "Baja de Rol":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Rol.bajaModificacionDeRol());
                    break;
                case "Modificacion de Rol":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Rol.bajaModificacionDeRol());
                    break;
                case "Alta de Ruta":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.altaDeRuta());
                    break;
                case "Baja de Ruta":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.bajaModificacionDeRuta());
                    break;
                case "Modificacion de Ruta":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.bajaModificacionDeRuta());
                    break;
                case "Comprar Pasaje/Encomienda":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.viajesDisponibles());
                    break;
                case "Generar Viaje":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Vuelos.generarViaje());
                    break;
                case "Registrar Llegadas":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_Llegada_Destino.registroDeLlegadaADestino());
                    break;
                case "Consultar Listado":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Listado_Estadistico.listadoEstadistico());
                    break;
                case "Cancelar Compra":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.cancelacionCompra());
                    break;
            }
            this.comboBoxFuncionalidad.SelectedIndex = -1;
        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            //Cuando no este harcodeado la podemos sacar la linea de abajo
            this.textRol.Text = funcionesComunes.getRol();
            //Carga las funcionalidades dependiendo del rol en el comboBox
            if (this.textRol.Text != "Administrador") {
                this.groupBox1.Text = " ";
                this.label2.Visible = false;
                this.textRol.Visible = false; 
            }

            DataTable dt = new DataTable();
            dt = SqlConnector.obtenerTablaSegunConsultaString(@"select funcionalidades.DETALLES from 
                aero.roles inner join aero.funcionalidades_por_rol on 
                roles.ID = funcionalidades_por_rol.ROL_ID inner join AERO.funcionalidades on 
                funcionalidades_por_rol.FUNCIONALIDAD_ID = funcionalidades.ID where 
                roles.NOMBRE = '" + funcionesComunes.getRol() + "'");
            foreach (DataRow row in dt.Rows)
            comboBoxFuncionalidad.Items.Add(row.ItemArray[0].ToString());
            comboBoxFuncionalidad.DisplayMember = "DETALLES";
            comboBoxFuncionalidad.SelectedIndex = 0;
        }
    }
}
