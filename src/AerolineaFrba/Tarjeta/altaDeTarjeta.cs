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

namespace AerolineaFrba.Tarjeta
{
    public partial class altaDeTarjeta : Form
    {
        DataTable listado;
        public altaDeTarjeta()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(this.comboBoxTipoTarjeta, "NOMBRE", "select ID, NOMBRE from " + SqlConnector.getSchema() + ".tipos_tarjeta");
        }

        //este boton borra el contenido de todos los campos

    
        private void consultarContactos()
        {
            String dni = this.textBoxDni.Text;
            if (dni != "")
            {
                listado = funcionesComunes.consultarClientes(this.dataGridCliente);
                this.dataGridCliente.DataSource = this.filtrarCliente();

            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable filtrarCliente()
        {
            DataTable tablaClientes = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();

            if (this.textBoxDni.Text != "") filtrosBusqueda.Add("Dni = " + this.textBoxDni.Text);
          

            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_rol += " AND " + filtro;
                else
                {
                    final_rol += filtro;
                    posFiltro = false;
                }
            }
            if (tablaClientes != null)
                tablaClientes.DefaultView.RowFilter = final_rol;
            return tablaClientes;
        }

        

        private bool validarDatos()
        {
            long numero;
            if (this.textBoxNumero.Text == "")
                numero = 0;
            else
                numero = long.Parse(this.textBoxNumero.Text);
            if (this.dataGridCliente.DataSource != null && numero > 0 && this.comboBoxTipoTarjeta.SelectedValue != null) {
                if (this.fechavencimiento.Value <= DateTime.Today.AddDays(1))
                {
                    MessageBox.Show("La fecha de vencimiento debe ser superior a la de hoy", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                else
                    return true;
            }
            else
            {
                MessageBox.Show("Complete los campos requeridos correctamente", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
   
        }

        private void soloNumer(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            consultarContactos();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (dataGridCliente.Rows.Count > 0)
            {
                if (validarDatos())
                {
                    bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".altaTarjeta",
                        funcionesComunes.generarListaParaProcedure("@idCliente", "@nroTarjeta", "@idTipo", "@fechaVto"),
                        long.Parse(dataGridCliente.SelectedCells[0].Value.ToString()),
                        long.Parse(this.textBoxNumero.Text),
                        this.comboBoxTipoTarjeta.SelectedValue,
                        String.Format("{0:yyyyMMdd HH:mm:ss}", this.fechavencimiento.Value));
                    if (resultado)
                    {
                        MessageBox.Show("Se dio de alta la tarjeta exitosamente");
                        funcionesComunes.habilitarAnterior();
                    }
                }
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDni.Clear();
            this.textBoxNumero.Clear();
            this.comboBoxTipoTarjeta.SelectedIndex = -1;
            this.dataGridCliente.DataSource = null;
            this.fechavencimiento.ResetText();
        }
    }
}
