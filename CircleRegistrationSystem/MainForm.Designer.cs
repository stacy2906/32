namespace CircleRegistrationSystem.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabCatalog = new System.Windows.Forms.TabPage();
            this.userPanel = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnGoToCatalog = new System.Windows.Forms.Button();
            this.btnGoToMyRegistrations = new System.Windows.Forms.Button();
            this.btnShowNotifications = new System.Windows.Forms.Button();
            this.adminPanel = new System.Windows.Forms.Panel();
            this.lblTotalCircles = new System.Windows.Forms.Label();
            this.lblTotalParticipants = new System.Windows.Forms.Label();
            this.lblTotalRegistrations = new System.Windows.Forms.Label();
            this.lblPendingRegistrations = new System.Windows.Forms.Label();
            this.btnAdminGoToRegistrations = new System.Windows.Forms.Button();
            this.btnAdminGoToCircles = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.teacherPanel = new System.Windows.Forms.Panel();
            this.btnViewAttendance = new System.Windows.Forms.Button();
            this.btnTeacherGoToCircles = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblMinAge = new System.Windows.Forms.Label();
            this.nudMinAge = new System.Windows.Forms.NumericUpDown();
            this.lblMaxAge = new System.Windows.Forms.Label();
            this.nudMaxAge = new System.Windows.Forms.NumericUpDown();
            this.lblMaxPrice = new System.Windows.Forms.Label();
            this.nudMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.dgvCircles = new System.Windows.Forms.DataGridView();
            this.btnRegisterForCircle = new System.Windows.Forms.Button();
            this.btnViewCircleDetails = new System.Windows.Forms.Button();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.notificationsPanel = new System.Windows.Forms.Panel();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.btnMarkAsRead = new System.Windows.Forms.Button();
            this.btnMarkAllAsRead = new System.Windows.Forms.Button();
            this.tabMyRegistrations = new System.Windows.Forms.TabPage();
            this.dgvRegistrations = new System.Windows.Forms.DataGridView();
            this.btnCancelRegistration = new System.Windows.Forms.Button();
            this.lblMyRegistrations = new System.Windows.Forms.Label();
            this.tabAdminRegistrations = new System.Windows.Forms.TabPage();
            this.dgvAdminRegistrations = new System.Windows.Forms.DataGridView();
            this.btnApproveRegistration = new System.Windows.Forms.Button();
            this.btnRejectRegistration = new System.Windows.Forms.Button();
            this.tabTeacherCircles = new System.Windows.Forms.TabPage();
            this.dgvTeacherCircles = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.tabCatalog.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.adminPanel.SuspendLayout();
            this.teacherPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCircles)).BeginInit();
            this.notificationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.tabMyRegistrations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrations)).BeginInit();
            this.tabAdminRegistrations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminRegistrations)).BeginInit();
            this.tabTeacherCircles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherCircles)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Controls.Add(this.tabCatalog);
            this.tabControl1.Controls.Add(this.tabMyRegistrations);
            this.tabControl1.Controls.Add(this.tabAdminRegistrations);
            this.tabControl1.Controls.Add(this.tabTeacherCircles);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 601);
            this.tabControl1.TabIndex = 0;
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabLogin.Controls.Add(this.loginPanel);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(992, 575);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Вход";
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.White;
            this.loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPanel.Controls.Add(this.lblAppTitle);
            this.loginPanel.Controls.Add(this.lblLoginTitle);
            this.loginPanel.Controls.Add(this.lblEmail);
            this.loginPanel.Controls.Add(this.txtEmail);
            this.loginPanel.Controls.Add(this.lblPassword);
            this.loginPanel.Controls.Add(this.txtPassword);
            this.loginPanel.Controls.Add(this.btnLogin);
            this.loginPanel.Location = new System.Drawing.Point(300, 150);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(400, 300);
            this.loginPanel.TabIndex = 0;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblAppTitle.Location = new System.Drawing.Point(80, 30);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(251, 26);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "КружокOnline System";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLoginTitle.Location = new System.Drawing.Point(150, 80);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(125, 20);
            this.lblLoginTitle.TabIndex = 1;
            this.lblLoginTitle.Text = "Вход в систему";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 130);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(100, 170);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(150, 220);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tabCatalog
            // 
            this.tabCatalog.Controls.Add(this.userPanel);
            this.tabCatalog.Controls.Add(this.notificationsPanel);
            this.tabCatalog.Location = new System.Drawing.Point(4, 22);
            this.tabCatalog.Name = "tabCatalog";
            this.tabCatalog.Padding = new System.Windows.Forms.Padding(3);
            this.tabCatalog.Size = new System.Drawing.Size(992, 575);
            this.tabCatalog.TabIndex = 1;
            this.tabCatalog.Text = "Каталог";
            this.tabCatalog.UseVisualStyleBackColor = true;
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.lblWelcome);
            this.userPanel.Controls.Add(this.lblRole);
            this.userPanel.Controls.Add(this.btnLogout);
            this.userPanel.Controls.Add(this.btnGoToCatalog);
            this.userPanel.Controls.Add(this.btnGoToMyRegistrations);
            this.userPanel.Controls.Add(this.btnShowNotifications);
            this.userPanel.Controls.Add(this.adminPanel);
            this.userPanel.Controls.Add(this.teacherPanel);
            this.userPanel.Controls.Add(this.lblSearch);
            this.userPanel.Controls.Add(this.txtSearch);
            this.userPanel.Controls.Add(this.lblCategory);
            this.userPanel.Controls.Add(this.cmbCategory);
            this.userPanel.Controls.Add(this.lblMinAge);
            this.userPanel.Controls.Add(this.nudMinAge);
            this.userPanel.Controls.Add(this.lblMaxAge);
            this.userPanel.Controls.Add(this.nudMaxAge);
            this.userPanel.Controls.Add(this.lblMaxPrice);
            this.userPanel.Controls.Add(this.nudMaxPrice);
            this.userPanel.Controls.Add(this.btnSearch);
            this.userPanel.Controls.Add(this.btnClearSearch);
            this.userPanel.Controls.Add(this.dgvCircles);
            this.userPanel.Controls.Add(this.btnRegisterForCircle);
            this.userPanel.Controls.Add(this.btnViewCircleDetails);
            this.userPanel.Controls.Add(this.btnViewSchedule);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPanel.Location = new System.Drawing.Point(3, 3);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(986, 569);
            this.userPanel.TabIndex = 0;
            this.userPanel.Visible = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWelcome.Location = new System.Drawing.Point(20, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(195, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Добро пожаловать, ...";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 35);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 13);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Роль:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(850, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Выход";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnGoToCatalog
            // 
            this.btnGoToCatalog.Location = new System.Drawing.Point(20, 60);
            this.btnGoToCatalog.Name = "btnGoToCatalog";
            this.btnGoToCatalog.Size = new System.Drawing.Size(120, 30);
            this.btnGoToCatalog.TabIndex = 3;
            this.btnGoToCatalog.Text = "Каталог кружков";
            this.btnGoToCatalog.UseVisualStyleBackColor = true;
            this.btnGoToCatalog.Click += new System.EventHandler(this.btnGoToCatalog_Click);
            // 
            // btnGoToMyRegistrations
            // 
            this.btnGoToMyRegistrations.Location = new System.Drawing.Point(150, 60);
            this.btnGoToMyRegistrations.Name = "btnGoToMyRegistrations";
            this.btnGoToMyRegistrations.Size = new System.Drawing.Size(120, 30);
            this.btnGoToMyRegistrations.TabIndex = 4;
            this.btnGoToMyRegistrations.Text = "Мои заявки";
            this.btnGoToMyRegistrations.UseVisualStyleBackColor = true;
            this.btnGoToMyRegistrations.Click += new System.EventHandler(this.btnGoToMyRegistrations_Click);
            // 
            // btnShowNotifications
            // 
            this.btnShowNotifications.Location = new System.Drawing.Point(280, 60);
            this.btnShowNotifications.Name = "btnShowNotifications";
            this.btnShowNotifications.Size = new System.Drawing.Size(120, 30);
            this.btnShowNotifications.TabIndex = 5;
            this.btnShowNotifications.Text = "Уведомления (0)";
            this.btnShowNotifications.UseVisualStyleBackColor = true;
            this.btnShowNotifications.Click += new System.EventHandler(this.btnShowNotifications_Click);
            // 
            // adminPanel
            // 
            this.adminPanel.Controls.Add(this.lblTotalCircles);
            this.adminPanel.Controls.Add(this.lblTotalParticipants);
            this.adminPanel.Controls.Add(this.lblTotalRegistrations);
            this.adminPanel.Controls.Add(this.lblPendingRegistrations);
            this.adminPanel.Controls.Add(this.btnAdminGoToRegistrations);
            this.adminPanel.Controls.Add(this.btnAdminGoToCircles);
            this.adminPanel.Controls.Add(this.btnGenerateReport);
            this.adminPanel.Location = new System.Drawing.Point(20, 100);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(950, 60);
            this.adminPanel.TabIndex = 8;
            this.adminPanel.Visible = false;
            // 
            // lblTotalCircles
            // 
            this.lblTotalCircles.AutoSize = true;
            this.lblTotalCircles.Location = new System.Drawing.Point(10, 10);
            this.lblTotalCircles.Name = "lblTotalCircles";
            this.lblTotalCircles.Size = new System.Drawing.Size(63, 13);
            this.lblTotalCircles.TabIndex = 0;
            this.lblTotalCircles.Text = "Кружков: 0";
            // 
            // lblTotalParticipants
            // 
            this.lblTotalParticipants.AutoSize = true;
            this.lblTotalParticipants.Location = new System.Drawing.Point(10, 30);
            this.lblTotalParticipants.Name = "lblTotalParticipants";
            this.lblTotalParticipants.Size = new System.Drawing.Size(79, 13);
            this.lblTotalParticipants.TabIndex = 1;
            this.lblTotalParticipants.Text = "Участников: 0";
            // 
            // lblTotalRegistrations
            // 
            this.lblTotalRegistrations.AutoSize = true;
            this.lblTotalRegistrations.Location = new System.Drawing.Point(120, 10);
            this.lblTotalRegistrations.Name = "lblTotalRegistrations";
            this.lblTotalRegistrations.Size = new System.Drawing.Size(56, 13);
            this.lblTotalRegistrations.TabIndex = 2;
            this.lblTotalRegistrations.Text = "Заявок: 0";
            // 
            // lblPendingRegistrations
            // 
            this.lblPendingRegistrations.AutoSize = true;
            this.lblPendingRegistrations.Location = new System.Drawing.Point(120, 30);
            this.lblPendingRegistrations.Name = "lblPendingRegistrations";
            this.lblPendingRegistrations.Size = new System.Drawing.Size(109, 13);
            this.lblPendingRegistrations.TabIndex = 3;
            this.lblPendingRegistrations.Text = "На рассмотрении: 0";
            // 
            // btnAdminGoToRegistrations
            // 
            this.btnAdminGoToRegistrations.Location = new System.Drawing.Point(250, 10);
            this.btnAdminGoToRegistrations.Name = "btnAdminGoToRegistrations";
            this.btnAdminGoToRegistrations.Size = new System.Drawing.Size(150, 30);
            this.btnAdminGoToRegistrations.TabIndex = 4;
            this.btnAdminGoToRegistrations.Text = "Управление заявками";
            this.btnAdminGoToRegistrations.UseVisualStyleBackColor = true;
            this.btnAdminGoToRegistrations.Click += new System.EventHandler(this.btnAdminGoToRegistrations_Click);
            // 
            // btnAdminGoToCircles
            // 
            this.btnAdminGoToCircles.Location = new System.Drawing.Point(410, 10);
            this.btnAdminGoToCircles.Name = "btnAdminGoToCircles";
            this.btnAdminGoToCircles.Size = new System.Drawing.Size(150, 30);
            this.btnAdminGoToCircles.TabIndex = 5;
            this.btnAdminGoToCircles.Text = "Управление кружками";
            this.btnAdminGoToCircles.UseVisualStyleBackColor = true;
            this.btnAdminGoToCircles.Click += new System.EventHandler(this.btnAdminGoToCircles_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(570, 10);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(150, 30);
            this.btnGenerateReport.TabIndex = 6;
            this.btnGenerateReport.Text = "Сформировать отчет";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // teacherPanel
            // 
            this.teacherPanel.Controls.Add(this.btnViewAttendance);
            this.teacherPanel.Controls.Add(this.btnTeacherGoToCircles);
            this.teacherPanel.Location = new System.Drawing.Point(20, 100);
            this.teacherPanel.Name = "teacherPanel";
            this.teacherPanel.Size = new System.Drawing.Size(950, 60);
            this.teacherPanel.TabIndex = 9;
            this.teacherPanel.Visible = false;
            // 
            // btnViewAttendance
            // 
            this.btnViewAttendance.Location = new System.Drawing.Point(150, 10);
            this.btnViewAttendance.Name = "btnViewAttendance";
            this.btnViewAttendance.Size = new System.Drawing.Size(150, 30);
            this.btnViewAttendance.TabIndex = 1;
            this.btnViewAttendance.Text = "Посещаемость";
            this.btnViewAttendance.UseVisualStyleBackColor = true;
            this.btnViewAttendance.Click += new System.EventHandler(this.btnViewAttendance_Click);
            // 
            // btnTeacherGoToCircles
            // 
            this.btnTeacherGoToCircles.Location = new System.Drawing.Point(10, 10);
            this.btnTeacherGoToCircles.Name = "btnTeacherGoToCircles";
            this.btnTeacherGoToCircles.Size = new System.Drawing.Size(130, 30);
            this.btnTeacherGoToCircles.TabIndex = 0;
            this.btnTeacherGoToCircles.Text = "Мои кружки";
            this.btnTeacherGoToCircles.UseVisualStyleBackColor = true;
            this.btnTeacherGoToCircles.Click += new System.EventHandler(this.btnTeacherGoToCircles_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 170);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 170);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 11;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(280, 170);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 12;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(350, 170);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(120, 21);
            this.cmbCategory.TabIndex = 13;
            // 
            // lblMinAge
            // 
            this.lblMinAge.AutoSize = true;
            this.lblMinAge.Location = new System.Drawing.Point(480, 170);
            this.lblMinAge.Name = "lblMinAge";
            this.lblMinAge.Size = new System.Drawing.Size(78, 13);
            this.lblMinAge.TabIndex = 14;
            this.lblMinAge.Text = "Мин. возраст:";
            // 
            // nudMinAge
            // 
            this.nudMinAge.Location = new System.Drawing.Point(570, 170);
            this.nudMinAge.Name = "nudMinAge";
            this.nudMinAge.Size = new System.Drawing.Size(60, 20);
            this.nudMinAge.TabIndex = 15;
            // 
            // lblMaxAge
            // 
            this.lblMaxAge.AutoSize = true;
            this.lblMaxAge.Location = new System.Drawing.Point(640, 170);
            this.lblMaxAge.Name = "lblMaxAge";
            this.lblMaxAge.Size = new System.Drawing.Size(84, 13);
            this.lblMaxAge.TabIndex = 16;
            this.lblMaxAge.Text = "Макс. возраст:";
            // 
            // nudMaxAge
            // 
            this.nudMaxAge.Location = new System.Drawing.Point(735, 170);
            this.nudMaxAge.Name = "nudMaxAge";
            this.nudMaxAge.Size = new System.Drawing.Size(60, 20);
            this.nudMaxAge.TabIndex = 17;
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Location = new System.Drawing.Point(20, 200);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(67, 13);
            this.lblMaxPrice.TabIndex = 18;
            this.lblMaxPrice.Text = "Макс. цена:";
            // 
            // nudMaxPrice
            // 
            this.nudMaxPrice.DecimalPlaces = 2;
            this.nudMaxPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxPrice.Location = new System.Drawing.Point(100, 200);
            this.nudMaxPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxPrice.Name = "nudMaxPrice";
            this.nudMaxPrice.Size = new System.Drawing.Size(100, 20);
            this.nudMaxPrice.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(210, 195);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(320, 195);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(100, 30);
            this.btnClearSearch.TabIndex = 21;
            this.btnClearSearch.Text = "Очистить";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // dgvCircles
            // 
            this.dgvCircles.AllowUserToAddRows = false;
            this.dgvCircles.AllowUserToDeleteRows = false;
            this.dgvCircles.AllowUserToResizeRows = false;
            this.dgvCircles.BackgroundColor = System.Drawing.Color.White;
            this.dgvCircles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCircles.Location = new System.Drawing.Point(20, 240);
            this.dgvCircles.MultiSelect = false;
            this.dgvCircles.Name = "dgvCircles";
            this.dgvCircles.ReadOnly = true;
            this.dgvCircles.RowHeadersVisible = false;
            this.dgvCircles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCircles.Size = new System.Drawing.Size(950, 280);
            this.dgvCircles.TabIndex = 22;
            // 
            // btnRegisterForCircle
            // 
            this.btnRegisterForCircle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegisterForCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterForCircle.ForeColor = System.Drawing.Color.White;
            this.btnRegisterForCircle.Location = new System.Drawing.Point(20, 530);
            this.btnRegisterForCircle.Name = "btnRegisterForCircle";
            this.btnRegisterForCircle.Size = new System.Drawing.Size(150, 30);
            this.btnRegisterForCircle.TabIndex = 23;
            this.btnRegisterForCircle.Text = "Записаться на кружок";
            this.btnRegisterForCircle.UseVisualStyleBackColor = false;
            this.btnRegisterForCircle.Click += new System.EventHandler(this.btnRegisterForCircle_Click);
            // 
            // btnViewCircleDetails
            // 
            this.btnViewCircleDetails.Location = new System.Drawing.Point(180, 530);
            this.btnViewCircleDetails.Name = "btnViewCircleDetails";
            this.btnViewCircleDetails.Size = new System.Drawing.Size(150, 30);
            this.btnViewCircleDetails.TabIndex = 24;
            this.btnViewCircleDetails.Text = "Просмотр деталей";
            this.btnViewCircleDetails.UseVisualStyleBackColor = true;
            this.btnViewCircleDetails.Click += new System.EventHandler(this.btnViewCircleDetails_Click);
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.Location = new System.Drawing.Point(340, 530);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(150, 30);
            this.btnViewSchedule.TabIndex = 25;
            this.btnViewSchedule.Text = "Расписание";
            this.btnViewSchedule.UseVisualStyleBackColor = true;
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // notificationsPanel
            // 
            this.notificationsPanel.BackColor = System.Drawing.Color.LightYellow;
            this.notificationsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationsPanel.Controls.Add(this.lblNotifications);
            this.notificationsPanel.Controls.Add(this.dgvNotifications);
            this.notificationsPanel.Controls.Add(this.btnMarkAsRead);
            this.notificationsPanel.Controls.Add(this.btnMarkAllAsRead);
            this.notificationsPanel.Location = new System.Drawing.Point(500, 100);
            this.notificationsPanel.Name = "notificationsPanel";
            this.notificationsPanel.Size = new System.Drawing.Size(470, 400);
            this.notificationsPanel.TabIndex = 26;
            this.notificationsPanel.Visible = false;
            // 
            // lblNotifications
            // 
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotifications.Location = new System.Drawing.Point(10, 10);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(108, 17);
            this.lblNotifications.TabIndex = 0;
            this.lblNotifications.Text = "Уведомления";
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.AllowUserToAddRows = false;
            this.dgvNotifications.AllowUserToDeleteRows = false;
            this.dgvNotifications.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotifications.Location = new System.Drawing.Point(10, 40);
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.ReadOnly = true;
            this.dgvNotifications.RowHeadersVisible = false;
            this.dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotifications.Size = new System.Drawing.Size(450, 300);
            this.dgvNotifications.TabIndex = 1;
            // 
            // btnMarkAsRead
            // 
            this.btnMarkAsRead.Location = new System.Drawing.Point(10, 350);
            this.btnMarkAsRead.Name = "btnMarkAsRead";
            this.btnMarkAsRead.Size = new System.Drawing.Size(150, 30);
            this.btnMarkAsRead.TabIndex = 2;
            this.btnMarkAsRead.Text = "Отметить как прочитанное";
            this.btnMarkAsRead.UseVisualStyleBackColor = true;
            this.btnMarkAsRead.Click += new System.EventHandler(this.btnMarkAsRead_Click);
            // 
            // btnMarkAllAsRead
            // 
            this.btnMarkAllAsRead.Location = new System.Drawing.Point(170, 350);
            this.btnMarkAllAsRead.Name = "btnMarkAllAsRead";
            this.btnMarkAllAsRead.Size = new System.Drawing.Size(150, 30);
            this.btnMarkAllAsRead.TabIndex = 3;
            this.btnMarkAllAsRead.Text = "Отметить все как прочитанные";
            this.btnMarkAllAsRead.UseVisualStyleBackColor = true;
            this.btnMarkAllAsRead.Click += new System.EventHandler(this.btnMarkAllAsRead_Click);
            // 
            // tabMyRegistrations
            // 
            this.tabMyRegistrations.Controls.Add(this.dgvRegistrations);
            this.tabMyRegistrations.Controls.Add(this.btnCancelRegistration);
            this.tabMyRegistrations.Controls.Add(this.lblMyRegistrations);
            this.tabMyRegistrations.Location = new System.Drawing.Point(4, 22);
            this.tabMyRegistrations.Name = "tabMyRegistrations";
            this.tabMyRegistrations.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyRegistrations.Size = new System.Drawing.Size(992, 575);
            this.tabMyRegistrations.TabIndex = 2;
            this.tabMyRegistrations.Text = "Мои заявки";
            this.tabMyRegistrations.UseVisualStyleBackColor = true;
            // 
            // dgvRegistrations
            // 
            this.dgvRegistrations.AllowUserToAddRows = false;
            this.dgvRegistrations.AllowUserToDeleteRows = false;
            this.dgvRegistrations.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrations.Location = new System.Drawing.Point(20, 60);
            this.dgvRegistrations.Name = "dgvRegistrations";
            this.dgvRegistrations.ReadOnly = true;
            this.dgvRegistrations.RowHeadersVisible = false;
            this.dgvRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistrations.Size = new System.Drawing.Size(950, 450);
            this.dgvRegistrations.TabIndex = 0;
            // 
            // btnCancelRegistration
            // 
            this.btnCancelRegistration.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelRegistration.ForeColor = System.Drawing.Color.White;
            this.btnCancelRegistration.Location = new System.Drawing.Point(20, 520);
            this.btnCancelRegistration.Name = "btnCancelRegistration";
            this.btnCancelRegistration.Size = new System.Drawing.Size(150, 30);
            this.btnCancelRegistration.TabIndex = 1;
            this.btnCancelRegistration.Text = "Отменить заявку";
            this.btnCancelRegistration.UseVisualStyleBackColor = false;
            this.btnCancelRegistration.Click += new System.EventHandler(this.btnCancelRegistration_Click);
            // 
            // lblMyRegistrations
            // 
            this.lblMyRegistrations.AutoSize = true;
            this.lblMyRegistrations.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMyRegistrations.Location = new System.Drawing.Point(20, 20);
            this.lblMyRegistrations.Name = "lblMyRegistrations";
            this.lblMyRegistrations.Size = new System.Drawing.Size(124, 24);
            this.lblMyRegistrations.TabIndex = 2;
            this.lblMyRegistrations.Text = "Мои заявки";
            // 
            // tabAdminRegistrations
            // 
            this.tabAdminRegistrations.Controls.Add(this.dgvAdminRegistrations);
            this.tabAdminRegistrations.Controls.Add(this.btnApproveRegistration);
            this.tabAdminRegistrations.Controls.Add(this.btnRejectRegistration);
            this.tabAdminRegistrations.Location = new System.Drawing.Point(4, 22);
            this.tabAdminRegistrations.Name = "tabAdminRegistrations";
            this.tabAdminRegistrations.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdminRegistrations.Size = new System.Drawing.Size(992, 575);
            this.tabAdminRegistrations.TabIndex = 3;
            this.tabAdminRegistrations.Text = "Управление заявками";
            this.tabAdminRegistrations.UseVisualStyleBackColor = true;
            // 
            // dgvAdminRegistrations
            // 
            this.dgvAdminRegistrations.AllowUserToAddRows = false;
            this.dgvAdminRegistrations.AllowUserToDeleteRows = false;
            this.dgvAdminRegistrations.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdminRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminRegistrations.Location = new System.Drawing.Point(20, 20);
            this.dgvAdminRegistrations.Name = "dgvAdminRegistrations";
            this.dgvAdminRegistrations.ReadOnly = true;
            this.dgvAdminRegistrations.RowHeadersVisible = false;
            this.dgvAdminRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdminRegistrations.Size = new System.Drawing.Size(950, 450);
            this.dgvAdminRegistrations.TabIndex = 0;
            // 
            // btnApproveRegistration
            // 
            this.btnApproveRegistration.BackColor = System.Drawing.Color.LightGreen;
            this.btnApproveRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproveRegistration.ForeColor = System.Drawing.Color.Black;
            this.btnApproveRegistration.Location = new System.Drawing.Point(20, 480);
            this.btnApproveRegistration.Name = "btnApproveRegistration";
            this.btnApproveRegistration.Size = new System.Drawing.Size(150, 30);
            this.btnApproveRegistration.TabIndex = 1;
            this.btnApproveRegistration.Text = "Подтвердить заявку";
            this.btnApproveRegistration.UseVisualStyleBackColor = false;
            this.btnApproveRegistration.Click += new System.EventHandler(this.btnApproveRegistration_Click);
            // 
            // btnRejectRegistration
            // 
            this.btnRejectRegistration.BackColor = System.Drawing.Color.LightCoral;
            this.btnRejectRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRejectRegistration.ForeColor = System.Drawing.Color.White;
            this.btnRejectRegistration.Location = new System.Drawing.Point(180, 480);
            this.btnRejectRegistration.Name = "btnRejectRegistration";
            this.btnRejectRegistration.Size = new System.Drawing.Size(150, 30);
            this.btnRejectRegistration.TabIndex = 2;
            this.btnRejectRegistration.Text = "Отклонить заявку";
            this.btnRejectRegistration.UseVisualStyleBackColor = false;
            // 
            // tabTeacherCircles
            // 
            this.tabTeacherCircles.Controls.Add(this.dgvTeacherCircles);
            this.tabTeacherCircles.Location = new System.Drawing.Point(4, 22);
            this.tabTeacherCircles.Name = "tabTeacherCircles";
            this.tabTeacherCircles.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeacherCircles.Size = new System.Drawing.Size(992, 575);
            this.tabTeacherCircles.TabIndex = 4;
            this.tabTeacherCircles.Text = "Кружки преподавателя";
            this.tabTeacherCircles.UseVisualStyleBackColor = true;
            // 
            // dgvTeacherCircles
            // 
            this.dgvTeacherCircles.AllowUserToAddRows = false;
            this.dgvTeacherCircles.AllowUserToDeleteRows = false;
            this.dgvTeacherCircles.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeacherCircles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacherCircles.Location = new System.Drawing.Point(20, 19);
            this.dgvTeacherCircles.Name = "dgvTeacherCircles";
            this.dgvTeacherCircles.ReadOnly = true;
            this.dgvTeacherCircles.RowHeadersVisible = false;
            this.dgvTeacherCircles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeacherCircles.Size = new System.Drawing.Size(950, 450);
            this.dgvTeacherCircles.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 601);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1016, 639);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "КружокOnline - Система записи на кружки и секции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.tabCatalog.ResumeLayout(false);
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.adminPanel.ResumeLayout(false);
            this.adminPanel.PerformLayout();
            this.teacherPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCircles)).EndInit();
            this.notificationsPanel.ResumeLayout(false);
            this.notificationsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.tabMyRegistrations.ResumeLayout(false);
            this.tabMyRegistrations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrations)).EndInit();
            this.tabAdminRegistrations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminRegistrations)).EndInit();
            this.tabTeacherCircles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherCircles)).EndInit();
            this.ResumeLayout(false);

        }

        // Объявление всех контролов
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabCatalog;
        private System.Windows.Forms.TabPage tabMyRegistrations;
        private System.Windows.Forms.TabPage tabAdminRegistrations;
        private System.Windows.Forms.TabPage tabTeacherCircles;

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Panel adminPanel;
        private System.Windows.Forms.Panel teacherPanel;
        private System.Windows.Forms.Panel notificationsPanel;

        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnGoToCatalog;
        private System.Windows.Forms.Button btnGoToMyRegistrations;
        private System.Windows.Forms.Button btnShowNotifications;

        private System.Windows.Forms.Label lblTotalCircles;
        private System.Windows.Forms.Label lblTotalParticipants;
        private System.Windows.Forms.Label lblTotalRegistrations;
        private System.Windows.Forms.Label lblPendingRegistrations;
        private System.Windows.Forms.Button btnAdminGoToRegistrations;
        private System.Windows.Forms.Button btnAdminGoToCircles;
        private System.Windows.Forms.Button btnGenerateReport;

        private System.Windows.Forms.Button btnViewAttendance;
        private System.Windows.Forms.Button btnTeacherGoToCircles;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblMinAge;
        private System.Windows.Forms.NumericUpDown nudMinAge;
        private System.Windows.Forms.Label lblMaxAge;
        private System.Windows.Forms.NumericUpDown nudMaxAge;
        private System.Windows.Forms.Label lblMaxPrice;
        private System.Windows.Forms.NumericUpDown nudMaxPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.DataGridView dgvCircles;
        private System.Windows.Forms.Button btnRegisterForCircle;
        private System.Windows.Forms.Button btnViewCircleDetails;
        private System.Windows.Forms.Button btnViewSchedule;

        private System.Windows.Forms.DataGridView dgvRegistrations;
        private System.Windows.Forms.Button btnCancelRegistration;
        private System.Windows.Forms.Label lblMyRegistrations;

        private System.Windows.Forms.DataGridView dgvAdminRegistrations;
        private System.Windows.Forms.Button btnApproveRegistration;
        private System.Windows.Forms.Button btnRejectRegistration;

        private System.Windows.Forms.DataGridView dgvTeacherCircles;

        private System.Windows.Forms.DataGridView dgvNotifications;
        private System.Windows.Forms.Button btnMarkAsRead;
        private System.Windows.Forms.Button btnMarkAllAsRead;
        private System.Windows.Forms.Label lblNotifications;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}