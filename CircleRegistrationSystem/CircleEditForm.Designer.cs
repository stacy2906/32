namespace CircleRegistrationSystem.Forms
{
    partial class CircleEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown nudAgeMin;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.NumericUpDown nudAgeMax;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblMaxParticipants;
        private System.Windows.Forms.NumericUpDown nudMaxParticipants;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblAge = new System.Windows.Forms.Label();
            this.nudAgeMin = new System.Windows.Forms.NumericUpDown();
            this.lblDash = new System.Windows.Forms.Label();
            this.nudAgeMax = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblMaxParticipants = new System.Windows.Forms.Label();
            this.nudMaxParticipants = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxParticipants)).BeginInit();
            this.SuspendLayout();

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtName.Location = new System.Drawing.Point(150, 30);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 24);
            this.txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(30, 70);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(85, 18);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(150, 70);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 26);
            this.cmbCategory.TabIndex = 3;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAge.Location = new System.Drawing.Point(30, 110);
            this.lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(73, 18);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "Возраст:";
            // 
            // nudAgeMin
            // 
            this.nudAgeMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudAgeMin.Location = new System.Drawing.Point(150, 110);
            this.nudAgeMin.Margin = new System.Windows.Forms.Padding(4);
            this.nudAgeMin.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAgeMin.Name = "nudAgeMin";
            this.nudAgeMin.Size = new System.Drawing.Size(60, 24);
            this.nudAgeMin.TabIndex = 5;
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDash.Location = new System.Drawing.Point(220, 110);
            this.lblDash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(14, 18);
            this.lblDash.TabIndex = 6;
            this.lblDash.Text = "-";
            // 
            // nudAgeMax
            // 
            this.nudAgeMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudAgeMax.Location = new System.Drawing.Point(240, 110);
            this.nudAgeMax.Margin = new System.Windows.Forms.Padding(4);
            this.nudAgeMax.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAgeMax.Name = "nudAgeMax";
            this.nudAgeMax.Size = new System.Drawing.Size(60, 24);
            this.nudAgeMax.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(30, 150);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(113, 18);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Цена (руб.):";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudPrice.Location = new System.Drawing.Point(150, 150);
            this.nudPrice.Margin = new System.Windows.Forms.Padding(4);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(100, 24);
            this.nudPrice.TabIndex = 9;
            // 
            // lblMaxParticipants
            // 
            this.lblMaxParticipants.AutoSize = true;
            this.lblMaxParticipants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxParticipants.Location = new System.Drawing.Point(30, 190);
            this.lblMaxParticipants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxParticipants.Name = "lblMaxParticipants";
            this.lblMaxParticipants.Size = new System.Drawing.Size(97, 18);
            this.lblMaxParticipants.TabIndex = 10;
            this.lblMaxParticipants.Text = "Макс. мест:";
            // 
            // nudMaxParticipants
            // 
            this.nudMaxParticipants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudMaxParticipants.Location = new System.Drawing.Point(150, 190);
            this.nudMaxParticipants.Margin = new System.Windows.Forms.Padding(4);
            this.nudMaxParticipants.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxParticipants.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxParticipants.Name = "nudMaxParticipants";
            this.nudMaxParticipants.Size = new System.Drawing.Size(100, 24);
            this.nudMaxParticipants.TabIndex = 11;
            this.nudMaxParticipants.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(30, 230);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 18);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDescription.Location = new System.Drawing.Point(150, 230);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.TabIndex = 13;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTeacher.Location = new System.Drawing.Point(30, 330);
            this.lblTeacher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(110, 18);
            this.lblTeacher.TabIndex = 14;
            this.lblTeacher.Text = "Преподаватель:";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(150, 330);
            this.cmbTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(200, 26);
            this.cmbTeacher.TabIndex = 15;
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddTeacher.Location = new System.Drawing.Point(360, 330);
            this.btnAddTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(40, 28);
            this.btnAddTeacher.TabIndex = 16;
            this.btnAddTeacher.Text = "+";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblIsActive.Location = new System.Drawing.Point(30, 370);
            this.lblIsActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(75, 18);
            this.lblIsActive.TabIndex = 17;
            this.lblIsActive.Text = "Активен:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkIsActive.Location = new System.Drawing.Point(150, 370);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(18, 17);
            this.chkIsActive.TabIndex = 18;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 420);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(280, 420);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // CircleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.lblIsActive);
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
            this.Controls.Add(this.lblDash);
            this.Controls.Add(this.nudAgeMin);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}