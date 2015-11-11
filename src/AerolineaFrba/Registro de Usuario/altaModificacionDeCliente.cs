using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class altaModificacionDeCliente : Form
    {
        string nombre;
        string apellido;
        long dni;
        long telefono;
        string direccion;
        string mail;
        string id;

        public altaModificacionDeCliente(int valor, string titulo)
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            textBoxTipoForm.Text = valor.ToString();
        }

        public altaModificacionDeCliente(int valor, string titulo, string dni)
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            textBoxTipoForm.Text = valor.ToString();
            textBoxDNI.Text = dni;
            textBoxDNI.Enabled = false;
            lblDni.Visible = false;
            botonVolver.Visible = false;
        }

        public altaModificacionDeCliente(int valor, string titulo, string id, string nombre, string apellido, string dni, string direccion, string telefono, string mail, DateTime fecha)
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            textBoxTipoForm.Text = valor.ToString();
            textBoxId.Text = id;
            textBoxNombre.Text = nombre;
            textBoxApellido.Text = apellido;
            textBoxDNI.Text = dni;
            textBoxDireccion.Text = direccion;
            textBoxTelefono.Text = telefono;
            textBoxMail.Text = mail;
            TimePickerNacimiento.Value = fecha;
            textBoxApellido.Enabled = false;
            textBoxNombre.Enabled = false;
            TimePickerNacimiento.Enabled = false;
            textBoxDNI.Enabled = false;
            lblApellido.Visible = false;
            lblDni.Visible = false;
            lblNombre.Visible = false;
            lblNacimiento.Visible = false;

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void altaModificacionDeCliente_Load(object sender, EventArgs e)
        {
            if (textBoxTipoForm.Text == "0" || textBoxTipoForm.Text == "1" || textBoxTipoForm.Text == "2")
            {
                botonModificar.Visible = false;
            }
            else
            {
                botonGuardar.Visible = false;
                botonLimpiar.Visible = false;
                textBoxNombre.Enabled = false;
                textBoxApellido.Enabled = false;
                textBoxDNI.Enabled = false;
                TimePickerNacimiento.Enabled = false;
            }
        }

        private void limpiar()
        {
            this.textBoxId.Clear();
            this.textBoxApellido.Clear();
            this.textBoxDireccion.Clear();
            this.textBoxMail.Clear();
            this.textBoxNombre.Clear();
            this.textBoxTelefono.Clear();
            if(this.textBoxTipoForm.Text != "1")
                 this.textBoxDNI.Clear();
            this.TimePickerNacimiento.ResetText();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            this.setearCamposIngresados();
            if (apellido != "" && nombre != "" && direccion != "" && dni > 0 && telefono > 0)
            {
                if (mail.Contains("@") || mail == "")
                {

                    if (TimePickerNacimiento.Value < DateTime.Today)
                    {
                        bool resultado = true;
                        if (this.textBoxTipoForm.Text == "1" || this.textBoxTipoForm.Text == "0")
                        {

                            resultado = this.persistirCliente();
                        }
                       
                            
                        if (textBoxTipoForm.Text == "2")
                        {
                            DataTable tabla = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT TOP 1 c.ID as id
                                                                    FROM " + SqlConnector.getSchema() + @".clientes c
                                                                    order by 1 desc");
                            Form anterior = funcionesComunes.getVentanaAnterior();
                            ((TextBox)anterior.Controls["textBoxIdCliente"]).Text = Convert.ToString(tabla.Rows[0].ItemArray[0]);
                            funcionesComunes.habilitarAnterior();
                            return;
                        }
                        if (resultado)
                        {
                            MessageBox.Show("Se guardo exitosamente");
                            if (textBoxTipoForm.Text == "1")
                            {
                                this.setearParaCompras();
                            }
                            if (textBoxTipoForm.Text == "0")
                            {
                                funcionesComunes.habilitarAnterior();
                            }
                            botonLimpiar.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("No se puede guardar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La fecha de nacimiento debe ser anterior a la fecha actual",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mail invalido", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
        }

        private void setearParaCompras()
        {
            Form anterior = funcionesComunes.getVentanaAnterior();
            ((TextBox)anterior.Controls["textBoxIdCliente"]).Text = "0";
            foreach (Control gb in anterior.Controls)
            {
                if (gb is GroupBox)
                {
                    if (gb.Name == "groupBox1")
                    {
                        foreach (Control subgb in gb.Controls)
                        {
                            if (subgb.Name == "groupBox2")
                            {
                                ((TextBox)subgb.Controls["textBoxApellido"]).Text = this.textBoxApellido.Text;
                                ((TextBox)subgb.Controls["textBoxNombre"]).Text = this.textBoxNombre.Text;
                                ((TextBox)subgb.Controls["textBoxDireccion"]).Text = this.textBoxDireccion.Text;
                                ((TextBox)subgb.Controls["textBoxMail"]).Text = this.textBoxMail.Text;
                                ((TextBox)subgb.Controls["textBoxTelefono"]).Text = this.textBoxTelefono.Text;
                                ((DateTimePicker)subgb.Controls["timePickerNacimiento"]).Value = this.TimePickerNacimiento.Value;
                            }
                        }
                    }
                }
            }
            funcionesComunes.habilitarAnterior();
        }

        private bool persistirCliente()
        {
            bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".agregarCliente",
                funcionesComunes.generarListaParaProcedure("@rol_id", "@nombreCliente","@apellidoCliente",
                "@documentoCliente","@direccion","@telefono","@mail","@fechaNac"),
                funcionesComunes.getIdRolCliente(), nombre, apellido, dni, direccion,
                telefono, mail, String.Format("{0:yyyyMMdd HH:mm:ss}", this.TimePickerNacimiento.Value));
            return resultado;
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            this.setearCamposIngresados();
            if (direccion != "" && telefono > 0)
            {
                bool resultado = SqlConnector.executeProcedure(SqlConnector.getSchema() + ".updateCliente",
                    funcionesComunes.generarListaParaProcedure("@id", "@direccion","@telefono","@mail"),
                    id, direccion, telefono, mail);
                if (resultado)
                {
                    MessageBox.Show("Se modificó exitosamente");
                    funcionesComunes.habilitarAnterior();
                }
            }
            else
            {
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }


        private void setearCamposIngresados()
        {
            id = this.textBoxId.Text;
            apellido = this.textBoxApellido.Text;
            nombre = this.textBoxNombre.Text;
            direccion = this.textBoxDireccion.Text;
            telefono = 0;
            if (this.textBoxTelefono.Text != "")
            {
                telefono = long.Parse(textBoxTelefono.Text);
            }
            dni = 0;
            if (this.textBoxDNI.Text != "")
            {
                dni = long.Parse(this.textBoxDNI.Text);
            }

            mail = this.textBoxMail.Text;
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void textBoxDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetrasYNumeros(e);
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloMail(e);
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }
    }
}
