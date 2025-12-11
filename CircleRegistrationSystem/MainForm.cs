using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;
using CircleRegistrationSystem.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Configuration;

namespace CircleRegistrationSystem.Forms
{
    public partial class MainForm : Form
    {
        private DatabaseService _db;
        private CircleService _circleService;
        private RegistrationService _registrationService;
        private UserService _userService;
        private NotificationService _notificationService;
        private ReportService _reportService;
        private SecurityService _securityService = new SecurityService();
        private CircleDisplayItem _selectedCircleFromCatalog = null;
        private Guid _currentSelectedCircleId = Guid.Empty;
        private Circle _currentSelectedCircle = null;
        private Circle _selectedCircleFromTeacherList = null;
        private Participant _currentUser;
        private List<Circle> _allCircles;
        private List<Registration> _userRegistrations;
        private List<Circle> _teacherCircles;
        private DatabaseService _databaseService;
        private Guid _selectedCircleId = Guid.Empty;
        private CircleDisplayItem _selectedCircleDisplay = null;


        // Классы для отображения данных
        private class CircleDisplayItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string AgeRange { get; set; }
            public string Price { get; set; }
            public string AvailableSlots { get; set; }
            public string TeacherName { get; set; }
        }

        private class RegistrationDisplayItem
        {
            public Guid Id { get; set; }
            public string CircleName { get; set; }
            public string RegistrationDate { get; set; }
            public string Status { get; set; }
            public string TeacherName { get; set; }
        }


        public MainForm()
        {
            InitializeComponent();

          

            InitializeUI();
            AddNavigationButtons();
        }





        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ТОЛЬКО настройка UI - НИКАКОЙ логики с БД!
                InitializeUI();

                // Инициализация ComboBox - сначала добавьте элементы, потом выбирайте
                LoadCategories();

                // Показываем панель входа
                ShowLoginPanel();

                // Установите начальные значения для NumericUpDown
                nudMinAge.Value = 0;
                nudMaxAge.Value = 0;
                nudMaxPrice.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации UI: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void MainForm_Shown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Простая инициализация - только самое необходимое
        //        _db = new DatabaseService();
        //        _securityService = new SecurityService();

        //        // Проверяем подключение к БД
        //        try
        //        {
        //            var test = _db.Circles.Count();
        //            Debug.WriteLine($"Подключение к БД успешно. Кружков: {test}");
        //        }
        //        catch (Exception dbEx)
        //        {
        //            MessageBox.Show($"Ошибка подключения к БД: {dbEx.Message}\nПроверьте строку подключения в App.config",
        //                "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        // Инициализируем остальные сервисы
        //        _circleService = new CircleService(_db);
        //        _registrationService = new RegistrationService(_db);
        //        _userService = new UserService(_db);
        //        _notificationService = new NotificationService(_db);
        //        _reportService = new ReportService(_db);

        //        // Проверяем данные
        //        CheckDatabaseData();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Критическая ошибка инициализации: {ex.Message}\n\n{ex.InnerException?.Message}",
        //            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    AddNavigationButtons();
        //}

        //private void CheckDatabaseData()
        //{
        //    try
        //    {
        //        // Проверяем кружки
        //        var circles = _db.Circles.ToList();
        //        Debug.WriteLine($"Найдено кружков в БД: {circles.Count}");

        //        foreach (var circle in circles)
        //        {
        //            Debug.WriteLine($"Кружок: {circle.Name}, IsActive: {circle.IsActive}");
        //        }

        //        // Проверяем пользователей
        //        var users = _db.Users.ToList();
        //        Debug.WriteLine($"Найдено пользователей в БД: {users.Count}");

        //        // Если кружки есть, но IsActive = false
        //        var activeCircles = circles.Where(c => c.IsActive).ToList();
        //        if (activeCircles.Count == 0 && circles.Count > 0)
        //        {
        //            Debug.WriteLine("Внимание: кружки есть, но не активны (IsActive = false)!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Ошибка проверки данных: {ex.Message}");
        //    }
        //}

        private void AddNavigationButtons()
        {
            // Кнопка Выход уже есть, но можно сделать ее умнее
            btnLogout.Click += (s, e) =>
            {
                _currentUser = null;
                ShowLoginPanel();
                tabControl1.SelectedTab = tabLogin;
            };

            // Кнопка Назад на каждой вкладке
            AddBackButton(tabMyRegistrations, "Назад к каталогу", () => tabControl1.SelectedTab = tabCatalog);
            AddBackButton(tabAdminRegistrations, "Назад к каталогу", () => tabControl1.SelectedTab = tabCatalog);
            AddBackButton(tabTeacherCircles, "Назад к каталогу", () => tabControl1.SelectedTab = tabCatalog);
        }

