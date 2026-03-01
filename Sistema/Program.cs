using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.FormLogin;
using Sistema.FormLoginMenu;
using Sistema.Formularios.FormUsuarios;

namespace Sistema
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // <--

            // --> iniciar con el FormCrearUsuarios para crear el usuario admin, luego iniciar con LoginForm.
            //Application.Run(new FormCrearUsuarios());
        }
    }
}
