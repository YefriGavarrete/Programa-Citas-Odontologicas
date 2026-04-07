using Sistema.Clases;
using Sistema.FormLoginMenu;
using Sistema.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.FormLogin
{
    public partial class LoginForm : Form
    {
        AlertasDelSistema Alertas = new AlertasDelSistema();
        ConsultarUsuario consultaUsuario = new ConsultarUsuario();

        public LoginForm()
        {
            InitializeComponent();
        }

        public void IniciarSesion()
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text ?? string.Empty;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                Alertas.Advertencia("Ingrese usuario y contraseña.");
                return;
            }

            try
            {
                btnIngresar.Text = "Validando..."; 
                btnIngresar.FillColor = Color.Gray;
                btnIngresar.ForeColor = Color.LightGray;

                bool acceso = consultaUsuario.BuscarUsuario("UsuariosLogin", usuario, clave);
                if (acceso)
                {
                    var menu = new MenuForm();
                    menu.StartPosition = FormStartPosition.CenterScreen;
                    menu.FormClosed += (s, args) =>
                    {
                        this.Show();
                    };
                    menu.Show();
                    this.Hide();
                }

                    btnIngresar.Text = "Ingresar";
                    btnIngresar.FillColor = Color.DodgerBlue;
                    btnIngresar.ForeColor = Color.White;
                
                    
            }
            catch(Exception ex)
            { 
                Alertas.Advertencia($"Error al iniciar sesión: {ex.Message}");
                btnIngresar.Text = "Ingresar";
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
            }
        }
    }
}
