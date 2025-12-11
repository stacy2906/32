using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;
using System.Data.SqlClient;
using System.Configuration;

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

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Настраиваем форму
            this.Text = _isEditMode ? "Редактирование кружка" : "Добавление кружка";

            // Настраиваем обработчики событий
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnAddTeacher.Click += BtnAddTeacher_Click;
            nudAgeMin.ValueChanged += NudAgeMin_ValueChanged;

            // Загружаем данные
            LoadCategories();
            LoadTeachers();

            if (_isEditMode)
            {
                LoadCircleData();
            }
            else
            {
                // Значения по умолчанию для нового кружка
                cmbCategory.SelectedIndex = 0;
                nudAgeMin.Value = 7;
                nudAgeMax.Value = 18;
                nudPrice.Value = 0;
                nudMaxParticipants.Value = 20;
                chkIsActive.Checked = true;
            }
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();

                // Загружаем категории из базы данных или используем фиксированный список
                var categories = new[]
                {
                    "Спорт", "Творчество", "Наука", "Языки",
                    "Музыка", "Танцы", "Робототехника", "Другое"
                };

                cmbCategory.Items.AddRange(categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeachers()
        {
            try
            {
                cmbTeacher.Items.Clear();

                var teachers = _db.GetUsers()
                    .Where(p => p.Role == "Teacher" && p.IsActive)
                    .OrderBy(p => p.FullName)
                    .ToList();

                foreach (var teacher in teachers)
                {
                    cmbTeacher.Items.Add(teacher);
                }

                cmbTeacher.DisplayMember = "FullName";
                cmbTeacher.ValueMember = "Id";

                if (teachers.Count > 0)
                {
                    cmbTeacher.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("В системе нет активных преподавателей.", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки преподавателей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCircleData()
        {
            try
            {
                _circle = _db.GetCircleById(_circleId.Value);

                if (_circle == null)
                {
                    MessageBox.Show("Кружок не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtName.Text = _circle.Name;

                // Устанавливаем категорию
                if (!string.IsNullOrEmpty(_circle.Category))
                {
                    for (int i = 0; i < cmbCategory.Items.Count; i++)
                    {
                        if (cmbCategory.Items[i].ToString() == _circle.Category)
                        {
                            cmbCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }

                nudAgeMin.Value = _circle.AgeMin;
                nudAgeMax.Value = _circle.AgeMax;
                nudPrice.Value = _circle.Price;
                nudMaxParticipants.Value = _circle.MaxParticipants;
                txtDescription.Text = _circle.Description ?? "";

                // Устанавливаем преподавателя
                if (_circle.TeacherId.HasValue)
                {
                    for (int i = 0; i < cmbTeacher.Items.Count; i++)
                    {
                        var teacher = cmbTeacher.Items[i] as Participant;
                        if (teacher != null && teacher.Id == _circle.TeacherId.Value)
                        {
                            cmbTeacher.SelectedIndex = i;
                            break;
                        }
                    }
                }

                chkIsActive.Checked = _circle.IsActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных кружка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (cmbCategory.SelectedIndex < 0)
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

            // Проверка преподавателя (опционально)
            if (cmbTeacher.SelectedIndex < 0)
            {
                if (MessageBox.Show("Преподаватель не выбран. Продолжить сохранение без преподавателя?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cmbTeacher.Focus();
                    return false;
                }
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (_isEditMode)
                    {
                        // ОБНОВЛЕНИЕ существующего кружка
                        using (var command = new SqlCommand(
                            @"UPDATE Circles SET 
                                Name = @Name,
                                Category = @Category,
                                AgeMin = @AgeMin,
                                AgeMax = @AgeMax,
                                Price = @Price,
                                MaxParticipants = @MaxParticipants,
                                Description = @Description,
                                TeacherId = @TeacherId,
                                IsActive = @IsActive,
                                UpdatedAt = GETDATE()
                              WHERE Id = @Id",
                            connection))
                        {
                            command.Parameters.AddWithValue("@Id", _circleId.Value);
                            command.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            command.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@AgeMin", (int)nudAgeMin.Value);
                            command.Parameters.AddWithValue("@AgeMax", (int)nudAgeMax.Value);
                            command.Parameters.AddWithValue("@Price", nudPrice.Value);
                            command.Parameters.AddWithValue("@MaxParticipants", (int)nudMaxParticipants.Value);
                            command.Parameters.AddWithValue("@Description",
                                string.IsNullOrWhiteSpace(txtDescription.Text) ?
                                (object)DBNull.Value : txtDescription.Text.Trim());

                            if (cmbTeacher.SelectedItem != null)
                                command.Parameters.AddWithValue("@TeacherId", ((Participant)cmbTeacher.SelectedItem).Id);
                            else
                                command.Parameters.AddWithValue("@TeacherId", DBNull.Value);

                            command.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Кружок успешно обновлен!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Не удалось обновить кружок", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        // СОЗДАНИЕ нового кружка
                        using (var command = new SqlCommand(
                            @"INSERT INTO Circles 
                                (Id, Name, Category, AgeMin, AgeMax, Price, MaxParticipants, 
                                 CurrentParticipants, Description, TeacherId, IsActive, CreatedAt) 
                              VALUES 
                                (@Id, @Name, @Category, @AgeMin, @AgeMax, @Price, @MaxParticipants, 
                                 @CurrentParticipants, @Description, @TeacherId, @IsActive, GETDATE())",
                            connection))
                        {
                            command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                            command.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            command.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@AgeMin", (int)nudAgeMin.Value);
                            command.Parameters.AddWithValue("@AgeMax", (int)nudAgeMax.Value);
                            command.Parameters.AddWithValue("@Price", nudPrice.Value);
                            command.Parameters.AddWithValue("@MaxParticipants", (int)nudMaxParticipants.Value);
                            command.Parameters.AddWithValue("@CurrentParticipants", 0);
                            command.Parameters.AddWithValue("@Description",
                                string.IsNullOrWhiteSpace(txtDescription.Text) ?
                                (object)DBNull.Value : txtDescription.Text.Trim());

                            if (cmbTeacher.SelectedItem != null)
                                command.Parameters.AddWithValue("@TeacherId", ((Participant)cmbTeacher.SelectedItem).Id);
                            else
                                command.Parameters.AddWithValue("@TeacherId", DBNull.Value);

                            command.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Кружок успешно добавлен!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Не удалось добавить кружок", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = $"Ошибка базы данных:\n{sqlEx.Message}";

                if (sqlEx.Number == 2627) // Ошибка уникальности
                    errorMessage += "\n\nКружок с таким названием уже существует.";
                else if (sqlEx.Number == 547) // Ошибка внешнего ключа
                    errorMessage += "\n\nВыбранный преподаватель не существует.";

                MessageBox.Show(errorMessage, "Ошибка БД",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении:\n{ex.Message}\n\n{ex.InnerException?.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnAddTeacher_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для добавления нового преподавателя:\n" +
                          "1. Выйдите из системы\n" +
                          "2. Зарегистрируйте нового пользователя с ролью 'Teacher'\n" +
                          "3. Войдите снова как администратор\n" +
                          "4. Преподаватель появится в списке",
                "Добавление преподавателя",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NudAgeMin_ValueChanged(object sender, EventArgs e)
        {
            if (nudAgeMin.Value > nudAgeMax.Value)
                nudAgeMax.Value = nudAgeMin.Value;
        }
    }
}