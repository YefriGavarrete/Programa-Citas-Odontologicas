using Sistema.Clases;
using Sistema.Clases.ClasesCitas;
using Sistema.Formularios;
using Sistema.Formularios.FormDentistas;
using Sistema.Formularios.FormPacientes;
using Sistema.Formularios.FormRecepView;
using Sistema.Formularios.FormUsuarios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema.FormLoginMenu
{
    public partial class MenuForm : Form
    {
        int m, mx, my;
        const int AnchoBtnNormal = 160;
        const int AnchoBtnActivo = 180;
        const int AlturaBtn      = 34;

        public MenuForm()
        {
            InitializeComponent();
            MarcarBotonActivo(btnInicioMenu);

            lblUsuario.Text = $"{UsuarioLogeado.Nombre} {UsuarioLogeado.Apellido} - {UsuarioLogeado.Rol}";
        }
        public void AbrirFormEnPanel(Form form)
        {
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock     = DockStyle.Fill;
            panelContenedor.Controls.Add(form);
            panelContenedor.Tag = form;
            form.Show();
        }

        public void MarcarBotonActivo(Guna.UI2.WinForms.Guna2Button btnActivo)
        {
            var botones = new[]
            {
                btnInicioMenu, btnCitas, btnPacientes,
                btnDentistas, btnEspecialidades, btnUsuarios
            };

            foreach (var btn in botones)
            {
                if (btn == null) continue;
                btn.FillColor = Color.SlateGray;
                btn.ForeColor = Color.White;

                if (btn == btnPacientes)
                    btn.Size = new Size(AnchoBtnNormal, 49);
                else
                    btn.Size      = new Size(AnchoBtnNormal, AlturaBtn);
            }

            if (btnActivo == null) return;

            btnActivo.FillColor = Color.DodgerBlue;
            btnActivo.ForeColor = Color.White;

            if (btnActivo == btnPacientes)
                btnActivo.Size      = new Size(AnchoBtnActivo, 49);
            else
                btnActivo.Size = new Size(AnchoBtnActivo, AlturaBtn);
        }


        private void btnInicioMenu_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new InicioLOGO());
            MarcarBotonActivo(btnInicioMenu);
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new CitasForm());
            this.BeginInvoke((Action)(() => MarcarBotonActivo(btnCitas)));
        }

        public void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new PacientesForm());
            this.BeginInvoke((Action)(() => MarcarBotonActivo(btnPacientes)));
        }

        private void btnDentistas_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado.Rol == "Recepcionista")
            {
                AbrirFormEnPanel(new ViewRecepcion());
                this.BeginInvoke((Action)(() => MarcarBotonActivo(btnDentistas)));
            }
            else
            {
                AbrirFormEnPanel(new DentistasForm());
                this.BeginInvoke((Action)(() => MarcarBotonActivo(btnDentistas)));
            }
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new EspecialidadesForm());
            this.BeginInvoke((Action)(() => MarcarBotonActivo(btnEspecialidades)));
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormCrearUsuarios());
            this.BeginInvoke((Action)(() => MarcarBotonActivo(btnUsuarios)));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m  = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void btnDentistasEspecialidades_Click(object sender, EventArgs e)
        {

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // Recepcionistas no pueden gestionar usuarios
            if (UsuarioLogeado.Rol == "Recepcionista")
            {
                btnUsuarios.Visible = false;
                btnEspecialidades.Visible = false;
                btnDentistas.Text = "Lista Dentistas";
            }                
        }
        private void inicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnUsuarios);
            AbrirFormEnPanel(new FormCrearUsuarios());
        }
    }
}
