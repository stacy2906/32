using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;
using System.Data.SqlClient;

namespace CircleRegistrationSystem.Forms
{
    public partial class AttendanceReportForm : Form
    {
        private readonly Guid _circleId;
        private readonly DatabaseService _db;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private Circle _circle;
        private List<Registration> _registrations;

        public AttendanceReportForm(Guid circleId, DatabaseService db, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            _circleId = circleId;
            _db = db;
            _startDate = startDate;
            _endDate = endDate;

            InitializeForm();
            GenerateReport();
        }

        private void InitializeForm()
        {
            Text = "Отчет по посещаемости";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // Настройка DataGridView
            dgvReport.AutoGenerateColumns = false;
            ConfigureReportGrid();
        }

        private void ConfigureReportGrid()
        {
            dgvReport.Columns.Clear();

            // Участник
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ParticipantName",
                HeaderText = "Участник",
                Width = 150,
                Name = "ParticipantName"
            });

            // Дни с посещаемостью (динамически добавим)
            // Статистика
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PresentDays",
                HeaderText = "Присутствовал",
                Width = 100,
                Name = "PresentDays"
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AbsentDays",
                HeaderText = "Отсутствовал",
                Width = 100,
                Name = "AbsentDays"
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalDays",
                HeaderText = "Всего дней",
                Width = 100,
                Name = "TotalDays"
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AttendancePercentage",
                HeaderText = "Посещаемость %",
                Width = 120,
                Name = "AttendancePercentage"
            });
        }

        private void GenerateReport()
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

                lblReportTitle.Text = $"Отчет по посещаемости: {_circle.Name}";
                lblPeriod.Text = $"Период: {_startDate:dd.MM.yyyy} - {_endDate:dd.MM.yyyy}";

                // Загружаем регистрации
                var registrationService = new RegistrationService(_db);
                _registrations = registrationService.GetRegistrationsByCircle(_circleId);

                if (_registrations.Count == 0)
                {
                    MessageBox.Show("Нет зарегистрированных участников для этого кружка", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Собираем отчет
                var reportData = new List<AttendanceReportItem>();

                foreach (var registration in _registrations)
                {
                    var reportItem = CreateReportItem(registration);
                    reportData.Add(reportItem);
                }

                // Добавляем динамические колонки для дней
                AddDayColumns();

                dgvReport.DataSource = reportData;

                // Общая статистика
                CalculateTotalStatistics(reportData);

                // Экспорт доступен
                btnExport.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDayColumns()
        {
            // Удаляем существующие колонки дней (если есть)
            var columnsToRemove = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn column in dgvReport.Columns)
            {
                if (column.Name.StartsWith("Day_"))
                    columnsToRemove.Add(column);
            }

            foreach (var column in columnsToRemove)
            {
                dgvReport.Columns.Remove(column);
            }

            // Добавляем колонки для каждого дня в периоде
            var currentDate = _startDate;
            int dayIndex = 0;

            while (currentDate <= _endDate)
            {
                var dayColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = $"Day_{dayIndex}",
                    HeaderText = currentDate.ToString("dd.MM"),
                    Width = 50,
                    Name = $"Day_{dayIndex}"
                };

                // Вставляем после колонки "Участник"
                dgvReport.Columns.Insert(1 + dayIndex, dayColumn);

                currentDate = currentDate.AddDays(1);
                dayIndex++;

                if (dayIndex > 30) // Ограничиваем 30 днями
                    break;
            }
        }

        private AttendanceReportItem CreateReportItem(Registration registration)
        {
            var participant = _db.GetUserById(registration.ParticipantId);
            var reportItem = new AttendanceReportItem
            {
                ParticipantName = participant?.FullName ?? "Неизвестно",
                RegistrationId = registration.Id
            };

            // Собираем посещаемость за период
            var attendances = _db.GetAttendances()
                .Where(a => a.RegistrationId == registration.Id &&
                           a.Date >= _startDate &&
                           a.Date <= _endDate)
                .ToList();

            var currentDate = _startDate;
            int dayIndex = 0;

            while (currentDate <= _endDate && dayIndex < 30)
            {
                var attendance = attendances.FirstOrDefault(a => a.Date.Date == currentDate.Date);
                reportItem.DayStatuses[dayIndex] = attendance?.Status ?? "-";

                // Статистика
                if (attendance != null)
                {
                    if (attendance.Status == "Present")
                        reportItem.PresentDays++;
                    else if (attendance.Status == "Absent")
                        reportItem.AbsentDays++;
                }

                currentDate = currentDate.AddDays(1);
                dayIndex++;
            }

            reportItem.TotalDays = reportItem.PresentDays + reportItem.AbsentDays;
            reportItem.AttendancePercentage = reportItem.TotalDays > 0 ?
                (int)((reportItem.PresentDays * 100.0) / reportItem.TotalDays) : 0;

            return reportItem;
        }

        private void CalculateTotalStatistics(List<AttendanceReportItem> reportData)
        {
            int totalPresent = reportData.Sum(r => r.PresentDays);
            int totalAbsent = reportData.Sum(r => r.AbsentDays);
            int totalParticipants = reportData.Count;
            int totalDays = totalPresent + totalAbsent;
            int avgPercentage = totalDays > 0 ? (int)((totalPresent * 100.0) / totalDays) : 0;

            lblTotalParticipants.Text = $"Участников: {totalParticipants}";
            lblTotalPresent.Text = $"Всего присутствий: {totalPresent}";
            lblTotalAbsent.Text = $"Всего отсутствий: {totalAbsent}";
            lblAverageAttendance.Text = $"Средняя посещаемость: {avgPercentage}%";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Excel файлы (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
                    saveDialog.FileName = $"Отчет_посещаемости_{_circle.Name}_{DateTime.Now:yyyyMMdd}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCsv(saveDialog.FileName, dgvReport);
                        MessageBox.Show("Отчет успешно экспортирован", "Успех",
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

        private void ExportToCsv(string filePath, DataGridView dataGridView)
        {
            try
            {
                using (var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // Заголовок отчета
                    writer.WriteLine($"Отчет по посещаемости: {_circle?.Name}");
                    writer.WriteLine($"Период: {_startDate:dd.MM.yyyy} - {_endDate:dd.MM.yyyy}");
                    writer.WriteLine($"Дата генерации: {DateTime.Now:dd.MM.yyyy HH:mm}");
                    writer.WriteLine();

                    // Заголовки колонок
                    var headers = new List<string>();
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                            headers.Add(column.HeaderText);
                    }
                    writer.WriteLine(string.Join(";", headers));

                    // Данные
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        var cells = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.OwningColumn.Visible)
                            {
                                string cellValue = cell.Value?.ToString() ?? "";
                                // Экранируем точку с запятой
                                if (cellValue.Contains(";"))
                                    cellValue = $"\"{cellValue}\"";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Здесь можно добавить логику печати
                    MessageBox.Show("Функция печати будет реализована в следующей версии", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // Класс для данных отчета
        private class AttendanceReportItem
        {
            public string ParticipantName { get; set; }
            public Guid RegistrationId { get; set; }
            public Dictionary<int, string> DayStatuses { get; set; } = new Dictionary<int, string>();
            public int PresentDays { get; set; }
            public int AbsentDays { get; set; }
            public int TotalDays { get; set; }
            public int AttendancePercentage { get; set; }

            // Для динамических колонок
            public string Day_0 => DayStatuses.ContainsKey(0) ? DayStatuses[0] : "-";
            public string Day_1 => DayStatuses.ContainsKey(1) ? DayStatuses[1] : "-";
            public string Day_2 => DayStatuses.ContainsKey(2) ? DayStatuses[2] : "-";
            public string Day_3 => DayStatuses.ContainsKey(3) ? DayStatuses[3] : "-";
            public string Day_4 => DayStatuses.ContainsKey(4) ? DayStatuses[4] : "-";
            public string Day_5 => DayStatuses.ContainsKey(5) ? DayStatuses[5] : "-";
            public string Day_6 => DayStatuses.ContainsKey(6) ? DayStatuses[6] : "-";
            public string Day_7 => DayStatuses.ContainsKey(7) ? DayStatuses[7] : "-";
            public string Day_8 => DayStatuses.ContainsKey(8) ? DayStatuses[8] : "-";
            public string Day_9 => DayStatuses.ContainsKey(9) ? DayStatuses[9] : "-";
            public string Day_10 => DayStatuses.ContainsKey(10) ? DayStatuses[10] : "-";
            public string Day_11 => DayStatuses.ContainsKey(11) ? DayStatuses[11] : "-";
            public string Day_12 => DayStatuses.ContainsKey(12) ? DayStatuses[12] : "-";
            public string Day_13 => DayStatuses.ContainsKey(13) ? DayStatuses[13] : "-";
            public string Day_14 => DayStatuses.ContainsKey(14) ? DayStatuses[14] : "-";
            public string Day_15 => DayStatuses.ContainsKey(15) ? DayStatuses[15] : "-";
            public string Day_16 => DayStatuses.ContainsKey(16) ? DayStatuses[16] : "-";
            public string Day_17 => DayStatuses.ContainsKey(17) ? DayStatuses[17] : "-";
            public string Day_18 => DayStatuses.ContainsKey(18) ? DayStatuses[18] : "-";
            public string Day_19 => DayStatuses.ContainsKey(19) ? DayStatuses[19] : "-";
            public string Day_20 => DayStatuses.ContainsKey(20) ? DayStatuses[20] : "-";
            public string Day_21 => DayStatuses.ContainsKey(21) ? DayStatuses[21] : "-";
            public string Day_22 => DayStatuses.ContainsKey(22) ? DayStatuses[22] : "-";
            public string Day_23 => DayStatuses.ContainsKey(23) ? DayStatuses[23] : "-";
            public string Day_24 => DayStatuses.ContainsKey(24) ? DayStatuses[24] : "-";
            public string Day_25 => DayStatuses.ContainsKey(25) ? DayStatuses[25] : "-";
            public string Day_26 => DayStatuses.ContainsKey(26) ? DayStatuses[26] : "-";
            public string Day_27 => DayStatuses.ContainsKey(27) ? DayStatuses[27] : "-";
            public string Day_28 => DayStatuses.ContainsKey(28) ? DayStatuses[28] : "-";
            public string Day_29 => DayStatuses.ContainsKey(29) ? DayStatuses[29] : "-";
        }
    }
}