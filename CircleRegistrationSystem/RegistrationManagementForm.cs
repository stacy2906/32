using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CircleRegistrationSystem.Models.Registration;

namespace CircleRegistrationSystem.Forms
{
    public partial class RegistrationManagementForm : Form
    {
        private readonly DatabaseService _db;
        private readonly RegistrationService _registrationService;
        private readonly Participant _currentUser;
        private List<RegistrationWithDetails> _allRegistrations;

        public RegistrationManagementForm(DatabaseService db, Participant currentUser)
        {
            InitializeComponent();
            _db = db;
            _currentUser = currentUser;
            _registrationService = new RegistrationService(db);

            InitializeForm();
            LoadData();
        }

        private void InitializeForm()
        {
            Text = "Управление заявками";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;

            // Настройка DataGridView
            dgvRegistrations.AutoGenerateColumns = false;
            ConfigureDataGridView();

            // Настройка ComboBox фильтров
            cmbStatus.Items.AddRange(new[] { "Все", "Pending", "Approved", "Rejected", "Cancelled", "Active" });
            cmbStatus.SelectedIndex = 0;

            // Настройка кнопок в зависимости от роли
            if (_currentUser.Role != "Admin")
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                btnExport.Visible = false;
            }

            // Назначаем обработчики событий
            btnApplyFilters.Click += BtnApplyFilters_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnExport.Click += BtnExport_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void ConfigureDataGridView()
        {
            dgvRegistrations.Columns.Clear();

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                Name = "Id"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ParticipantName",
                HeaderText = "Участник",
                Width = 150,
                Name = "ParticipantName"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CircleName",
                HeaderText = "Кружок",
                Width = 150,
                Name = "CircleName"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ApplicationDate",
                HeaderText = "Дата заявки",
                Width = 120,
                Name = "ApplicationDate"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Статус",
                Width = 100,
                Name = "Status"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TeacherName",
                HeaderText = "Преподаватель",
                Width = 120,
                Name = "TeacherName"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CircleCategory",
                HeaderText = "Категория",
                Width = 100,
                Name = "CircleCategory"
            });
        }

        private void LoadData()
        {
            try
            {
                Debug.WriteLine("Начинаем загрузку данных в RegistrationManagementForm...");
                Debug.WriteLine($"DatabaseService: {_db != null}");

                // ИСПОЛЬЗУЕМ НОВЫЙ МЕТОД ДЛЯ ПОЛУЧЕНИЯ ДАННЫХ
                _allRegistrations = _db.GetRegistrationsWithDetails();

                Debug.WriteLine($"Получено заявок: {_allRegistrations?.Count ?? 0}");

                if (_allRegistrations != null && _allRegistrations.Count > 0)
                {
                    Debug.WriteLine("Первые 3 заявки:");
                    foreach (var reg in _allRegistrations.Take(3))
                    {
                        Debug.WriteLine($"  - {reg.ParticipantName} -> {reg.CircleName} ({reg.Status})");
                    }
                }
                    // ИСПОЛЬЗУЕМ НОВЫЙ МЕТОД ДЛЯ ПОЛУЧЕНИЯ ДАННЫХ
                    _allRegistrations = _db.GetRegistrationsWithDetails();

                if (_allRegistrations == null || _allRegistrations.Count == 0)
                {
                    MessageBox.Show("В базе данных нет заявок для отображения.\n\n" +
                                  "Проверьте:\n" +
                                  "1. Есть ли пользователи в системе\n" +
                                  "2. Подавали ли пользователи заявки\n" +
                                  "3. Корректность подключения к базе данных",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblTotal.Text = "Всего: 0";
                    return;
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\n\n" +
                               $"Подробности: {ex.InnerException?.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            try
            {
                if (_allRegistrations == null)
                {
                    dgvRegistrations.DataSource = null;
                    lblTotal.Text = "Всего: 0";
                    return;
                }

                var filtered = _allRegistrations.AsEnumerable();

                // Фильтр по статусу
                if (cmbStatus.SelectedItem?.ToString() != "Все")
                {
                    filtered = filtered.Where(r => r.Status == cmbStatus.SelectedItem.ToString());
                }

                // Фильтр по дате
                if (dtpFromDate.Checked)
                {
                    filtered = filtered.Where(r => r.ApplicationDate >= dtpFromDate.Value.Date);
                }

                if (dtpToDate.Checked)
                {
                    filtered = filtered.Where(r => r.ApplicationDate <= dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));
                }

                // Преобразование для отображения
                var displayData = filtered.Select(r => new
                {
                    Id = r.Id,
                    ParticipantName = r.ParticipantName ?? "Неизвестно",
                    CircleName = r.CircleName ?? "Неизвестно",
                    ApplicationDate = r.ApplicationDate.ToString("dd.MM.yyyy HH:mm"),
                    Status = GetStatusDisplay(r.Status),
                    TeacherName = GetTeacherName(r.CircleId) ?? "Не указан",
                    CircleCategory = r.CircleCategory ?? "Не указана"
                }).ToList();

                dgvRegistrations.DataSource = displayData;
                lblTotal.Text = $"Всего: {displayData.Count}";

                // Включаем/выключаем кнопки в зависимости от наличия данных
                bool hasData = displayData.Count > 0;
                btnApprove.Enabled = hasData;
                btnReject.Enabled = hasData;
                btnViewDetails.Enabled = hasData;
                btnExport.Enabled = hasData;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка фильтрации: {ex.Message}");
                MessageBox.Show($"Ошибка при фильтрации данных: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTeacherName(Guid circleId)
        {
            try
            {
                var circle = _db.GetCircleById(circleId);
                if (circle?.TeacherId != null)
                {
                    var teacher = _db.GetUserById(circle.TeacherId.Value);
                    return teacher?.FullName;
                }
            }
            catch
            {
                // Игнорируем ошибки
            }
            return null;
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
                default: return status;
            }
        }

        private void BtnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
            ApplyFilters();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для подтверждения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedId = (Guid)dgvRegistrations.SelectedRows[0].Cells["Id"].Value;

            if (MessageBox.Show("Подтвердить выбранную заявку?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_registrationService.ApproveRegistration(selectedId, _currentUser.Id))
                {
                    MessageBox.Show("Заявка подтверждена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Перезагружаем данные
                }
                else
                {
                    MessageBox.Show("Ошибка при подтверждении заявки", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для отклонения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedId = (Guid)dgvRegistrations.SelectedRows[0].Cells["Id"].Value;

            using (var reasonForm = new RejectReasonForm())
            {
                if (reasonForm.ShowDialog() == DialogResult.OK)
                {
                    if (_registrationService.RejectRegistration(selectedId, reasonForm.Reason, _currentUser.Id))
                    {
                        MessageBox.Show("Заявка отклонена", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Перезагружаем данные
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при отклонении заявки", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для просмотра", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedId = (Guid)dgvRegistrations.SelectedRows[0].Cells["Id"].Value;

            // Находим заявку в списке
            var registration = _allRegistrations?.FirstOrDefault(r => r.Id == selectedId);

            if (registration != null)
            {
                // Создаем объект Registration из RegistrationWithDetails
                var reg = new Registration
                {
                    Id = registration.Id,
                    ParticipantId = registration.ParticipantId,
                    CircleId = registration.CircleId,
                    ApplicationDate = registration.ApplicationDate,
                    Status = registration.Status,
                    ApprovalDate = registration.ApprovalDate,
                    RejectionReason = registration.RejectionReason,
                    CreatedAt = registration.CreatedAt
                };

                using (var detailsForm = new RegistrationDetailsForm(reg, _db))
                {
                    detailsForm.ShowDialog();
                    LoadData(); // Обновляем данные после закрытия формы
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Excel файлы (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
                    saveDialog.FileName = $"Заявки_{DateTime.Now:yyyyMMdd_HHmm}";
                    saveDialog.RestoreDirectory = true;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCsv(saveDialog.FileName);
                        MessageBox.Show($"Данные успешно экспортированы в файл:\n{saveDialog.FileName}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCsv(string filePath)
        {
            try
            {
                using (var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // Заголовок
                    writer.WriteLine("Экспорт заявок;Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    writer.WriteLine();

                    // Заголовки колонок
                    var headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvRegistrations.Columns)
                    {
                        if (column.Visible && column.Name != "Id")
                            headers.Add(column.HeaderText);
                    }
                    writer.WriteLine(string.Join(";", headers));

                    // Данные
                    foreach (DataGridViewRow row in dgvRegistrations.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var cells = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.OwningColumn.Visible && cell.OwningColumn.Name != "Id")
                            {
                                string cellValue = cell.Value?.ToString() ?? "";
                                // Экранируем точку с запятой
                                if (cellValue.Contains(";") || cellValue.Contains("\""))
                                    cellValue = $"\"{cellValue.Replace("\"", "\"\"")}\"";
                                cells.Add(cellValue);
                            }
                        }
                        writer.WriteLine(string.Join(";", cells));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при экспорте в CSV: {ex.Message}", ex);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}