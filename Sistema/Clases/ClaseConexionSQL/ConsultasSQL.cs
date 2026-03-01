using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    internal class ConsultasSQL : Conexion
    {
        AlertasDelSistema Alertas = new AlertasDelSistema();

        string consulta;
        int filasAfectadas = 0;

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConexionDB"]?.ConnectionString ?? string.Empty;
        }

        public bool Guardar(string tabla, string columnas, string valores)
        {
            consulta = $"INSERT INTO {tabla}({columnas}) VALUES ({valores})";

            int filasAfectadas = EjecutarConsulta(consulta);

            return filasAfectadas > 0;
        }

        public int update(string tablename, string data, string condicion = "")
        {
            if (condicion == "")
            {
                consulta = $"UPDATE {tablename} SET {data}";
            }
            else
            {
                consulta = $"UPDATE {tablename} SET {data} WHERE {condicion}";
            }

            filasAfectadas = EjecutarConsulta(consulta);

            return filasAfectadas;
        }

        public int Eliminar(string tablename, string condicion = "")
        {
            if (condicion == "")
            {
                consulta = $"DELETE FROM {tablename}";
            }
            else
            {
                consulta = $"DELETE FROM {tablename} WHERE {condicion}";
            }
            filasAfectadas = EjecutarConsulta(consulta);
            return filasAfectadas;
        }

        public DataTable Buscar(string tabla, string columnas, string condicion = "")
        {
            DataTable resultados = new DataTable();
            string consulta = string.IsNullOrEmpty(condicion) ?
                $"SELECT {columnas} FROM {tabla}" :
                $"SELECT {columnas} FROM {tabla} WHERE {condicion}";
            string connString = GetConnectionString();
            try
            {
                using (var conn = new SqlConnection(connString))
                using (var comando = new SqlCommand(consulta, conn))
                {
                    conn.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        resultados.Load(lector);
                    }
                }
            }
            catch (SqlException error)
            {
                Alertas.Advertencia($"Error al recuperar datos:\n{error.Message}");
            }

            return resultados;
        }

        public int EjecutarConsulta(string consulta)
        {
            int filasAfectadas = 0;
            string connString = GetConnectionString();
            try
            {
                using (var conn = new SqlConnection(connString))
                using (var comando = new SqlCommand(consulta, conn))
                {
                    conn.Open();
                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException error)
            {
                Alertas.Advertencia($"Error al ejecutar consulta:\n{error.Message}");
            }

            return filasAfectadas;
        }

        public int EjecutarComando(SqlCommand comando)
        {
            int filasAfectadas = 0;
            string connString = GetConnectionString();
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    comando.Connection = conn;
                    conn.Open();
                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException error)
            {
                Alertas.Advertencia($"Error al ejecutar comando parametrizado:\n{error.Message}");
            }

            return filasAfectadas;
        }

        // Consulta SELECT generica para obtener datos de la BDD
        public DataTable EjecutarConsultaSelect(string consulta)
        {
            DataTable resultados = new DataTable();

            try
            {
                using (SqlCommand comando = new SqlCommand(consulta, SQLConexion))
                {
                    abrirConexion();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        resultados.Load(lector);
                    }
                }
            }

            catch (SqlException error)
            {
                Alertas.Advertencia($"Error al ejecutar consulta SELECT:\n{error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return resultados;
        }

        // Guardar archivo pdf
        public bool GuardarPDF(string tabla, string columnas, Dictionary<string, object> parametros)
        {
            string sql = $"INSERT INTO {tabla}({columnas}) VALUES (";

            var names = parametros.Keys.Select(p => "@" + p);
            sql += string.Join(", ", names) + ")";

            using (var conn = new SqlConnection(GetConnectionString()))
            using (var cmd = new SqlCommand(sql, conn))
            {
                foreach (var par in parametros)
                {
                    cmd.Parameters.AddWithValue("@" + par.Key, par.Value);
                }

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
