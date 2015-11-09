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

namespace AerolineaFrba.Compra
{
    public partial class viajesDisponibles : Form
    {
        DataTable listado;
        public viajesDisponibles()
        {
            InitializeComponent();
            this.textBoxKgEncomienda.Text = "0";
            funcionesComunes.consultarViajesDisponibles(this.dataGridViajes, String.Format("{0:yyyyMMdd HH:mm:ss}", DateTime.Today.Subtract(TimeSpan.FromDays(1))));
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            if (compraValida())
            {
                string fechaSalida = String.Format("{0:yyyyMMdd HH:mm:ss}", Convert.ToDateTime(this.dataGridViajes.SelectedCells[1].Value.ToString()));
                string fechaLlegada = String.Format("{0:yyyyMMdd HH:mm:ss}", Convert.ToDateTime(this.dataGridViajes.SelectedCells[2].Value.ToString()));
                string origen = this.dataGridViajes.SelectedCells[3].Value.ToString();
                string destino = this.dataGridViajes.SelectedCells[4].Value.ToString();
                Form frmCargaDeDatos = new Compra.cargaDeDatos(fechaSalida,fechaLlegada,origen,destino);
                ((TextBox)frmCargaDeDatos.Controls["textBoxCantPasajes"]).Text = this.numericUpDownPasajes.Value.ToString();
                ((TextBox)frmCargaDeDatos.Controls["textBoxIDVuelo"]).Text = this.dataGridViajes.SelectedCells[0].Value.ToString();
                ((TextBox)frmCargaDeDatos.Controls["textBoxKgEncomiendas"]).Text = this.textBoxKgEncomienda.Text;
                funcionesComunes.deshabilitarVentanaYAbrirNueva(frmCargaDeDatos);
            }
        }

        private bool compraValida()
        {
            if (this.numericUpDownPasajes.Value == 0 && Double.Parse(this.textBoxKgEncomienda.Text) == 0) {
                MessageBox.Show("Debes eleccionar una cantidad de pasajes o kg");
                return false;
            }
            if (this.numericUpDownPasajes.Value > Int32.Parse( dataGridViajes.SelectedCells[5].Value.ToString())) {
                MessageBox.Show("No hay esa cantidad de pasajes disponibles para ese vuelo");
                return false;
            }
            if (Double.Parse(this.textBoxKgEncomienda.Text) > Double.Parse(dataGridViajes.SelectedCells[6].Value.ToString()))
            {
                MessageBox.Show("No hay esa cantidad de Kg disponibles para ese vuelo");
                return false;
            }
            return true;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxOrigen.SelectedIndex != comboBoxDestino.SelectedIndex){

                   if (timePickerFecha.Value >= DateTime.Today)
                      {
                         this.dataGridViajes.DataSource = filtrarViajes();
                         this.dataGridViajes.Columns[0].Visible = false;
                      }
                   else
                      {
                          MessageBox.Show("La fecha seleccionada debe ser el dia actual o posterior al dia actual");
                      }
            }else{
                MessageBox.Show("La ciudad de origen no puede ser la misma que la de destino");
            }
        }

        private DataTable filtrarViajes()
        {
            listado = funcionesComunes.consultarViajesDisponibles(this.dataGridViajes, String.Format("{0:yyyyMMdd HH:mm:ss}", this.timePickerFecha.Value));
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            filtrosBusqueda.Add("Origen LIKE '%" + this.comboBoxOrigen.Text + "%'");
            filtrosBusqueda.Add("Destino LIKE '%" + this.comboBoxDestino.Text + "%'");
            
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
            if (listado != null)
                listado.DefaultView.RowFilter = final_rol;
            return listado;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.timePickerFecha.ResetText();
            this.textBoxKgEncomienda.Clear();
            this.numericUpDownPasajes.Value=0;
            this.comboBoxOrigen.SelectedIndex = 0;
            this.comboBoxDestino.SelectedIndex = 0;
            funcionesComunes.consultarViajesDisponibles(this.dataGridViajes, String.Format("{0:yyyyMMdd HH:mm:ss}", this.timePickerFecha.Value));
        }

        private void viajesDisponibles_Load(object sender, EventArgs e)
        {
            llenarComboBoxs();
        }

        private void llenarComboBoxs()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = SqlConnector.obtenerTablaSegunConsultaString("select c.ID, c.NOMBRE from aero.ciudades c order by c.NOMBRE");
            comboBoxOrigen.DataSource = dt1;
            comboBoxOrigen.DisplayMember = "NOMBRE";
            comboBoxOrigen.ValueMember = "ID";
            dt2 = SqlConnector.obtenerTablaSegunConsultaString("select c.ID, c.NOMBRE from aero.ciudades c order by c.NOMBRE");
            comboBoxDestino.DataSource = dt2;
            comboBoxDestino.DisplayMember = "NOMBRE";
            comboBoxDestino.ValueMember = "ID";
        }

        private void validadorInput(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxKgEncomienda, e);
        }
    }
}
