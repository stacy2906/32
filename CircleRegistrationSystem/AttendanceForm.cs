using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;

namespace CircleRegistrationSystem.Forms
{
    public partial class AttendanceForm : Form
    {
        private readonly Guid _circleId;
        private readonly DatabaseService _db;
        private readonly RegistrationService _registrationService;
        private List<Registration> _registrations;
        private DateTime _selectedDate;
        private Circle _circle;

        public AttendanceForm(Guid circleId, DatabaseService db)
        {
            InitializeComponent();
            _circleId = circleId;
            _db = db;
            _registrationService = new RegistrationService(db);
            _selectedDate = DateTime.Today;

            InitializeForm();
            LoadData();
        }

        private void InitializeForm()
        {
            Text = "Отметка посещаемости";
            Size = new Size(800, 500);
            StartPosition = FormStartPosition.CenterParent;

            dtpDate.Value = DateTime.Today;
            dtpDate.ValueChanged += (s, e) =>
            {
                _selectedDate = dtpDate.Value;
                LoadAttendanceForDate();
            };

            // Настройка DataGridView
            dgvAttendance.AutoGenerateColumns = false;
            ConfigureAttendanceGrid();
        }

        private void ConfigureAttendanceGrid()
        {
            dgvAttendance.Columns.Clear();

            // Колонка ID (скрытая)
            var idColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RegistrationId",
                HeaderText = "ID",
                Visible = false,
                Name = "RegistrationId"
            };
            dgvAttendance.Columns.Add(idColumn);

            // Колонка имени участника
            var nameColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ParticipantName",
                HeaderText = "Участник",
                Width = 150,
                ReadOnly = true,
                Name = "ParticipantName"
            };
            dgvAttendance.Columns.Add(nameColumn);

