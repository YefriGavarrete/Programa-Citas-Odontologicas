using Guna.UI2.WinForms;
using Sistema.Clases;
using Sistema.Clases.ClasesCitas;
using Sistema.FormLoginMenu;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema.Formularios.FormPacientes
{

    public partial class CitasForm : Form
    {
        Citas controladorCitas = new Citas();
        AlertasDelSistema Alertas = new AlertasDelSistema();
          
        
        //cree esto para que no me olvidara            
        // 0 = modo CREAR  |  > 0 = modo ACTUALIZAR (Id_Cita de la fila seleccionada)
        private int _idCitaEnEdicion = 0;

        public CitasForm()
        {
            InitializeComponent();
            rbInactivos.Text   = "Pendiente";
            rbActivos.Text = "Confirmada";
            lblOperacion.Visible = false;
            rbInactivos.Checked= true;
            CargarDatos();
        }

        void CargarDatos()
        {
            try
            {
                DataTable dtDentistas = controladorCitas.ObtenerDentistas();
                if (dtDentistas != null && dtDentistas.Rows.Count > 0)
                {
                    cmbDentista.DataSource    = dtDentistas;
                    cmbDentista.DisplayMember = "NombreCompleto";
                    cmbDentista.ValueMember   = "Id_Dentista";
                }

                rbPendiente.Checked = true;
                dtpFechaCita.Value = DateTime.Today;
                dtpHoraCita.Value = new DateTime(DateTime.Now.Year, 1, 1, 7, 0, 0);

               
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al cargar datos: {ex.Message}");
            }
        }

        public void GuardarPacienteYCita()
        {
            try
            {
                DataRowView dentistaSel = cmbDentista.SelectedItem as DataRowView;
                string estadoGuardado   = rbPendiente.Checked ? "Pendiente" : "Confirmada";

                CitaModel modelo = new CitaModel
                {
                    NombrePaciente   = txtNombre.Text.Trim(),
                    ApellidoPaciente = txtApellido.Text.Trim(),

                    IdDentista       = dentistaSel != null ? Convert.ToInt32(dentistaSel["Id_Dentista"]) : 0,
                    NombreDentista   = dentistaSel != null ? dentistaSel["Nombre"].ToString()   : string.Empty,
                    ApellidoDentista = dentistaSel != null ? dentistaSel["Apellido"].ToString() : string.Empty,

                    FechaCita     = dtpFechaCita.Value.Date,
                    HoraCita      = dtpHoraCita.Value.TimeOfDay,
                    Estado        = estadoGuardado,
                    MotivoCita    = txtMotivo.Text.Trim(),
                    Observaciones = txtObservaciones.Text.Trim()
                };

                if (_idCitaEnEdicion > 0)
                {
                    bool ok = controladorCitas.ActualizarCita(_idCitaEnEdicion, modelo);
                    if (ok)
                    {
                        LimpiarFormulario();
                        SincronizarFiltroGrid(estadoGuardado);
                        ActualizarGridCitas();
                    }
                }
                else
                {
                    int idCita = controladorCitas.GuardarPacienteYCita(modelo);
                    if (idCita > 0)
                    {
                        LimpiarFormulario();
                        SincronizarFiltroGrid(estadoGuardado);
                        ActualizarGridCitas();
                    }
                }
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error inesperado: {ex.Message}");
            }
        }

        void SincronizarFiltroGrid(string estado)
        {
            if (estado == "Pendiente")
            {
                rbInactivos.CheckedChanged   -= rbInactivos_CheckedChanged;
                rbInactivos.Checked           = true;
                rbInactivos.CheckedChanged   += rbInactivos_CheckedChanged;
            }
            else
            {
                rbActivos.CheckedChanged -= rbActivos_CheckedChanged;
                rbActivos.Checked         = true;
                rbActivos.CheckedChanged += rbActivos_CheckedChanged;
            }
        }

        void EnviarDatosParaEditar(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];
                object idVal = fila.Cells["Id_Cita"].Value;
                if (idVal == null || idVal == DBNull.Value)
                {
                    Alertas.Advertencia("No se pudo determinar el ID de la cita.");
                    return;
                }
                _idCitaEnEdicion = Convert.ToInt32(idVal);

                // Mostrar Id en el textbox (solo visual, ya no determina el modo)
                txtID.Text = _idCitaEnEdicion.ToString();

                txtNombre.Text        = fila.Cells["NombrePaciente"].Value?.ToString()   ?? string.Empty;
                txtApellido.Text      = fila.Cells["ApellidoPaciente"].Value?.ToString() ?? string.Empty;
                txtMotivo.Text        = fila.Cells["Motivo"].Value?.ToString()            ?? string.Empty;
                txtObservaciones.Text = fila.Cells["Observaciones"].Value?.ToString()     ?? string.Empty;

                if (fila.Cells["Id_Dentista"].Value != null)
                    cmbDentista.SelectedValue = Convert.ToInt32(fila.Cells["Id_Dentista"].Value);

                if (fila.Cells["FechaCita"].Value != null)
                    dtpFechaCita.Value = Convert.ToDateTime(fila.Cells["FechaCita"].Value);

                if (fila.Cells["HoraCita"].Value != null &&
                    fila.Cells["HoraCita"].Value != DBNull.Value)
                {
                    object valorHora = fila.Cells["HoraCita"].Value;
                    TimeSpan hora = valorHora is TimeSpan ts
                                    ? ts
                                    : TimeSpan.Parse(valorHora.ToString());

                    dtpHoraCita.Value = new DateTime(2000, 1, 1,
                                                     hora.Hours,
                                                     hora.Minutes,
                                                     hora.Seconds);
                }

                string estado = fila.Cells["Estado"].Value?.ToString() ?? "Pendiente";
                rbPendiente.Checked  = (estado == "Pendiente");
                rbConfirmada.Checked = (estado == "Confirmada");

                lblOperacion.Text    = $"Editando Cita #{_idCitaEnEdicion}";
                lblOperacion.Visible = true;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al cargar datos: {ex.Message}");
                _idCitaEnEdicion = 0;
                lblOperacion.Visible = false;
            }
        }

        void LimpiarFormulario()
        {
            try
            {
                _idCitaEnEdicion = 0;

                txtNombre.Text        = string.Empty;
                txtApellido.Text      = string.Empty;
                txtID.Text            = string.Empty;
                txtMotivo.Text        = string.Empty;
                txtObservaciones.Text = string.Empty;

                cmbDentista.SelectedIndex = cmbDentista.Items.Count > 0 ? 0 : -1;
                rbPendiente.Checked = true;

                dtpFechaCita.Value = DateTime.Now;
                dtpHoraCita.Value  = new DateTime(DateTime.Now.Year, 1, 1, 7, 0, 0);

                lblOperacion.Visible = false;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al limpiar formulario: {ex.Message}");
            }
        }

        public void ActualizarGridCitas()
        {
            try
            {
                string estado = rbInactivos.Checked ? "Pendiente" : "Confirmada";
                DataTable dt  = controladorCitas.MostrarCitasPorEstado(estado);

                dgvDatos.DataSource             = (dt != null && dt.Rows.Count > 0) ? dt : null;
                dgvDatos.AutoSizeColumnsMode    = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDatos.Refresh();
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al actualizar citas: {ex.Message}");
            }
        }


        void FiltrarCitasPorEstado(string estado)
        {
            try
            {
                DataTable dt = controladorCitas.MostrarCitasPorEstado(estado);
                dgvDatos.DataSource = (dt != null && dt.Rows.Count > 0) ? dt : null;


                // Ocultar las primeras 2 columnas
                if (dgvDatos.Columns.Count >= 3)
                {
                    dgvDatos.Columns["Id_Cita"].Visible = false;
                    dgvDatos.Columns["Id_Dentista"].Visible = false;
                    dgvDatos.Columns["Id_Paciente"].Visible = false;
                }

                dgvDatos.Refresh();
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al filtrar citas: {ex.Message}");
            }
        }

        void AbrirCitasProgramadas()
        {
            try
            {
                Control panel = this.Parent; 
                this.Visible = false;

                PacientesForm formCitasProg = new PacientesForm();
                formCitasProg.TopLevel = false;
                formCitasProg.Dock     = DockStyle.Fill;

                formCitasProg.FormClosed += (s, args) =>
                {
                    panel.Controls.Remove(formCitasProg);
                    this.Visible = true;
                    ActualizarGridCitas();
                };

                panel.Controls.Add(formCitasProg);
                formCitasProg.Show();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                Alertas.Advertencia($"Error al abrir citas programadas: {ex.Message}");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPacienteYCita();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            rbInactivos.Checked = true;
        }

        private void btnCitasProgramadas_Click(object sender, EventArgs e)
        {
            AbrirCitasProgramadas();
        }

        private void rbPendiente_CheckedChanged(object sender, EventArgs e)  { /*  */ }
        private void rbConfirmada_CheckedChanged(object sender, EventArgs e) { /*  */ }

     

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EnviarDatosParaEditar(e);
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInactivos.Checked) {
                FiltrarCitasPorEstado("Pendiente");
            }
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivos.Checked) {
                FiltrarCitasPorEstado("Confirmada");
            }
        }

        private void cmbDentista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDentista.SelectedItem != null)
            {
                DataRowView fila = (DataRowView)cmbDentista.SelectedItem;
                txtMotivo.Text = fila["Especialidad"].ToString();
            }
        }
    }
}
