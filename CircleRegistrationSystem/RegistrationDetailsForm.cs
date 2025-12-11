using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;

namespace CircleRegistrationSystem.Forms
{
    public partial class RegistrationDetailsForm : Form
    {
        private readonly Registration _registration;
        private readonly DatabaseService _db;
        private readonly RegistrationService _registrationService;
        private Participant _participant;
        private Circle _circle;

        public RegistrationDetailsForm(Registration registration, DatabaseService db)
        {
            InitializeComponent();
            _registration = registration;
            _db = db;
            _registrationService = new RegistrationService(db);

            InitializeForm();
            LoadData();
        }

        private void InitializeForm()
        {
            Text = "Детали заявки";
            Size = new Size(600, 500);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void LoadData()
        {
            try
            {
                // Загружаем данные участника
                _participant = _db.GetUserById(_registration.ParticipantId);

                // Загружаем данные кружка
                _circle = _db.GetCircleById(_registration.CircleId);

                // Заполняем поля
                lblRegistrationId.Text = $"ID заявки: {_registration.Id}";
                lblParticipantName.Text = $"Участник: {_participant?.FullName ?? "Неизвестно"}";
                lblParticipantEmail.Text = $"Email: {_participant?.Email ?? "Неизвестно"}";
                lblParticipantRole.Text = $"Роль: {_participant?.Role ?? "Неизвестно"}";

                lblCircleName.Text = $"Кружок: {_circle?.Name ?? "Неизвестно"}";
                lblCircleCategory.Text = $"Категория: {_circle?.Category ?? "Неизвестно"}";
                lblCircleAgeRange.Text = $"Возраст: {_circle?.AgeMin ?? 0}-{_circle?.AgeMax ?? 0} лет";
                lblCirclePrice.Text = $"Цена: {_circle?.Price ?? 0:F2} руб.";

                lblApplicationDate.Text = $"Дата заявки: {_registration.ApplicationDate:dd.MM.yyyy HH:mm}";
                lblStatus.Text = $"Статус: {GetStatusDisplay(_registration.Status)}";
                lblAttendanceStatus.Text = $"Посещаемость: {_registration.AttendanceStatus ?? "Не указана"}";

                if (_registration.ApprovalDate.HasValue)
                {
                    lblApprovalDate.Text = $"Дата подтверждения: {_registration.ApprovalDate.Value:dd.MM.yyyy HH:mm}";
                }
                else
                {
                    lblApprovalDate.Text = "Дата подтверждения: Не подтверждена";
                }

                if (!string.IsNullOrEmpty(_registration.RejectionReason))
                {
                    lblRejectionReason.Text = $"Причина отклонения: {_registration.RejectionReason}";
                    lblRejectionReason.Visible = true;
                }
                else
                {
                    lblRejectionReason.Visible = false;
                }

                // Загружаем историю посещаемости
                var attendanceHistory = _registrationService.GetAttendanceHistory(_registration.Id);

                if (attendanceHistory.Any())
                {
                    lblAttendanceHistory.Text = $"История посещаемости ({attendanceHistory.Count} записей):";

                    var historyText = string.Join("\n", attendanceHistory.Select(a =>
                        $"{a.Date:dd.MM.yyyy}: {GetAttendanceStatusDisplay(a.Status)} - {a.Notes}"));

                    txtAttendanceHistory.Text = historyText;
                }
                else
                {
                    lblAttendanceHistory.Text = "История посещаемости: Нет данных";
                    txtAttendanceHistory.Text = "Записей о посещаемости нет.";
                }

                // Настраиваем кнопки в зависимости от статуса
                ConfigureButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureButtons()
        {
            // Показываем кнопки в зависимости от роли и статуса заявки
            bool isAdmin = (_participant?.Role == "Admin");
            bool isTeacher = (_participant?.Role == "Teacher");
            bool isPending = (_registration.Status == "Pending");
            bool isApproved = (_registration.Status == "Approved");

            btnApprove.Visible = isAdmin && isPending;
            btnReject.Visible = isAdmin && isPending;
            btnCancel.Visible = !isAdmin && isPending; // Только участник может отменить свою заявку
            btnEdit.Visible = isPending && CanEditRegistration();
            btnMarkAttendance.Visible = isTeacher && isApproved;

            // Кнопка закрытия всегда видна
            btnClose.Visible = true;
        }

        private bool CanEditRegistration()
        {
            if (_circle == null || !_circle.AllowRegistrationEdit)
                return false;

            var daysSinceApplication = (DateTime.Now - _registration.ApplicationDate).TotalDays;
            return daysSinceApplication <= _circle.EditDeadlineDays;
        }

        private string GetStatusDisplay(string status)
        {
            switch (status)
            {
                case "Pending": return "На рассмотрении";
                case "Approved": return "Подтверждена";
                case "Rejected": return "Отклонена";
                case "Cancelled": return "Отменена";
                case "Active": return "Активна";
                case "Inactive": return "Неактивна";
                default: return status;
            }
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

        // Обработчики событий кнопок
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердить эту заявку?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_registrationService.ApproveRegistration(_registration.Id, _participant.Id))
                {
                    MessageBox.Show("Заявка подтверждена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при подтверждении заявки", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            using (var reasonForm = new RejectReasonForm())
            {
                if (reasonForm.ShowDialog() == DialogResult.OK)
                {
                    if (_registrationService.RejectRegistration(_registration.Id, reasonForm.Reason, _participant.Id))
                    {
                        MessageBox.Show("Заявка отклонена", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при отклонении заявки", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить эту заявку?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_registrationService.CancelRegistration(_registration.Id))
                {
                    MessageBox.Show("Заявка отменена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при отмене заявки", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактирование заявки будет доступно в следующей версии", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            using (var attendanceForm = new AttendanceForm(_circle.Id, _db))
            {
                attendanceForm.ShowDialog();
                LoadData(); // Обновляем данные после закрытия формы
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}