using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases.ClasesCitas
{

    public class CitaModel
    {
        public int    IdPaciente      { get; set; }
        public string NombrePaciente  { get; set; }
        public string ApellidoPaciente { get; set; }
        public int    IdDentista      { get; set; }   
        public string NombreDentista  { get; set; }   
        public string ApellidoDentista { get; set; }  
        public int      IdCita      { get; set; }
        public DateTime FechaCita   { get; set; }
        public TimeSpan HoraCita    { get; set; }   
        public string   Estado      { get; set; }   
        public string   MotivoCita  { get; set; }
        public string   Observaciones { get; set; }

        public CitaModel()
        {
            FechaCita = DateTime.Now;
            HoraCita  = TimeSpan.FromHours(7);  
            Estado    = "Pendiente";
        }
        public CitaModel(int idPaciente, string nombrePaciente, string apellidoPaciente,
                         int idDentista, string nombreDentista, string apellidoDentista,
                         DateTime fechaCita, TimeSpan horaCita, string estado,
                         string motivoCita, string observaciones)
        {
            IdPaciente       = idPaciente;
            NombrePaciente   = nombrePaciente;
            ApellidoPaciente = apellidoPaciente;
            IdDentista       = idDentista;
            NombreDentista   = nombreDentista;
            ApellidoDentista = apellidoDentista;
            FechaCita        = fechaCita;
            HoraCita         = horaCita;
            Estado           = estado;
            MotivoCita       = motivoCita;
            Observaciones    = observaciones;
        }
    }
}
