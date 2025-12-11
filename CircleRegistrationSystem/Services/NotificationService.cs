using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CircleRegistrationSystem.Models;

namespace CircleRegistrationSystem.Services
{
    public class NotificationService
    {
        private readonly DatabaseService _db;

        public NotificationService(DatabaseService db)
        {
            _db = db;
        }

        // Отправка уведомления о регистрации
        public bool SendRegistrationNotification(Guid registrationId)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null) return false;

                var participant = _db.GetUserById(registration.ParticipantId);
                var circle = _db.GetCircleById(registration.CircleId);

                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    UserId = registration.ParticipantId,
                    Title = "Новая заявка на кружок",
                    Message = $"Ваша заявка на кружок '{circle?.Name}' принята. Номер заявки: {registration.Id.ToString().Substring(0, 8)}",
                    Type = "Registration",
                    ReferenceId = registrationId,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                return AddNotification(notification);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления о регистрации: {ex.Message}");
                return false;
            }
        }

        // Уведомление о подтверждении заявки
        public bool SendApprovalNotification(Guid registrationId)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null) return false;

                var circle = _db.GetCircleById(registration.CircleId);

                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    UserId = registration.ParticipantId,
                    Title = "Заявка подтверждена",
                    Message = $"Ваша заявка на кружок '{circle?.Name}' подтверждена. Вы можете начинать занятия.",
                    Type = "Approval",
                    ReferenceId = registrationId,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                return AddNotification(notification);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления о подтверждении: {ex.Message}");
                return false;
            }
        }

        // Уведомление об отклонении заявки
        public bool SendRejectionNotification(Guid registrationId, string reason)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null) return false;

                var circle = _db.GetCircleById(registration.CircleId);

                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    UserId = registration.ParticipantId,
                    Title = "Заявка отклонена",
                    Message = $"Ваша заявка на кружок '{circle?.Name}' отклонена. Причина: {reason}",
                    Type = "Rejection",
                    ReferenceId = registrationId,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                return AddNotification(notification);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления об отклонении: {ex.Message}");
                return false;
            }
        }

        // Уведомление о посещаемости (для преподавателей)
        public bool SendAttendanceNotification(Guid attendanceId, Guid markedBy)
        {
            try
            {
                var attendance = GetAttendanceById(attendanceId);
                if (attendance == null) return false;

                var registration = _db.GetRegistrationById(attendance.RegistrationId);
                var circle = _db.GetCircleById(registration.CircleId);

                // Уведомление для родителя/участника
                var userNotification = new Notification
                {
                    Id = Guid.NewGuid(),
                    UserId = registration.ParticipantId,
                    Title = "Отметка посещаемости",
                    Message = $"Ваше посещение кружка '{circle?.Name}' от {attendance.Date:dd.MM.yyyy} отмечено как '{GetAttendanceStatusDisplay(attendance.Status)}'",
                    Type = "Attendance",
                    ReferenceId = attendanceId,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                // Уведомление для преподавателя
                var teacherNotification = new Notification
                {
                    Id = Guid.NewGuid(),
                    UserId = circle.TeacherId ?? Guid.Empty,
                    Title = "Посещаемость отмечена",
                    Message = $"Посещаемость участника {GetParticipantName(registration.ParticipantId)} отмечена",
                    Type = "AttendanceMarked",
                    ReferenceId = attendanceId,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                return AddNotification(userNotification) && AddNotification(teacherNotification);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления о посещаемости: {ex.Message}");
                return false;
            }
        }

        // Уведомление о приближении дедлайна редактирования
        public bool SendEditDeadlineNotification(Guid registrationId)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null) return false;

                var circle = _db.GetCircleById(registration.CircleId);
                var daysLeft = circle.EditDeadlineDays - (DateTime.Now - registration.ApplicationDate).Days;

                if (daysLeft <= 3 && daysLeft > 0)
                {
                    var notification = new Notification
                    {
                        Id = Guid.NewGuid(),
                        UserId = registration.ParticipantId,
                        Title = "Срок редактирования заявки",
                        Message = $"У вас осталось {daysLeft} дня(ей) для редактирования заявки на кружок '{circle?.Name}'",
                        Type = "Deadline",
                        ReferenceId = registrationId,
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    };

                    return AddNotification(notification);
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления о дедлайне: {ex.Message}");
                return false;
            }
        }
        // Найдите все места, где используется GetParticipantName и замените:
        private string GetParticipantName(Guid participantId)
        {
            try
            {
                // Используем DatabaseService для получения имени
                var participant = _db.GetUserById(participantId);
                return participant?.FullName ?? "Участник";
            }
            catch
            {
                return "Неизвестно";
            }
        }

        // Или если нужно получить через RegistrationService:
     
        // Получение уведомлений пользователя
        public List<Notification> GetUserNotifications(Guid userId)
        {
            try
            {
                var notifications = new List<Notification>();

                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    "SELECT * FROM Notifications WHERE UserId = @UserId ORDER BY CreatedAt DESC",
                    connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var notification = new Notification
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Message = reader.GetString(reader.GetOrdinal("Message")),
                                Type = reader.GetString(reader.GetOrdinal("Type")),
                                IsRead = reader.GetBoolean(reader.GetOrdinal("IsRead")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("ReferenceId")))
                                notification.ReferenceId = reader.GetGuid(reader.GetOrdinal("ReferenceId"));

                            if (!reader.IsDBNull(reader.GetOrdinal("ReadAt")))
                                notification.ReadAt = reader.GetDateTime(reader.GetOrdinal("ReadAt"));

                            notifications.Add(notification);
                        }
                    }
                }

                return notifications;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения уведомлений: {ex.Message}");
                return new List<Notification>();
            }
        }
        public bool SendTeacherNotification(Guid teacherId, string title, string message, string type, Guid referenceId)
        {
            try
            {
                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    UserId = teacherId,
                    Title = title,
                    Message = message,
                    Type = type,
                    ReferenceId = referenceId,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                return AddNotification(notification);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления преподавателю: {ex.Message}");
                return false;
            }
        }
        // Получение количества непрочитанных уведомлений
        public int GetUnreadCount(Guid userId)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    "SELECT COUNT(*) FROM Notifications WHERE UserId = @UserId AND IsRead = 0",
                    connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения количества уведомлений: {ex.Message}");
                return 0;
            }
        }

        // Отметить как прочитанное
        public bool MarkAsRead(Guid notificationId)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    "UPDATE Notifications SET IsRead = 1, ReadAt = @ReadAt WHERE Id = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", notificationId);
                    command.Parameters.AddWithValue("@ReadAt", DateTime.Now);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отметки уведомления как прочитанного: {ex.Message}");
                return false;
            }
        }

        // Отметить все как прочитанные
        public bool MarkAllAsRead(Guid userId)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    "UPDATE Notifications SET IsRead = 1, ReadAt = @ReadAt WHERE UserId = @UserId AND IsRead = 0",
                    connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@ReadAt", DateTime.Now);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отметки всех уведомлений: {ex.Message}");
                return false;
            }
        }

        // Добавление уведомления в БД
        private bool AddNotification(Notification notification)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    @"INSERT INTO Notifications 
                      (Id, UserId, Title, Message, Type, ReferenceId, IsRead, CreatedAt) 
                      VALUES (@Id, @UserId, @Title, @Message, @Type, @ReferenceId, @IsRead, @CreatedAt)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", notification.Id);
                    command.Parameters.AddWithValue("@UserId", notification.UserId);
                    command.Parameters.AddWithValue("@Title", notification.Title);
                    command.Parameters.AddWithValue("@Message", notification.Message);
                    command.Parameters.AddWithValue("@Type", notification.Type);
                    command.Parameters.AddWithValue("@ReferenceId", notification.ReferenceId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsRead", notification.IsRead);
                    command.Parameters.AddWithValue("@CreatedAt", notification.CreatedAt);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка добавления уведомления: {ex.Message}");
                return false;
            }
        }

        // Вспомогательные методы
        private Attendance GetAttendanceById(Guid attendanceId)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    "SELECT * FROM Attendances WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", attendanceId);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Attendance
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                RegistrationId = reader.GetGuid(reader.GetOrdinal("RegistrationId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }
            catch
            {
                // Игнорируем ошибки
            }

            return null;
        }

        private string GetAttendanceStatusDisplay(string status)
        {
            switch (status)
            {
                case "Present": return "Присутствовал";
                case "Absent": return "Отсутствовал";
                case "Late": return "Опоздал";
                case "Excused": return "По уважительной причине";
                default: return status;
            }
        }

     
    }
}