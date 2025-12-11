using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CircleRegistrationSystem.Models;

namespace CircleRegistrationSystem.Services
{
    public class UserService
    {
        private readonly DatabaseService _db;
        private readonly SecurityService _securityService;

        public UserService(DatabaseService db)
        {
            _db = db;
            _securityService = new SecurityService();
        }

        // Получить пользователя по Email
        public Participant GetUserByEmail(string email)
        {
            return _db.GetUserByEmail(email);
        }

        // Регистрация нового пользователя
        public bool RegisterUser(Participant user, string password)
        {
            try
            {
                // Проверяем, существует ли уже пользователь с таким email
                var existingUser = _db.GetUserByEmail(user.Email);
                if (existingUser != null)
                    return false;

                // Хэшируем пароль
                user.PasswordHash = _securityService.HashPassword(password);
                user.Id = Guid.NewGuid();
                user.IsActive = true;

                // Сохраняем пользователя в базу данных
                // Вам нужно реализовать метод AddUser в DatabaseService
                return _db.AddUser(user);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка регистрации: {ex.Message}");
                return false;
            }
        }

        // Сохранение пользователя в БД
        private bool SaveUser(Participant user)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    INSERT INTO Users (Id, FullName, Email, PasswordHash, Role, DateOfBirth, IsActive) 
                    VALUES (@Id, @FullName, @Email, @PasswordHash, @Role, @DateOfBirth, @IsActive)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                        command.Parameters.AddWithValue("@Role", user.Role);
                        command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения пользователя: {ex.Message}");
                return false;
            }
        }

        // Смена пароля
        public bool ChangePassword(Guid userId, string newPassword)
        {
            try
            {
                string newHash = _securityService.HashPassword(newPassword);

                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Id = @Id";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", userId);
                        command.Parameters.AddWithValue("@PasswordHash", newHash);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка смены пароля: {ex.Message}");
                return false;
            }
        }

        // Вход пользователя
        public Participant Login(string email, string password)
        {
            var user = GetUserByEmail(email);
            if (user == null)
                return null;

            return _securityService.VerifyPassword(password, user.PasswordHash) ? user : null;
        }

        // Получить всех пользователей
        public List<Participant> GetAllUsers()
        {
            try
            {
                return _db.GetUsers();
            }
            catch
            {
                return new List<Participant>();
            }
        }
    }
}
