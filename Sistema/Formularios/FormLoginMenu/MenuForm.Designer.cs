namespace Sistema.FormLoginMenu
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.Minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.btnUsuarios = new Guna.UI2.WinForms.Guna2Button();
            this.btnEspecialidades = new Guna.UI2.WinForms.Guna2Button();
            this.btnDentistas = new Guna.UI2.WinForms.Guna2Button();
            this.btnPacientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnCitas = new Guna.UI2.WinForms.Guna2Button();
            this.btnInicioMenu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.LogoInicio = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.guna2Separator1);
            this.panel2.Controls.Add(this.Minimizar);
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 39);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "AgendaSonrisas - Sistema de Citas Odontólogicas";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblUsuario.Location = new System.Drawing.Point(700, 11);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(216, 18);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Nombre Apellido - RolUsuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(668, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(1, 33);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1050, 10);
            this.guna2Separator1.TabIndex = 3;
            // 
            // Minimizar
            // 
            this.Minimizar.BackColor = System.Drawing.Color.Transparent;
            this.Minimizar.BorderRadius = 7;
            this.Minimizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.Minimizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Minimizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Minimizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Minimizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Minimizar.FillColor = System.Drawing.Color.Transparent;
            this.Minimizar.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimizar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Minimizar.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.Minimizar.HoverState.ForeColor = System.Drawing.Color.White;
            this.Minimizar.Location = new System.Drawing.Point(939, 4);
            this.Minimizar.Name = "Minimizar";
            this.Minimizar.Size = new System.Drawing.Size(40, 29);
            this.Minimizar.TabIndex = 4;
            this.Minimizar.Text = "-";
            this.Minimizar.Click += new System.EventHandler(this.Minimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BorderRadius = 7;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCerrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrar.FillColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnCerrar.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnCerrar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(983, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 29);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.guna2VSeparator1);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnEspecialidades);
            this.panel1.Controls.Add(this.btnDentistas);
            this.panel1.Controls.Add(this.btnPacientes);
            this.panel1.Controls.Add(this.btnCitas);
            this.panel1.Controls.Add(this.btnInicioMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 513);
            this.panel1.TabIndex = 2;
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Location = new System.Drawing.Point(209, -6);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(10, 513);
            this.guna2VSeparator1.TabIndex = 3;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BorderRadius = 8;
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FillColor = System.Drawing.Color.SlateGray;
            this.btnUsuarios.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnUsuarios.Location = new System.Drawing.Point(19, 298);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(160, 34);
            this.btnUsuarios.TabIndex = 85;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.BorderRadius = 8;
            this.btnEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEspecialidades.FillColor = System.Drawing.Color.SlateGray;
            this.btnEspecialidades.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnEspecialidades.ForeColor = System.Drawing.Color.White;
            this.btnEspecialidades.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnEspecialidades.Location = new System.Drawing.Point(19, 248);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(160, 34);
            this.btnEspecialidades.TabIndex = 84;
            this.btnEspecialidades.Text = "Especialidades";
            // 
            // btnDentistas
            // 
            this.btnDentistas.BorderRadius = 8;
            this.btnDentistas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDentistas.FillColor = System.Drawing.Color.SlateGray;
            this.btnDentistas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDentistas.ForeColor = System.Drawing.Color.White;
            this.btnDentistas.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnDentistas.Location = new System.Drawing.Point(19, 197);
            this.btnDentistas.Name = "btnDentistas";
            this.btnDentistas.Size = new System.Drawing.Size(160, 34);
            this.btnDentistas.TabIndex = 83;
            this.btnDentistas.Text = "Odontólogos";
            this.btnDentistas.Click += new System.EventHandler(this.btnDentistas_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.BorderRadius = 8;
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FillColor = System.Drawing.Color.SlateGray;
            this.btnPacientes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnPacientes.Location = new System.Drawing.Point(19, 142);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(160, 34);
            this.btnPacientes.TabIndex = 82;
            this.btnPacientes.Text = "Pacientes";
            // 
            // btnCitas
            // 
            this.btnCitas.BorderRadius = 8;
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.FillColor = System.Drawing.Color.SlateGray;
            this.btnCitas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCitas.ForeColor = System.Drawing.Color.White;
            this.btnCitas.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnCitas.Location = new System.Drawing.Point(19, 88);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(160, 34);
            this.btnCitas.TabIndex = 81;
            this.btnCitas.Text = "Citas";
            // 
            // btnInicioMenu
            // 
            this.btnInicioMenu.BorderRadius = 8;
            this.btnInicioMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicioMenu.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnInicioMenu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInicioMenu.ForeColor = System.Drawing.Color.White;
            this.btnInicioMenu.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnInicioMenu.Location = new System.Drawing.Point(19, 34);
            this.btnInicioMenu.Name = "btnInicioMenu";
            this.btnInicioMenu.Size = new System.Drawing.Size(160, 34);
            this.btnInicioMenu.TabIndex = 80;
            this.btnInicioMenu.Text = "Inicio";
            this.btnInicioMenu.Click += new System.EventHandler(this.btnInicioMenu_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Controls.Add(this.LogoInicio);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(215, 39);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(817, 513);
            this.panelContenedor.TabIndex = 3;
            // 
            // LogoInicio
            // 
            this.LogoInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoInicio.Image = ((System.Drawing.Image)(resources.GetObject("LogoInicio.Image")));
            this.LogoInicio.Location = new System.Drawing.Point(0, 0);
            this.LogoInicio.Name = "LogoInicio";
            this.LogoInicio.Size = new System.Drawing.Size(817, 513);
            this.LogoInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoInicio.TabIndex = 7;
            this.LogoInicio.TabStop = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1032, 552);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoInicio)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2Button Minimizar;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnInicioMenu;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private System.Windows.Forms.Panel panelContenedor;
        private Guna.UI2.WinForms.Guna2Button btnDentistas;
        private Guna.UI2.WinForms.Guna2Button btnPacientes;
        private Guna.UI2.WinForms.Guna2Button btnCitas;
        private Guna.UI2.WinForms.Guna2Button btnEspecialidades;
        private Guna.UI2.WinForms.Guna2Button btnUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox LogoInicio;
        private System.Windows.Forms.Label label1;
    }
}