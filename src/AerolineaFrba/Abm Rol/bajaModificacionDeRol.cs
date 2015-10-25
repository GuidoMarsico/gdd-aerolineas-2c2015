using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class bajaModificacionDeRol : Form
    {
        DataTable listado;
        public bajaModificacionDeRol()
        {
            InitializeComponent();
        }

        private void bajaModificacionDeRol_Load(object sender, EventArgs e)
        {
            listado = funcionesComunes.consultarRoles(dataGridListadoRoles);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            textRol.Clear();
            textEstado.Clear();
          listado =  funcionesComunes.consultarRoles(dataGridListadoRoles);
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            if (rolActivo())
            {
                bool resultado = SqlConnector.executeProcedure("AERO.inhabilitarRol",
                    funcionesComunes.generarListaParaProcedure("@idRol"), Convert.ToInt32(dataGridListadoRoles.SelectedCells[0].Value));
                if (resultado)
                {
                    MessageBox.Show("El rol fue inhabilitado exitosamente");
                   listado = funcionesComunes.consultarRoles(dataGridListadoRoles);
                }
            }else{
                MessageBox.Show("El rol no se encuentra activo");
            }
        }

        private bool rolActivo()
        {
                if (dataGridListadoRoles.SelectedCells[3].Value.ToString() == "Activo"){
                    return true;
                }else{
                    return false;
                }
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            if (dataGridListadoRoles.SelectedRows.Count > 0)
            {
                Form modificacionDeRol = new Abm_Rol.altaModificacionDeRol();
                int val = 1;
                ((TextBox)modificacionDeRol.Controls["textTipoForm"]).Text = val.ToString();
                ((TextBox)modificacionDeRol.Controls["textId"]).Text = dataGridListadoRoles.SelectedCells[0].Value.ToString();
                ((TextBox)modificacionDeRol.Controls["textRol"]).Text = dataGridListadoRoles.SelectedCells[1].Value.ToString();
                modificacionDeRol.Text = "Modificación de Rol";
                funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionDeRol);
            }
            else
            {
                MessageBox.Show("Seleccione un rol para modificar");
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable clientesFiltro = filtrarRol(textRol.Text, textEstado.Text);
            dataGridListadoRoles.DataSource = clientesFiltro;
        }

        private DataTable filtrarRol(string rol, string estado)
        {
            DataTable tablaRoles = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (rol != "") filtrosBusqueda.Add("Rol LIKE '%" + rol + "%'");
            if (estado != "") filtrosBusqueda.Add("Estado LIKE '%" + estado + "%'");

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
            if (tablaRoles != null)
                tablaRoles.DefaultView.RowFilter = final_rol;
            return tablaRoles;
        }

        private void textRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void textEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            if (!rolActivo())
            {
                bool resultado = SqlConnector.executeProcedure("AERO.habilitarRol",
                    funcionesComunes.generarListaParaProcedure("@idRol"), Convert.ToInt32(dataGridListadoRoles.SelectedCells[0].Value));
                if (resultado)
                {
                    MessageBox.Show("El rol fue habilitado exitosamente");
                    listado = funcionesComunes.consultarRoles(dataGridListadoRoles);
                }
            }
            else
            {
                MessageBox.Show("El rol no se encuentra inactivo");
            }
        }
    }
}
