using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.CancelarReprogramarVuelos
{
    public partial class VuelosARemplazar : Form
    {
        String inicioInactividad;
        String finInactividad;
        public VuelosARemplazar(string idA, string tipo)
        {
            InitializeComponent();
            textBoxTipo.Text = tipo;
            textBoxTipoIdAero.Text = idA;
        }

        public VuelosARemplazar(string idA, string inicio, string fin, string tipo)
        {
           InitializeComponent();
           textBoxTipoIdAero.Text = idA;
           inicioInactividad = inicio;
           finInactividad = fin;
           textBoxTipo.Text = tipo;
        }

        private void cargaVentana_load(object sender, EventArgs e)
        {
            cargarListados();
        }

        private void cargarListados()
        {
            if (textBoxTipo.Text == "0")
            {
                this.dataGridListadoVuelos.DataSource = obtenerVuelosEnElPeriodo();
            }
            else
            {
                this.dataGridListadoVuelos.DataSource = this.vuelosVinculados();
            }
            this.dataGridListadoVuelos.Columns[0].Visible = false;
            this.dataGridListadoVuelos.Columns[6].Visible = false;
            this.dataGridListadoVuelos.Columns[7].Visible = false;
            this.dataGridListadoVuelos.Columns[8].Visible = false;
        }

   
        private void darDeBajaLosVuelosDe(DataTable tabla)
        {
            foreach (DataRow vuelo in tabla.Rows)
            {
                funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
            }
        }

        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Se cancelaran todos los vuelos que no se remplazaron ¿Esta Seguro?", "Terminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.botonRemplazar.Enabled = false;
                this.buttonTerminar.Enabled = false;
                MessageBox.Show("Realizando la operacion, aguarde un momento ... ");
                DataTable tabla = (DataTable)this.dataGridListadoVuelos.DataSource;
                this.darDeBajaLosVuelosDe(tabla);
                this.botonRemplazar.Enabled = false;
                this.buttonTerminar.Enabled = false;
                if (this.textBoxTipo.Text != "0")
                    funcionesComunes.darDeBajaAeronave(this.textBoxTipoIdAero.Text);
                funcionesComunes.volverAMenuPrincipal();
            }
        }

        private void botonRemplazar_Click(object sender, EventArgs e)
        {   
            DataTable aeronavesDisponibles = this.obtenerAeronavesDisponibles();
            Int32 cantidadDisponible = aeronavesDisponibles.Rows.Count;
            if (cantidadDisponible > 0){
                Form seleccionarAeronave = new CancelarReprogramarVuelos.SeleccionarAeronave(aeronavesDisponibles);
                ((TextBox)seleccionarAeronave.Controls["textBoxIdVuelo"]).Text = this.dataGridListadoVuelos.SelectedCells[0].Value.ToString();
                funcionesComunes.deshabilitarVentanaYAbrirNueva(seleccionarAeronave);
            }else{
                 DialogResult dialogResult = MessageBox.Show("¿Desea dar de alta una nueva aeronave para usar como remplazo?","No hay aeronave de remplazo",MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.altaDeAeronave());
                 }
               // MessageBox.Show("No hay ninguna aeronave que pueda ser usada como remplazo");
                //Int32 id = Int32.Parse(dataGridListadoVuelos.SelectedCells[0].Value.ToString());
                //funcionesComunes.darDebajaVuelo(id);
            }
        }

        private DataTable obtenerAeronavesDisponibles()
        {
            String fechaSalida = String.Format("{0:yyyyMMdd HH:mm:ss}",
                Convert.ToDateTime(this.dataGridListadoVuelos.SelectedCells[1].Value).AddHours(-1));
            String fechaLlegadaEstimada = String.Format("{0:yyyyMMdd HH:mm:ss}",
                Convert.ToDateTime(this.dataGridListadoVuelos.SelectedCells[3].Value).AddHours(1));

            return SqlConnector.obtenerTablaSegunConsultaString(@"SELECT a.ID, a.MATRICULA, a.MODELO FROM " + SqlConnector.getSchema() + @".vuelos v, 
                " + SqlConnector.getSchema() + @".aeronaves a where v.AERONAVE_ID = a.ID and a.ID != " +
                Int32.Parse(this.textBoxTipoIdAero.Text) + @" and a.ID not in (select naves.ID 
                from " + SqlConnector.getSchema() + @".aeronaves naves, " + SqlConnector.getSchema() + @".vuelos vu where vu.AERONAVE_ID = naves.ID and 
                (vu.FECHA_SALIDA > convert(datetime, '" + fechaSalida + @"',109) and 
                vu.FECHA_SALIDA < convert(datetime, '" + fechaLlegadaEstimada + @"',109) and vu.FECHA_LLEGADA > 
                convert(datetime, '" + fechaSalida + @"',109) and vu.FECHA_LLEGADA < convert(datetime, '" +
                fechaLlegadaEstimada + @"',109) and vu.FECHA_LLEGADA_ESTIMADA >
                convert(datetime, '" + fechaSalida + @"',109) and vu.FECHA_LLEGADA_ESTIMADA  <convert(datetime, '" +
                fechaLlegadaEstimada + @"',109)) or v.INVALIDO = 1 or naves.BAJA IS NOT NULL or 
                naves.TIPO_SERVICIO_ID != " +
                Int32.Parse(this.dataGridListadoVuelos.SelectedCells[8].Value.ToString()) +
                @") or (a.ID not in (select distinct AERONAVE_ID from LAS_PELOTAS.vuelos) and 
                a.TIPO_SERVICIO_ID = " +
                Int32.Parse(this.dataGridListadoVuelos.SelectedCells[8].Value.ToString()) +
                @") group by a.ID, a.MATRICULA, a.MODELO order by a.ID, a.MATRICULA, a.MODELO");
        }
        private DataTable vuelosVinculados()
        {
            String id = this.textBoxTipoIdAero.Text;
            return SqlConnector.obtenerTablaSegunConsultaString(@"SELECT v.ID as Id,v.FECHA_SALIDA as 'Fecha Salida',v.FECHA_LLEGADA as 'Fecha Llegada'
                        ,v.FECHA_LLEGADA_ESTIMADA as 'Fecha Estimada',r.CODIGO as 'Codigo Ruta',t.NOMBRE as Servicio, v.AERONAVE_ID as Aeronave,v.RUTA_ID as RutaID,
                        servxruta.TIPOS_DE_SERVICIO_ID as IdServicio
                        FROM " + SqlConnector.getSchema() + @".vuelos v
                        join " + SqlConnector.getSchema() + @".rutas r on r.ID = v.Ruta_ID
                        join " + SqlConnector.getSchema() + @".servicios_Por_Ruta servxruta on servxruta.RUTAS_ID = r.ID
                        join " + SqlConnector.getSchema() + @".tipos_de_servicio t on t.ID = servxruta.TIPOS_DE_SERVICIO_ID
                        where v.AERONAVE_ID =" + id + " AND v.INVALIDO = 0 AND v.FECHA_SALIDA > convert(datetime,'" + funcionesComunes.getFecha() + "',109) order by 2");
        }

        private DataTable obtenerVuelosEnElPeriodo() 
        {

           DataTable vuelosEnElPeriodo = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT v.ID as Id,v.FECHA_SALIDA as 'Fecha Salida',v.FECHA_LLEGADA as 'Fecha Llegada'
                        ,v.FECHA_LLEGADA_ESTIMADA as 'Fecha Estimada',r.CODIGO as 'Codigo Ruta',t.NOMBRE as Servicio, v.AERONAVE_ID as Aeronave,v.RUTA_ID as RutaID,
                        servxruta.TIPOS_DE_SERVICIO_ID as IdServicio
                        FROM " + SqlConnector.getSchema() + @".vuelos v
                        join " + SqlConnector.getSchema() + @".rutas r on r.ID = v.Ruta_ID
                        join " + SqlConnector.getSchema() + @".servicios_Por_Ruta servxruta on servxruta.RUTAS_ID = r.ID
                        join " + SqlConnector.getSchema() + @".tipos_de_servicio t on t.ID = servxruta.TIPOS_DE_SERVICIO_ID
                        where v.AERONAVE_ID = " + textBoxTipoIdAero.Text + @" AND (v.FECHA_SALIDA 
                > convert(datetime, '" + inicioInactividad + @"',109) and (v.FECHA_SALIDA <
                convert(datetime, '" + finInactividad + @"',109)) or v.FECHA_LLEGADA > 
                convert(datetime, '" + inicioInactividad + @"',109) and v.FECHA_LLEGADA < convert(datetime, '" +
               finInactividad + @"',109) or v.FECHA_LLEGADA_ESTIMADA > 
                convert(datetime, '" + inicioInactividad + @"',109) and v.FECHA_LLEGADA_ESTIMADA < convert(datetime, '" +
               finInactividad + @"',109)) ");
           return vuelosEnElPeriodo;
       }

        private void recarga_enter(object sender, EventArgs e)
        {
            cargarListados();
        }
        
    }
}
