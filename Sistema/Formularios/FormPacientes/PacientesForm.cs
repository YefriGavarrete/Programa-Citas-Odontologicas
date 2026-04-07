using Sistema.Clases;
using Sistema.Clases.ClasesCitas;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema.Formularios.FormPacientes
{

    ///   • Horario: 07:00 – 17:00
    ///   • Cada turno dura 30 minutos
    ///   • Las filas con estado "Pendiente" se muestran en amarillo claro
    ///     y las "Confirmada" en verde claro.
    public partial class PacientesForm : Form
    {
        Citas controladorCitas = new Citas();
        AlertasDelSistema Alertas = new AlertasDelSistema();
        private DateTime _fechaActual = DateTime.Today;

        public PacientesForm()
        {
            InitializeComponent();
            this.Resize += PacientesForm_Resize;
            CargarCitasDia(DateTime.Today);
        }

        private void PacientesForm_Resize(object sender, EventArgs e)
        {
            //CentrarContenido();
        }

       /* void CentrarContenido()
        {
            int anchoTotal = pnlCalendario.Width + 10 + pnlGrid.Width;
            int altoTotal  = pnlCalendario.Height;

            int x = (this.ClientSize.Width  - anchoTotal) / 2;
            int y = lblTitulo.Height + (this.ClientSize.Height - lblTitulo.Height - altoTotal) / 2;

            if (x < 10) x = 10;
            if (y < lblTitulo.Height + 5) y = lblTitulo.Height + 5;

            pnlCalendario.Location = new System.Drawing.Point(x, y);
            pnlGrid.Location       = new System.Drawing.Point(x + pnlCalendario.Width + 10, y);

            btnCerrar.Location = new System.Drawing.Point(this.ClientSize.Width - btnCerrar.Width - 15, 7);
        }*/

   
        public void CargarCitasDia(DateTime fecha)
        {
            try
            {
                _fechaActual = fecha;
                lblFechaActual.Text = $"Citas del día:  {fecha:dddd, dd 'de' MMMM 'de' yyyy}";

                DataTable dt = controladorCitas.GetCitasPorFecha(fecha);

                bool hayCitas = dt != null && dt.Rows.Count > 0;

                lblSinCitas.Visible   = !hayCitas;
                dgvCitasDia.Visible   = hayCitas;

                if (hayCitas)
                {
                    dgvCitasDia.DataSource = dt;
                    if (dgvCitasDia.Columns.Contains("Id_Cita"))
                        dgvCitasDia.Columns["Id_Cita"].Visible = false;
                    AplicarEstiloFilas();
                }
                else
                {
                    dgvCitasDia.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al cargar citas del día: {ex.Message}");
            }
        }
        void AplicarEstiloFilas()
        {
            foreach (DataGridViewRow fila in dgvCitasDia.Rows)
            {
                if (fila.IsNewRow) continue;

                string estado = fila.Cells["Estado"].Value?.ToString() ?? string.Empty;

                switch (estado)
                {
                    case "Pendiente":
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGoldenrod;
                        break;

                    case "Confirmada":
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                        break;
                }
            }
        }

        void EliminarCitaSeleccionada()
        {
            try
            {
                if (dgvCitasDia.SelectedRows.Count == 0)
                {
                    Alertas.Advertencia("Por favor, seleccione una cita para eliminar.");
                    return;
                }

                DataGridViewRow filaSeleccionada = dgvCitasDia.SelectedRows[0];

                if (filaSeleccionada.Cells["Id_Cita"].Value == null ||
                    filaSeleccionada.Cells["Id_Cita"].Value == DBNull.Value)
                {
                    Alertas.Advertencia("No se pudo obtener el ID de la cita seleccionada.");
                    return;
                }

                int idCita = Convert.ToInt32(filaSeleccionada.Cells["Id_Cita"].Value);

                bool confirmacion = Alertas.Confirmacion("¿Está seguro que desea eliminar esta cita? Esta acción no se puede deshacer.");
                if (confirmacion)
                {
                    bool eliminada = controladorCitas.EliminarCita(idCita);
                    if (eliminada)
                        CargarCitasDia(_fechaActual);
                }
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al eliminar la cita: {ex.Message}");
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            CargarCitasDia(e.Start);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCitaSeleccionada();
        }
    }
}
