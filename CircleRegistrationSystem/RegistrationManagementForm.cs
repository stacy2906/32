using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;

namespace CircleRegistrationSystem.Forms
{
    public partial class RegistrationManagementForm : Form
    {
        private readonly DatabaseService _db;
        private readonly RegistrationService _registrationService;
        private readonly Participant _currentUser;
        private List<Registration> _allRegistrations;

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
        }

        private void ConfigureDataGridView()
        {
            dgvRegistrations.Columns.Clear();

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ParticipantName",
                HeaderText = "Участник",
                Width = 150
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CircleName",
                HeaderText = "Кружок",
                Width = 150
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ApplicationDate",
                HeaderText = "Дата заявки",
                Width = 120
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Статус",
                Width = 100
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AttendanceStatus",
                HeaderText = "Посещаемость",
                Width = 100
            });
        }

        private void LoadData()
        {
            try
            {
                _allRegistrations = _registrationService.GetAllRegistrations();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            try
            {
                var filtered = _allRegistrations.AsEnumerable();

                // Фильтр по статусу
                if (cmbStatus.SelectedItem?.ToString() != "Все")
                {
                    filtered = filtered.Where(r => r.Status == cmbStatus.SelectedItem.ToString());
                }

                // Фильтр по дате
                if (dtpFromDate.Checked)
                {
                    filtered = filtered.Where(r => r.ApplicationDate >= dtpFromDate.Value);
                }

                if (dtpToDate.Checked)
                {
                    filtered = filtered.Where(r => r.ApplicationDate <= dtpToDate.Value.AddDays(1));
                }

                // Преобразование для отображения
                var displayData = filtered.Select(r => new
                {
                    r.Id,
                    ParticipantName = GetParticipantName(r.ParticipantId),
                    CircleName = GetCircleName(r.CircleId),
                    ApplicationDate = r.ApplicationDate.ToString("dd.MM.yyyy"),
                    Status = GetStatusDisplay(r.Status),
                    AttendanceStatus = r.AttendanceStatus ?? "Не указано"
                }).ToList();

                dgvRegistrations.DataSource = displayData;
                lblTotal.Text = $"Всего: {displayData.Count}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка фильтрации: {ex.Message}");
            }
        }

        private string GetParticipantName(Guid participantId)
        {
            var participant = _db.GetUserById(participantId);
            return participant?.FullName ?? "Неизвестно";
        }

        private string GetCircleName(Guid circleId)
        {
            var circle = _db.GetCircleById(circleId);
            return circle?.Name ?? "Неизвестно";
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

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
            ApplyFilters();
        }

        private void btnApprove_Click(object sender, EventArgs e)
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
                    LoadData();
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
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при отклонении заявки", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для просмотра", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedId = (Guid)dgvRegistrations.SelectedRows[0].Cells["Id"].Value;
            var registration = _registrationService.GetAllRegistrations()
                .FirstOrDefault(r => r.Id == selectedId);

            if (registration != null)
            {
                using (var detailsForm = new RegistrationDetailsForm(registration, _db))
                {
                    detailsForm.ShowDialog();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                    saveDialog.FileName = $"Регистрации_{DateTime.Now:yyyyMMdd}.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCsv(saveDialog.FileName);
                        MessageBox.Show("Данные экспортированы успешно", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Реализация экспорта в CSV
            // ...
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}