using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AerolineaFrba
{
    
    public partial class Principal : Form
    {
  
        
        public Principal()
        {
            InitializeComponent();
            DateTime fechaGlobal = DateTime.Parse(@System.Configuration.ConfigurationSettings.AppSettings["Fecha"]);
            funcionesComunes.setFecha(fechaGlobal);
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            if (SqlConnector.conectarABaseDeDatos()){
                SqlConnector.executeProcedure(SqlConnector.getSchema() + @".activarAeronaves",
                funcionesComunes.generarListaParaProcedure("@fecha"), funcionesComunes.getFecha());
                funcionesComunes.ventanaInicial(new Ingreso.Ingreso());
            }else{
                MessageBox.Show("Cierre el programa e intente nuevamente");
            }
            
     
        }
    }
}
