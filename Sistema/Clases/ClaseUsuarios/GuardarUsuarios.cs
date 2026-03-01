using Sistema.Formularios.FormUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Clases.ClaseUsuarios
{
    internal class GuardarUsuarios
    {
        AlertasDelSistema Alertas = new AlertasDelSistema();
        ConsultasSQL consultas = new ConsultasSQL();
        string msg = "";
        public void Guardar(string tabla, int id, string usuario, string nombre, string apellido, string clave, DateTime fecha, string estado, string rol, string operacion)
        {
            try
            {
                byte[] saltBytes = SalHash.GenerarSalt();
                byte[] hashBytes = SalHash.ComputeHash(clave, saltBytes/*, PBKDF2_ITERATIONS, PBKDF2_HASH_BYTES*/);

                string sql = "";

                bool esEdicion = operacion == "Editando";
               // int idUser = 0;

                if (esEdicion)
                {
                    msg = "actualizo";

                    sql = $@"UPDATE {tabla}
                            SET Usuario = @Usuario,
                                Clave = @Clave,
                                SAL = @SAL,
                                Iteraciones = @Iteraciones,
                                Nombre = @Nombre,
                                Apellido = @Apellido,
                                Fecha_Creacion = @Fecha_Creacion,
                                Estado = @Estado,
                                Rol = @Rol
                            WHERE Id_User = {id}"
                    ;
                }
                else
                {
                    msg = "guardo";

                    sql = $@"INSERT INTO {tabla}
                            (Usuario, Clave, SAL, Iteraciones, Nombre, Apellido, Fecha_Creacion, Estado, Rol)
                            VALUES
                            (@Usuario, @Clave, @SAL, @Iteraciones, @Nombre, @Apellido, @Fecha_Creacion, @Estado, @Rol)"
                    ;
                }

                using (var cmd = new SqlCommand(sql))
                {
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
                    cmd.Parameters.Add("@Clave", SqlDbType.VarBinary, SalHash.PBKDF2_HASH_BYTES).Value = hashBytes;
                    cmd.Parameters.Add("@Sal", SqlDbType.VarBinary, SalHash.SALT_BYTES).Value = saltBytes;
                    cmd.Parameters.Add("@Iteraciones", SqlDbType.Int).Value = SalHash.PBKDF2_ITERATIONS;

                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = apellido;

                    cmd.Parameters.Add("@Fecha_Creacion", SqlDbType.DateTime).Value = fecha;
                    cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 15).Value = estado;
                    cmd.Parameters.Add("@Rol", SqlDbType.VarChar, 15).Value = rol;

                    int filas = consultas.EjecutarComando(cmd);

                    if (filas > 0)
                    {
                        Alertas.Realizado($"El Usuario '{nombre + apellido}' se {msg} correctamente");
                        FormCrearUsuarios form = Application.OpenForms.OfType<FormCrearUsuarios>().FirstOrDefault();

                        form.limpiarCampos();
                        form.MostrarRegistros("Activo");
                    }
                }
            }
            catch (Exception ex)
            {
                Alertas.Advertencia($"Error al guardar usuario: {ex.Message}");
            }
        }
    }
}
