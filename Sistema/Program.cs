using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.FormLogin;
using Sistema.FormLoginMenu;
using Sistema.Formularios.FormPacientes;
using Sistema.Formularios.FormUsuarios;

namespace Sistema
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); 
        }
    }
}
