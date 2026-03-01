using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases.ClaseUsuarios
{
    internal class SalHash
    {
        // PBKDF2 parametros
        public const int PBKDF2_ITERATIONS = 10000;
        public const int PBKDF2_HASH_BYTES = 32; // 256-bit
        public const int SALT_BYTES = 16;

        // SALT
        public static byte[] GenerarSalt(int size = SALT_BYTES)
        {
            var salt = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Calcula el hash PBKDF2
        public static byte[] ComputeHash(string password, byte[] salt, int iterations = PBKDF2_ITERATIONS, int outputBytes = PBKDF2_HASH_BYTES)
        {
            using (var pbk = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbk.GetBytes(outputBytes);
            }
        }
    }
}
