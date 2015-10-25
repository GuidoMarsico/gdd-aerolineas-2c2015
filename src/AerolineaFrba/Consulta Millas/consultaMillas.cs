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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class consultaMillas : Form
    {
       
        public consultaMillas()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        //este boton borra el contenido del textbox
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDNI.Clear();
            dataGridConsultaMillas.DataSource = null;
        }

        //este boton le cambia el valor al label con la cantidad de millas del usuario
        private void botonConsultar_Click(object sender, EventArgs e)
        {
            String dni = this.textBoxDNI.Text;
            if (dni != "") {
                DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id 
                from AERO.clientes where BAJA = 0 AND DNI = " + dni);
                if (tablaClientes.Rows.Count > 0)
                {
                    DataTable resultado = SqlConnector.obtenerTablaSegunProcedure("AERO.consultarMillas",
                        funcionesComunes.generarListaParaProcedure("@dni"), dni);
                    dataGridConsultaMillas.DataSource = resultado;
                    Int32 millas = 0;
                    foreach (DataRow row in resultado.Rows)
                    {
                        millas += Int32.Parse(row.ItemArray[2].ToString());
                    }
                    textBoxTotal.Text = millas.ToString();
                }
                else
                {
                    MessageBox.Show("No se encuentra el cliente. Por favor ingrese nuevamente el DNI");
                }
            }else 
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