            // Колонка статуса (выпадающий список)
            var statusColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Статус",
                Width = 120,
                Name = "Status"
            };
            statusColumn.Items.AddRange("Present", "Absent", "Late", "Excused");
            dgvAttendance.Columns.Add(statusColumn);

            // Колонка примечаний
            var notesColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Notes",
                HeaderText = "Примечания",
                Width = 200,
                Name = "Notes"
            };
            dgvAttendance.Columns.Add(notesColumn);

            // Колонка "Отмечено" (только для чтения)
            var markedColumn = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsMarked",
                HeaderText = "Отмечено",
                Width = 80,
                ReadOnly = true,
                Name = "IsMarked"
            };
            dgvAttendance.Columns.Add(markedColumn);
        }

        private void LoadData()
        {
            try
            {
                // Загружаем информацию о кружке
                _circle = _db.GetCircleById(_circleId);

                if (_circle == null)
                {
                    MessageBox.Show("Кружок не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                lblCircleName.Text = $"Кружок: {_circle.Name}";

                // Загружаем утвержденные регистрации для этого кружка
                _registrations = _registrationService.GetRegistrationsByCircle(_circleId);

                lblParticipantsCount.Text = $"Участников: {_registrations.Count}";

                LoadAttendanceForDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAttendanceForDate()
        {
            try
            {
                var attendanceData = new List<AttendanceRecord>();

                foreach (var registration in _registrations)
                {
                    // Получаем отметку посещаемости для этой даты
                    var attendances = _db.GetAttendances();
                    var attendance = attendances
                        .FirstOrDefault(a => a.RegistrationId == registration.Id &&
                                           a.Date.Date == _selectedDate.Date);

                    attendanceData.Add(new AttendanceRecord
                    {
                        RegistrationId = registration.Id,
                        ParticipantName = GetParticipantName(registration.ParticipantId),
                        Status = attendance?.Status ?? "Absent",
                        Notes = attendance?.Notes ?? "",
                        IsMarked = attendance != null
                    });
                }

                dgvAttendance.DataSource = attendanceData;
                lblDate.Text = $"Дата: {_selectedDate:dd.MM.yyyy}";
                lblMarkedCount.Text = $"Отмечено: {attendanceData.Count(r => r.IsMarked)} из {attendanceData.Count}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки посещаемости: {ex.Message}");
            }
        }

        private string GetParticipantName(Guid participantId)
        {
            try
            {
                var participant = _db.GetUserById(participantId);
                return participant?.FullName ?? "Неизвестно";
            }
            catch
            {
                return "Ошибка загрузки";
            }
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                int savedCount = 0;
                int errorCount = 0;

                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    if (row.DataBoundItem is AttendanceRecord record)
                    {
                        try
                        {
                            // Получаем текущую отметку посещаемости
                            var attendances = _db.GetAttendances();
                            var existingAttendance = attendances
                                .FirstOrDefault(a => a.RegistrationId == record.RegistrationId &&
                                                   a.Date.Date == _selectedDate.Date);

                            if (existingAttendance != null)
                            {
                                // Обновляем существующую отметку
                                existingAttendance.Status = record.Status;
                                existingAttendance.Notes = record.Notes;
                                existingAttendance.CheckInTime = DateTime.Now;

                                // Здесь нужно добавить метод UpdateAttendance в DatabaseService
                                // или создать новый
                                SaveAttendance(existingAttendance, true);
                            }
                            else
                            {
                                // Создаем новую отметку
                                var newAttendance = new Attendance
                                {
                                    Id = Guid.NewGuid(),
                                    RegistrationId = record.RegistrationId,
                                    Date = _selectedDate.Date,
                                    Status = record.Status,
                                    Notes = record.Notes,
                                    CheckInTime = DateTime.Now,
                                    CreatedBy = _circle.TeacherId ?? Guid.Empty, // ID преподавателя
                                    CreatedAt = DateTime.Now
                                };

                                SaveAttendance(newAttendance, false);
                            }

                            savedCount++;
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Ошибка сохранения для строки {row.Index}: {ex.Message}");
                            errorCount++;
                        }
                    }
                }

                string message = $"Сохранено отметок: {savedCount} из {dgvAttendance.Rows.Count}";
                if (errorCount > 0)
                {
                    message += $"\nОшибок: {errorCount}";
                }

                MessageBox.Show(message, savedCount > 0 ? "Успех" : "Внимание",
                    MessageBoxButtons.OK, savedCount > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                // Обновляем данные
                LoadAttendanceForDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveAttendance(Attendance attendance, bool isUpdate)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql;
                    if (isUpdate)
                    {
                        sql = @"UPDATE Attendances SET 
                                Status = @Status, 
                                Notes = @Notes, 
                                CheckInTime = @CheckInTime
                                WHERE RegistrationId = @RegistrationId AND Date = @Date";
                    }
                    else
                    {
                        sql = @"INSERT INTO Attendances 
                                (Id, RegistrationId, Date, Status, Notes, CheckInTime, CreatedBy, CreatedAt) 
                                VALUES (@Id, @RegistrationId, @Date, @Status, @Notes, @CheckInTime, @CreatedBy, @CreatedAt)";
                    }

                    using (var command = new SqlCommand(sql, connection))
                    {
                        if (!isUpdate)
                        {
                            command.Parameters.AddWithValue("@Id", attendance.Id);
                        }

                        command.Parameters.AddWithValue("@RegistrationId", attendance.RegistrationId);
                        command.Parameters.AddWithValue("@Date", attendance.Date);
                        command.Parameters.AddWithValue("@Status", attendance.Status);
                        command.Parameters.AddWithValue("@Notes", attendance.Notes ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CheckInTime", attendance.CheckInTime ?? (object)DBNull.Value);

                        if (!isUpdate)
                        {
                            command.Parameters.AddWithValue("@CreatedBy", attendance.CreatedBy);
                            command.Parameters.AddWithValue("@CreatedAt", attendance.CreatedAt);
                        }

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка сохранения посещаемости: {ex.Message}");
                return false;
            }
        }

        private void btnMarkAllPresent_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                row.Cells["Status"].Value = "Present";
                if (row.DataBoundItem is AttendanceRecord record)
                {
                    record.Status = "Present";
                }
            }
        }

        private void btnMarkAllAbsent_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                row.Cells["Status"].Value = "Absent";
                if (row.DataBoundItem is AttendanceRecord record)
                {
                    record.Status = "Absent";
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                var reportForm = new AttendanceReportForm(_circleId, _db, dtpFromDate.Value, dtpToDate.Value);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // Вспомогательный класс для отображения
        private class AttendanceRecord
        {
            public Guid RegistrationId { get; set; }
            public string ParticipantName { get; set; }
            public string Status { get; set; }
            public string Notes { get; set; }
            public bool IsMarked { get; set; }
        }
    }
}