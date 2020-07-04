using System;
using System.Security.Cryptography;

namespace Xsolla_Summer_School_2020._Backend.Security
{
    /// <summary>
    /// Класс хелпер для генерации хеша.
    /// </summary>
    public static class SecurePasswordHasher
    {
        /// <summary>
        /// Создание хеша.
        /// </summary>
        /// <param name="password">Пароль</param>
        public static string HasFunction(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }
    }
}
