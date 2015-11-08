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
    public partial class altaModificacionDeRol : Form
    {
        int idFuncionalidad;
        int idRol;
        public altaModificacionDeRol()
        {
            InitializeComponent();
        }

        private void altaModificacionDeRol_Load(object sender, EventArgs e)
        {
            cargarComboBoxFuncionalidades();
            if (textTipoForm.Text == "0")
            {
                botonAgregar.Enabled = false;
                botonQuitar.Enabled = false;
                botonAsignar.Enabled = false;
                comboBoxUsers.Enabled = false;
                comboBoxFuncionalidades.Enabled = false;
            }else{
                funcionesComunes.consultarFuncionalidadesDelRol(Convert.ToInt32(textId.Text), 
                    dataGridFuncionalidades);
                botonCrearRol.Text ="Modificar";
                textRol.Enabled = true;
                cargarComboBoxUsuarios();
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void cargarComboBoxFuncionalidades()
        {
            funcionesComunes.llenarCombobox(comboBoxFuncionalidades, "DETALLES", @"select f.ID, 
                f.DETALLES from aero.funcionalidades f order by f.DETALLES");           
        }

        private void cargarComboBoxUsuarios()
        {
            funcionesComunes.llenarCombobox(comboBoxUsers, "USERNAME", @"select DISTINCT u.ID, u.USERNAME from aero.usuarios u, 
                aero.roles_por_usuario ru, AERO.roles r where ru.USUARIO_ID = u.ID and ru.ROL_ID = r.ID and '" + textRol.Text + 
                @"' not in (select r2.NOMBRE from aero.roles_por_usuario ru2, AERO.roles r2 where ru2.ROL_ID = r2.ID and 
                ru2.USUARIO_ID = u.ID)");
        }

        private void botonCrearRol_Click(object sender, EventArgs e)
        {
            //Aca haria todo el procedure de creacion de Rol en la tabla roles, me devuelve el Id y lo guardo en textId
            //Si guarda bien hace lo siguiente:
            if (this.textTipoForm.Text == "0")
            {
                if (textRol.Text.Trim() != "")
                {
                     DataTable tabla_rol = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT NOMBRE FROM AERO.ROLES WHERE NOMBRE ='" + this.textRol.Text + "'");
                     if (tabla_rol.Rows.Count == 0)
                     {
                         int id = SqlConnector.executeProcedureWithReturnValue("AERO.agregarRol",
                          funcionesComunes.generarListaParaProcedure("@nombreRol"), textRol.Text);
                         if (id != -1)
                         {
                             MessageBox.Show("El rol fue creado exitosamente");
                             botonCrearRol.Enabled = false;
                             botonAgregar.Enabled = true;
                             botonQuitar.Enabled = true;
                             this.textRol.Enabled = false;
                             idRol = id;
                             textId.Text = Convert.ToString(idRol);
                             botonAsignar.Enabled = true;
                             comboBoxUsers.Enabled = true;
                             comboBoxFuncionalidades.Enabled = true;
                             cargarComboBoxUsuarios();
                         }
                         else
                         {
                             MessageBox.Show("Ocurrio un error al intentar crear el rol");
                         }
                     }
                     else
                     {
                         MessageBox.Show("Ese rol ya existe");
                     }
                }
                else
                    MessageBox.Show("Debe poner un nombre al rol");
            }
            else 
            {
                if (textRol.Text.Trim() != "")
                {
                    bool resultado = SqlConnector.executeProcedure("AERO.cambiarNombreRol",
                    funcionesComunes.generarListaParaProcedure("@idRol","@nombre"),
                    this.textId.Text,this.textRol.Text);
                    if (resultado)
                        MessageBox.Show("Se cambio el nombre del rol correctamente");
                }
                else
                {
                    MessageBox.Show("Debe poner un nombre al rol");
                }
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            if (comboBoxFuncionalidades.SelectedIndex != -1)
            {
                idFuncionalidad = Convert.ToInt32(comboBoxFuncionalidades.SelectedValue);
                idRol = Convert.ToInt32(textId.Text);
                if (!(existeFuncionalidad(idFuncionalidad)))
                {
                    SqlConnector.executeProcedure("AERO.agregarFuncionalidad",
                        funcionesComunes.generarListaParaProcedure("@idRol", "@idFunc"), idRol, idFuncionalidad);
                    funcionesComunes.consultarFuncionalidadesDelRol(Convert.ToInt32(textId.Text),
                        dataGridFuncionalidades);
                }
                else
                {
                    MessageBox.Show("La funcionalidad seleccionada ya existe");
                }
            }
        }

        private bool existeFuncionalidad(int idFuncionalidad)
        {
            foreach (DataGridViewRow row in dataGridFuncionalidades.Rows){
                if (Convert.ToInt32(row.Cells[0].Value) == idFuncionalidad)
                {
                    return true;
                }
            }
            return false;
        }

        private void botonQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridFuncionalidades.Rows.Count > 0)
            {
                idFuncionalidad = Convert.ToInt32(dataGridFuncionalidades.SelectedCells[0].Value);
                idRol = Convert.ToInt32(textId.Text);
                SqlConnector.executeProcedure("AERO.quitarFuncionalidad",
                    funcionesComunes.generarListaParaProcedure("@idRol", "@idFunc"), idRol, idFuncionalidad);
                funcionesComunes.consultarFuncionalidadesDelRol(Convert.ToInt32(textId.Text),
                        dataGridFuncionalidades);
            }
        }

        private void botonAsignar_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedIndex != -1)
            {
                SqlConnector.executeProcedure("AERO.asignarRol", funcionesComunes.generarListaParaProcedure("@idRol", "@idUser"),
                    textId.Text, comboBoxUsers.SelectedValue.ToString());
                MessageBox.Show("El usuario fue asignado correctamente");
                comboBoxUsers.DataSource = null;
                cargarComboBoxUsuarios();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario al cual asignar el rol");
            }
        }
    }
}
