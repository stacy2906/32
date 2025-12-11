using CircleRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using static CircleRegistrationSystem.Models.Registration;

namespace CircleRegistrationSystem.Services
{
    public class DatabaseService
    {
        // Мок-данные
        private List<Circle> _mockCircles;
        private List<Participant> _mockUsers;
        private List<Registration> _mockRegistrations;
        private List<Schedule> _mockSchedules;
        private string _connectionString;
        public DbSet<Participant> Users { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DatabaseService(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;

        
        }

        public DatabaseService()
        {
            try
            {
                if (ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"] == null)
                {
                    throw new Exception("Строка подключения не найдена в конфиге");
                }

                // ДОБАВЬ ЭТУ СТРОЧКУ!
                _connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                System.Diagnostics.Debug.WriteLine($"Строка из конфига: {_connectionString}");
            }
            catch (Exception ex)
            {
                _connectionString = "Data Source=ADMIN-PC97;Initial Catalog=CircleRegistrationSystem;Integrated Security=True;MultipleActiveResultSets=True";
                System.Diagnostics.Debug.WriteLine($"Fallback строка: {_connectionString}");
                System.Diagnostics.Debug.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        // Добавьте в DatabaseService.cs следующие методы:

        public bool AddRegistration(Registration registration)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    @"INSERT INTO Registrations 
              (Id, ParticipantId, CircleId, ApplicationDate, Status, CreatedAt) 
              VALUES (@Id, @ParticipantId, @CircleId, @ApplicationDate, @Status, @CreatedAt)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", registration.Id);
                    command.Parameters.AddWithValue("@ParticipantId", registration.ParticipantId);
                    command.Parameters.AddWithValue("@CircleId", registration.CircleId);
                    command.Parameters.AddWithValue("@ApplicationDate", registration.ApplicationDate);
                    command.Parameters.AddWithValue("@Status", registration.Status);
                    command.Parameters.AddWithValue("@CreatedAt", registration.CreatedAt);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка добавления регистрации: {ex.Message}");
                return false;
            }
        }

        public bool UpdateRegistration(Registration registration)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    @"UPDATE Registrations SET 
                Status = @Status,
                ApprovalDate = @ApprovalDate,
                ApprovedBy = @ApprovedBy,
                RejectionReason = @RejectionReason,
                UpdatedAt = @UpdatedAt
              WHERE Id = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", registration.Id);
                    command.Parameters.AddWithValue("@Status", registration.Status);
                    command.Parameters.AddWithValue("@ApprovalDate", registration.ApprovalDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ApprovedBy", registration.ApprovedBy ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RejectionReason", registration.RejectionReason ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления регистрации: {ex.Message}");
                return false;
            }
        }

        public List<Registration> GetRegistrations()
        {
            var registrations = new List<Registration>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SELECT * FROM Registrations", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var registration = new Registration
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                ParticipantId = reader.GetGuid(reader.GetOrdinal("ParticipantId")),
                                CircleId = reader.GetGuid(reader.GetOrdinal("CircleId")),
                                ApplicationDate = reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("ApprovalDate")))
                                registration.ApprovalDate = reader.GetDateTime(reader.GetOrdinal("ApprovalDate"));

                            if (!reader.IsDBNull(reader.GetOrdinal("RejectionReason")))
                                registration.RejectionReason = reader.GetString(reader.GetOrdinal("RejectionReason"));

                            registrations.Add(registration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения регистраций: {ex.Message}");
            }

            return registrations;
        }

        public Registration GetRegistrationById(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SELECT * FROM Registrations WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Registration
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                ParticipantId = reader.GetGuid(reader.GetOrdinal("ParticipantId")),
                                CircleId = reader.GetGuid(reader.GetOrdinal("CircleId")),
                                ApplicationDate = reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения регистрации: {ex.Message}");
            }

