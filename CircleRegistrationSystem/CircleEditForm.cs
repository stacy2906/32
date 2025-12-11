using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;

namespace CircleRegistrationSystem.Forms
{
    public partial class CircleEditForm : Form
    {
        private Guid? _circleId;
        private DatabaseService _db;
        private Circle _circle;
        private bool _isEditMode;

        public CircleEditForm(Guid? circleId, DatabaseService db)
        {
            InitializeComponent();
            _db = db;
            _circleId = circleId;
            _isEditMode = circleId.HasValue;

     
        }

        //private void InitializeForm()
        //{
        //    // Загрузка категорий
        //    var categories = new[] { "Спорт", "Творчество", "Наука", "Языки", "Музыка", "Другое" };
        //    cmbCategory.Items.AddRange(categories);

        //    // Загрузка преподавателей
        //    LoadTeachers();

        //    if (_isEditMode)
        //    {
        //        Text = "Редактирование кружка";
        //        LoadCircleData();
        //    }
        //    else
        //    {
        //        Text = "Добавление кружка";
        //        // Значения по умолчанию
        //        nudAgeMin.Value = 7;
        //        nudAgeMax.Value = 18;
        //        nudPrice.Value = 0;
        //        nudMaxParticipants.Value = 20;
        //        chkIsActive.Checked = true;
        //    }
        //}

        //private void LoadTeachers()
        //{
        //    try
        //    {
        //        var teachers = _db.Users
        //            .Where(p => p.Role == "Teacher")
        //            .ToList();
                    
        //        cmbTeacher.DataSource = teachers;
        //        cmbTeacher.DisplayMember = "FullName";
        //        cmbTeacher.ValueMember = "Id";

        //        if (teachers.Count == 0)
        //        {
        //            MessageBox.Show("В системе нет преподавателей. Сначала добавьте преподавателей.",
        //                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка загрузки преподавателей: {ex.Message}",
        //            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void LoadCircleData()
        {
            try
            {
                _circle = _db.Circles
                    .Include("Teacher")
                    .FirstOrDefault(c => c.Id == _circleId.Value);

                if (_circle != null)
                {
                    txtName.Text = _circle.Name;
                    cmbCategory.Text = _circle.Category;
                    nudAgeMin.Value = _circle.AgeMin;
                    nudAgeMax.Value = _circle.AgeMax;
                    nudPrice.Value = _circle.Price;
                    nudMaxParticipants.Value = _circle.MaxParticipants;
                    txtDescription.Text = _circle.Description;

                    if (cmbTeacher.Items.Count > 0 && _circle.TeacherId != Guid.Empty)
                    {
                        var teachers = cmbTeacher.DataSource as System.Collections.IList;
                        if (teachers != null)
                        {
                            for (int i = 0; i < teachers.Count; i++)
                            {
                                if (teachers[i] is Participant teacher && teacher.Id == _circle.TeacherId)
                                {
                                    cmbTeacher.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }

                    chkIsActive.Checked = _circle.IsActive;
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
                MessageBox.Show($"Ошибка загрузки данных кружка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            // Проверка названия
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название кружка", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            // Проверка категории
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Выберите категорию", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
                return false;
            }

            // Проверка возрастных ограничений
            if (nudAgeMin.Value > nudAgeMax.Value)
            {
                MessageBox.Show("Минимальный возраст не может быть больше максимального",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudAgeMin.Focus();
                return false;
            }

            // Проверка цены
            if (nudPrice.Value < 0)
            {
                MessageBox.Show("Цена не может быть отрицательной",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudPrice.Focus();
                return false;
            }

            // Проверка количества участников
            if (nudMaxParticipants.Value <= 0)
            {
                MessageBox.Show("Количество участников должно быть положительным",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudMaxParticipants.Focus();
                return false;
            }

            // Проверка преподавателя
            if (cmbTeacher.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите преподавателя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTeacher.Focus();
                return false;
            }

            return true;
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (!ValidateInput())
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        if (_isEditMode)
        //        {
        //            // Обновление существующего кружка
        //            _circle.Name = txtName.Text;
        //            _circle.Category = cmbCategory.Text;
        //            _circle.AgeMin = (int)nudAgeMin.Value;
        //            _circle.AgeMax = (int)nudAgeMax.Value;
        //            _circle.Price = nudPrice.Value;
        //            _circle.MaxParticipants = (int)nudMaxParticipants.Value;
        //            _circle.Description = txtDescription.Text;
                    
        //            if (cmbTeacher.SelectedItem is Participant selectedTeacher)
        //            {
        //                _circle.TeacherId = selectedTeacher.Id;
        //            }
                    
        //            _circle.IsActive = chkIsActive.Checked;
        //            _circle.UpdatedAt = DateTime.Now;

        //            _db.Entry(_circle).State = EntityState.Modified;
        //        }
        //        else
        //        {
        //            // Создание нового кружка
        //            var newCircle = new Circle
        //            {
        //                Name = txtName.Text,
        //                Category = cmbCategory.Text,
        //                AgeMin = (int)nudAgeMin.Value,
        //                AgeMax = (int)nudAgeMax.Value,
        //                Price = nudPrice.Value,
        //                MaxParticipants = (int)nudMaxParticipants.Value,
        //                Description = txtDescription.Text,
        //                IsActive = chkIsActive.Checked
        //            };
                    
        //            if (cmbTeacher.SelectedItem is Participant selectedTeacher)
        //            {
        //                newCircle.TeacherId = selectedTeacher.Id;
        //            }

        //            _db.Circles.Add(newCircle);
        //        }

        //        _db.SaveChanges();

        //        MessageBox.Show("Кружок успешно сохранен", "Успех",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        DialogResult = DialogResult.OK;
        //        Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при сохранении: {ex.Message}\n\nПодробности: {ex.InnerException?.Message}",
        //            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void nudAgeMin_ValueChanged(object sender, EventArgs e)
        {
            // Автоматически настраиваем максимальный возраст
            if (nudAgeMin.Value > nudAgeMax.Value)
            {
                nudAgeMax.Value = nudAgeMin.Value;
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для добавления нового преподавателя обратитесь к администратору.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}