using System;
using System.Collections.Generic;
using System.Linq;
using CircleRegistrationSystem.Models;

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
                    // УВЕДОМЛЕНИЕ для участника
                    var notificationService = new NotificationService(_db);
                    notificationService.SendApprovalNotification(registrationId);

                    // УВЕДОМЛЕНИЕ для преподавателя (если есть)
                    var circle = _db.GetCircleById(registration.CircleId);
                    if (circle?.TeacherId != null)
                    {
                        notificationService.SendTeacherNotification(
                            circle.TeacherId.Value,
                            $"Новый участник подтвержден в кружке '{circle.Name}'",
                            $"Участник {GetParticipantName(registration.ParticipantId)} подтвержден",
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
                System.Diagnostics.Debug.WriteLine($"Ошибка подтверждения заявки: {ex.Message}");
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
            return UpdateRegistrationStatus(registrationId, "Rejected", rejectedBy, reason);
        }

        // Получение заявок пользователя
        public List<Registration> GetUserRegistrations(Guid userId)
        {
            try
            {
                return _db.GetRegistrations()
                    .Where(r => r.ParticipantId == userId)
                    .ToList();
            }
            catch
            {
                return new List<Registration>();
            }
        }
    }
}