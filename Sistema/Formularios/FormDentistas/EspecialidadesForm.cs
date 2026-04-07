using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Clases;
using Sistema.Clases.ClaseEspecialidad;

namespace Sistema.Formularios.FormDentistas
{
    public partial class EspecialidadesForm : Form
    {
        public EspecialidadesForm()
        {
            InitializeComponent();
            MostrarEspecialidad("Activo");
            rbActivos.Checked = true;
        }

        ConsultasSQL con = new ConsultasSQL();
        AlertasDelSistema Al = new AlertasDelSistema();

        string estado = "";

        void GuardarEspecialidad()
        {
            EspecialidadMO MO = new EspecialidadMO();
            AlertasDelSistema AL = new AlertasDelSistema();

            EspecialidadMO.Especialidad = txtEspecialidad.Text;

            if (CEstado.Checked == true)
            {
                EspecialidadMO.Estado = "Activo";
            }
            else
            {
                EspecialidadMO.Estado = "Inactivo";
            }

            string columnas = "Especialidad,Estado";
            string valores = $"'{EspecialidadMO.Especialidad}','{(EspecialidadMO.Estado)}'";

            if (con.Guardar("Especialidad", columnas, valores)) 
            {
                AL.Realizado($"La Especialidad {EspecialidadMO.Especialidad} se ha guardado correctamente.");
                MostrarEspecialidad("Activo");
                Limpiar();
            }
        }
        void ActualizarEspecialidad()
        {
            string AC = "¿Desea actualizar la informacion de la Especialidad?";

            if (Al.Confirmacion(AC))
            {
                string IDA = txtID.Text.Trim();
                string NomE = txtEspecialidad.Text.Trim();
                string EstaA;

                if (CEstado.Checked == true)
                {
                    EstaA = "Activo";
                }
                else
                {
                    EstaA = "Inactivo";
                }

                string Act = $"Especialidad = '{NomE}'," + $"Estado = '{EstaA}'";
                string condicion = $"Id_Especialidad = '{IDA}'";

                if (con.update("Especialidad", Act, condicion) > 0)
                {
                    Al.Realizado("Los datos se actualizaron con exito");
                    MostrarEspecialidad("Activo");
                    Limpiar();
                   //btnActualizar.Visible = false;
                    btnActualizar.Enabled = false;
                    btnGuardar.Visible = true;
                    btnGuardar.Enabled = true;
                }
                else
                {
                    Al.Realizado("No se logro actualizar");
                }

            }

        }
        void EliminarEspecialidad()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                Al.Advertencia("Seleccione primero la especialidad a eliminar.");
                return;
            }

            string mensaje = $"¿Desea eliminar la especialidad '{txtEspecialidad.Text}'?";
            if (!Al.Confirmacion(mensaje)) return;

            // Evitar múltiples clicks
            btnEliminar.Enabled = false;
            try
            {
                string condicion = $"Id_Especialidad = '{txtID.Text.Trim()}'";
                int filas = con.Eliminar("Especialidad", condicion);

                if (filas > 0)
                {
                    Al.Realizado("La especialidad se eliminó correctamente.");
                    MostrarEspecialidad("Activo");
                    Limpiar();

                    // Restablecer botones
                    //btnActualizar.Visible = false;
                    btnActualizar.Enabled = false;
                    //btnEliminar.Visible = false;
                    btnEliminar.Enabled = false;
                    btnGuardar.Visible = true;
                    btnGuardar.Enabled = true;
                }
                else
                {
                    Al.Advertencia("No se pudo eliminar la especialidad.");
                }
            }
            finally
            {
                btnEliminar.Enabled = false;
            }
        }

        void MostrarEspecialidad(string estado)  
        {
            string columnas = "Id_Especialidad, Especialidad, Estado";
            string condicion = $"Estado = '{estado}'";
            DataTable dt = con.Buscar("Especialidad", columnas, condicion);
            dgvEspecialidad.DataSource = dt;
            dgvEspecialidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEspecialidad.Refresh();
        }
        void Limpiar()
        {
            txtID.Text = null;
            txtEspecialidad.Text = null;
            CEstado.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar() == true)
            {
                lblOperacion.Text = "Agregando";
                GuardarEspecialidad();
                lblOperacion.Text = "Operacion";
            }
        }
        bool validar()
        {
            AlertasDelSistema AL = new AlertasDelSistema();
            bool V = true;

            if (string.IsNullOrEmpty(txtEspecialidad.Text))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;
            btnActualizar.Enabled = false;
            //btnActualizar.Visible = false;
            btnEliminar.Enabled = false;
            //btnEliminar.Visible = false;
            MostrarEspecialidad("Activo");
            rbInactivos.Checked = false;
            rbActivos.Checked = true;
             lblOperacion.Text = "Operacion";
        }
        void EnviarDatosParaEditar(DataGridViewCellEventArgs e)
        {
            try
            {
                lblOperacion.Text = "Editando";
                lblOperacion.Visible = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvEspecialidad.Rows[e.RowIndex];
                    txtID.Text = fila.Cells["Id_Especialidad"].Value.ToString();
                    txtEspecialidad.Text = fila.Cells["Especialidad"].Value.ToString();
                    estado = fila.Cells["Estado"].Value.ToString();

                    if (estado == "Activo")
                        CEstado.Checked = true;
                    else
                        CEstado.Checked = false;

                    string operacion = lblOperacion.Text;

                    if (operacion == "Editando")
                    {
                        txtID.Enabled = false;
                        txtEspecialidad.Enabled = true;
                        btnActualizar.Enabled = true;
                        btnActualizar.Visible = true;
                        btnEliminar.Enabled = true;
                        btnEliminar.Visible = true;
                        btnGuardar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Al.Advertencia($"Error al cargar datos: {ex.Message}");
                lblOperacion.Visible = false;
            }

        }
        private void dgvEspecialidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //EnviarDatosParaEditar(e);
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarEspecialidad("Activo");
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarEspecialidad("Inactivo");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEspecialidad();
            rbInactivos.Checked = false;
            rbActivos.Checked = true;
            lblOperacion.Text = "Operacion";
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEspecialidad();
            rbInactivos.Checked = false;
            rbActivos.Checked = true;
            lblOperacion.Text = "Operacion";
        }

        private void dgvEspecialidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EnviarDatosParaEditar(e);
        }
    }
}
