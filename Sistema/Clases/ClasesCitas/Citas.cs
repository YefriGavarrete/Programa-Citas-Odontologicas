using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.Clases.ClasesCitas
{
    public class Citas
    {
        ConsultasSQL consulta = new ConsultasSQL();
        AlertasDelSistema Alertas = new AlertasDelSistema();


        private static readonly TimeSpan HoraApertura = TimeSpan.FromHours(7);
        private static readonly TimeSpan HoraCierre   = TimeSpan.FromHours(17);
        private const int DuracionMinutos = 30;

        public int GuardarPacienteYCita(CitaModel modelo)
        {
            try
            {
                // ── Validaciones básicas ──────────────────────
                if (string.IsNullOrEmpty(modelo.NombrePaciente) ||
                    string.IsNullOrEmpty(modelo.ApellidoPaciente))
                {
                    Alertas.Advertencia("Complete los datos del paciente (Nombre y Apellido).");
                    return 0;
                }

                if (modelo.IdDentista <= 0)
                {
                    Alertas.Advertencia("Seleccione un dentista.");
                    return 0;
                }

                if (string.IsNullOrEmpty(modelo.MotivoCita))
                {
                    Alertas.Advertencia("Ingrese el motivo de la cita.");
                    return 0;
                }

                TimeSpan horaFin = modelo.HoraCita.Add(TimeSpan.FromMinutes(DuracionMinutos));

                if (modelo.HoraCita < HoraApertura || horaFin > HoraCierre)
                {
                    Alertas.Advertencia(
                        $"Horario de atención: 07:00 – 17:00.\n" +
                        $"Cada cita dura {DuracionMinutos} min.\n" +
                        $"Última hora de inicio disponible: 16:30.");
                    return 0;
                }

                if (ExisteConflictoHorario(modelo.IdDentista, modelo.FechaCita, modelo.HoraCita, null))
                {
                    Alertas.Advertencia(
                        "El dentista ya tiene una cita en ese horario o muy próxima.\n" +
                        "Debe haber al menos 30 minutos de diferencia entre citas.");
                    return 0;
                }
                string sqlPaciente = @"INSERT INTO Pacientes
                                           (Nombre, Apellido, [Dirección], Telefono, Estado)
                                       VALUES
                                           (@Nombre, @Apellido, @Dir, @Tel, @EstPac);
                                       SELECT SCOPE_IDENTITY();";

                int idPaciente = 0;
                using (var cmd = new SqlCommand(sqlPaciente))
                {
                    cmd.Parameters.AddWithValue("@Nombre",  modelo.NombrePaciente);
                    cmd.Parameters.AddWithValue("@Apellido", modelo.ApellidoPaciente);
                    cmd.Parameters.AddWithValue("@Dir",     string.Empty);
                    cmd.Parameters.AddWithValue("@Tel",     string.Empty);
                    cmd.Parameters.AddWithValue("@EstPac",  "Activo");

                    object res = consulta.EjecutarEscalar(cmd);
                    if (res != null && res != DBNull.Value)
                        idPaciente = Convert.ToInt32(res);
                }

                if (idPaciente <= 0)
                {
                    DataTable dtPac = consulta.Buscar("Pacientes", "MAX(Id_Paciente) AS Id", "");
                    if (dtPac?.Rows.Count > 0)
                        idPaciente = Convert.ToInt32(dtPac.Rows[0]["Id"]);
                }

                if (idPaciente <= 0)
                {
                    Alertas.Advertencia("Error al crear el paciente.");
                    return 0;
                }
                string sqlCita = @"INSERT INTO Citas
                                   (Id_Dentista, Id_Paciente,
                                    NombrePaciente,  ApellidoPaciente,
                                    NombreDentista,  ApellidoDentista,
                                    FechaCita, HoraCita, Estado, Motivo, Observaciones)
                                   VALUES
                                   (@IdDentista, @IdPaciente,
                                    @NombrePaciente,  @ApellidoPaciente,
                                    @NombreDentista,  @ApellidoDentista,
                                    @FechaCita, @HoraCita, @Estado, @Motivo, @Observaciones);
                                   SELECT SCOPE_IDENTITY();";

                int idCita = 0;
                using (var cmd = new SqlCommand(sqlCita))
                {
                    cmd.Parameters.AddWithValue("@IdDentista",       modelo.IdDentista);
                    cmd.Parameters.AddWithValue("@IdPaciente",       idPaciente);
                    cmd.Parameters.AddWithValue("@NombrePaciente",   modelo.NombrePaciente);
                    cmd.Parameters.AddWithValue("@ApellidoPaciente", modelo.ApellidoPaciente);
                    cmd.Parameters.AddWithValue("@NombreDentista",
                        (object)modelo.NombreDentista   ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ApellidoDentista",
                        (object)modelo.ApellidoDentista ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaCita",  modelo.FechaCita.Date);
                    cmd.Parameters.AddWithValue("@HoraCita",   modelo.HoraCita);
                    cmd.Parameters.AddWithValue("@Estado",     modelo.Estado);
                    cmd.Parameters.AddWithValue("@Motivo",
                        string.IsNullOrEmpty(modelo.MotivoCita)    ? (object)DBNull.Value : modelo.MotivoCita);
                    cmd.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrEmpty(modelo.Observaciones) ? (object)DBNull.Value : modelo.Observaciones);

                    object res = consulta.EjecutarEscalar(cmd);
                    if (res != null && res != DBNull.Value)
                        idCita = Convert.ToInt32(res);
                }

                if (idCita <= 0)
                {
                    DataTable dtC = consulta.Buscar("Citas", "MAX(Id_Cita) AS Id", "");
                    if (dtC?.Rows.Count > 0)
                        idCita = Convert.ToInt32(dtC.Rows[0]["Id"]);
                }

                if (idCita <= 0)
                {
                    Alertas.Advertencia("Error al crear la cita.");
                    return 0;
                }

                Alertas.Realizado(
                    $"Cita creada exitosamente.\n" +
                    $"Paciente: {modelo.NombrePaciente} {modelo.ApellidoPaciente}\n" +
                    $"Hora: {modelo.HoraCita:hh\\:mm} – {horaFin:hh\\:mm}  |  ID Cita: {idCita}");

                return idCita;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error inesperado: {ex.Message}");
                return 0;
            }
        }


        public bool ExisteConflictoHorario(int idDentista, DateTime fecha,
                                            TimeSpan hora, int? idCitaExcluir)
        {
            try
            {
                string horaStr = $"{hora.Hours:D2}:{hora.Minutes:D2}:00";

                string sql = $@"SELECT Id_Cita
                                FROM   Citas
                                WHERE  Id_Dentista = {idDentista}
                                AND    CONVERT(DATE, FechaCita) = '{fecha:yyyy-MM-dd}'
                                AND    ABS(DATEDIFF(MINUTE, HoraCita, '{horaStr}')) < {DuracionMinutos}";

                if (idCitaExcluir.HasValue)
                    sql += $" AND Id_Cita <> {idCitaExcluir.Value}";

                DataTable dt = consulta.EjecutarConsultaSelect(sql);
                return dt != null && dt.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public DataTable MostrarCitas()
        {
            try
            {
                string sql = @"SELECT Id_Cita,
                                      Id_Dentista,
                                      Id_Paciente,
                                      NombrePaciente,
                                      ApellidoPaciente,
                                      NombreDentista,
                                      ApellidoDentista,
                                      FechaCita,
                                      HoraCita,
                                      Estado,
                                      Motivo,
                                      Observaciones
                               FROM   Citas
                               ORDER  BY FechaCita, HoraCita";

                DataTable dt = consulta.EjecutarConsultaSelect(sql);
                if (dt == null || dt.Rows.Count == 0)
                    Alertas.Advertencia("No hay citas registradas.");

                return dt;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al mostrar citas: {ex.Message}");
                return null;
            }
        }
        public DataTable MostrarCitasPorEstado(string estado)
        {
            try
            {
                string sql = $@"SELECT Id_Cita,
                                       Id_Dentista,
                                       Id_Paciente,
                                       NombrePaciente,
                                       ApellidoPaciente,
                                       NombreDentista,
                                       ApellidoDentista,
                                       FechaCita,
                                       HoraCita,
                                       Estado,
                                       Motivo,
                                       Observaciones
                                FROM   Citas
                                WHERE  Estado = '{estado}'
                                ORDER  BY FechaCita, HoraCita";

                return consulta.EjecutarConsultaSelect(sql);
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al filtrar citas: {ex.Message}");
                return null;
            }
        }

        public DataTable GetCitasPorFecha(DateTime fecha)
        {
            try
            {
                string sql = $@"SELECT
                                    Id_Cita,
                                    CONVERT(VARCHAR(5), HoraCita, 108)  AS Hora,
                                    (NombrePaciente  + ' ' + ApellidoPaciente)  AS Paciente,
                                    (NombreDentista  + ' ' + ApellidoDentista)  AS Dentista,
                                    Estado,
                                    Motivo,
                                    Observaciones
                                FROM   Citas
                                WHERE  CONVERT(DATE, FechaCita) = '{fecha:yyyy-MM-dd}'
                                ORDER  BY HoraCita";

                return consulta.EjecutarConsultaSelect(sql);
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al obtener citas del día: {ex.Message}");
                return null;
            }
        }

        public DataTable ObtenerDentistas()
        {
            try
            {
                string sql = @"SELECT Id_Dentista,
                                      Nombre,
                                      Apellido,
                                      (Nombre + ' ' + Apellido) AS NombreCompleto
                               FROM   Dentistas
                               WHERE  Estado = 'Activo'";

                return consulta.EjecutarConsultaSelect(sql);
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al cargar dentistas: {ex.Message}");
                return null;
            }
        }
        public bool ActualizarCita(int idCita, CitaModel modelo)
        {
            try
            {
                if (idCita <= 0)
                {
                    Alertas.Advertencia("ID de cita inválido.");
                    return false;
                }

                if (string.IsNullOrEmpty(modelo.NombrePaciente) ||
                    string.IsNullOrEmpty(modelo.ApellidoPaciente))
                {
                    Alertas.Advertencia("Complete los datos del paciente.");
                    return false;
                }

                if (modelo.IdDentista <= 0)
                {
                    Alertas.Advertencia("Seleccione un dentista.");
                    return false;
                }

                TimeSpan horaFin = modelo.HoraCita.Add(TimeSpan.FromMinutes(DuracionMinutos));
                if (modelo.HoraCita < HoraApertura || horaFin > HoraCierre)
                {
                    Alertas.Advertencia(
                        $"Horario de atención: 07:00 – 17:00.\n" +
                        $"Última hora de inicio válida: 16:30.");
                    return false;
                }


                // Solo verificar conflicto si cambiaron dentista, fecha u hora
                bool debeVerificarConflicto = true;

                DataTable dtOriginal = consulta.Buscar(
                    "Citas",
                    "Id_Dentista, FechaCita, HoraCita",
                    $"Id_Cita = {idCita}");

                if (dtOriginal != null && dtOriginal.Rows.Count > 0)
                {
                    DataRow orig = dtOriginal.Rows[0];

                    int      origDentista = Convert.ToInt32(orig["Id_Dentista"]);
                    DateTime origFecha    = Convert.ToDateTime(orig["FechaCita"]).Date;

                    // Comparar solo horas y minutos para evitar problemas de
                    // precisión entre SQL Server TIME(7) y DateTimePicker
                    int origHoras   = 0, origMinutos = 0;
                    if (orig["HoraCita"] != DBNull.Value)
                    {
                        TimeSpan origTs = (TimeSpan)orig["HoraCita"];
                        origHoras   = origTs.Hours;
                        origMinutos = origTs.Minutes;
                    }

                    bool mismoDentista = origDentista == modelo.IdDentista;
                    bool mismaFecha    = origFecha    == modelo.FechaCita.Date;
                    bool mismaHora     = origHoras   == modelo.HoraCita.Hours
                                      && origMinutos == modelo.HoraCita.Minutes;

                    debeVerificarConflicto = !mismoDentista || !mismaFecha || !mismaHora;
                }

                if (debeVerificarConflicto &&
                    ExisteConflictoHorario(modelo.IdDentista, modelo.FechaCita, modelo.HoraCita, idCita))
                {
                    Alertas.Advertencia(
                        "El dentista ya tiene otra cita en ese horario.\n" +
                        "Debe haber al menos 30 minutos de diferencia.");
                    return false;
                }

                string sql = @"UPDATE Citas
                               SET  Id_Dentista      = @IdDentista,
                                    NombrePaciente   = @NombrePaciente,
                                    ApellidoPaciente = @ApellidoPaciente,
                                    NombreDentista   = @NombreDentista,
                                    ApellidoDentista = @ApellidoDentista,
                                    FechaCita        = @FechaCita,
                                    HoraCita         = @HoraCita,
                                    Estado           = @Estado,
                                    Motivo           = @Motivo,
                                    Observaciones    = @Observaciones
                               WHERE Id_Cita = @IdCita";

                using (var cmd = new SqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@IdCita",          idCita);
                    cmd.Parameters.AddWithValue("@IdDentista",       modelo.IdDentista);
                    cmd.Parameters.AddWithValue("@NombrePaciente",   modelo.NombrePaciente);
                    cmd.Parameters.AddWithValue("@ApellidoPaciente", modelo.ApellidoPaciente);
                    cmd.Parameters.AddWithValue("@NombreDentista",
                        string.IsNullOrEmpty(modelo.NombreDentista)   ? (object)DBNull.Value : modelo.NombreDentista);
                    cmd.Parameters.AddWithValue("@ApellidoDentista",
                        string.IsNullOrEmpty(modelo.ApellidoDentista) ? (object)DBNull.Value : modelo.ApellidoDentista);
                    cmd.Parameters.AddWithValue("@FechaCita",  modelo.FechaCita.Date);
                    cmd.Parameters.AddWithValue("@HoraCita",   modelo.HoraCita);
                    cmd.Parameters.AddWithValue("@Estado",     modelo.Estado);
                    cmd.Parameters.AddWithValue("@Motivo",
                        string.IsNullOrEmpty(modelo.MotivoCita)    ? (object)DBNull.Value : modelo.MotivoCita);
                    cmd.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrEmpty(modelo.Observaciones) ? (object)DBNull.Value : modelo.Observaciones);

                    int filas = consulta.EjecutarComando(cmd);

                    if (filas > 0)
                    {
                        Alertas.Realizado(
                            $"Cita #{idCita} actualizada correctamente.\n" +
                            $"Hora: {modelo.HoraCita:hh\\:mm} – {horaFin:hh\\:mm}");
                        return true;
                    }
                }

                Alertas.Advertencia("No se pudo actualizar la cita.");
                return false;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al actualizar cita: {ex.Message}");
                return false;
            }
        }

        public bool EliminarCita(int idCita)
        {
            try
            {
                if (idCita <= 0)
                {
                    Alertas.Advertencia("Seleccione una cita válida.");
                    return false;
                }

                if (!Alertas.Confirmacion($"¿Eliminar la cita #{idCita}?"))
                    return false;

                int filas = consulta.Eliminar("Citas", $"Id_Cita = {idCita}");

                if (filas > 0)
                {
                    Alertas.Realizado("Cita eliminada exitosamente.");
                    return true;
                }

                Alertas.Advertencia("No se pudo eliminar la cita.");
                return false;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al eliminar cita: {ex.Message}");
                return false;
            }
        }

        public bool ActualizarEstadoCita(int idCita, string nuevoEstado)
        {
            try
            {
                if (idCita <= 0 || string.IsNullOrEmpty(nuevoEstado))
                {
                    Alertas.Advertencia("Datos inválidos para actualizar la cita.");
                    return false;
                }

                int filas = consulta.update("Citas", $"Estado = '{nuevoEstado}'", $"Id_Cita = {idCita}");

                if (filas > 0)
                {
                    Alertas.Realizado($"Estado actualizado a: {nuevoEstado}");
                    return true;
                }

                Alertas.Advertencia("No se pudo actualizar el estado.");
                return false;
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al actualizar cita: {ex.Message}");
                return false;
            }
        }
    }
}
