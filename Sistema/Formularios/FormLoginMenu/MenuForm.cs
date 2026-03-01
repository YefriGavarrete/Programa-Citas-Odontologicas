using Sistema.Clases;
using Sistema.Formularios;
using Sistema.Formularios.FormDentistas;
using Sistema.Formularios.FormUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.FormLoginMenu
{
    public partial class MenuForm : Form
    {
        int m , mx, my;

        public MenuForm()
        {
            InitializeComponent();

            btnInicioMenu.FillColor = Color.DodgerBlue;
            btnInicioMenu.Size = new Size(175, 34);

            lblUsuario.Text = $"{UsuarioLogeado.Nombre + " " + UsuarioLogeado.Apellido + " - " + UsuarioLogeado.Rol}";
        }

        void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        void btnInteractivo(Form form)
        {
            // cambiar de color el boton seleccionado segun el formulario abierto
            Color defaul = Color.SlateGray;
            Color activo = Color.DodgerBlue;

            // lista de botones del menu lateral
            var botones = new[] { btnInicioMenu, btnCitas, btnPacientes, btnDentistas, btnEspecialidades, btnUsuarios };

            // resetear todos a color por defecto
            foreach (var btn in botones)
            {
                if (btn != null)
                {
                    btn.FillColor = defaul;
                    btn.ForeColor = Color.White;
                    btn.Size = new Size(160, 34);
                }
            }

            if (form == null)
                return; // sin formulario activo

            // marcar boton activo segun el tipo de formulario
            if(form is InicioLOGO)
            {
                btnInicioMenu.FillColor = activo;
                btnInicioMenu.Size = new Size(175, 34);
            }
            else if (form is FormCrearUsuarios)
            {
                btnUsuarios.FillColor = activo;
                btnUsuarios.Size = new Size(175, 34);
            }
            else if (form is DentistasForm)
            {
                btnDentistas.FillColor = activo;
                btnDentistas.Size = new Size(175, 34);
            }
        }

        void newFomr(Form newFORM)
        {
            newFORM.ShowDialog();
        }

        private void inicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFomr(new FormCrearUsuarios());
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var form = new FormCrearUsuarios();
            AbrirFormEnPanel(form);
            btnInteractivo(form);
        }

        private void btnInicioMenu_Click(object sender, EventArgs e)
        {
            var form = new InicioLOGO();
            AbrirFormEnPanel(form);
            btnInteractivo(form);
        }

        private void btnDentistas_Click(object sender, EventArgs e)
        {
            var form = new DentistasForm();
            AbrirFormEnPanel(form);
            btnInteractivo(form);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            string user = UsuarioLogeado.Rol;
            if (user == "Recepcionista")
                btnUsuarios.Visible = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
