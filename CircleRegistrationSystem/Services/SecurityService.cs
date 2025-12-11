using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CircleRegistrationSystem.Services
{
    public class SecurityService
    {
        // Хэширование пароля SHA256 + Base64
        public string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Пароль не может быть пустым");

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Проверка пароля
        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                return false;

            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }

        // Генерация случайного пароля
        public string GenerateRandomPassword(int length = 8)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
            var random = new Random();

            var password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }

        // Валидация email
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Простая валидация email
                var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // Валидация номера телефона (российский формат)
        public bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Удаляем все нецифровые символы
            var digitsOnly = new string(phone.Where(char.IsDigit).ToArray());

            // Проверяем российские номера: +7..., 8..., 7...
            if (digitsOnly.Length == 11)
            {
                // Номер начинается с 7 или 8
                return digitsOnly[0] == '7' || digitsOnly[0] == '8';
            }
            else if (digitsOnly.Length == 10)
            {
                // Номер начинается с 9 (без кода страны)
                return digitsOnly[0] == '9';
            }

            return false;
        }

        // Очистка ввода от потенциально опасных символов
        // Очистка ввода от потенциально опасных символов
        public string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Удаляем HTML теги
            input = Regex.Replace(input, @"<[^>]*>", string.Empty);

            // Удаляем потенциально опасные SQL символы и команды
            var dangerousPatterns = new[]
            {
        @"(\b|')select(\b|')", @"(\b|')insert(\b|')", @"(\b|')delete(\b|')", @"(\b|')update(\b|')",
        @"(\b|')drop(\b|')", @"(\b|')create(\b|')", @"(\b|')alter(\b|')", @"(\b|')exec(\b|')",
        @"(\b|')execute(\b|')", @"(\b|')declare(\b|')", @"'", @"""", @";", @"--", @"\/\*", @"\*\/"
    };

            foreach (var pattern in dangerousPatterns)
            {
                input = Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
            }

            return input.Trim();
        }
        // Проверка пароля на сложность (дополнительно)
        public bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            // Проверяем наличие хотя бы одной цифры
            if (!password.Any(char.IsDigit))
                return false;

            // Проверяем наличие хотя бы одной буквы в верхнем регистре
            if (!password.Any(char.IsUpper))
                return false;

            // Проверяем наличие хотя бы одной буквы в нижнем регистре
            if (!password.Any(char.IsLower))
                return false;

            return true;
        }

        // Генерация соли для пароля (дополнительная безопасность)
        public string GenerateSalt(int length = 16)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Хэширование пароля с солью (более безопасный вариант)
        public string HashPasswordWithSalt(string password, string salt)
        {
            var passwordWithSalt = password + salt;
            return HashPassword(passwordWithSalt);
        }
    }
}