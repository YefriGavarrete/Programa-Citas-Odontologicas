using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    internal static class UsuarioLogeado
    {
        // Propiedades estáticas para que vivan en toda la app
        public static int User { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Rol { get; set; }

        // Método para "setear" los datos al hacer Login
        public static void DatosUser(int user, string nomb, string apell, string roluser)
        {
            User = user;
            Nombre = nomb;
            Apellido = apell;
            Rol = roluser;
        }
    }
}
