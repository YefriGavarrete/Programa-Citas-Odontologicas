using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Login
{
    internal class VerificarContraseña
    {
        // Verifica la contraseña usando PBKDF2 (Rfc2898). Comparación en tiempo constante.
        public static bool VerificarPassword(string password, byte[] salt, byte[] storedHash, int iteraciones)
        {
            if (password == null || salt == null || storedHash == null) return false;
            try
            {
                using (var pbk = new Rfc2898DeriveBytes(password, salt, iteraciones))
                {
                    byte[] computed = pbk.GetBytes(storedHash.Length);
                    if (computed.Length != storedHash.Length) return false;

                    int diff = 0;
                    for (int i = 0; i < storedHash.Length; i++)
                        diff |= storedHash[i] ^ computed[i];

                    return diff == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Lee una columna que puede contener VARBINARY (byte[]) o una cadena Base64 (NVARCHAR) y devuelve byte[]
        public static byte[] LeerDbBinary(SqlDataReader reader, string nombreColumna)
        {
            try
            {
                object val = reader[nombreColumna];
                if (val == DBNull.Value || val == null) return null;

                if (val is byte[] bytes) return bytes;

                var s = val as string;
                if (!string.IsNullOrEmpty(s))
                {
                    try
                    {
                        return Convert.FromBase64String(s);
                    }
                    catch
                    {
                        return null;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
