using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba;

namespace AerolineaFrba.Ingreso
{
    public partial class Ingreso : Form
    {
     
        public Ingreso()
        {
            InitializeComponent();
            setearIdRolCliente();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            //Validar campos ingresados y buscar en la BD
            //Si valida correctamente ingresa
            //Apertura formulario menu para administrador
           
                String contr = "";
                int activo = -1;
                int intentos = -1;
                String nombreRol = " ";
                Int32 idRol;
                DataTable usuario = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT u.PASSWORD, u.ACTIVO, u.INTENTOS_LOGIN, r.NOMBRE, r.ID from " + SqlConnector.getSchema() + @".usuarios u, 
                " + SqlConnector.getSchema() + @".roles_por_usuario ru, " + SqlConnector.getSchema() + @".roles r where u.USERNAME = '" + this.textUsuario.Text + 
                @"' AND r.ID = ru.ROL_ID and ru.USUARIO_ID = u.ID");
               
                if (usuario.Rows.Count > 0 && existeAdministrador(usuario)) {
                        contr = (String)usuario.Rows[0].ItemArray[0];
                        activo = (int)usuario.Rows[0].ItemArray[1];
                        intentos = (int)usuario.Rows[0].ItemArray[2];
                        nombreRol = (String)usuario.Rows[0].ItemArray[3];
                        idRol = (Int32)usuario.Rows[0].ItemArray[4];
                    if (activo == 1) {
                        if (contr == Base.pasarASha256(this.textPassword.Text)) {
                            SqlConnector.executeProcedure(SqlConnector.getSchema() + @".updateIntento",
                                funcionesComunes.generarListaParaProcedure("@nombre", "@exitoso"), 
                                this.textUsuario.Text, 1);
                            menuPrincipal menu = new menuPrincipal(this.textUsuario.Text);
                            funcionesComunes.setRol(crearListaRoles(usuario));
                            funcionesComunes.deshabilitarVentanaYAbrirNueva(menu);
                        }else{
                            SqlConnector.executeProcedure(SqlConnector.getSchema() + @"updateIntento",
                                funcionesComunes.generarListaParaProcedure("@nombre", "@exitoso"), this.textUsuario.Text, 2);
                            MessageBox.Show("Contraseña inválida, le quedan " + (2 - intentos) + " intentos"); 
                        }
                    }else{
                        MessageBox.Show("El usuario ingresado esta inhabilitado, contacte al administrador");
                    }
                }else{
                    MessageBox.Show("Usuario inválido");
                }
                this.textUsuario.Clear();
                this.textPassword.Clear();
        }

        private void botonInvitado_Click(object sender, EventArgs e)
        {
            //Apertura formulario menu para invitado
            this.botonLimpiar.PerformClick();
            List<String> cliente_rol = new List<String>();
            cliente_rol.Add("Cliente");
            funcionesComunes.setRol(cliente_rol);
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new menuPrincipal());
        } 

        //este boton borra el contenido de los input
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textUsuario.Clear();
            this.textPassword.Clear();
        }

        private void setearIdRolCliente()
        {
            DataTable cliente = SqlConnector.obtenerTablaSegunConsultaString(@"select ID from " + SqlConnector.getSchema() + @".roles where NOMBRE = 'cliente'");
            if (cliente.Rows.Count > 0){
                funcionesComunes.setIdRolCliente((Int32)cliente.Rows[0].ItemArray[0]);
            }else{
                MessageBox.Show("El rol de cliente no puede ser seteado");
            }
        }
        private bool existeAdministrador(DataTable usuario)
        {
            foreach (DataRow row in usuario.Rows)
            {
                if (row[3].ToString().Equals( "Administrador"))
                {
                    return true;
                }
            }
            return false;
        }

        private List<String> crearListaRoles(DataTable tabla)
        {
            List<String> roles = new List<String>();
            foreach (DataRow row in tabla.Rows)
            {
                roles.Add(row[3].ToString());
            }
            return roles;

        }
        
    }
}
