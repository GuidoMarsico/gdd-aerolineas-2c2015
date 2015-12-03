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
using System.Collections;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class altaDeAeronave : Form
    {
        public altaDeAeronave()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(comboBoxFabricante,"NOMBRE","select ID, NOMBRE from " + SqlConnector.getSchema() + ".fabricantes");
            funcionesComunes.llenarCombobox(comboBoxServicio, "NOMBRE", "select ID, NOMBRE from " + SqlConnector.getSchema() + ".tipos_de_servicio");
            this.timePickerAlta.Value = funcionesComunes.getFechaGlobal();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar(){
            this.textBoxCantButacas.Clear();
            this.textBoxKgDisponibles.Clear();
            this.textBoxMatricula.Clear();
            this.textBoxModelo.Clear();
            this.timePickerAlta.Value = funcionesComunes.getFechaGlobal();
            this.comboBoxFabricante.SelectedIndex = -1;
            this.comboBoxServicio.SelectedIndex = -1;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            Int32 cantButacas = 0;
            if(this.textBoxCantButacas.Text != ""){
                cantButacas = Int32.Parse(this.textBoxCantButacas.Text);
            }
            Int32 kg = 0;
            if(this.textBoxKgDisponibles.Text != ""){
               kg = Int32.Parse(this.textBoxKgDisponibles.Text);
            }
            String matricula = this.textBoxMatricula.Text;
            String modelo = this.textBoxModelo.Text;
            Int32 fabricante = 0;
            Int32 servicio = 0;
            if (comboBoxFabricante.SelectedValue != null)
                fabricante = (Int32)comboBoxFabricante.SelectedValue;
            if (comboBoxServicio.SelectedValue != null)
                servicio = (Int32)this.comboBoxServicio.SelectedValue;
            if (validar(matricula, modelo, fabricante, servicio, kg, cantButacas))
                if(validarMatricula(matricula)){
                    bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".agregarAeronave",
                        funcionesComunes.generarListaParaProcedure("@matricula","@modelo","@kg_disponibles",
                        "@fabricante","@tipo_servicio","@alta","@cantButacas"),
                        matricula, modelo, kg, fabricante, servicio,
                        String.Format("{0:yyyyMMdd HH:mm:ss}",this.timePickerAlta.Value), cantButacas);
                    if (resultado){
                        MessageBox.Show("Se guardo exitosamente");
                        limpiar();
                    }
                }else{
                    MessageBox.Show("La matrícula ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private bool validarMatricula(String matricula){
            DataTable dt = new DataTable();
            dt = SqlConnector.obtenerTablaSegunConsultaString(@"select MATRICULA from " + SqlConnector.getSchema() + @".aeronaves where 
                MATRICULA = UPPER('"+ matricula +"')");
            if (dt.Rows.Count != 0){
                return false;
            }
            return true;
        }

        private void textBoxKgDisponibles_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxCantButacas_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.martricula(this.textBoxMatricula,e);
        }

        private void textBoxModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetrasYNumeros(e);
        }

        private bool validar(String matricula, String modelo, Int32 fabricante, Int32 servicio, Int32 kg, Int32 cantButacas)
        {
            if (cantButacas <= 0){
                MessageBox.Show("La cantidad de butacas debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (kg <= 0){
                MessageBox.Show("La cantidad de KG debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (matricula == ""){
                MessageBox.Show("La matrícula es un campo requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (modelo == ""){
                MessageBox.Show("El modelo es un campo requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (fabricante <= 0){
                MessageBox.Show("Seleccione un fabricante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (servicio <= 0){
                MessageBox.Show("Seleccione un servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
