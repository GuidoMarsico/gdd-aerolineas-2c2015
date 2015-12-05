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
    public partial class CancelarVuelos : Form
    {
        public string inicio = "";
        public string fin = "";
        public DataTable vuelos;
        public CancelarVuelos(DataTable tabla)
        {
            InitializeComponent();
            this.vuelos = tabla;
        }

        public CancelarVuelos(string tipo, string idVuelo,string i,string f, DataTable tabla)
        {
            InitializeComponent();
            textBoxTipo.Text = tipo;
            textBoxTipoIdAero.Text = idVuelo;
            inicio = i;
            fin = f;
            this.vuelos = tabla;
        }

        public void actualizarAeronave()
        {
            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + @".updateAeronave",
        funcionesComunes.generarListaParaProcedure("@id", "@fechaInicio", "@fechaFin"),
        this.textBoxTipoIdAero.Text, inicio, fin);
            if (resultado)
            {
                MessageBox.Show("La aeronave se actualizo exitosamente");
                funcionesComunes.volverAMenuPrincipal();
            }
        }

        private void botonBajaTodos_Click(object sender, EventArgs e)
        {   
            //Si es igual a 0 significa que vino de cuando modificamos la aeronave y la dejamos deshabilitada por un periodo 
            //y eligio dar de baja todos los vuelos de ese periodo de esa aeronave
            if (this.textBoxTipo.Text == "0")
            {
                this.botonBajaTodos.Enabled = false;
                this.buttonReprogramar.Enabled = false;
                MessageBox.Show("Realizando la operacion, aguarde un momento ... ");
                foreach(DataRow vuelo in vuelos.Rows)
                {
                    funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
                }
                actualizarAeronave();
                this.botonBajaTodos.Enabled = true;
                this.buttonReprogramar.Enabled = true;
           
            }
            else 
            {
                this.botonBajaTodos.Enabled = false;
                this.buttonReprogramar.Enabled = false;
                MessageBox.Show("Realizando la operacion, aguarde un momento... ");
                foreach (DataRow vuelo in vuelos.Rows)
                {
                    funcionesComunes.darDebajaVuelo(Int32.Parse(vuelo[0].ToString()));
                }
                this.botonBajaTodos.Enabled = true;
                this.buttonReprogramar.Enabled = true;
                funcionesComunes.darDeBajaAeronave(this.textBoxTipoIdAero.Text);
            }
            funcionesComunes.volverAMenuPrincipal();   
        }

        private void buttonReprogramar_Click(object sender, EventArgs e)
        {
            DataTable aeronave = SqlConnector.obtenerTablaSegunConsultaString(@"select KG_DISPONIBLES, FABRICANTE_ID, 
                TIPO_SERVICIO_ID, CANT_BUTACAS from " + SqlConnector.getSchema() + @".aeronaves a where a.ID = " +
                Int32.Parse(this.textBoxTipoIdAero.Text));
            
            DataTable tablaAeronaves = SqlConnector.obtenerTablaSegunConsultaString(@"select * from "+SqlConnector.getSchema()+
                @".aeronaves a where a.ID !=" + Int32.Parse(this.textBoxTipoIdAero.Text) + @" and a.tipo_servicio_id = "+
                Int32.Parse(aeronave.Rows[0].ItemArray[2].ToString()) + @" and a.fabricante_id = "+
                Int32.Parse(aeronave.Rows[0].ItemArray[1].ToString()) + @" and a.kg_disponibles >= " +
                Int32.Parse(aeronave.Rows[0].ItemArray[0].ToString()) + @" and a.cant_butacas >= "+
                Int32.Parse(aeronave.Rows[0].ItemArray[3].ToString()) + @" and a.fecha_alta <= convert(datetime,'" + 
                funcionesComunes.getFecha() + @"',109)");
            DataTable tablaAeronavesValidas = tablaAeronaves.Clone();
            tablaAeronavesValidas.Clear();
            Int32 i, j;
            for (i=0; i < tablaAeronaves.Rows.Count; i++){
	            bool sirve = true;
                for (j=0; j < vuelos.Rows.Count; j++){
                    DataTable dt = SqlConnector.obtenerTablaSegunProcedure(SqlConnector.getSchema() + ".validarVuelo", 
                        funcionesComunes.generarListaParaProcedure("@id", "@fechaSalida", "@fechaLlegadaEstimada"),
                        Int32.Parse(tablaAeronaves.Rows[i].ItemArray[0].ToString()), 
                        String.Format("{0: yyyyMMdd HH:mm:ss}",DateTime.Parse(vuelos.Rows[j].ItemArray[1].ToString())),
                        String.Format("{0: yyyyMMdd HH:mm:ss}",DateTime.Parse(vuelos.Rows[j].ItemArray[3].ToString())));
		            if(Int32.Parse(dt.Rows[0].ItemArray[0].ToString()) != 0){
			            sirve = false;
		            }
	            }
	            if(sirve){
                    tablaAeronavesValidas.ImportRow(tablaAeronaves.Rows[i]);
	            }
            }
            if (tablaAeronavesValidas.Rows.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show(@"No se encontro una aeronave que sirva de reemplazo, debe dar de 
                    alta una nueva ¿Esta Seguro?", "Nueva aeronave", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Form altaAeronave = new Abm_Aeronave.altaDeAeronave();
                    ((TextBox)altaAeronave.Controls["textBoxTipo"]).Text = "1";
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(altaAeronave);
                }else
                    MessageBox.Show("Debe dar de alta una aeronave nueva o cancelar todos los vuelos de la actual");
            }
            else if (tablaAeronavesValidas.Rows.Count == 1)
            {
                MessageBox.Show("Se encontro una aeronave que sirve de reemplazo, se estan reemplazando los vuelos...");
                foreach(DataRow vuelo in vuelos.Rows){
                    SqlConnector.executeProcedure(SqlConnector.getSchema() + @".cambiarAeronaveDeVuelo",
                       funcionesComunes.generarListaParaProcedure("@idVuelo", "@idAeronaveNueva"),
                       Int32.Parse(vuelo.ItemArray[0].ToString()),
                       Int32.Parse(tablaAeronavesValidas.Rows[0].ItemArray[0].ToString())); 
                }
                MessageBox.Show("Se reemplazo correctamente");
                if (textBoxTipo.Text == "0")
                    actualizarAeronave();
                else
                    funcionesComunes.darDeBajaAeronave(this.textBoxTipoIdAero.Text);
                funcionesComunes.volverAMenuPrincipal();
            }
            else{
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new CancelarReprogramarVuelos.SeleccionarAeronave(tablaAeronavesValidas, vuelos));
            }
        }

        private void enter(object sender, EventArgs e)
        {
            if (this.textBoxIdAeroValida.Text == "1")
            {
                buttonReprogramar.PerformClick();
            }
            else if (this.textBoxIdAeroValida.Text == "2")
            {
                if (textBoxTipo.Text == "0")
                    actualizarAeronave();
                else
                    funcionesComunes.darDeBajaAeronave(this.textBoxTipoIdAero.Text);
                funcionesComunes.volverAMenuPrincipal();
            }
        }
    }
}
