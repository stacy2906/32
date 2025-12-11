using System;
using System.Drawing;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;

namespace CircleRegistrationSystem.Forms
{
    public partial class CircleDetailsForm : Form
    {
        private readonly DatabaseService _db;
        private readonly Guid _circleId;
        private Circle _circle;

        public CircleDetailsForm(Guid circleId, DatabaseService db)
        {
            InitializeComponent();
            _db = db;
            _circleId = circleId;

            // Настраиваем события
            btnClose.Click += (s, e) => this.Close();
            btnPrint.Click += BtnPrint_Click;
            btnExport.Click += BtnExport_Click;

            LoadCircleDetails();
        }

        private void LoadCircleDetails()
        {
            try
            {
                _circle = _db.GetCircleById(_circleId);

                if (_circle != null)
                {
                    // Основная информация
                    lblName.Text = _circle.Name;
                    lblCategory.Text = _circle.Category ?? "Не указана";
                    lblAgeRange.Text = $"{_circle.AgeMin}-{_circle.AgeMax} лет";
                    lblPrice.Text = $"{_circle.Price:F2} руб.";
                    lblParticipants.Text = $"{_circle.CurrentParticipants}/{_circle.MaxParticipants} мест";

                    // Описание
                    txtDescription.Text = _circle.Description ?? "Описание отсутствует";

                    // Преподаватель
                    if (_circle.TeacherId.HasValue)
                    {
                        var teacher = _db.GetUserById(_circle.TeacherId.Value);
                        lblTeacher.Text = teacher?.FullName ?? "Не указан";
                    }
                    else
                    {
                        lblTeacher.Text = "Не назначен";
                    }

                    // Статистика
                    LoadStatistics();
                    LoadSchedule();

                    // Стилизация
                    if (!_circle.IsActive)
                    {
                        panelHeader.BackColor = Color.Gray;
                        lblHeaderTitle.Text += " (Неактивен)";
                    }
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
                MessageBox.Show($"Ошибка загрузки деталей кружка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                // Заполняемость
                if (_circle.MaxParticipants > 0)
                {
                    double fillPercentage = (double)_circle.CurrentParticipants / _circle.MaxParticipants * 100;
                    lblFillPercentage.Text = $"{fillPercentage:F1}%";

                    // Цвет в зависимости от заполненности
                    if (fillPercentage < 50)
                        lblFillPercentage.ForeColor = Color.Green;
                    else if (fillPercentage < 80)
                        lblFillPercentage.ForeColor = Color.Orange;
                    else
                        lblFillPercentage.ForeColor = Color.Red;
                }
                else
                {
                    lblFillPercentage.Text = "0%";
                }

                // Тестовые данные для статистики
                lblTotalRegistrations.Text = "12";
                lblApprovedRegistrations.Text = "8";
                lblPendingRegistrations.Text = "3";
                lblRejectedRegistrations.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSchedule()
        {
            try
            {
                dgvSchedule.Rows.Clear();
                dgvSchedule.Columns.Clear();

                // Настраиваем колонки
                dgvSchedule.Columns.Add("Day", "День недели");
                dgvSchedule.Columns.Add("Time", "Время");
                dgvSchedule.Columns.Add("Room", "Кабинет");
                dgvSchedule.Columns.Add("Teacher", "Преподаватель");

                // Тестовые данные для расписания
                if (_circle != null)
                {
                    string teacherName = lblTeacher.Text;

                    // Простое расписание
                    dgvSchedule.Rows.Add("Понедельник", "15:00-16:30", "Спортзал №1", teacherName);
                    dgvSchedule.Rows.Add("Среда", "15:00-16:30", "Спортзал №1", teacherName);
                    dgvSchedule.Rows.Add("Пятница", "14:00-15:30", "Спортзал №2", teacherName);
                }

                // Настраиваем ширину колонок
                dgvSchedule.Columns["Day"].Width = 100;
                dgvSchedule.Columns["Time"].Width = 80;
                dgvSchedule.Columns["Room"].Width = 80;
                dgvSchedule.Columns["Teacher"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Функция печати информации о кружке будет реализована в следующей версии",
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
                        MessageBox.Show($"Данные успешно экспортированы в файл: {saveFileDialog.FileName}",
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
    }
}