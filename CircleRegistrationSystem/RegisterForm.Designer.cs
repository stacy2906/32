namespace CircleRegistrationSystem.Forms
{
    partial class RegisterForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblParentName = new System.Windows.Forms.Label();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.txtSpecialization = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(357, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Регистрация нового пользователя";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(50, 70);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(37, 13);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "ФИО:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(150, 70);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(50, 160);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPassword.TabIndex = 7;
            this.lblConfirmPassword.Text = "Подтверждение:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(150, 160);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(250, 20);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(50, 190);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 13);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(150, 190);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(50, 220);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 13);
            this.lblRole.TabIndex = 13;
            this.lblRole.Text = "Роль:";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(150, 220);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(200, 21);
            this.cmbRole.TabIndex = 6;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(50, 250);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(89, 13);
            this.lblDateOfBirth.TabIndex = 15;
            this.lblDateOfBirth.Text = "Дата рождения:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Checked = false;
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(150, 250);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.ShowCheckBox = true;
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 20);
            this.dtpDateOfBirth.TabIndex = 7;
            this.dtpDateOfBirth.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lblParentName
            // 
            this.lblParentName.AutoSize = true;
            this.lblParentName.Location = new System.Drawing.Point(50, 280);
            this.lblParentName.Name = "lblParentName";
            this.lblParentName.Size = new System.Drawing.Size(87, 13);
            this.lblParentName.TabIndex = 17;
            this.lblParentName.Text = "ФИО родителя:";
            this.lblParentName.Visible = false;
            // 
            // txtParentName
            // 
            this.txtParentName.Location = new System.Drawing.Point(150, 280);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.Size = new System.Drawing.Size(300, 20);
            this.txtParentName.TabIndex = 8;
            this.txtParentName.Visible = false;
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Location = new System.Drawing.Point(50, 280);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(89, 13);
            this.lblSpecialization.TabIndex = 19;
            this.lblSpecialization.Text = "Специализация:";
            this.lblSpecialization.Visible = false;
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Location = new System.Drawing.Point(150, 280);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(300, 20);
            this.txtSpecialization.TabIndex = 9;
            this.txtSpecialization.Visible = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(150, 320);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 30);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Зарегистрировать";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(410, 130);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(40, 23);
            this.btnGeneratePassword.TabIndex = 9;
            this.btnGeneratePassword.Text = "Gen";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            // 
            // RegisterForm
            // 
            this.ClientSize = new System.Drawing.Size(598, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.txtParentName);
            this.Controls.Add(this.lblParentName);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        public System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblParentName;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGeneratePassword;
    }
}