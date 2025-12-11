using CircleRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace CircleRegistrationSystem.Services
{
    public class RegistrationService
    {
        private readonly DatabaseService _db;
        private readonly NotificationService _notificationService;

        public RegistrationService(DatabaseService db)
        {
            _db = db;
            _notificationService = new NotificationService(db);
        }
        public bool ApproveRegistration(Guid registrationId, Guid approvedBy)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null)
                    return false;

                registration.Status = "Approved";
                registration.ApprovalDate = DateTime.Now;
                registration.ApprovedBy = approvedBy;
                registration.UpdatedAt = DateTime.Now;

                // Сохраняем в БД
                if (_db.UpdateRegistration(registration))
                {
                    // Отправляем уведомление пользователю
                    var circle = _db.GetCircleById(registration.CircleId);
                    var user = _db.GetUserById(registration.ParticipantId);

                    if (user != null && circle != null)
                    {
                        _db.SendNotificationToUser(
                            registration.ParticipantId,
                            "✅ Заявка подтверждена!",
                            $"Ваша заявка на кружок '{circle.Name}' подтверждена. Можете начинать занятия!",
                            "Approval",
                            registrationId
                        );
                    }

                    // Отправляем уведомление преподавателю (если есть)
                    if (circle?.TeacherId != null)
                    {
                        _db.SendNotificationToUser(
                            circle.TeacherId.Value,
                            "📝 Новый участник в кружке",
                            $"В ваш кружок '{circle.Name}' добавлен новый участник: {user?.FullName}",
                            "NewParticipant",
                            registrationId
                        );
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка подтверждения заявки: {ex.Message}");
                return false;
            }
        }
        // В классе RegistrationService добавьте:
        private string GetParticipantName(Guid participantId)
        {
            try
            {
                var participant = _db.GetUserById(participantId);
                return participant?.FullName ?? "Неизвестный участник";
            }
            catch
            {
                return "Ошибка загрузки";
            }
        }

        // Или добавьте публичный метод для использования в других местах:
        public string GetParticipantNamePublic(Guid participantId)
        {
            return GetParticipantName(participantId);
        }
        // 3.2. Регистрация участников с уникальным ID
        public Registration CreateRegistration(Guid participantId, Guid circleId)
        {
            try
            {
                var circle = _db.GetCircleById(circleId);
                if (circle == null || !circle.IsActive)
                    return null;

                // Проверка периода регистрации
                if (DateTime.Now < circle.RegistrationStartDate ||
                    DateTime.Now > circle.RegistrationEndDate)
                {
                    return null; // Регистрация закрыта
                }

                // Проверка доступности мест
                if (circle.CurrentParticipants >= circle.MaxParticipants)
                    return null;

                // Проверка дублирующих заявок
                var existingRegistration = _db.GetRegistrations()
                    .FirstOrDefault(r => r.ParticipantId == participantId &&
                                        r.CircleId == circleId &&
                                        r.Status != "Cancelled" &&
                                        r.Status != "Rejected");

                if (existingRegistration != null)
                    return null;

                // Создание заявки с уникальным ID
                var registration = new Registration
                {
                    Id = Guid.NewGuid(), // Уникальный идентификатор
                    ParticipantId = participantId,
                    CircleId = circleId,
                    ApplicationDate = DateTime.Now,
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                };

                if (_db.AddRegistration(registration))
                {
                    // Отправка уведомления
                    _notificationService.SendRegistrationNotification(registration.Id);

                    return registration;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка создания заявки: {ex.Message}");
            }
            return null;
        }

        // 3.2. Редактирование заявки до определенного срока
        public bool UpdateRegistration(Guid registrationId, Registration updatedRegistration)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null)
                    return false;

                // Проверка возможности редактирования
                var circle = _db.GetCircleById(registration.CircleId);
                if (!circle.AllowRegistrationEdit)
                    return false;

                // Проверка срока редактирования
                var daysSinceApplication = (DateTime.Now - registration.ApplicationDate).TotalDays;
                if (daysSinceApplication > circle.EditDeadlineDays)
                    return false;

                // Только определенные поля можно редактировать
                registration.UpdatedAt = DateTime.Now;

                return _db.UpdateRegistration(registration);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления заявки: {ex.Message}");
                return false;
            }
        }

        // 3.3. Просмотр списка записанных участников
        public List<Registration> GetRegistrationsByCircle(Guid circleId, string role = null, Guid? viewerId = null)
        {
            try
            {
                var registrations = _db.GetRegistrations()
                    .Where(r => r.CircleId == circleId && r.Status == "Approved")
                    .ToList();

                // Фильтрация по роли просматривающего
                if (role == "Teacher")
                {
                    // Преподаватель видит только своих кружков
                    var circle = _db.GetCircleById(circleId);
                    if (circle?.TeacherId != viewerId)
                        return new List<Registration>();
                }

                return registrations;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка получения регистраций: {ex.Message}");
                return new List<Registration>();
            }
        }

        // 3.3. История посещаемости
        public List<Attendance> GetAttendanceHistory(Guid registrationId)
        {
            try
            {
                return _db.GetAttendances()
                    .Where(a => a.RegistrationId == registrationId)
                    .OrderByDescending(a => a.Date)
                    .ToList();
            }
            catch
            {
                return new List<Attendance>();
            }
        }

        // 3.3. Отметка присутствия
        public bool MarkAttendance(Guid registrationId, DateTime date, string status, string notes, Guid markedBy)
        {
            try
            {
                var attendance = new Attendance
                {
                    RegistrationId = registrationId,
                    Date = date.Date,
                    Status = status,
                    Notes = notes,
                    CheckInTime = DateTime.Now,
                    CreatedBy = markedBy,
                    CreatedAt = DateTime.Now
                };

                return _db.AddAttendance(attendance);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отметки посещаемости: {ex.Message}");
                return false;
            }
        }

        // 3.3. Обновление статуса участника
        public bool UpdateRegistrationStatus(Guid registrationId, string status, Guid updatedBy, string reason = null)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null)
                    return false;

                registration.Status = status;
                registration.UpdatedAt = DateTime.Now;

                if (status == "Approved")
                {
                    registration.ApprovalDate = DateTime.Now;
                    registration.ApprovedBy = updatedBy;

                    // Увеличиваем счетчик участников кружка
                    var circle = _db.GetCircleById(registration.CircleId);
                    if (circle != null)
                    {
                        circle.CurrentParticipants++;
                        _db.UpdateCircle(circle);
                    }
                }
                else if (status == "Rejected")
                {
                    registration.RejectedBy = updatedBy;
                    registration.RejectionReason = reason;
                }

                return _db.UpdateRegistration(registration);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления статуса: {ex.Message}");
                return false;
            }
        }

        // Получение всех заявок (для админа)
        public List<Registration> GetAllRegistrations()
        {
            try
            {
                return _db.GetRegistrations();
            }
            catch
            {
                return new List<Registration>();
            }
        }

        // Отмена заявки
        public bool CancelRegistration(Guid registrationId)
        {
            try
            {
                return UpdateRegistrationStatus(registrationId, "Cancelled", Guid.Empty);
            }
            catch
            {
                return false;
            }
        }



        // Отклонение заявки
        public bool RejectRegistration(Guid registrationId, string reason, Guid rejectedBy)
        {
            try
            {
                var registration = _db.GetRegistrationById(registrationId);
                if (registration == null)
                    return false;

                registration.Status = "Rejected";
                registration.RejectionReason = reason;
                registration.RejectedBy = rejectedBy;
                registration.UpdatedAt = DateTime.Now;

                if (_db.UpdateRegistration(registration))
                {
                    // Отправляем уведомление пользователю
                    var circle = _db.GetCircleById(registration.CircleId);
                    var user = _db.GetUserById(registration.ParticipantId);

                    if (user != null && circle != null)
                    {
                        _db.SendNotificationToUser(
                            registration.ParticipantId,
                            "❌ Заявка отклонена",
                            $"Ваша заявка на кружок '{circle.Name}' отклонена. Причина: {reason}",
                            "Rejection",
                            registrationId
                        );
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка отклонения заявки: {ex.Message}");
                return false;
            }
        }

        // Получение заявок пользователя
        public List<Registration> GetUserRegistrations(Guid userId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                var registrations = new List<Registration>();

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(
                    @"SELECT r.*, c.Name as CircleName, u.FullName as TeacherName 
              FROM Registrations r
              LEFT JOIN Circles c ON r.CircleId = c.Id
              LEFT JOIN Users u ON c.TeacherId = u.Id
              WHERE r.ParticipantId = @UserId
              ORDER BY r.ApplicationDate DESC",
                    connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
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

                            // Дополнительная информация
                            if (!reader.IsDBNull(reader.GetOrdinal("CircleName")))
                            {
                                registration.Circle = new Circle
                                {
                                    Id = registration.CircleId,
                                    Name = reader.GetString(reader.GetOrdinal("CircleName"))
                                };
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("TeacherName")))
                            {
                                registration.Circle.Teacher = new Participant
                                {
                                    FullName = reader.GetString(reader.GetOrdinal("TeacherName"))
                                };
                            }

                            registrations.Add(registration);
                        }
                    }
                }

                return registrations;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка GetUserRegistrations: {ex.Message}");
                return new List<Registration>();
            }
        }
    }
}