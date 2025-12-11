using System;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;


namespace CircleRegistrationSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public Participant NewParticipant { get; private set; }
        private readonly SecurityService _securityService;
        private UserService _userService;
        private DatabaseService _databaseService;



        public RegisterForm(DatabaseService databaseService)
        {
            InitializeComponent();
            _securityService = new SecurityService();

            if (databaseService == null)
                throw new ArgumentNullException(nameof(databaseService));

            _userService = new UserService(databaseService);
            LoadRoles();
        }

        private void LoadRoles()
        {
            var roles = new[] { "Student", "Parent", "Teacher" };
            cmbRole.Items.AddRange(roles);
            cmbRole.SelectedIndex = 0;
        }

        private bool ValidateInput()
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return false;
            }

            // Проверка email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Введите email", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            if (!_securityService.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Введите корректный email", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            // Проверка пароля
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

            // Проверка телефона
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                if (!_securityService.IsValidPhoneNumber(txtPhone.Text))
                {
                    MessageBox.Show("Введите корректный номер телефона", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhone.Focus();
                    return false;
                }
            }

            // Проверка даты рождения
            if (dtpDateOfBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть в будущем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateOfBirth.Focus();
                return false;
            }

            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                // Создаем объект пользователя без PasswordHash
                NewParticipant = new Participant
                {
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = cmbRole.SelectedItem.ToString(),
                    DateOfBirth = dtpDateOfBirth.Checked ? dtpDateOfBirth.Value : (DateTime?)null,
                    ParentName = txtParentName.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim()
                };

                // Передаем пароль в UserService для хэширования
                bool registered = _userService.RegisterUser(NewParticipant, txtPassword.Text);

                if (registered)
                {
                    MessageBox.Show($"Регистрация успешна!\nЛогин: {NewParticipant.Email}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка регистрации. Пользователь уже существует или данные некорректны.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем/скрываем поля в зависимости от роли
            var role = cmbRole.SelectedItem.ToString();

            // Для ученика показываем поле "ФИО родителя"
            lblParentName.Visible = txtParentName.Visible = (role == "Student");

            // Для преподавателя показываем поле "Специализация"
            lblSpecialization.Visible = txtSpecialization.Visible = (role == "Teacher");
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            var password = _securityService.GenerateRandomPassword(10);
            txtPassword.Text = password;
            txtConfirmPassword.Text = password;
        }
    }
}