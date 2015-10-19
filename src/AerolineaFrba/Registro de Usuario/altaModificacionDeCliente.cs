﻿using System;
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

        public altaModificacionDeCliente()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void altaModificacionDeCliente_Load(object sender, EventArgs e)
        {
            if (textBoxTipoForm.Text == "0" || textBoxTipoForm.Text == "1")
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
            //TODO: Acordarse de validar que la fecha sea anteior a hoy y que la edad sea > 18
            if (apellido != "" && nombre != "" && direccion != "" && dni > 0 && telefono > 0)
            {
                if (TimePickerNacimiento.Value < DateTime.Today)
                {
                    bool resultado=true;
                    if (this.textBoxTipoForm.Text == "1")
                    {
                        this.setearParaCompras();
                    }
                    else
                       resultado=  this.persistirCliente();
                    if (resultado)
                    {
                        MessageBox.Show("Se guardo exitosamente");
                        botonLimpiar.PerformClick();
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
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void setearParaCompras()
        {
            Form anterior = funcionesComunes.getVentanaAnterior();
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
                                ((TextBox)subgb.Controls["textBoxApellidoPas"]).Text = this.textBoxApellido.Text;
                                ((TextBox)subgb.Controls["textBoxNombrePas"]).Text = this.textBoxNombre.Text;
                                ((TextBox)subgb.Controls["textBoxDireccionPas"]).Text = this.textBoxDireccion.Text;
                                ((TextBox)subgb.Controls["textBoxMailPas"]).Text = this.textBoxMail.Text;
                                ((TextBox)subgb.Controls["textBoxTelefonoPas"]).Text = this.textBoxTelefono.Text;
                                ((DateTimePicker)subgb.Controls["timePickerFecha"]).Value = this.TimePickerNacimiento.Value;
                            }
                        }
                    }
                }
            }
            funcionesComunes.habilitarAnterior();
        }

        private bool persistirCliente()
        {
            List<string> lista = new List<string>();
            lista.Add("@rol_id");
            lista.Add("@nombreCliente");
            lista.Add("@apellidoCliente");
            lista.Add("@documentoCliente");
            lista.Add("@direccion");
            lista.Add("@telefono");
            lista.Add("@mail");
            lista.Add("@fechaNac");
            bool resultado = SqlConnector.executeProcedure("AERO.agregarCliente", lista,
                funcionesComunes.getIdRolCliente(), nombre, apellido, dni, direccion,
                telefono, mail, String.Format("{0:yyyyMMdd HH:mm:ss}", this.TimePickerNacimiento.Value));
            return resultado;
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            this.setearCamposIngresados();
            if (direccion != "" && telefono > 0)
            {
                List<string> lista = new List<string>();
                lista.Add("@id");
                lista.Add("@direccion");
                lista.Add("@telefono");
                lista.Add("@mail");
                bool resultado = SqlConnector.executeProcedure("AERO.updateCliente", lista, id,
                    direccion, telefono, mail);
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
