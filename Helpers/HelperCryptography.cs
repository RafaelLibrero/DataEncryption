using System.Security.Cryptography;
using System.Text;

namespace DataEncryption.Helpers
{
    public class HelperCryptography
    {
        public static byte[] EncryptPasswordSHA
            (string password, string salt)
        {
            string contenido = password + salt;
            SHA512 sha512 = SHA512.Create();
            byte[] salida = Encoding.UTF8.GetBytes(contenido);

            for (int i = 1; i <= 33; i++)
            {
                salida = sha512.ComputeHash(salida);
            }
            sha512.Clear();
            return salida;
        }

    }


}