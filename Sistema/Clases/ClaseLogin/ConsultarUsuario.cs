using Sistema.Clases;
using Sistema.FormLogin;
using Sistema.FormLoginMenu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Login
{
    internal class ConsultarUsuario
    {
        AlertasDelSistema Alertas = new AlertasDelSistema();

        public void BuscarUsuario(string tabla, string usuario, string clave)
        {
            string connString = ConsultasSQL.GetConnectionString();

            try
            {
                DataTable resultados = new DataTable();
                string consulta = $@"SELECT TOP(1)
                                u.Id_User,
                                u.Clave,
                                u.Sal,
                                u.Iteraciones,   
                                u.Nombre,
                                u.Apellido,
                                u.Fecha_Creacion,
                                u.Estado,
                                u.ROL
                            FROM {tabla} u
                            WHERE u.Usuario = '{usuario}'";

                using (var conn = new SqlConnection(connString))
                using (var comando = new SqlCommand(consulta, conn))
                {
                    conn.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Alertas.Advertencia("Usuario no encontrado.");
                            return;
                        }
                        reader.Read();

                        string estado = reader["Estado"] != DBNull.Value ? reader["Estado"].ToString() : string.Empty;
                        if (!string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
                        {
                            Alertas.Advertencia("Usuario no está activo.");
                            return;
                        }

                        int iteraciones = 10000;
                        if (reader["Iteraciones"] != DBNull.Value)
                            int.TryParse(reader["Iteraciones"].ToString(), out iteraciones);

                        byte[] storedHash = VerificarContraseña.LeerDbBinary(reader, "Clave");
                        byte[] salt = VerificarContraseña.LeerDbBinary(reader, "Sal");

                        if (storedHash == null || salt == null)
                        {
                            Alertas.Advertencia("Credenciales incompletas en la base de datos.");
                            return;
                        }

                        bool valido = VerificarContraseña.VerificarPassword(clave, salt, storedHash, iteraciones);

                        if (!valido)
                        {
                            Alertas.Advertencia("Usuario o contraseña incorrectos.");
                            return;
                        }

                        string nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty;
                        string apellido = reader["Apellido"] != DBNull.Value ? reader["Apellido"].ToString() : string.Empty;
                        string rolNombre = reader["Rol"] != DBNull.Value ? reader["Rol"].ToString() : string.Empty;
                        int idUsuario = reader["Id_User"] != DBNull.Value ? Convert.ToInt32(reader["Id_User"]) : 0;

                        Alertas.Realizado("Inicio de sesión exitoso.");

                        UsuarioLogeado.DatosUser(idUsuario, nombre, apellido, rolNombre);

                        abrirMenuPrincipal();
                    }
                }
            }
            catch (SqlException error)
            {
                Alertas.Advertencia($"Error al recuperar datos:\n{error.Message}");
            }
        }

        void abrirMenuPrincipal()
        {
            var menu = new MenuForm();
            var login = new LoginForm();

            menu.StartPosition = FormStartPosition.CenterScreen;

            // Al cerrar el menu, mostrar nuevamente el formulario de login
            menu.FormClosed += (s, args) =>
            {
                login.Show();
            };

            menu.Show();
            login.Hide();
        }
    }
}
