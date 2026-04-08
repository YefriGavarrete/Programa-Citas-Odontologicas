using Sistema.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Formularios.FormRecepView
{
    public partial class ViewRecepcion : Form
    {
        ConsultasSQL con = new ConsultasSQL();

        public ViewRecepcion()
        {
            InitializeComponent();
            rbActivos.Checked = true;
            MostrarDentistas("Activo");
            MostrarEspecialidad("Activo");
        }

        void MostrarDentistas(string estado)
        {
            string columnas = "Id_Dentista, Id_Especialidad, Nombre, Apellido, Estado, Especialidad";
            string condicion = $"Estado = '{estado}'";
            DataTable dt = con.Buscar("Dentistas", columnas, condicion);

            dgbDentista.DataSource = dt;
            dgbDentista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ocultar las primeras 2 columnas
            if (dgbDentista.Columns.Count >= 2)
            {
                dgbDentista.Columns["Id_Dentista"].Visible = false;
                dgbDentista.Columns["Id_Especialidad"].Visible = false;
            }

            dgbDentista.Refresh();
        }

        void MostrarEspecialidad(string estado)
        {
            string columnas = "Id_Especialidad, Especialidad, Estado";
            string condicion = $"Estado = '{estado}'";
            DataTable dt = con.Buscar("Especialidad", columnas, condicion);
            dgvEspecialidades.DataSource = dt;
            dgvEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvEspecialidades.Columns.Count >= 2)
            {
                dgvEspecialidades.Columns["Id_Especialidad"].Visible = false;
            }

            dgvEspecialidades.Refresh();
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDentistas("Activo");
            MostrarEspecialidad("Activo");
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDentistas("Inactivo");
            MostrarEspecialidad("Inactivo");
        }
    }
}