        private void AddBackButton(TabPage tabPage, string text, Action backAction)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(850, tabPage == tabMyRegistrations ? 520 : 480),
                Size = new Size(120, 30),
                Font = new Font("Microsoft Sans Serif", 9f)
            };

            btn.Click += (s, e) => backAction();
            tabPage.Controls.Add(btn);
        }


        //private void InitializeApplication()
        //{
        //    try
        //    {
        //        _db = new DatabaseService();
        //        _circleService = new CircleService(_db);
        //        _registrationService = new RegistrationService(_db);
        //        _userService = new UserService(_db);
        //        _notificationService = new NotificationService(_db);
        //        _reportService = new ReportService(_db);
        //        _securityService = new SecurityService();

        //        // Инициализация интерфейса - ВЫЗЫВАЙТЕ ЗДЕСЬ!
        //        InitializeUI();
        //        LoadCategories();

        //        // Показываем панель входа
        //        ShowLoginPanel();

        //        // Загрузка данных (для тестирования)
        //        _db.InitializeSampleData();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        private void InitializeUI()
        {
            try
            {
                dgvCircles.SelectionChanged += (s, e) =>
                {
                    if (dgvCircles.SelectedRows.Count > 0)
                    {
                        var selectedRow = dgvCircles.SelectedRows[0];
                        if (selectedRow.DataBoundItem is CircleDisplayItem circleData)
                        {
                            _selectedCircleFromCatalog = circleData;
                            Debug.WriteLine($"Выбран кружок из каталога: {circleData.Name}");
                        }
                    }
                };
                // Настройка табов
                tabControl1.Appearance = TabAppearance.FlatButtons;
                tabControl1.ItemSize = new Size(0, 1);
                tabControl1.SizeMode = TabSizeMode.Fixed;

                // Настройка DataGridView
                ConfigureDataGridViews();

                // Начальное состояние панелей
                adminPanel.Visible = false;
                teacherPanel.Visible = false;
                userPanel.Visible = false;
                loginPanel.Visible = true;
                notificationsPanel.Visible = false;

                // Настройка NumericUpDown
                nudMinAge.Maximum = 100;
                nudMaxAge.Maximum = 100;
                nudMaxPrice.Maximum = 100000;
                nudMinAge.Value = 0;
                nudMaxAge.Value = 0;
                nudMaxPrice.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка настройки UI: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Кнопка регистрации
            var btnRegister = new Button
            {
                Text = "Зарегистрироваться",
                Location = new Point(150, 260),
                Size = new Size(120, 30),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };

            btnRegister.Click += (s, e) =>
            {
                RegisterForm registerForm = new RegisterForm(_databaseService); // <-- передаем существующий DatabaseService
                if (registerForm.ShowDialog() == DialogResult.OK && registerForm.NewParticipant != null)
                {
                    var newUser = registerForm.NewParticipant;

                    string plainPassword = registerForm.txtPassword.Text;

                    if (_userService.RegisterUser(newUser, plainPassword))
                    {
                        MessageBox.Show(
                            $"Регистрация успешна!\nЛогин: {newUser.Email}\nПароль: {plainPassword}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtEmail.Text = newUser.Email;
                        txtPassword.Text = plainPassword;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Регистрация не удалась. Возможно, пользователь с таким email уже существует.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };



            loginPanel.Controls.Add(btnRegister);
        }



        private void ConfigureDataGridViews()
        {
            // DataGridView для кружков
            dgvCircles.AutoGenerateColumns = false;
            dgvCircles.Columns.Clear();

            dgvCircles.SelectionChanged += (s, e) =>
            {
                if (dgvCircles.SelectedRows.Count > 0 && dgvCircles.SelectedRows[0].DataBoundItem != null)
                {
                    try
                    {
                        var selectedRow = dgvCircles.SelectedRows[0];
                        var idValue = selectedRow.Cells["Id"].Value;

                        if (idValue != null && idValue != DBNull.Value)
                        {
                            _currentSelectedCircleId = (Guid)idValue;
                            // Получаем полную информацию о кружке
                            _currentSelectedCircle = _circleService?.GetCircleById(_currentSelectedCircleId);
                            Debug.WriteLine($"Выбран кружок ID: {_currentSelectedCircleId}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Ошибка выбора кружка: {ex.Message}");
                    }
                }
            };

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                Name = "Id"
            };
            dgvCircles.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Название",
                Width = 150,
                Name = "Name"
            };
            dgvCircles.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Категория",
                Width = 100,
                Name = "Category"
            };
            dgvCircles.Columns.Add(categoryColumn);

            DataGridViewTextBoxColumn ageColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AgeRange",
                HeaderText = "Возраст",
                Width = 80,
                Name = "AgeRange"
            };
            dgvCircles.Columns.Add(ageColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Цена",
                Width = 80,
                Name = "Price"
            };
            dgvCircles.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn slotsColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AvailableSlots",
                HeaderText = "Свободно мест",
                Width = 100,
                Name = "AvailableSlots"
            };
            dgvCircles.Columns.Add(slotsColumn);

            DataGridViewTextBoxColumn teacherColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TeacherName",
                HeaderText = "Преподаватель",
                Width = 120,
                Name = "TeacherName"
            };
            dgvCircles.Columns.Add(teacherColumn);

            // DataGridView для заявок пользователя
            dgvRegistrations.AutoGenerateColumns = false;
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
                DataPropertyName = "CircleName",
                HeaderText = "Кружок",
                Width = 150,
                Name = "CircleName"
            });

            dgvRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RegistrationDate",
                HeaderText = "Дата заявки",
                Width = 120,
                Name = "RegistrationDate"
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

            // DataGridView для админских заявок
            dgvAdminRegistrations.AutoGenerateColumns = false;
            dgvAdminRegistrations.Columns.Clear();

            dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                Name = "Id"
            });

            dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CircleName",
                HeaderText = "Кружок",
                Width = 150,
                Name = "CircleName"
            });

            dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RegistrationDate",
                HeaderText = "Дата заявки",
                Width = 120,
                Name = "RegistrationDate"
            });

            dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Статус",
                Width = 100,
                Name = "Status"
            });

            // DataGridView для кружков учителя
            dgvTeacherCircles.AutoGenerateColumns = false;
            dgvTeacherCircles.Columns.Clear();

            dgvTeacherCircles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                Name = "Id"
            });

            dgvTeacherCircles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Название кружка",
                Width = 200,
                Name = "Name"
            });

            dgvTeacherCircles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ParticipantsCount",
                HeaderText = "Участников",
                Width = 80,
                Name = "ParticipantsCount"
            });

            dgvTeacherCircles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaxParticipants",
                HeaderText = "Максимум",
                Width = 80,
                Name = "MaxParticipants"
            });

            // DataGridView для уведомлений
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.Columns.Clear();

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                Name = "Id"
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Заголовок",
                Width = 150,
                Name = "Title"
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Message",
                HeaderText = "Сообщение",
                Width = 200,
                Name = "Message"
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SentDate",
                HeaderText = "Дата отправки",
                Width = 120,
                Name = "SentDate"
            });

            dgvNotifications.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsRead",
                HeaderText = "Прочитано",
                Width = 80,
                Name = "IsRead"
            });

            dgvCircles.SelectionChanged += DgvCircles_SelectionChanged;
        }

        private void DgvCircles_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCircles.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvCircles.SelectedRows[0];

                    // Сохраняем ID выбранного кружка
                    if (selectedRow.Cells["Id"].Value != null &&
                        selectedRow.Cells["Id"].Value != DBNull.Value)
                    {
                        _selectedCircleId = (Guid)selectedRow.Cells["Id"].Value;
                        _selectedCircleDisplay = selectedRow.DataBoundItem as CircleDisplayItem;

                        Debug.WriteLine($"Выбран кружок: ID={_selectedCircleId}, Name={_selectedCircleDisplay?.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при выборе кружка: {ex.Message}");
            }
        }
        private void LoadCategories()
        {
            try
            {
                // ОЧИСТИТЬ ПРЕЖДЕ ЧЕМ ДОБАВЛЯТЬ
                cmbCategory.Items.Clear();

                // Добавляем элементы
                var categories = new List<string> { "Все", "Спорт", "Творчество", "Наука", "Языки", "Музыка" };
                cmbCategory.Items.AddRange(categories.ToArray());

                // ТОЛЬКО ПОСЛЕ ТОГО КАК ДОБАВИЛИ ЭЛЕМЕНТЫ
                if (cmbCategory.Items.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Молча игнорируем или логируем
                Debug.WriteLine($"Ошибка загрузки категорий: {ex.Message}");
            }
        }

        private void ShowLoginPanel()
        {
            loginPanel.Visible = true;
            userPanel.Visible = false;
            adminPanel.Visible = false;
            teacherPanel.Visible = false;
            notificationsPanel.Visible = false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                // 1. Создаем DatabaseService с правильной строкой подключения
                if (_databaseService == null)
                {
                    // Используем строку из конфига ИЛИ жестко закодированную
                    var connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"]?.ConnectionString;

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        connectionString = "Data Source=ADMIN-PC97;Initial Catalog=CircleRegistrationSystem;Integrated Security=True";
                    }

                    _databaseService = new DatabaseService(connectionString);
                }

                // 2. Создаем UserService с этим DatabaseService
                if (_userService == null)
                {
                    _userService = new UserService(_databaseService);
                }

                // 3. Ищем пользователя
                var user = _userService.GetUserByEmail(email);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Проверяем пароль
                bool ok = _securityService.VerifyPassword(password, user.PasswordHash);

                if (!ok)
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 5. Устанавливаем текущего пользователя
                _currentUser = user;

                MessageBox.Show($"Добро пожаловать, {_currentUser.FullName}!",
                    "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 6. Инициализируем остальные сервисы
                InitializeServicesWithDatabase();
                UpdateUserInterface();
                tabControl1.SelectedTab = tabCatalog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка входа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string GetRoleDisplayName(string role)
        {
            switch (role)
            {
                case "Admin": return "Администратор";
                case "Teacher": return "Преподаватель";
                case "Student": return "Ученик";
                case "Parent": return "Родитель";
                default: return role;
            }
        }
        //private void InitializeTestDataIfEmpty()
        //{
        //    try
        //    {
        //        // Проверяем, есть ли кружки в базе
        //        var circlesCount = _db.Circles.Count();

        //        if (circlesCount == 0)
        //        {
        //            // Создаем тестовые кружки
        //            var testCircles = new List<Circle>
        //    {
        //        new Circle
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Футбол для детей",
        //            Description = "Обучение основам футбола для детей",
        //            Category = "Спорт",
        //            AgeMin = 6,
        //            AgeMax = 12,
        //            Price = 1500,
        //            MaxParticipants = 15,
        //            CurrentParticipants = 0,
        //            TeacherId = GetOrCreateTestTeacherId(),
        //            IsActive = true,
        //            CreatedAt = DateTime.Now
        //        },
        //        new Circle
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Рисование акварелью",
        //            Description = "Основы рисования акварельными красками",
        //            Category = "Творчество",
        //            AgeMin = 8,
        //            AgeMax = 14,
        //            Price = 1200,
        //            MaxParticipants = 10,
        //            CurrentParticipants = 0,
        //            TeacherId = GetOrCreateTestTeacherId(),
        //            IsActive = true,
        //            CreatedAt = DateTime.Now
        //        },
        //        new Circle
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Программирование на Scratch",
        //            Description = "Введение в программирование для детей",
        //            Category = "Наука",
        //            AgeMin = 10,
        //            AgeMax = 16,
        //            Price = 2000,
        //            MaxParticipants = 12,
        //            CurrentParticipants = 0,
        //            TeacherId = GetOrCreateTestTeacherId(),
        //            IsActive = true,
        //            CreatedAt = DateTime.Now
        //        }
        //    };

        //            foreach (var circle in testCircles)
        //            {
        //                _db.Circles.Add(circle);
        //            }

        //            _db.SaveChanges();

        //            Debug.WriteLine("Создано тестовых кружков: " + testCircles.Count);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Ошибка инициализации тестовых данных: " + ex.Message);
        //    }
        //}

        //private Guid GetOrCreateTestTeacherId()
        //{
        //    try
        //    {
        //        // Пробуем найти существующего преподавателя
        //        var teacher = _db.Users.FirstOrDefault(u => u.Role == "Teacher");

        //        if (teacher != null)
        //        {
        //            return teacher.Id;
        //        }

        //        // Если нет, создаем тестового преподавателя
        //        var newTeacher = new Participant
        //        {
        //            Id = Guid.NewGuid(),
        //            FullName = "Тестовый Преподаватель",
        //            Email = "teacher@test.ru",
        //            PasswordHash = _securityService.HashPassword("Test123!"),
        //            Role = "Teacher",
        //            IsActive = true
        //        };

        //        _db.Users.Add(newTeacher);
        //        _db.SaveChanges();

        //        return newTeacher.Id;
        //    }
        //    catch
        //    {
        //        // Возвращаем случайный Guid в случае ошибки
        //        return Guid.NewGuid();
        //    }
        //}
        private void LoadAllCircles()
        {
            try
            {
                if (_circleService == null)
                {
                    MessageBox.Show("Сервис кружков не инициализирован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var circles = _circleService.GetAvailableCircles();

                if (circles == null || circles.Count == 0)
                {
                    MessageBox.Show("Нет доступных кружков", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCircles.DataSource = null;
                    return;
                }

                // Преобразуем для отображения
                var displayData = circles.Select(c => new CircleDisplayItem
                {
                    Id = c.Id,
                    Name = c.Name ?? "Без названия",
                    Category = c.Category ?? "Без категории",
                    AgeRange = $"{c.AgeMin}-{c.AgeMax}",
                    Price = $"{c.Price:F2} руб.",
                    AvailableSlots = $"{c.MaxParticipants - c.CurrentParticipants}/{c.MaxParticipants}",
                    TeacherName = GetTeacherName(c.TeacherId)
                }).ToList();

                dgvCircles.DataSource = displayData;

                // ВАЖНО: Разрешаем выбор строк
                dgvCircles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCircles.MultiSelect = false;

                // Если есть кружки, выбираем первый
                if (dgvCircles.Rows.Count > 0)
                {
                    dgvCircles.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки кружков: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Добавьте метод GetTeacherName:
        private string GetTeacherName(Guid? teacherId)
        {
            if (!teacherId.HasValue) return "Не указан";

            try
            {
                var teacher = _db.GetUserById(teacherId.Value);
                return teacher?.FullName ?? "Неизвестный";
            }
            catch
            {
                return "Ошибка загрузки";
            }
        }
        private void UpdateUserInterface()
        {
            if (_currentUser != null)
            {
                try
                {
                    lblWelcome.Text = $"Добро пожаловать, {_currentUser.FullName}!";
                    lblRole.Text = $"Роль: {GetRoleDisplayName(_currentUser.Role)}";
                    loginPanel.Visible = false;
                    userPanel.Visible = true;

                    LoadCategories();
                    LoadAllCircles();  // Загружаем кружки

                    // Проверяем сервисы перед вызовом
                    if (_registrationService != null)
                        LoadUserRegistrations();

                    // Настройка панелей в зависимости от роли
                    if (_currentUser.Role == "Admin" && adminPanel != null)
                    {
                        adminPanel.Visible = true;
                        try
                        {
                            if (_db != null)
                                LoadAdminData();
                        }
                        catch { /* игнорируем */ }
                    }
                    else if (_currentUser.Role == "Teacher" && teacherPanel != null)
                    {
                        teacherPanel.Visible = true;
                        LoadTeacherData(); // Закомментировано пока нет реализации
                    }

                    // Обновляем кнопку уведомлений
                    btnShowNotifications.Text = "Уведомления (0)";
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления интерфейса: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Метод для получения выбранного кружка из каталога
        private CircleDisplayItem GetSelectedCircleFromCatalog()
        {
            // Сначала проверяем сохраненный выбор
            if (_selectedCircleFromCatalog != null)
            {
                return _selectedCircleFromCatalog;
            }

            // Если сохраненного выбора нет, проверяем текущий выбор в таблице
            if (dgvCircles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кружок из каталога", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                var selectedRow = dgvCircles.SelectedRows[0];
                if (selectedRow.DataBoundItem is CircleDisplayItem circleData)
                {
                    // Сохраняем выбор для будущего использования
                    _selectedCircleFromCatalog = circleData;
                    return circleData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе кружка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        // Метод для получения выбранного кружка из списка преподавателя
        private Circle GetSelectedCircleFromTeacherList()
        {
            if (dgvTeacherCircles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кружок из вашего списка", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                var selectedRow = dgvTeacherCircles.SelectedRows[0];
                var rowData = selectedRow.DataBoundItem;

                var idProperty = rowData.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    var circleId = (Guid)idProperty.GetValue(rowData);
                    // Сохраняем выбор
                    _selectedCircleFromTeacherList = _circleService.GetCircleById(circleId);
                    return _selectedCircleFromTeacherList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе кружка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        private void btnEditCircle_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. ПРОВЕРЯЕМ РОЛЬ
                if (_currentUser == null || (_currentUser.Role != "Admin" && _currentUser.Role != "Teacher"))
                {
                    MessageBox.Show("Только администраторы и преподаватели могут редактировать кружки",
                        "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. ОПРЕДЕЛЯЕМ, КАКОЙ КРУЖОК РЕДАКТИРОВАТЬ
                Guid? circleIdToEdit = null;

                if (tabControl1.SelectedTab == tabCatalog)
                {
                    // Редактируем выбранный в каталоге кружок
                    if (_currentSelectedCircleId == Guid.Empty)
                    {
                        MessageBox.Show("Сначала выберите кружок для редактирования!",
                            "Выберите кружок", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    circleIdToEdit = _currentSelectedCircleId;
                }
                else if (tabControl1.SelectedTab == tabTeacherCircles && _currentUser.Role == "Teacher")
                {
                    // Преподаватель редактирует свой кружок
                    if (dgvTeacherCircles.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Выберите кружок из вашего списка", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var selectedRow = dgvTeacherCircles.SelectedRows[0];
                    var idProperty = selectedRow.DataBoundItem?.GetType().GetProperty("Id");
                    if (idProperty != null)
                    {
                        circleIdToEdit = (Guid)idProperty.GetValue(selectedRow.DataBoundItem);
                    }
                }

                // 3. ЕСЛИ НЕ ВЫБРАН КРУЖОК - СОЗДАЕМ НОВЫЙ (только для админа)
                if (!circleIdToEdit.HasValue)
                {
                    if (_currentUser.Role == "Admin")
                    {
                        circleIdToEdit = null; // null = новый кружок
                    }
                    else
                    {
                        MessageBox.Show("Выберите кружок для редактирования", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 4. ПРОВЕРЯЕМ БАЗУ ДАННЫХ
                if (_db == null)
                {
                    MessageBox.Show("Ошибка инициализации базы данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 5. ОТКРЫВАЕМ ФОРМУ РЕДАКТИРОВАНИЯ
                var editForm = new CircleEditForm(circleIdToEdit, _db);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Изменения сохранены", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем данные
                    LoadAllCircles();
                    if (_currentUser.Role == "Teacher")
                        LoadTeacherData();
                    if (_currentUser.Role == "Admin")
                        LoadAdminData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании кружка:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ДОБАВЬТЕ ЭТОТ МЕТОД в MainForm.cs
        private void btnManageCircles_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. ПРОВЕРЯЕМ РОЛЬ
                if (_currentUser == null || _currentUser.Role != "Admin")
                {
                    MessageBox.Show("Только администраторы могут управлять кружками",
                        "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. ПРОВЕРЯЕМ БАЗУ ДАННЫХ
                if (_db == null)
                {
                    MessageBox.Show("Ошибка инициализации базы данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. ОТКРЫВАЕМ ФОРМУ УПРАВЛЕНИЯ КРУЖКАМИ
                // Если у вас есть форма для управления кружками, используйте ее
                // Если нет - откроем форму редактирования с возможностью выбора кружка

                using (var selectionForm = new Form())
                {
                    selectionForm.Text = "Управление кружками";
                    selectionForm.Size = new Size(400, 300);
                    selectionForm.StartPosition = FormStartPosition.CenterParent;

                    var btnAddNew = new Button
                    {
                        Text = "Добавить новый кружок",
                        Location = new Point(100, 50),
                        Size = new Size(200, 40)
                    };

                    var btnEditExisting = new Button
                    {
                        Text = "Редактировать существующий",
                        Location = new Point(100, 120),
                        Size = new Size(200, 40)
                    };

                    var btnClose = new Button
                    {
                        Text = "Закрыть",
                        Location = new Point(100, 190),
                        Size = new Size(200, 40)
                    };

                    btnAddNew.Click += (s, ev) =>
                    {
                        var editForm = new CircleEditForm(null, _db); // null = новый кружок
                        editForm.ShowDialog();
                        selectionForm.Close();
                        LoadAllCircles(); // Обновляем список
                    };

                    btnEditExisting.Click += (s, ev) =>
                    {
                        // Показываем форму выбора кружка
                        var circles = _circleService.GetAvailableCircles();
                        if (circles.Count == 0)
                        {
                            MessageBox.Show("Нет доступных кружков для редактирования",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        using (var circleSelect = new CircleSelectionForm(circles, "Выберите кружок для редактирования"))
                        {
                            if (circleSelect.ShowDialog() == DialogResult.OK && circleSelect.SelectedCircle != null)
                            {
                                var editForm = new CircleEditForm(circleSelect.SelectedCircle.Id, _db);
                                editForm.ShowDialog();
                                LoadAllCircles(); // Обновляем список
                            }
                        }
                        selectionForm.Close();
                    };

                    btnClose.Click += (s, ev) => selectionForm.Close();

                    selectionForm.Controls.Add(btnAddNew);
                    selectionForm.Controls.Add(btnEditExisting);
                    selectionForm.Controls.Add(btnClose);

                    selectionForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при управлении кружками:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 1. Открытие AttendanceForm для преподавателя
        private void btnViewAttendanceForTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. ПРОВЕРЯЕМ, ВЫБРАН ЛИ КРУЖОК
                if (_currentSelectedCircleId == Guid.Empty)
                {
                    MessageBox.Show("Сначала выберите кружок из каталога!\n\nНажмите на строку с нужным кружком в таблице, затем нажмите кнопку 'Посещаемость'",
                        "Выберите кружок", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. ПРОВЕРЯЕМ РОЛЬ
                if (_currentUser == null || (_currentUser.Role != "Teacher" && _currentUser.Role != "Admin"))
                {
                    MessageBox.Show("Только преподаватели и администраторы могут просматривать посещаемость",
                        "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. ПРОВЕРЯЕМ ИНИЦИАЛИЗАЦИЮ СЕРВИСОВ
                if (_db == null)
                {
                    MessageBox.Show("Ошибка инициализации базы данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. ПРОВЕРЯЕМ ПРАВА (если преподаватель, должен быть преподавателем этого кружка)
                if (_currentUser.Role == "Teacher")
                {
                    var circle = _circleService?.GetCircleById(_currentSelectedCircleId);
                    if (circle == null || circle.TeacherId != _currentUser.Id)
                    {
                        MessageBox.Show("Вы не являетесь преподавателем выбранного кружка",
                            "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 5. ОТКРЫВАЕМ ФОРМУ ПОСЕЩАЕМОСТИ
                var attendanceForm = new AttendanceForm(_currentSelectedCircleId, _db);
                attendanceForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы посещаемости:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 2. Открытие RegistrationManagementForm для администратора
        private void btnManageRegistrations_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role == "Admin")
            {
                var managementForm = new RegistrationManagementForm(_db, _currentUser);
                managementForm.ShowDialog();
            }
        }

        // 3. Открытие отчетов
        private void btnViewReports_Click(object sender, EventArgs e)
        {
            // Форма выбора типа отчета
            using (var reportTypeForm = new Form())
            {
                reportTypeForm.Text = "Выберите тип отчета";
                reportTypeForm.Size = new Size(300, 200);
                reportTypeForm.StartPosition = FormStartPosition.CenterParent;

                var btnAttendanceReport = new Button
                {
                    Text = "Отчет по посещаемости",
                    Location = new Point(50, 30),
                    Size = new Size(200, 40)
                };

                var btnRegistrationsReport = new Button
                {
                    Text = "Отчет по заявкам",
                    Location = new Point(50, 90),
                    Size = new Size(200, 40)
                };

                btnAttendanceReport.Click += (s, ev) =>
                {
                    // Сначала выбираем кружок
                    var circles = _circleService.GetAvailableCircles();
                    using (var selectForm = new CircleSelectionForm(circles, "Выберите кружок для отчета"))
                    {
                        if (selectForm.ShowDialog() == DialogResult.OK && selectForm.SelectedCircle != null)
                        {
                            // Форма выбора периода
                            using (var periodForm = new PeriodSelectionForm())
                            {
                                if (periodForm.ShowDialog() == DialogResult.OK)
                                {
                                    var reportForm = new AttendanceReportForm(
                                        selectForm.SelectedCircle.Id,
                                        _db,
                                        periodForm.StartDate,
                                        periodForm.EndDate);
                                    reportForm.ShowDialog();
                                }
                            }
                        }
                    }
                    reportTypeForm.DialogResult = DialogResult.OK;
                };

                btnRegistrationsReport.Click += (s, ev) =>
                {
                    MessageBox.Show("Отчет по заявкам будет в следующей версии", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reportTypeForm.DialogResult = DialogResult.OK;
                };

                reportTypeForm.Controls.Add(btnAttendanceReport);
                reportTypeForm.Controls.Add(btnRegistrationsReport);
                reportTypeForm.ShowDialog();
            }
        }

        // 4. Просмотр деталей заявки (двойной клик)
        private void dgvRegistrations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRegistrations.Rows[e.RowIndex].DataBoundItem != null)
            {
                try
                {
                    // Получаем ID заявки
                    var registrationId = (Guid)dgvRegistrations.Rows[e.RowIndex].Cells["Id"].Value;

                    // Находим заявку
                    var registration = _registrationService?.GetAllRegistrations()
                        .FirstOrDefault(r => r.Id == registrationId);

                    if (registration != null && _db != null)
                    {
                        var detailsForm = new RegistrationDetailsForm(registration, _db);
                        detailsForm.ShowDialog();

                        // Обновляем данные после закрытия
                        LoadUserRegistrations();
                    }
                    else
                    {
                        MessageBox.Show("Заявка не найдена", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии деталей заявки:\n{ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadUserRegistrations()
        {
            try
            {
                if (_currentUser == null) return;

                Debug.WriteLine("=== ЗАГРУЗКА МОИХ ЗАЯВОК ===");

                _userRegistrations = _registrationService.GetUserRegistrations(_currentUser.Id);
                Debug.WriteLine($"Найдено заявок: {_userRegistrations?.Count ?? 0}");

                if (_userRegistrations == null || _userRegistrations.Count == 0)
                {
                    dgvRegistrations.DataSource = null;
                    return;
                }

                // Используем список для отладки
                var displayData = new List<RegistrationDisplayItem>();

                foreach (var reg in _userRegistrations)
                {
                    Debug.WriteLine($"Заявка ID: {reg.Id}, CircleId: {reg.CircleId}");

                    // Получаем информацию о кружке
                    Circle circle = null;
                    if (reg.CircleId != Guid.Empty)
                    {
                        circle = _db.GetCircleById(reg.CircleId);
                        Debug.WriteLine($"  Кружок найден: {circle?.Name ?? "NULL"}");
                    }

                    // Получаем информацию о преподавателе
                    string teacherName = "Не указан";
                    if (circle?.TeacherId != null)
                    {
                        var teacher = _db.GetUserById(circle.TeacherId.Value);
                        teacherName = teacher?.FullName ?? "Неизвестно";
                    }

                    displayData.Add(new RegistrationDisplayItem
                    {
                        Id = reg.Id,
                        CircleName = circle?.Name ?? "Кружок удален",
                        RegistrationDate = reg.ApplicationDate.ToString("dd.MM.yyyy HH:mm"),
                        Status = GetStatusDisplayText(reg.Status),
                        TeacherName = teacherName
                    });
                }

                dgvRegistrations.DataSource = displayData;
                Debug.WriteLine($"Отображено заявок: {displayData.Count}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ОШИБКА в LoadUserRegistrations: {ex.Message}");
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetStatusDisplayText(string status)
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

        private void LoadAdminData()
        {
            try
            {
                // Используем новый метод для получения данных
                var registrations = _db.GetRegistrationsWithDetails();

                if (registrations == null || registrations.Count == 0)
                {
                    dgvAdminRegistrations.DataSource = null;
                    lblTotalRegistrations.Text = "Заявок: 0";
                    lblPendingRegistrations.Text = "На рассмотрении: 0";

                    // Показываем информацию об отсутствии данных
                    MessageBox.Show("Нет заявок для отображения.\n\n" +
                                  "Возможные причины:\n" +
                                  "1. В базе данных нет заявок\n" +
                                  "2. Пользователи еще не подавали заявки\n" +
                                  "3. Проблема с подключением к базе данных",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Настраиваем DataGridView
                dgvAdminRegistrations.AutoGenerateColumns = false;
                dgvAdminRegistrations.Columns.Clear();

                // Добавляем колонки
                dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Visible = false,
                    Name = "Id"
                });

                dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ParticipantName",
                    HeaderText = "Участник",
                    Width = 150,
                    Name = "ParticipantName"
                });

                dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CircleName",
                    HeaderText = "Кружок",
                    Width = 150,
                    Name = "CircleName"
                });

                dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ApplicationDate",
                    HeaderText = "Дата заявки",
                    Width = 120,
                    Name = "ApplicationDate"
                });

                dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Status",
                    HeaderText = "Статус",
                    Width = 100,
                    Name = "Status"
                });

                dgvAdminRegistrations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CircleCategory",
                    HeaderText = "Категория",
                    Width = 100,
                    Name = "CircleCategory"
                });

                // Преобразуем данные для отображения
                var displayData = registrations.Select(r => new
                {
                    Id = r.Id,
                    ParticipantName = r.ParticipantName ?? "Неизвестно",
                    CircleName = r.CircleName ?? "Неизвестно",
                    ApplicationDate = r.ApplicationDate.ToString("dd.MM.yyyy HH:mm"),
                    Status = GetStatusDisplayText(r.Status),
                    CircleCategory = GetCircleCategory(r.CircleId) // Получаем категорию кружка
                }).ToList();

                dgvAdminRegistrations.DataSource = displayData;

                // Статистика
                lblTotalRegistrations.Text = $"Заявок: {registrations.Count}";
                lblPendingRegistrations.Text = $"На рассмотрении: {registrations.Count(r => r.Status == "Pending")}";

                // Отладочная информация
                Debug.WriteLine($"Загружено заявок: {registrations.Count}");
                foreach (var reg in registrations.Take(3))
                {
                    Debug.WriteLine($"Заявка: {reg.ParticipantName} -> {reg.CircleName} ({reg.Status})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных администратора:\n{ex.Message}\n\n" +
                               $"Подробности: {ex.InnerException?.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvAdminRegistrations.DataSource = new List<object>();
            }
        }

        // Добавьте этот вспомогательный метод в MainForm:
        private string GetCircleCategory(Guid circleId)
        {
            try
            {
                var circle = _db.GetCircleById(circleId);
                return circle?.Category ?? "Не указана";
            }
            catch
            {
                return "Ошибка";
            }
        }

        // Добавьте этот вспомогательный метод в MainForm:
        private string GetCircleAgeRange(Guid circleId)
        {
            try
            {
                var circle = _db.GetCircleById(circleId);
                return circle != null ? $"{circle.AgeMin}-{circle.AgeMax}" : "0-0";
            }
            catch
            {
                return "0-0";
            }
        }
        private void LoadTeacherData()
        {
            try
            {
                _teacherCircles = _circleService.GetTeacherCircles(_currentUser.Id);

                if (_teacherCircles == null || _teacherCircles.Count == 0)
                {
                    dgvTeacherCircles.DataSource = null;
                    MessageBox.Show("У вас нет кружков для управления", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // СОЗДАЕМ СПИСОК С ЯВНЫМ ID
                var displayData = _teacherCircles.Select(c => new
                {
                    Id = c.Id, // ВАЖНО: добавляем Id
                    Name = c.Name,
                    Category = c.Category,
                    ParticipantsCount = c.CurrentParticipants,
                    MaxParticipants = c.MaxParticipants,
                    AvailableSlots = c.MaxParticipants - c.CurrentParticipants
                }).ToList();

                dgvTeacherCircles.DataSource = displayData;

                // Настраиваем колонки
                if (dgvTeacherCircles.Columns["Id"] != null)
                    dgvTeacherCircles.Columns["Id"].Visible = false; // Скрываем ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных учителя: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvTeacherCircles.DataSource = null;
            }
        }
        private void LoadNotifications()
        {
            try
            {
                if (_currentUser == null) return;

                // Упрощенные уведомления
                var notifications = new List<object>
        {
            new { Id = Guid.NewGuid(), Title = "Добро пожаловать!", Message = "Вы успешно вошли в систему", SentDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm"), IsRead = false },
            new { Id = Guid.NewGuid(), Title = "Системное уведомление", Message = "Проверьте доступные кружки", SentDate = DateTime.Now.AddHours(-1).ToString("dd.MM.yyyy HH:mm"), IsRead = true }
        };

                dgvNotifications.DataSource = notifications;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки уведомлений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvNotifications.DataSource = new List<object>();
            }
        }

        private void btnMarkAsRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNotifications.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Уведомление отмечено как прочитанное", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Выберите уведомление", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarkAllAsRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Все уведомления отмечены как прочитанные", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateNotificationButton();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = _securityService.SanitizeInput(txtSearch.Text.Trim());
                string category = cmbCategory.SelectedItem?.ToString();
                int? minAge = nudMinAge.Value > 0 ? (int?)nudMinAge.Value : null;
                int? maxAge = nudMaxAge.Value > 0 ? (int?)nudMaxAge.Value : null;
                decimal? maxPrice = nudMaxPrice.Value > 0 ? (decimal?)nudMaxPrice.Value : null;

                var filteredCircles = _circleService.SearchCircles(
                    keyword: searchText,
                    category: category != "Все" ? category : null,
                    minAge: minAge,
                    maxAge: maxAge,
                    maxPrice: maxPrice
                );

                var displayData = filteredCircles.Select(c => new CircleDisplayItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    Category = c.Category,
                    AgeRange = $"{c.AgeMin}-{c.AgeMax}",
                    Price = $"{c.Price:F2} руб.",
                    AvailableSlots = $"{c.MaxParticipants - c.CurrentParticipants}/{c.MaxParticipants}",
                    TeacherName = c.Teacher?.FullName ?? "Не указан"
                }).ToList();

                dgvCircles.DataSource = displayData;

                if (filteredCircles.Count == 0)
                {
                    MessageBox.Show("Кружки по заданным критериям не найдены", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterForCircle_Click(object sender, EventArgs e)
        {
            if (dgvCircles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кружок для записи", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedRow = dgvCircles.SelectedRows[0];
                if (selectedRow.DataBoundItem is CircleDisplayItem circleData)
                {
                    var circleId = circleData.Id;

                    // Получаем информацию о кружке
                    var circle = _circleService.GetCircleById(circleId);
                    if (circle == null)
                    {
                        MessageBox.Show("Кружок не найден", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Проверяем доступность мест
                    if (circle.CurrentParticipants >= circle.MaxParticipants)
                    {
                        MessageBox.Show("На этот кружок нет свободных мест", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Проверка возраста
                    if (_currentUser.DateOfBirth.HasValue)
                    {
                        var age = CalculateAge(_currentUser.DateOfBirth.Value);
                        if (age < circle.AgeMin || age > circle.AgeMax)
                        {
                            MessageBox.Show($"Ваш возраст ({age} лет) не соответствует требованиям кружка ({circle.AgeMin}-{circle.AgeMax} лет)",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Создание заявки
                    var registration = _registrationService.CreateRegistration(_currentUser.Id, circleId);

                    if (registration != null)
                    {
                        MessageBox.Show("Заявка подана успешно! Ожидайте подтверждения.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновление данных
                        LoadAllCircles();
                        LoadUserRegistrations();

                        if (_currentUser.Role == "Admin")
                            LoadAdminData();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось создать заявку. Возможно:\n1. Вы уже записаны на этот кружок\n2. Регистрация закрыта\n3. Не подходит возраст",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private bool CheckAvailableSlots(Guid circleId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                SELECT (MaxParticipants - CurrentParticipants) as AvailableSlots 
                FROM Circles 
                WHERE Id = @CircleId";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CircleId", circleId);
                        int availableSlots = (int)cmd.ExecuteScalar();

                        return availableSlots > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private (int MinAge, int MaxAge) GetCircleAgeRestrictions(Guid circleId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT AgeMin, AgeMax FROM Circles WHERE Id = @CircleId";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CircleId", circleId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (reader.GetInt32(0), reader.GetInt32(1));
                            }
                        }
                    }
                }
            }
            catch
            {
                return (0, 100); // Дефолтные значения при ошибке
            }

            return (0, 100);
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        private void btnCancelRegistration_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для отмены", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedRow = dgvRegistrations.SelectedRows[0];
                if (selectedRow.DataBoundItem is RegistrationDisplayItem regData)
                {
                    var registration = _userRegistrations.FirstOrDefault(r => r.Id == regData.Id);

                    if (registration == null)
                    {
                        MessageBox.Show("Заявка не найдена", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (registration.Status != "Pending")
                    {
                        MessageBox.Show("Можно отменить только заявки со статусом 'На рассмотрении'",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Вы уверены, что хотите отменить заявку?", "Подтверждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var success = _registrationService.CancelRegistration(registration.Id);

                        if (success)
                        {
                            MessageBox.Show("Заявка отменена", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserRegistrations();
                            LoadAllCircles();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось отменить заявку", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApproveRegistration_Click(object sender, EventArgs e)
        {
            if (dgvAdminRegistrations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для подтверждения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedRow = dgvAdminRegistrations.SelectedRows[0];
                var rowData = selectedRow.DataBoundItem;

                // Используем отражение для получения ID
                var idProperty = rowData.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    var registrationId = (Guid)idProperty.GetValue(rowData);

                    var success = _registrationService.ApproveRegistration(registrationId, _currentUser.Id);

                    if (success)
                    {
                        // Отправка уведомления
                        _notificationService.SendApprovalNotification(registrationId);

                        MessageBox.Show("Заявка подтверждена", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAdminData();
                        LoadAllCircles();
                        LoadNotifications();
                        UpdateNotificationButton();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось подтвердить заявку", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подтверждении заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnRejectRegistration_Click(object sender, EventArgs e)
        //{
        //    if (dgvAdminRegistrations.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Выберите заявку для отклонения", "Ошибка",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        var selectedRow = dgvAdminRegistrations.SelectedRows[0];
        //        var rowData = selectedRow.DataBoundItem;

        //        // Используем отражение для получения ID
        //        var idProperty = rowData.GetType().GetProperty("Id");
        //        if (idProperty != null)
        //        {
        //            var registrationId = (Guid)idProperty.GetValue(rowData);

        //            RejectReasonForm reasonForm = new RejectReasonForm();
        //            if (reasonForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(reasonForm.Reason))
        //            {
        //                var reason = _securityService.SanitizeInput(reasonForm.Reason);
        //                var success = _registrationService.RejectRegistration(registrationId, reason, _currentUser.Id);

        //                if (success)
        //                {
        //                    // Отправка уведомления
        //                    _notificationService.SendRejectionNotification(registrationId, reason);

        //                    MessageBox.Show("Заявка отклонена", "Успех",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    LoadAdminData();
        //                    LoadAllCircles();
        //                    LoadNotifications();
        //                    UpdateNotificationButton();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Не удалось отклонить заявку", "Ошибка",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при отклонении заявки: {ex.Message}", "Ошибка",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void btnAdminGoToCircles_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем роль
                if (_currentUser == null || _currentUser.Role != "Admin")
                {
                    MessageBox.Show("Только администраторы могут управлять кружками",
                        "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем базу данных
                if (_db == null || _circleService == null)
                {
                    MessageBox.Show("Ошибка инициализации базы данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создаем форму управления кружками
                var managementForm = new Form
                {
                    Text = "Управление кружками",
                    Size = new Size(500, 350),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                // Кнопка "Добавить новый кружок"
                var btnAddCircle = new Button
                {
                    Text = "➕ Добавить новый кружок",
                    Location = new Point(150, 50),
                    Size = new Size(200, 40),
                    Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold),
                    BackColor = Color.LightGreen,
                    FlatStyle = FlatStyle.Flat
                };

                // Кнопка "Редактировать существующий"
                var btnEditCircle = new Button
                {
                    Text = "✏️ Редактировать кружок",
                    Location = new Point(150, 110),
                    Size = new Size(200, 40),
                    Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold),
                    BackColor = Color.LightBlue,
                    FlatStyle = FlatStyle.Flat
                };

                // Кнопка "Удалить кружок"
                var btnDeleteCircle = new Button
                {
                    Text = "🗑️ Удалить кружок",
                    Location = new Point(150, 170),
                    Size = new Size(200, 40),
                    Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold),
                    BackColor = Color.LightCoral,
                    FlatStyle = FlatStyle.Flat
                };

                // Кнопка "Закрыть"
                var btnClose = new Button
                {
                    Text = "Закрыть",
                    Location = new Point(150, 230),
                    Size = new Size(200, 40),
                    Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    FlatStyle = FlatStyle.Flat
                };

                // Обработчики событий
                btnAddCircle.Click += (s, ev) =>
                {
                    var editForm = new CircleEditForm(null, _db); // null = новый кружок
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Новый кружок добавлен успешно!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllCircles(); // Обновляем список
                    }
                    managementForm.Close();
                };

                btnEditCircle.Click += (s, ev) =>
                {
                    // Загружаем все кружки для выбора
                    var circles = _circleService.GetAvailableCircles();
                    if (circles.Count == 0)
                    {
                        MessageBox.Show("Нет доступных кружков для редактирования",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Создаем форму выбора кружка
                    var selectForm = new Form
                    {
                        Text = "Выберите кружок для редактирования",
                        Size = new Size(600, 400),
                        StartPosition = FormStartPosition.CenterParent
                    };

                    var dgv = new DataGridView
                    {
                        Location = new Point(10, 10),
                        Size = new Size(560, 300),
                        DataSource = circles,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                        ReadOnly = true
                    };

                    var btnSelect = new Button
                    {
                        Text = "Редактировать выбранный",
                        Location = new Point(10, 320),
                        Size = new Size(200, 30)
                    };

                    var btnCancel = new Button
                    {
                        Text = "Отмена",
                        Location = new Point(220, 320),
                        Size = new Size(100, 30)
                    };

                    btnSelect.Click += (s1, ev1) =>
                    {
                        if (dgv.SelectedRows.Count > 0)
                        {
                            var selectedCircle = dgv.SelectedRows[0].DataBoundItem as Circle;
                            if (selectedCircle != null)
                            {
                                var editForm = new CircleEditForm(selectedCircle.Id, _db);
                                if (editForm.ShowDialog() == DialogResult.OK)
                                {
                                    LoadAllCircles(); // Обновляем список
                                }
                                selectForm.Close();
                                managementForm.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите кружок для редактирования",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    btnCancel.Click += (s1, ev1) => selectForm.Close();

                    selectForm.Controls.Add(dgv);
                    selectForm.Controls.Add(btnSelect);
                    selectForm.Controls.Add(btnCancel);
                    selectForm.ShowDialog();
                };

                btnDeleteCircle.Click += (s, ev) =>
                {
                    try
                    {
                        // Загружаем кружки для выбора
                        var circles = _circleService.GetAvailableCircles();
                        if (circles.Count == 0)
                        {
                            MessageBox.Show("Нет доступных кружков",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Создаем форму выбора кружка
                        var selectForm = new Form
                        {
                            Text = "Выберите кружок для удаления",
                            Size = new Size(600, 400),
                            StartPosition = FormStartPosition.CenterParent
                        };

                        var dgv = new DataGridView
                        {
                            Location = new Point(10, 10),
                            Size = new Size(560, 300),
                            DataSource = circles,
                            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                            ReadOnly = true
                        };

                        var btnDelete = new Button
                        {
                            Text = "УДАЛИТЬ выбранный",
                            Location = new Point(10, 320),
                            Size = new Size(200, 30),
                            BackColor = Color.Red,
                            ForeColor = Color.White,
                            Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold)
                        };

                        var btnCancel = new Button
                        {
                            Text = "Отмена",
                            Location = new Point(220, 320),
                            Size = new Size(100, 30)
                        };

                        btnDelete.Click += (s1, ev1) =>
                        {
                            if (dgv.SelectedRows.Count > 0)
                            {
                                var selectedCircle = dgv.SelectedRows[0].DataBoundItem as Circle;
                                if (selectedCircle != null)
                                {
                                    if (MessageBox.Show($"Вы уверены, что хотите удалить кружок:\n\n" +
                                                       $"Название: {selectedCircle.Name}\n" +
                                                       $"Категория: {selectedCircle.Category}\n\n" +
                                                       $"Это действие нельзя отменить!",
                                        "ПОДТВЕРЖДЕНИЕ УДАЛЕНИЯ",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        // Мягкое удаление - делаем неактивным
                                        selectedCircle.IsActive = false;
                                        if (_db.UpdateCircle(selectedCircle))
                                        {
                                            MessageBox.Show("Кружок успешно удален (деактивирован)", "Успех",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            LoadAllCircles(); // Обновляем список
                                            selectForm.Close();
                                            managementForm.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ошибка при удалении кружка", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Выберите кружок для удаления",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        btnCancel.Click += (s1, ev1) => selectForm.Close();

                        selectForm.Controls.Add(dgv);
                        selectForm.Controls.Add(btnDelete);
                        selectForm.Controls.Add(btnCancel);
                        selectForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении кружка:\n{ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                btnClose.Click += (s, ev) => managementForm.Close();

                // Добавляем кнопки на форму
                managementForm.Controls.Add(btnAddCircle);
                managementForm.Controls.Add(btnEditCircle);
                managementForm.Controls.Add(btnDeleteCircle);
                managementForm.Controls.Add(btnClose);

                // Показываем форму
                managementForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при управлении кружками:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddCircle_Click(object sender, EventArgs e)
        {
            try
            {
                CircleEditForm editForm = new CircleEditForm(null, _db);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Кружок добавлен успешно", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновление данных
                    LoadAllCircles();
                    if (_currentUser.Role == "Admin")
                        LoadAdminData();
                    if (_currentUser.Role == "Teacher")
                        LoadTeacherData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении кружка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewCircleDetails_Click(object sender, EventArgs e)
        {
            if (dgvCircles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кружок для просмотра", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedRow = dgvCircles.SelectedRows[0];
                if (selectedRow.DataBoundItem is CircleDisplayItem circleData)
                {
                    CircleDetailsForm detailsForm = new CircleDetailsForm(circleData.Id, _db);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии деталей кружка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _currentUser = null;
            ShowLoginPanel();
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _db?.Dispose();
        }

        private void btnGoToMyRegistrations_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabMyRegistrations;
        }

        private void btnGoToCatalog_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabCatalog;
        }

        private void btnAdminGoToRegistrations_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем роль
                if (_currentUser == null || _currentUser.Role != "Admin")
                {
                    MessageBox.Show("Только администраторы могут управлять заявками",
                        "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем базу данных
                if (_db == null)
                {
                    MessageBox.Show("Ошибка инициализации базы данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Открываем форму управления заявками
                var managementForm = new RegistrationManagementForm(_db, _currentUser);
                managementForm.ShowDialog();

                // Обновляем данные после закрытия формы
                LoadAdminData();
                LoadAllCircles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии управления заявками:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTeacherGoToCircles_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabTeacherCircles;
        }

        private void btnShowNotifications_Click(object sender, EventArgs e)
        {
            notificationsPanel.Visible = !notificationsPanel.Visible;

            if (notificationsPanel.Visible)
            {
                LoadNotifications();
            }
        }

       



        private void UpdateNotificationButton()
        {
            if (_currentUser == null) return;

            var unreadCount = _notificationService.GetUnreadCount(_currentUser.Id);
            btnShowNotifications.Text = $"Уведомления ({unreadCount})";

            if (unreadCount > 0)
            {
                btnShowNotifications.BackColor = Color.LightYellow;
                btnShowNotifications.ForeColor = Color.Red;
            }
            else
            {
                btnShowNotifications.BackColor = SystemColors.Control;
                btnShowNotifications.ForeColor = SystemColors.ControlText;
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Упрощенный отчет
                var statistics = new List<object>
        {
            new { Показатель = "Всего кружков", Значение = _db.Circles?.Count() ?? 0 },
            new { Показатель = "Активных кружков", Значение = _db.Circles?.Count(c => c.IsActive) ?? 0 },
            new { Показатель = "Всего пользователей", Значение = _db.Users?.Count() ?? 0 },
            new { Показатель = "Всего заявок", Значение = _db.Registrations?.Count() ?? 0 },
            new { Показатель = "Заявок на рассмотрении", Значение = _db.Registrations?.Count(r => r.Status == "Pending") ?? 0 },
            new { Показатель = "Подтвержденных заявок", Значение = _db.Registrations?.Count(r => r.Status == "Approved") ?? 0 }
        };

                using (var reportForm = new Form())
                {
                    reportForm.Text = "Отчет по системе";
                    reportForm.Size = new Size(500, 400);
                    reportForm.StartPosition = FormStartPosition.CenterParent;

                    var dgv = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        AllowUserToDeleteRows = false,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    };

                    dgv.DataSource = statistics;
                    reportForm.Controls.Add(dgv);

                    reportForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, находится ли пользователь на вкладке "Мои кружки"
                if (tabControl1.SelectedTab == tabTeacherCircles)
                {
                    // Преподаватель хочет посмотреть посещаемость своего кружка
                    if (dgvTeacherCircles.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Выберите кружок из списка ваших кружков",
                            "Выберите кружок", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var selectedRow = dgvTeacherCircles.SelectedRows[0];
                    var circleId = (Guid)dgvTeacherCircles.Rows[selectedRow.Index].Cells["Id"].Value;

                    var attendanceForm = new AttendanceForm(circleId, _db);
                    attendanceForm.ShowDialog();
                }
                else
                {
                    // Преподаватель на вкладке каталога
                    if (_selectedCircleId == Guid.Empty)
                    {
                        MessageBox.Show("Сначала выберите кружок!\n\nНажмите на строку с нужным кружком в таблице",
                            "Выберите кружок", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var attendanceForm = new AttendanceForm(_selectedCircleId, _db);
                    attendanceForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии посещаемости:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            // Проверяем, есть ли элементы в ComboBox
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
            else
            {
                // Если элементов нет, просто очищаем выбранный элемент
                cmbCategory.SelectedItem = null;
                cmbCategory.Text = "";
            }

            nudMinAge.Value = 0;
            nudMaxAge.Value = 0;
            nudMaxPrice.Value = 0;

            LoadAllCircles();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllCircles();
            LoadUserRegistrations();

            if (_currentUser != null)
            {
                if (_currentUser.Role == "Admin")
                    LoadAdminData();
                if (_currentUser.Role == "Teacher")
                    LoadTeacherData();

                LoadNotifications();
                UpdateNotificationButton();
            }
        }

        //private void btnChangePassword_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (var passwordForm = new Form())
        //        {
        //            passwordForm.Text = "Смена пароля";
        //            passwordForm.Size = new Size(300, 200);
        //            passwordForm.StartPosition = FormStartPosition.CenterParent;

        //            var lblOld = new Label { Text = "Старый пароль:", Left = 20, Top = 20, Width = 100 };
        //            var txtOld = new TextBox { Left = 130, Top = 20, Width = 140, PasswordChar = '*' };

        //            var lblNew = new Label { Text = "Новый пароль:", Left = 20, Top = 50, Width = 100 };
        //            var txtNew = new TextBox { Left = 130, Top = 50, Width = 140, PasswordChar = '*' };

        //            var lblConfirm = new Label { Text = "Подтвердите:", Left = 20, Top = 80, Width = 100 };
        //            var txtConfirm = new TextBox { Left = 130, Top = 80, Width = 140, PasswordChar = '*' };

        //            var btnOk = new Button { Text = "OK", Left = 80, Top = 120, Width = 60 };
        //            var btnCancel = new Button { Text = "Отмена", Left = 160, Top = 120, Width = 60 };

        //            btnOk.Click += (s, ev) =>
        //            {
        //                if (string.IsNullOrEmpty(txtOld.Text) || string.IsNullOrEmpty(txtNew.Text))
        //                {
        //                    MessageBox.Show("Заполните все поля", "Ошибка",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }

        //                if (txtNew.Text != txtConfirm.Text)
        //                {
        //                    MessageBox.Show("Пароли не совпадают", "Ошибка",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }

        //                if (!_securityService.VerifyPassword(txtOld.Text, _currentUser.PasswordHash))
        //                {
        //                    MessageBox.Show("Неверный старый пароль", "Ошибка",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }

        //                var newHash = _securityService.HashPassword(txtNew.Text);
        //                if (_userService.ChangePassword(_currentUser.Id, newHash))
        //                {
        //                    MessageBox.Show("Пароль успешно изменен", "Успех",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    passwordForm.DialogResult = DialogResult.OK;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Ошибка при смене пароля", "Ошибка",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            };

        //            btnCancel.Click += (s, ev) => passwordForm.DialogResult = DialogResult.Cancel;

        //            passwordForm.Controls.AddRange(new Control[]
        //            {
        //                lblOld, txtOld, lblNew, txtNew, lblConfirm, txtConfirm, btnOk, btnCancel
        //            });

        //            if (passwordForm.ShowDialog() == DialogResult.OK)
        //            {
        //                MessageBox.Show("Пароль успешно изменен", "Успех",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при смене пароля: {ex.Message}", "Ошибка",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void AddBackButtons()
        {
            // Кнопка "Назад в каталог" на вкладке "Мои заявки"
            var btnBackToCatalogFromRegistrations = new Button
            {
                Text = "← Назад в каталог",
                Location = new Point(20, 520),
                Size = new Size(150, 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnBackToCatalogFromRegistrations.Click += (s, e) => tabControl1.SelectedTab = tabCatalog;
            tabMyRegistrations.Controls.Add(btnBackToCatalogFromRegistrations);

            // Кнопка "Назад в каталог" на вкладке админа
            var btnBackToCatalogFromAdmin = new Button
            {
                Text = "← Назад в каталог",
                Location = new Point(20, 520),
                Size = new Size(150, 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnBackToCatalogFromAdmin.Click += (s, e) => tabControl1.SelectedTab = tabCatalog;
            tabAdminRegistrations.Controls.Add(btnBackToCatalogFromAdmin);

            // Кнопка "Назад в каталог" на вкладке учителя
            var btnBackToCatalogFromTeacher = new Button
            {
                Text = "← Назад в каталог",
                Location = new Point(20, 520),
                Size = new Size(150, 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnBackToCatalogFromTeacher.Click += (s, e) => tabControl1.SelectedTab = tabCatalog;
            tabTeacherCircles.Controls.Add(btnBackToCatalogFromTeacher);
        }
        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            if (dgvCircles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кружок для просмотра расписания", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedRow = dgvCircles.SelectedRows[0];
                if (selectedRow.DataBoundItem is CircleDisplayItem circleData)
                {
                    ScheduleForm scheduleForm = new ScheduleForm(circleData.Id, _db);
                    scheduleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool TestDatabaseConnection()
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"].ConnectionString))
                {
                    connection.Open();
                    MessageBox.Show("Подключение к БД успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}\n\n" +
                               $"Строка подключения: {ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"]?.ConnectionString}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void InitializeServicesWithDatabase()
        {
            try
            {
                // УБЕДИТЕСЬ, что DatabaseService уже создан
                if (_databaseService == null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["CircleRegistrationSystemConnection"]?.ConnectionString;

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        connectionString = "Data Source=ADMIN-PC97;Initial Catalog=CircleRegistrationSystem;Integrated Security=True";
                    }

                    _databaseService = new DatabaseService(connectionString);
                }

                // Используем ОДИН И ТОТ ЖЕ DatabaseService для всех сервисов
                _db = _databaseService; // Теперь _db и _databaseService ссылаются на один объект

                // Сначала создаем сервисы, потом инициализируем данные
                _circleService = new CircleService(_db);
                _registrationService = new RegistrationService(_db);
                _userService = new UserService(_db);
                _notificationService = new NotificationService(_db);
                _reportService = new ReportService(_db);

                // Инициализируем тестовые данные если нужно
                _db.InitializeSampleData();

                Debug.WriteLine("Сервисы инициализированы успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации сервисов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

  
    }
}