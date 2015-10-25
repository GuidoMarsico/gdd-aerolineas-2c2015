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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class modificacionDeAeronave : Form
    {
        public modificacionDeAeronave()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(comboBoxFabricante, "NOMBRE", "select ID, NOMBRE from AERO.fabricantes");
            funcionesComunes.llenarCombobox(comboBoxServicio, "NOMBRE", "select ID, NOMBRE from AERO.tipos_de_servicio");
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            if (this.fechaFinInactividad.Value < this.fechaInicioInactividad.Value){
                MessageBox.Show("La fecha de fin de la inactividad no puede ser menor que la de inicio");
            } else {
                bool resultado = SqlConnector.executeProcedure("AERO.updateAeronave",
                    funcionesComunes.generarListaParaProcedure("@id","@fechaInicio","@fechaFin"), 
                    this.textBoxId.Text, 
                    String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaInicioInactividad.Value), 
                    String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechaFinInactividad.Value));
                if (resultado){
                    MessageBox.Show("La aeronave se actualizo exitosamente");
                    funcionesComunes.habilitarAnterior();
                }
            }
            limpiar();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar(){
            this.fechaFinInactividad.ResetText();
            this.fechaInicioInactividad.ResetText();
        }
    }
}
