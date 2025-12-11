namespace CircleRegistrationSystem.Forms
{
    partial class CircleEditForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblAgeMin = new System.Windows.Forms.Label();
            this.nudAgeMin = new System.Windows.Forms.NumericUpDown();
            this.lblAgeMax = new System.Windows.Forms.Label();
            this.nudAgeMax = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblMaxParticipants = new System.Windows.Forms.Label();
            this.nudMaxParticipants = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxParticipants)).BeginInit();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 20);
            this.txtName.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 50);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Категория:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(120, 50);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 3;

            // lblAgeMin
            this.lblAgeMin.AutoSize = true;
            this.lblAgeMin.Location = new System.Drawing.Point(20, 80);
            this.lblAgeMin.Name = "lblAgeMin";
            this.lblAgeMin.Size = new System.Drawing.Size(90, 13);
            this.lblAgeMin.TabIndex = 4;
            this.lblAgeMin.Text = "Мин. возраст:";

            // nudAgeMin
            this.nudAgeMin.Location = new System.Drawing.Point(120, 80);
            this.nudAgeMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAgeMin.Name = "nudAgeMin";
            this.nudAgeMin.Size = new System.Drawing.Size(60, 20);
            this.nudAgeMin.TabIndex = 5;
            this.nudAgeMin.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudAgeMin.ValueChanged += new System.EventHandler(this.nudAgeMin_ValueChanged);

            // lblAgeMax
            this.lblAgeMax.AutoSize = true;
            this.lblAgeMax.Location = new System.Drawing.Point(200, 80);
            this.lblAgeMax.Name = "lblAgeMax";
            this.lblAgeMax.Size = new System.Drawing.Size(96, 13);
            this.lblAgeMax.TabIndex = 6;
            this.lblAgeMax.Text = "Макс. возраст:";

            // nudAgeMax
            this.nudAgeMax.Location = new System.Drawing.Point(300, 80);
            this.nudAgeMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAgeMax.Name = "nudAgeMax";
            this.nudAgeMax.Size = new System.Drawing.Size(60, 20);
            this.nudAgeMax.TabIndex = 7;
            this.nudAgeMax.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 110);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Цена:";

            // nudPrice
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(120, 110);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(100, 20);
            this.nudPrice.TabIndex = 9;

            // lblMaxParticipants
            this.lblMaxParticipants.AutoSize = true;
            this.lblMaxParticipants.Location = new System.Drawing.Point(20, 140);
            this.lblMaxParticipants.Name = "lblMaxParticipants";
            this.lblMaxParticipants.Size = new System.Drawing.Size(94, 13);
            this.lblMaxParticipants.TabIndex = 10;
            this.lblMaxParticipants.Text = "Макс. участников:";

            // nudMaxParticipants
            this.nudMaxParticipants.Location = new System.Drawing.Point(120, 140);
            this.nudMaxParticipants.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxParticipants.Name = "nudMaxParticipants";
            this.nudMaxParticipants.Size = new System.Drawing.Size(100, 20);
            this.nudMaxParticipants.TabIndex = 11;
            this.nudMaxParticipants.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 170);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Описание:";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 170);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(300, 100);
            this.txtDescription.TabIndex = 13;

            // lblTeacher
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(20, 280);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(89, 13);
            this.lblTeacher.TabIndex = 14;
            this.lblTeacher.Text = "Преподаватель:";

            // cmbTeacher
            this.cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(120, 280);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(200, 21);
            this.cmbTeacher.TabIndex = 15;

            // btnAddTeacher
            this.btnAddTeacher.Location = new System.Drawing.Point(330, 280);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(90, 23);
            this.btnAddTeacher.TabIndex = 16;
            this.btnAddTeacher.Text = "Добавить...";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(120, 310);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(68, 17);
            this.chkIsActive.TabIndex = 17;
            this.chkIsActive.Text = "Активен";
            this.chkIsActive.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            //this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(230, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // CircleEditForm
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnAddTeacher);
            this.Controls.Add(this.cmbTeacher);
            this.Controls.Add(this.lblTeacher);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.nudMaxParticipants);
            this.Controls.Add(this.lblMaxParticipants);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.nudAgeMax);
            this.Controls.Add(this.lblAgeMax);
            this.Controls.Add(this.nudAgeMin);
            this.Controls.Add(this.lblAgeMin);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CircleEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование кружка";
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblAgeMin;
        private System.Windows.Forms.NumericUpDown nudAgeMin;
        private System.Windows.Forms.Label lblAgeMax;
        private System.Windows.Forms.NumericUpDown nudAgeMax;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblMaxParticipants;
        private System.Windows.Forms.NumericUpDown nudMaxParticipants;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddTeacher;
    }
}