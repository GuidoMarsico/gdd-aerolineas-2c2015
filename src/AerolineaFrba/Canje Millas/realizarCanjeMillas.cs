using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Canje_Millas
{
    public partial class realizarCanjeMillas : Form
    {
        public realizarCanjeMillas()
        {
            InitializeComponent();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            consultarContactos();
        }

        private void consultarContactos()
        {
            String dni = this.textDni.Text;
            if (dni != "")
            {
                DataTable resultado = SqlConnector.obtenerTablaSegunProcedure(SqlConnector.getSchema() + @".obtenerClienteConMillas",
                    funcionesComunes.generarListaParaProcedure("@dni"), dni);
                dataGridCliente.DataSource = resultado;
                dataGridCliente.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonCanjear_Click(object sender, EventArgs e)
        {
            String cantidad = this.textCantidad.Text;
            if (cantidad != ""){
                if (dataGridProductos.Rows.Count == 0){
                    MessageBox.Show("No hay canjes disponibles");
                }else {
                    if (Int32.Parse(cantidad) > Int32.Parse(dataGridProductos.SelectedCells[3].Value.ToString())){
                        MessageBox.Show("No hay stock suficiente para realizar el canje");
                    }else{
                        Int32 millas = Int32.Parse(dataGridCliente.SelectedCells[5].Value.ToString());
                        Int32 cantidadACanjear = Int32.Parse(cantidad);
                        Int32 millasRequeridas = Int32.Parse(dataGridProductos.SelectedCells[2].Value.ToString());
                        if ( millas > (cantidadACanjear * millasRequeridas)){
                            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + @".altaCanje",
                                funcionesComunes.generarListaParaProcedure("@idCliente","@idProducto","@cantidad"),
                                dataGridCliente.SelectedCells[0].Value, dataGridProductos.SelectedCells[0].Value,
                                cantidad);
                            if (resultado == true){
                                MessageBox.Show("El canje ha sido realizado con éxito");
                                consultarContactos();
                                dataGridProductos.DataSource = null;
                            }else{
                                MessageBox.Show("Ocurrió un error al realizar el canje");
                            }
                        }else{
                            MessageBox.Show(@"No posee las millas necesarias para realizar el 
                                canje. Millas requeridas: " + cantidadACanjear * millasRequeridas);
                        }
                    }
                }
            }else{
                MessageBox.Show("Ingrese la cantidad a canjear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonVerCanjes_Click(object sender, EventArgs e)
        {
            if (dataGridCliente.DataSource == null){
                MessageBox.Show("Debe seleccionar un cliente primero");
            }else{
                if (dataGridCliente.Rows.Count > 0)
                {
                    funcionesComunes.consultarMillas(Int32.Parse(dataGridCliente.SelectedCells[5].Value.ToString()),
                        dataGridProductos);
                }
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textDni.Clear();
            this.textCantidad.Clear();
            this.dataGridCliente.DataSource = null;
            this.dataGridProductos.DataSource = null;
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }
    }
}