            return null;
        }

        public bool AddAttendance(Attendance attendance)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    @"INSERT INTO Attendances 
              (Id, RegistrationId, Date, Status, Notes, CheckInTime, CreatedBy, CreatedAt) 
              VALUES (@Id, @RegistrationId, @Date, @Status, @Notes, @CheckInTime, @CreatedBy, @CreatedAt)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", attendance.Id);
                    command.Parameters.AddWithValue("@RegistrationId", attendance.RegistrationId);
                    command.Parameters.AddWithValue("@Date", attendance.Date);
                    command.Parameters.AddWithValue("@Status", attendance.Status);
                    command.Parameters.AddWithValue("@Notes", attendance.Notes ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CheckInTime", attendance.CheckInTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", attendance.CreatedBy);
                    command.Parameters.AddWithValue("@CreatedAt", attendance.CreatedAt);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка добавления посещаемости: {ex.Message}");
                return false;
            }
        }

        public List<Attendance> GetAttendances()
        {
            var attendances = new List<Attendance>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SELECT * FROM Attendances", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var attendance = new Attendance
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                RegistrationId = reader.GetGuid(reader.GetOrdinal("RegistrationId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                CreatedBy = reader.GetGuid(reader.GetOrdinal("CreatedBy"))
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                                attendance.Notes = reader.GetString(reader.GetOrdinal("Notes"));

                            attendances.Add(attendance);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения посещаемости: {ex.Message}");
            }

            return attendances;
        }
        public bool AddUser(Participant user)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    // ДОБАВЬТЕ CreatedAt
                    "INSERT INTO Users (Id, FullName, Email, PasswordHash, Role, DateOfBirth, PhoneNumber, ParentName, Specialization, IsActive, CreatedAt) " +
                    "VALUES (@Id, @FullName, @Email, @PasswordHash, @Role, @DateOfBirth, @PhoneNumber, @ParentName, @Specialization, @IsActive, @CreatedAt)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@FullName", user.FullName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Role", user.Role ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ParentName", user.ParentName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Specialization", user.Specialization ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt); // ДОБАВЬТЕ эту строку

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка добавления пользователя: {ex.Message}");
                return false;
            }
        }

        // Добавляем метод GetUsers
        public List<Participant> GetUsers()
        {
            var users = new List<Participant>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Users", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new Participant
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                            Role = reader.GetString(reader.GetOrdinal("Role")),
                            DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ?
                                                 (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        // Основные методы для работы с данными через ADO.NET
        public List<Circle> GetCircles()
        {
            var circles = new List<Circle>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Circles WHERE IsActive = 1", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var circle = new Circle
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                         null : reader.GetString(reader.GetOrdinal("Description")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ?
                                      null : reader.GetString(reader.GetOrdinal("Category")),
                            AgeMin = reader.GetInt32(reader.GetOrdinal("AgeMin")),
                            AgeMax = reader.GetInt32(reader.GetOrdinal("AgeMax")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            MaxParticipants = reader.GetInt32(reader.GetOrdinal("MaxParticipants")),
                            CurrentParticipants = reader.GetInt32(reader.GetOrdinal("CurrentParticipants")),
                            TeacherId = reader.IsDBNull(reader.GetOrdinal("TeacherId")) ?
                                       (Guid?)null : reader.GetGuid(reader.GetOrdinal("TeacherId")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        };
                        circles.Add(circle);
                    }
                }
            }

            return circles;
        }

        public Participant GetUserByEmail(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Participant
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                            Role = reader.GetString(reader.GetOrdinal("Role")),
                            DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ?
                                         (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };
                    }
                }
            }

            return null;
        }

        public Circle GetCircleById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Circles WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Circle
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                         null : reader.GetString(reader.GetOrdinal("Description")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ?
                                      null : reader.GetString(reader.GetOrdinal("Category")),
                            AgeMin = reader.GetInt32(reader.GetOrdinal("AgeMin")),
                            AgeMax = reader.GetInt32(reader.GetOrdinal("AgeMax")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            MaxParticipants = reader.GetInt32(reader.GetOrdinal("MaxParticipants")),
                            CurrentParticipants = reader.GetInt32(reader.GetOrdinal("CurrentParticipants")),
                            TeacherId = reader.IsDBNull(reader.GetOrdinal("TeacherId")) ?
            (Guid?)null : reader.GetGuid(reader.GetOrdinal("TeacherId")),

                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        };
                    }
                }
            }

            return null;
        }

        public Participant GetUserById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Participant
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                            Role = reader.GetString(reader.GetOrdinal("Role")),
                            DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ?
                                         (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };
                    }
                }
            }

            return null;
        }

        public void InitializeSampleData()
        {
            try
            {
                var security = new SecurityService();

                // Проверяем, есть ли пользователи
                bool hasUsers;
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SELECT COUNT(*) FROM Users", connection))
                {
                    connection.Open();
                    hasUsers = (int)command.ExecuteScalar() > 0;
                }

                if (!hasUsers)
                {
                    // Добавляем тестовых пользователей с хэшированными паролями
                    var users = new List<Participant>
            {
                new Participant
                {
                    Id = Guid.NewGuid(),
                    FullName = "Иван Иванов",
                    Email = "student@test.ru",
                    PasswordHash = security.HashPassword("test123"),
                    Role = "Student",
                    DateOfBirth = new DateTime(2010, 5, 15),
                    IsActive = true
                },
                new Participant
                {
                    Id = Guid.NewGuid(),
                    FullName = "Петр Петров",
                    Email = "teacher@test.ru",
                    PasswordHash = security.HashPassword("test123"),
                    Role = "Teacher",
                    IsActive = true
                },
                new Participant
                {
                    Id = Guid.NewGuid(),
                    FullName = "Админ Админов",
                    Email = "admin@test.ru",
                    PasswordHash = security.HashPassword("test123"),
                    Role = "Admin",
                    IsActive = true
                }
            };

                    foreach (var user in users)
                    {
                        using (var connection = new SqlConnection(_connectionString))
                        using (var command = new SqlCommand(
                            "INSERT INTO Users (Id, FullName, Email, PasswordHash, Role, DateOfBirth, IsActive) " +
                            "VALUES (@Id, @FullName, @Email, @PasswordHash, @Role, @DateOfBirth, @IsActive)", connection))
                        {
                            command.Parameters.AddWithValue("@Id", user.Id);
                            command.Parameters.AddWithValue("@FullName", user.FullName);
                            command.Parameters.AddWithValue("@Email", user.Email);
                            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                            command.Parameters.AddWithValue("@Role", user.Role);
                            command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@IsActive", user.IsActive);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Проверяем, есть ли кружки
                bool hasCircles;
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SELECT COUNT(*) FROM Circles", connection))
                {
                    connection.Open();
                    hasCircles = (int)command.ExecuteScalar() > 0;
                }

                if (!hasCircles)
                {
                    // Получаем ID преподавателя
                    Guid teacherId;
                    using (var connection = new SqlConnection(_connectionString))
                    using (var command = new SqlCommand("SELECT Id FROM Users WHERE Role = 'Teacher'", connection))
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        teacherId = result != null ? (Guid)result : Guid.NewGuid();
                    }

                    // Добавляем тестовые кружки
                    var circles = new List<Circle>
            {
                new Circle
                {
                    Id = Guid.NewGuid(),
                    Name = "Футбол для детей",
                    Description = "Обучение основам футбола для детей",
                    Category = "Спорт",
                    AgeMin = 6,
                    AgeMax = 12,
                    Price = 1500,
                    MaxParticipants = 15,
                    CurrentParticipants = 5,
                    TeacherId = teacherId,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Circle
                {
                    Id = Guid.NewGuid(),
                    Name = "Рисование акварелью",
                    Description = "Основы рисования акварельными красками",
                    Category = "Творчество",
                    AgeMin = 8,
                    AgeMax = 14,
                    Price = 1200,
                    MaxParticipants = 10,
                    CurrentParticipants = 3,
                    TeacherId = teacherId,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Circle
                {
                    Id = Guid.NewGuid(),
                    Name = "Программирование на Scratch",
                    Description = "Введение в программирование для детей",
                    Category = "Наука",
                    AgeMin = 10,
                    AgeMax = 16,
                    Price = 2000,
                    MaxParticipants = 12,
                    CurrentParticipants = 2,
                    TeacherId = teacherId,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            };

                    foreach (var circle in circles)
                    {
                        using (var connection = new SqlConnection(_connectionString))
                        using (var command = new SqlCommand(
                            "INSERT INTO Circles (Id, Name, Description, Category, AgeMin, AgeMax, Price, " +
                            "MaxParticipants, CurrentParticipants, TeacherId, IsActive, CreatedAt) " +
                            "VALUES (@Id, @Name, @Description, @Category, @AgeMin, @AgeMax, @Price, " +
                            "@MaxParticipants, @CurrentParticipants, @TeacherId, @IsActive, @CreatedAt)", connection))
                        {
                            command.Parameters.AddWithValue("@Id", circle.Id);
                            command.Parameters.AddWithValue("@Name", circle.Name);
                            command.Parameters.AddWithValue("@Description", (object)circle.Description ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Category", (object)circle.Category ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AgeMin", circle.AgeMin);
                            command.Parameters.AddWithValue("@AgeMax", circle.AgeMax);
                            command.Parameters.AddWithValue("@Price", circle.Price);
                            command.Parameters.AddWithValue("@MaxParticipants", circle.MaxParticipants);
                            command.Parameters.AddWithValue("@CurrentParticipants", circle.CurrentParticipants);
                            command.Parameters.AddWithValue("@TeacherId", (object)circle.TeacherId ?? DBNull.Value);
                            command.Parameters.AddWithValue("@IsActive", circle.IsActive);
                            command.Parameters.AddWithValue("@CreatedAt", circle.CreatedAt);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации данных: {ex.Message}");
            }
        }
        // В класс DatabaseService добавьте:
        public bool UpdateCircle(Circle circle)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    @"UPDATE Circles SET 
                Name = @Name,
                Description = @Description,
                Category = @Category,
                AgeMin = @AgeMin,
                AgeMax = @AgeMax,
                Price = @Price,
                MaxParticipants = @MaxParticipants,
                CurrentParticipants = @CurrentParticipants,
                TeacherId = @TeacherId,
                IsActive = @IsActive,
                UpdatedAt = @UpdatedAt,
                RegistrationStartDate = @RegistrationStartDate,
                RegistrationEndDate = @RegistrationEndDate,
                MaxRegistrationsPerUser = @MaxRegistrationsPerUser,
                AllowRegistrationEdit = @AllowRegistrationEdit,
                EditDeadlineDays = @EditDeadlineDays
              WHERE Id = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", circle.Id);
                    command.Parameters.AddWithValue("@Name", circle.Name);
                    command.Parameters.AddWithValue("@Description", circle.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", circle.Category);
                    command.Parameters.AddWithValue("@AgeMin", circle.AgeMin);
                    command.Parameters.AddWithValue("@AgeMax", circle.AgeMax);
                    command.Parameters.AddWithValue("@Price", circle.Price);
                    command.Parameters.AddWithValue("@MaxParticipants", circle.MaxParticipants);
                    command.Parameters.AddWithValue("@CurrentParticipants", circle.CurrentParticipants);
                    command.Parameters.AddWithValue("@TeacherId", circle.TeacherId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", circle.IsActive);
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    command.Parameters.AddWithValue("@RegistrationStartDate", circle.RegistrationStartDate);
                    command.Parameters.AddWithValue("@RegistrationEndDate", circle.RegistrationEndDate);
                    command.Parameters.AddWithValue("@MaxRegistrationsPerUser", circle.MaxRegistrationsPerUser);
                    command.Parameters.AddWithValue("@AllowRegistrationEdit", circle.AllowRegistrationEdit);
                    command.Parameters.AddWithValue("@EditDeadlineDays", circle.EditDeadlineDays);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления кружка: {ex.Message}");
                return false;
            }
        }
        // В класс DatabaseService добавьте этот метод:
        public bool SendNotificationToUser(Guid userId, string title, string message, string notificationType, Guid? referenceId = null)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    @"INSERT INTO Notifications 
                (Id, UserId, Title, Message, Type, ReferenceId, IsRead, CreatedAt) 
              VALUES 
                (@Id, @UserId, @Title, @Message, @Type, @ReferenceId, @IsRead, @CreatedAt)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@Type", notificationType);
                    command.Parameters.AddWithValue("@ReferenceId", referenceId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsRead", false);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка отправки уведомления: {ex.Message}");
                return false;
            }
        }
        // В класс DatabaseService добавьте этот метод:
        public List<RegistrationWithDetails> GetRegistrationsWithDetails()
        {
            var registrations = new List<RegistrationWithDetails>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    @"SELECT 
                r.Id,
                r.ParticipantId,
                r.CircleId,
                r.ApplicationDate,
                r.Status,
                r.ApprovalDate,
                r.RejectionReason,
                r.CreatedAt,
                u.FullName as ParticipantName,
                c.Name as CircleName,
                c.Category as CircleCategory,
                c.Price as CirclePrice,
                t.FullName as TeacherName
              FROM Registrations r
              LEFT JOIN Users u ON r.ParticipantId = u.Id
              LEFT JOIN Circles c ON r.CircleId = c.Id
              LEFT JOIN Users t ON c.TeacherId = t.Id
              ORDER BY r.ApplicationDate DESC",
                    connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reg = new RegistrationWithDetails
                            {
                                Id = reader.GetGuid(0),
                                ParticipantId = reader.GetGuid(1),
                                CircleId = reader.GetGuid(2),
                                ApplicationDate = reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                CreatedAt = reader.GetDateTime(7),
                                ParticipantName = reader.IsDBNull(8) ? "Неизвестно" : reader.GetString(8),
                                CircleName = reader.IsDBNull(9) ? "Неизвестно" : reader.GetString(9),
                                CircleCategory = reader.IsDBNull(10) ? null : reader.GetString(10),
                                CirclePrice = reader.IsDBNull(11) ? 0 : reader.GetDecimal(11),
                                TeacherName = reader.IsDBNull(12) ? null : reader.GetString(12)
                            };

                            if (!reader.IsDBNull(5))
                                reg.ApprovalDate = reader.GetDateTime(5);

                            if (!reader.IsDBNull(6))
                                reg.RejectionReason = reader.GetString(6);

                            registrations.Add(reg);
                        }
                    }
                }

                Debug.WriteLine($"Загружено {registrations.Count} заявок с деталями");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка получения заявок с деталями: {ex.Message}");
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return registrations;
        }
        public List<Participant> GetAllTeachers()
        {
            var teachers = new List<Participant>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    "SELECT * FROM Users WHERE Role = 'Teacher' AND IsActive = 1",
                    connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var teacher = new Participant
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Role = reader.GetString(reader.GetOrdinal("Role")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            };
                            teachers.Add(teacher);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения преподавателей: {ex.Message}");
            }

            return teachers;
        }
        public void Dispose()
        {
            // Ничего не делаем, так как соединение открывается/закрывается в каждом методе
        }
    }
}