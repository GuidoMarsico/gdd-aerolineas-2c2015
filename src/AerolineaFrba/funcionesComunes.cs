using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace AerolineaFrba
{
    //creamos una clase con funciones que utilizan las demas para no repetir codigo
    class funcionesComunes
    {
        public static string fecha;

        #region Singletons Ventanas
        private static Form ventanaAnterior;
        private static Form ventanaActual;
        private static List<Form> listaVentanas = new List<Form>();
        private static int pos;

        //lo que hace esta funcion es setear cual es la ventana principal
        public static void ventanaInicial(Form ventanaInicial)
        {
            listaVentanas.Add(ventanaInicial);
            ventanaInicial.MdiParent = Principal.ActiveForm;
            ventanaInicial.Show();
        }

        //esta funcion abre una ventana nueva seteando la anterior para luego poder volver atras
        public static void deshabilitarVentanaYAbrirNueva(Form ventanaNueva)
        {
            pos = listaVentanas.Count();
            ventanaAnterior = listaVentanas[pos -1];
            ventanaAnterior.Hide();
            listaVentanas.Add(ventanaNueva);
            ventanaNueva.MdiParent = Principal.ActiveForm;
            ventanaNueva.Show();
        }


        //esta funcion permite volver a la ventana anterior
        public static void habilitarAnterior()
        {
            pos = listaVentanas.Count();
            if (pos > 0)
            {
                ventanaAnterior = listaVentanas[pos - 2];
                ventanaActual = listaVentanas[pos - 1];
                ventanaActual.Close();
                listaVentanas.RemoveAt(pos - 1);
                ventanaAnterior.Show();
            }
        }
        public static Form getVentanaAnterior() 
        {
            pos = listaVentanas.Count();
            return listaVentanas[pos-2];        
        }

        //esta funcion permite volver al menu principal
        public static void volverAMenuPrincipal()
        {
            pos = listaVentanas.Count();
            ventanaActual = listaVentanas[pos - 1];
            ventanaActual.Hide();
            while (pos > 2)
            {
                listaVentanas.RemoveAt(pos - 1);
                pos = pos - 1;
            }
            pos = listaVentanas.Count();
            ventanaActual = listaVentanas[pos - 1];
            ventanaActual.Show();
        }
        #endregion

        #region rol

        private static List<String> roles;
        private static Int32 idRol;
        public static void setRol(List<String> r)
        {
            roles = r;
        }
        public static String getRol()
        {
            String roles_parsed = "";
            String separador = "";
            foreach (String rol in roles)
            {
                roles_parsed += separador + rol;
                separador = "-";
            }
            return roles_parsed;
        }

        public static bool containsAdmin()
        {
            return roles.Contains("Administrador");            
        }

        public static Int32 getIdRolCliente()
        {
            return idRol;
        }

        public static void setIdRolCliente(Int32 id)
        {
            idRol = id;
        }


        #endregion

        #region llenado
        public static void llenarCombobox(ComboBox combo, String display, String query)
        {
            DataTable dt = new DataTable();
            dt = SqlConnector.obtenerTablaSegunConsultaString(query);
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.ValueMember = "ID";
            combo.DisplayMember = display;
            combo.SelectedIndex = -1;
        }

        public static void soloNumeros(KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        public static void soloPrecio(KeyPressEventArgs e)
        {   
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == ',') || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        public static void precioONumeros(TextBox textbox, KeyPressEventArgs e)
        {
            if (textbox.Text.Contains(','))
                funcionesComunes.soloNumeros(e);
            else
                funcionesComunes.soloPrecio(e);
        }

        public static void martricula(TextBox textbox, KeyPressEventArgs e)
        {
            if (textbox.Text.Contains('-'))
                funcionesComunes.soloNumeros(e);
            else
                funcionesComunes.soloMail(e);
        }

        public static void soloLetras(KeyPressEventArgs e)
        {
            if (!((char.IsLetter(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                 e.Handled = true;
            }
        }

        public static void soloMail(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        public static void soloLetrasYNumeros(KeyPressEventArgs e)
        {
            if (!((char.IsLetter(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space) || (char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

       

        #endregion

        #region consultas

        public static DataTable consultarRutas(DataGridView datagridview)
        {
            DataTable listadoRutas = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT r.ID as ID, r.CODIGO as Codigo, 
                r.PRECIO_BASE_KG as 'Precio Base Kg', r.PRECIO_BASE_PASAJE as 'Precio Base Pasaje', 
                c1.NOMBRE as Origen, c2.NOMBRE as Destino, t.NOMBRE as Servicio from " + SqlConnector.getSchema() + @".rutas r, 
                " + SqlConnector.getSchema() + @".ciudades c1, " + SqlConnector.getSchema() + @".ciudades c2, " +  
                 SqlConnector.getSchema() + @".servicios_por_ruta servxruta, " + SqlConnector.getSchema() + @".tipos_de_servicio t WHERE r.ORIGEN_ID = c1.ID AND 
                r.DESTINO_ID=c2.ID AND servxruta.RUTAS_ID = r.ID AND servxruta.TIPOS_DE_SERVICIO_ID = t.ID AND r.BAJA = 0 ");
            datagridview.DataSource = listadoRutas;
            datagridview.Columns[0].Visible = false;
            return listadoRutas;
        }

        public static DataTable consultarAeronaves(DataGridView datagridview)
        {
            DataTable listadoAeronaves = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT a.ID as Id, a.MATRICULA as Matricula, 
                a.MODELO as Modelo, a.KG_DISPONIBLES as 'KG Disponibles', f.NOMBRE as Fabricante, ts.NOMBRE as 
                Servicio, a.FECHA_ALTA as 'Fecha de Alta', a.CANT_BUTACAS as Butacas FROM " + SqlConnector.getSchema() + @".aeronaves a, 
                " + SqlConnector.getSchema() + @".fabricantes f, " + SqlConnector.getSchema() + @".tipos_de_servicio ts WHERE a.FABRICANTE_ID = f.ID AND 
                a.TIPO_SERVICIO_ID = ts.ID AND a.BAJA IS NULL;");
            datagridview.DataSource = listadoAeronaves;
            datagridview.Columns[0].Visible = false;
            return listadoAeronaves;
        }

        public static DataTable consultarVuelos()
        {
            DataTable listado = SqlConnector.obtenerTablaSegunConsultaString(@"select v.ID as ID,
                a.MATRICULA as Matricula,r.CODIGO as 'Codigo de Ruta', o.NOMBRE as Origen, d.NOMBRE 
                as Destino,v.FECHA_SALIDA as 'Fecha De Salida' from " + SqlConnector.getSchema() + @".vuelos v join 
                " + SqlConnector.getSchema() + @".aeronaves a on v.AERONAVE_ID = a.ID join " + SqlConnector.getSchema() + @".rutas r on v.RUTA_ID = r.ID join 
                " + SqlConnector.getSchema() + @".ciudades o on r.ORIGEN_ID = o.ID join " + SqlConnector.getSchema() + @".ciudades d on 
                r.DESTINO_ID = d.ID where v.FECHA_LLEGADA IS NULL AND v.INVALIDO = 0");
            return listado;
        }

        public static void consultarMillas(Int32 valor, DataGridView datagridview)
        {
            DataTable productos = SqlConnector.obtenerTablaSegunConsultaString(@"select p.ID as 
                    ID, p.NOMBRE as Producto, p.MILLAS_REQUERIDAS as Millas, p.STOCK as Stock from " + SqlConnector.getSchema() + @".productos p where p.MILLAS_REQUERIDAS <= '" +
                    valor + "'");
            datagridview.DataSource = productos;
            datagridview.Columns[0].Visible = false;
        }

        public static void consultarFuncionalidadesDelRol(Int32 valor, DataGridView datagridview)
        {
            DataTable listado = SqlConnector.obtenerTablaSegunConsultaString(@"select f.ID as Id, 
                f.DETALLES as Funcionalidad from " + SqlConnector.getSchema() + @".funcionalidades_por_rol fr inner 
                join " + SqlConnector.getSchema() + @".funcionalidades f on fr.FUNCIONALIDAD_ID = f.ID where fr.ROL_ID = '" + 
                valor + "'");
            datagridview.DataSource = listado;
            datagridview.Columns[0].Visible = false;
        }

        public static DataTable consultarRoles(DataGridView datagridview){
            DataTable listado = SqlConnector.obtenerTablaSegunConsultaString(@"select r.ID as IdRol, 
                r.NOMBRE as Rol, r.ACTIVO as Activo from " + SqlConnector.getSchema() + ".roles r");
            listado.Columns.Add("Estado", typeof(String));
            foreach (DataRow row in listado.Rows){
                if (Convert.ToInt32(row[2]) == 0){
                    row[3] = "Inactivo";
                }else{
                    row[3] = "Activo";
                }
            }
            datagridview.DataSource = listado;
            datagridview.Columns[0].Visible = false;
            datagridview.Columns[2].Visible = false;
            return listado;
        }

        public static DataTable consultarClientes(DataGridView datagridview)
        {
            DataTable listado = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                from " + SqlConnector.getSchema() + ".clientes where BAJA = 0");
            datagridview.DataSource = listado;
            datagridview.Columns[0].Visible = false;
            return listado;
        }

       public static DataTable consultarViajesDisponibles(DataGridView datagridview,string fecha)
        {
            DataTable listado;
            listado = SqlConnector.obtenerTablaSegunProcedure(SqlConnector.getSchema() + ".vuelosDisponibles",
                generarListaParaProcedure("@fecha"), fecha);
            datagridview.DataSource = listado;
            datagridview.Columns[0].Visible = false;
            return listado;
        }

         public  static void darDeBajaAeronave(String id)
        {
            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + @".bajaAeronave", 
                generarListaParaProcedure("@id","@fecha"), id,funcionesComunes.getFecha());
            if (resultado)
            {
                MessageBox.Show("La aeronave se dio de baja exitosamente");
            }
        }
        public static void darDebajaVuelo(int id)
        {
           SqlConnector.executeProcedure(SqlConnector.getSchema() + ".bajaVuelo", generarListaParaProcedure("@id","@fecha"), id,funcionesComunes.getFecha());
        }

        public static List<string> generarListaParaProcedure(params Object[] parametros)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < parametros.Length; i++ )
            {
                lista.Add(parametros[i].ToString());
            }            
            return lista;
        }

        #endregion

        public static void setFecha(String fec)
        {

           fecha = fec;     
        }

      public static string getFecha()
      {
            return fecha;
      }

        public static double precioEncomienda(DataGridViewRow encomienda)
        {
            return Double.Parse(encomienda.Cells[5].Value.ToString());
        }



        public static double precioPasaje(DataGridViewRow pasaje)
        {
            return Double.Parse(pasaje.Cells[6].Value.ToString());
        }

        public static string crearBoleto(DataGridView pasajes, DataGridView encomiendas, double precioCompra, Int32 idTarjeta, int cuotas, Int32 idCliente,Int32 idVuelo )
        {


            SqlConnector.executeProcedure(SqlConnector.getSchema() + ".altaBoletoDeCompra",
            funcionesComunes.generarListaParaProcedure("@idCliente", "@fecha","@id_tarj","@cant_cuotas"),
                 idCliente, funcionesComunes.getFecha(),idTarjeta,cuotas);

            Int32 idBoleto = funcionesComunes.obtenerBoleto();
            if (pasajes.RowCount != 0)
                funcionesComunes.darAltaPasajes(pasajes,idBoleto,idVuelo);
            if (encomiendas.RowCount != 0)
                funcionesComunes.darAltaEncomiendas(encomiendas,idBoleto,idVuelo);
         
            return idBoleto.ToString();
        }

        private static int obtenerBoleto()
        {
            DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT TOP 1 bc.ID as id
                                                                    FROM " + SqlConnector.getSchema() + @".boletos_de_compra bc
                                                                    order by 1 desc");
            return Convert.ToInt32(tabla.Rows[0].ItemArray[0]);
        }

        private static void darAltaEncomiendas(DataGridView encomiendas,Int32 idBoleto,Int32 idVuelo)
        {
            foreach (DataGridViewRow encomienda in encomiendas.Rows) 
            { 
                double kg = Convert.ToDouble(encomienda.Cells[4].Value);
                double precio = Convert.ToDouble(encomienda.Cells[5].Value);
                SqlConnector.executeProcedure(SqlConnector.getSchema() + ".altaPaquete",
                    funcionesComunes.generarListaParaProcedure("@idBoletoCompra", "@kg", "@precio","@idVuelo"),
                    idBoleto,kg,precio,idVuelo);
            }
        }

        private static void darAltaPasajes(DataGridView pasajes,Int32 idBoleto,Int32 idVuelo)
        {
            foreach (DataGridViewRow pasaje in pasajes.Rows) 
            {
                Int32 idPasajero = Int32.Parse(pasaje.Cells[0].Value.ToString());
                Int32 idButaca = Int32.Parse(pasaje.Cells[11].Value.ToString());
                Double precio = Convert.ToDouble(pasaje.Cells[6].Value.ToString());

                SqlConnector.executeProcedure(SqlConnector.getSchema() + ".altaPasaje",
                funcionesComunes.generarListaParaProcedure("@idCliente","@idButaca","@idBoletoCompra","@precio","@idVuelo"),
                idPasajero,idButaca,idBoleto,precio,idVuelo);
                //Aca hacemos el insert del pasaje usando el idBoleto , el idPasajero, el precio , el id de la butaca y el codigo que hay que ver como generar
            }
        }

        public static bool validarDni(string dni)
        {
            DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                from " + SqlConnector.getSchema() + ".clientes where BAJA = 0 AND DNI = " + dni);
            return tablaClientes.Rows.Count != 0;
        }


        public static DataRow getcliente(string id)
        {
            DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                         NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                         TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                         from " + SqlConnector.getSchema() + ".clientes where BAJA = 0 AND ID = " + id);
            return tablaClientes.Rows[0];
        }
    }
}
