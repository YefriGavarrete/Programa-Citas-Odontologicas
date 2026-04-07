using Sistema.Clases;
using Sistema.Clases.ClaseDentista;
using Sistema.Clases.ClaseDentista.DentistaModelo;
using Sistema.Clases.ClaseEspecialidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Sistema.Formularios.FormDentistas
{
    public partial class DentistasForm : Form
    {
        public DentistasForm()
        {
            InitializeComponent();
            MostrarDentistas("Activo");
            CargarCB();
            lblOperacion.Text = "Agregando";
            rbActivos.Checked = true;
        }

        ConsultasSQL con = new ConsultasSQL();
        AlertasDelSistema Al = new AlertasDelSistema();
        private void CargarCB() {

            DataTable dt = con.Buscar("Especialidad", "Id_Especialidad, Especialidad", "Estado = 'Activo'");

            int idespeci = Convert.ToInt32(dt.Rows[0]["Id_Especialidad"]);
            string especi = dt.Rows[0]["Especialidad"].ToString();

            EspecialidadMO.EspecialidadDatos(idespeci, especi);

            CBEsp.Items.Clear();

            foreach (DataRow fila in dt.Rows)
            {
                CBEsp.Items.Add(fila["Especialidad"].ToString());
            }

            if (CBEsp.Items.Count > 0)
                CBEsp.SelectedIndex = 0;
        }

        void GuardarD()
        {
            DentistaMO MO = new DentistaMO();
            AlertasDelSistema AL = new AlertasDelSistema();

            EspecialidadMO.Especialidad = CBEsp.Text;
            int id = EspecialidadMO.Id_Especialidad;
            string esp = EspecialidadMO.Especialidad;
             if (MO.Especialidad == esp)
            {
                MO.Id_Especialidad = id;
            }
            MO.Nombre = txtNombre.Text;
            MO.Apellido = txtApellido.Text;

            if(CEstado.Checked == true)
            {
                MO.Estado = "Activo";
            }
            else
            {
                MO.Estado = "Inactivo";
            }

            string columnas = "Id_Especialidad,Nombre,Apellido,Estado, Especialidad";
            string valores = $"'{EspecialidadMO.Id_Especialidad}','{MO.Nombre}','{MO.Apellido}','{(MO.Estado)}','{EspecialidadMO.Especialidad}'";

            if (con.Guardar("Dentistas", columnas, valores))
            {
                AL.Realizado($"El Dentista {MO.Nombre} se registro con éxito");
                MostrarDentistas("Activo");
                Limpiar();
                lblOperacion.Text = "Agregando";
                btnGuardar.Text = "Guardar";
            }
        }

        void ActualizarD()
        {
            string AC = "¿Desea actualizar la informacion del dentista?";

            if (Al.Confirmacion(AC))
            {
                string IDA = txtID.Text.Trim();
                string NomA = txtNombre.Text.Trim();
                string ApeA = txtApellido.Text.Trim();
                string EspeA = CBEsp.Text.Trim();
                string EstaA;

                if (CEstado.Checked == true)
                {
                    EstaA = "Activo";
                }
                else
                {
                    EstaA = "Inactivo";
                }

                string columnas = $"Nombre = '{NomA}'," + $"Apellido = '{ApeA}',"  + $"Estado = '{EstaA}'," + $"Especialidad = '{EspeA}'";
                string condicion = $"Id_Dentista = '{IDA}'";

                if (con.update("Dentistas", columnas, condicion) > 0)
                {
                    Al.Realizado("Los datos se actualizaron con exito");
                    MostrarDentistas("Activo");
                    Limpiar();
                  //  btnActualizar.Visible = false;
                  //  btnActualizar.Enabled = false;
                   // btnGuardar.Visible = true;
                  //  btnGuardar.Enabled = true;
                    lblOperacion.Text = "Agregando";
                    btnGuardar.Text = "Guardar";
                }
                else
                {
                    Al.Realizado("No se logro actualizar");
                    lblOperacion.Text = "Agregando";
                    btnGuardar.Text = "Guardar";
                }

            }

        }

        void Obtenerdatos(DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgbDentista.Rows[e.RowIndex];
            txtID.Text = fila.Cells["Id_Dentista"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
            CBEsp.Text = fila.Cells["Especialidad"].Value.ToString();
             if(fila.Cells["Estado"].Value.ToString() == "Activo")
            {
                CEstado.Checked = true;
            }
            else
            {
                CEstado.Checked = false;
            }

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


        bool validar()
        {
            AlertasDelSistema AL = new AlertasDelSistema();
            bool V = true;

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(CBEsp.Text))
            {
                AL.Advertencia("Por favor, complete todos los campos vacios.");
                V = false;
            }
            else
            {
                V = true;
            }

            return V;
        }


        void Limpiar()
        {
            txtID.Text = null;
            txtNombre.Text= null;
            txtApellido.Text= null;
            CEstado.Checked = false;
            //CBEsp.Text = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Agregando")
            {
                if (validar() == true)
                {
                    GuardarD();
                }
            }
            else
                ActualizarD();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblOperacion.Text = "Agregando";
            btnGuardar.Text = "Guardar";
            // btnGuardar.Enabled = true;
            // btnGuardar.Visible = true;
            // btnActualizar.Enabled = false;
            // btnActualizar.Visible = false;
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDentistas("Activo");
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarDentistas("Inactivo");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarD();
        }

        private void dgbDentista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblOperacion.Text = "Actualizando";
            btnGuardar.Text = "Actualizar";
            //btnGuardar.Enabled = false;
            //btnGuardar.Visible = false;
            //btnActualizar.Enabled = true;
            // btnActualizar.Visible = true;
            Obtenerdatos(e);
        }
    }
}
