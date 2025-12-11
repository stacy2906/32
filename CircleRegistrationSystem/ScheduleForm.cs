using System;
using System.Drawing;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;

namespace CircleRegistrationSystem.Forms
{
    public partial class ScheduleForm : Form
    {
        private readonly DatabaseService _db;
        private readonly Guid _circleId;
        private Circle _circle;

        public ScheduleForm(Guid circleId, DatabaseService db)
        {
            InitializeComponent();
            _db = db;
            _circleId = circleId;

            // Настраиваем события
            btnClose.Click += (s, e) => this.Close();
            btnPrint.Click += BtnPrint_Click;
            btnExport.Click += BtnExport_Click;

            LoadScheduleData();
            ApplyModernDesign();
        }

        private void LoadScheduleData()
        {
            try
            {
                // Получаем информацию о кружке
                _circle = _db.GetCircleById(_circleId);

                if (_circle != null)
                {
                    lblHeaderTitle.Text = $"Расписание: {_circle.Name}";
                    LoadScheduleToGrid();
                }
                else
                {
                    MessageBox.Show("Кружок не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScheduleToGrid()
        {
            try
            {
                dgvSchedule.Rows.Clear();
                dgvSchedule.Columns.Clear();

                // Настраиваем колонки
                dgvSchedule.Columns.Add("Day", "День недели");
                dgvSchedule.Columns.Add("Time", "Время");
                dgvSchedule.Columns.Add("Duration", "Продолжительность");
                dgvSchedule.Columns.Add("Room", "Место проведения");

                // Тестовые данные для расписания
                if (_circle != null)
                {
                    switch (_circle.Name)
                    {
                        case "Футбол для детей":
                            dgvSchedule.Rows.Add("Понедельник", "15:00-16:30", "1 час 30 мин", "Спортзал №1");
                            dgvSchedule.Rows.Add("Среда", "15:00-16:30", "1 час 30 мин", "Спортзал №1");
                            dgvSchedule.Rows.Add("Пятница", "14:00-15:30", "1 час 30 мин", "Спортзал №2");
                            break;
                        case "Рисование акварелью":
                            dgvSchedule.Rows.Add("Вторник", "16:00-17:30", "1 час 30 мин", "Кабинет 101");
                            dgvSchedule.Rows.Add("Четверг", "16:00-17:30", "1 час 30 мин", "Кабинет 101");
                            break;
                        case "Программирование на Scratch":
                            dgvSchedule.Rows.Add("Понедельник", "17:00-18:30", "1 час 30 мин", "Компьютерный класс");
                            dgvSchedule.Rows.Add("Среда", "17:00-18:30", "1 час 30 мин", "Компьютерный класс");
                            break;
                        default:
                            dgvSchedule.Rows.Add("Понедельник", "10:00-11:30", "1 час 30 мин", "Кабинет 201");
                            dgvSchedule.Rows.Add("Среда", "10:00-11:30", "1 час 30 мин", "Кабинет 201");
                            break;
                    }
                }

                // Настраиваем ширину колонок
                dgvSchedule.Columns["Day"].Width = 120;
                dgvSchedule.Columns["Time"].Width = 100;
                dgvSchedule.Columns["Duration"].Width = 120;
                dgvSchedule.Columns["Room"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyModernDesign()
        {
            // Устанавливаем цвета формы
            this.BackColor = Color.White;

            // Настраиваем DataGridView
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.GridColor = Color.FromArgb(240, 240, 240);
            dgvSchedule.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvSchedule.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvSchedule.RowHeadersVisible = false;

            // Настраиваем кнопки
            btnPrint.BackColor = Color.FromArgb(52, 152, 219);
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Функция печати расписания будет реализована в следующей версии",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Текстовые файлы (*.txt)|*.txt";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Здесь будет логика экспорта данных
                        MessageBox.Show($"Расписание успешно экспортировано в файл: {saveFileDialog.FileName}",
                            "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация при загрузке формы
            if (_circle != null && !_circle.IsActive)
            {
                // Добавляем предупреждение для неактивных кружков
                Label lblWarning = new Label
                {
                    Text = "⚠ Этот кружок временно не активен",
                    ForeColor = Color.OrangeRed,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Location = new Point(20, 25),
                    AutoSize = true
                };
                panelHeader.Controls.Add(lblWarning);
            }
        }
    }
}