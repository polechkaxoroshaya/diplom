using System;
using System.Security.Cryptography;
using System.Text;

namespace EVS
{
    public static class PasswordHelper
    {
        // Генерация случайной соли (16 байт -> 32 символа hex)
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return BitConverter.ToString(saltBytes).Replace("-", "").ToLower();
        }

        // Вычисление хэша SHA-256 от (соль + пароль)
        public static string HashPassword(string password, string salt)
        {
            string saltedPassword = salt + password;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Проверка пароля: хэшируем введённый пароль с солью и сравниваем с сохранённым хэшем
        public static bool VerifyPassword(string enteredPassword, string storedSalt, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword, storedSalt);
            return string.Equals(enteredHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}