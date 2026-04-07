using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases.ClaseEspecialidad
{
    internal class EspecialidadMO
    {
        public static int Id_Especialidad { get; set; }
        public static string Especialidad { get; set; }
        public static string Estado { get; set; }

        public static void EspecialidadDatos(int idesp, string espec)
        {
            Id_Especialidad = idesp;
            Especialidad = espec;
        }
    }
}
