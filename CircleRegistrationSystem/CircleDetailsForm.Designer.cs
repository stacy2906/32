namespace CircleRegistrationSystem.Forms
{
    partial class CircleDetailsForm
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
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.lblAgeTitle = new System.Windows.Forms.Label();
            this.lblPriceTitle = new System.Windows.Forms.Label();
            this.lblParticipantsTitle = new System.Windows.Forms.Label();
            this.lblTeacherTitle = new System.Windows.Forms.Label();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.lblScheduleTitle = new System.Windows.Forms.Label();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.lblTotalRegistrationsTitle = new System.Windows.Forms.Label();
            this.lblApprovedRegistrationsTitle = new System.Windows.Forms.Label();
            this.lblPendingRegistrationsTitle = new System.Windows.Forms.Label();
            this.lblRejectedRegistrationsTitle = new System.Windows.Forms.Label();
            this.lblFillPercentageTitle = new System.Windows.Forms.Label();
            this.gbMainInfo = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAgeRange = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbSchedule = new System.Windows.Forms.GroupBox();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.gbStatistics = new System.Windows.Forms.GroupBox();
            this.lblFillPercentage = new System.Windows.Forms.Label();
            this.lblRejectedRegistrations = new System.Windows.Forms.Label();
            this.lblPendingRegistrations = new System.Windows.Forms.Label();
            this.lblApprovedRegistrations = new System.Windows.Forms.Label();
            this.lblTotalRegistrations = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbMainInfo.SuspendLayout();
            this.gbSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.gbStatistics.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNameTitle.Location = new System.Drawing.Point(20, 30);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(66, 15);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "Название:";
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoryTitle.Location = new System.Drawing.Point(20, 60);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(70, 15);
            this.lblCategoryTitle.TabIndex = 1;
            this.lblCategoryTitle.Text = "Категория:";
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.AutoSize = true;
            this.lblAgeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAgeTitle.Location = new System.Drawing.Point(20, 90);
            this.lblAgeTitle.Name = "lblAgeTitle";
            this.lblAgeTitle.Size = new System.Drawing.Size(101, 15);
            this.lblAgeTitle.TabIndex = 2;
            this.lblAgeTitle.Text = "Возрастной ряд:";
            // 
            // lblPriceTitle
            // 
            this.lblPriceTitle.AutoSize = true;
            this.lblPriceTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPriceTitle.Location = new System.Drawing.Point(20, 120);
            this.lblPriceTitle.Name = "lblPriceTitle";
            this.lblPriceTitle.Size = new System.Drawing.Size(40, 15);
            this.lblPriceTitle.TabIndex = 3;
            this.lblPriceTitle.Text = "Цена:";
            // 
            // lblParticipantsTitle
            // 
            this.lblParticipantsTitle.AutoSize = true;
            this.lblParticipantsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblParticipantsTitle.Location = new System.Drawing.Point(20, 150);
            this.lblParticipantsTitle.Name = "lblParticipantsTitle";
            this.lblParticipantsTitle.Size = new System.Drawing.Size(71, 15);
            this.lblParticipantsTitle.TabIndex = 4;
            this.lblParticipantsTitle.Text = "Участники:";
            // 
            // lblTeacherTitle
            // 
            this.lblTeacherTitle.AutoSize = true;
            this.lblTeacherTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTeacherTitle.Location = new System.Drawing.Point(20, 180);
            this.lblTeacherTitle.Name = "lblTeacherTitle";
            this.lblTeacherTitle.Size = new System.Drawing.Size(99, 15);
            this.lblTeacherTitle.TabIndex = 5;
            this.lblTeacherTitle.Text = "Преподаватель:";
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(20, 210);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(68, 15);
            this.lblDescriptionTitle.TabIndex = 6;
            this.lblDescriptionTitle.Text = "Описание:";
            // 
            // lblScheduleTitle
            // 
            this.lblScheduleTitle.AutoSize = true;
            this.lblScheduleTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScheduleTitle.Location = new System.Drawing.Point(10, 15);
            this.lblScheduleTitle.Name = "lblScheduleTitle";
            this.lblScheduleTitle.Size = new System.Drawing.Size(92, 19);
            this.lblScheduleTitle.TabIndex = 0;
            this.lblScheduleTitle.Text = "Расписание";
            // 
            // lblStatsTitle
            // 
            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatsTitle.Location = new System.Drawing.Point(10, 15);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(85, 19);
            this.lblStatsTitle.TabIndex = 0;
            this.lblStatsTitle.Text = "Статистика";
            // 
            // lblTotalRegistrationsTitle
            // 
            this.lblTotalRegistrationsTitle.AutoSize = true;
            this.lblTotalRegistrationsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRegistrationsTitle.Location = new System.Drawing.Point(20, 45);
            this.lblTotalRegistrationsTitle.Name = "lblTotalRegistrationsTitle";
            this.lblTotalRegistrationsTitle.Size = new System.Drawing.Size(93, 15);
            this.lblTotalRegistrationsTitle.TabIndex = 1;
            this.lblTotalRegistrationsTitle.Text = "Всего заявок:";
            // 
            // lblApprovedRegistrationsTitle
            // 
            this.lblApprovedRegistrationsTitle.AutoSize = true;
            this.lblApprovedRegistrationsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApprovedRegistrationsTitle.Location = new System.Drawing.Point(20, 75);
            this.lblApprovedRegistrationsTitle.Name = "lblApprovedRegistrationsTitle";
            this.lblApprovedRegistrationsTitle.Size = new System.Drawing.Size(109, 15);
            this.lblApprovedRegistrationsTitle.TabIndex = 2;
            this.lblApprovedRegistrationsTitle.Text = "Подтверждено:";
            // 
            // lblPendingRegistrationsTitle
            // 
            this.lblPendingRegistrationsTitle.AutoSize = true;
            this.lblPendingRegistrationsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPendingRegistrationsTitle.Location = new System.Drawing.Point(20, 105);
            this.lblPendingRegistrationsTitle.Name = "lblPendingRegistrationsTitle";
            this.lblPendingRegistrationsTitle.Size = new System.Drawing.Size(123, 15);
            this.lblPendingRegistrationsTitle.TabIndex = 3;
            this.lblPendingRegistrationsTitle.Text = "На рассмотрении:";
            // 
            // lblRejectedRegistrationsTitle
            // 
            this.lblRejectedRegistrationsTitle.AutoSize = true;
            this.lblRejectedRegistrationsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRejectedRegistrationsTitle.Location = new System.Drawing.Point(20, 135);
            this.lblRejectedRegistrationsTitle.Name = "lblRejectedRegistrationsTitle";
            this.lblRejectedRegistrationsTitle.Size = new System.Drawing.Size(82, 15);
            this.lblRejectedRegistrationsTitle.TabIndex = 4;
            this.lblRejectedRegistrationsTitle.Text = "Отклонено:";
            // 
            // lblFillPercentageTitle
            // 
            this.lblFillPercentageTitle.AutoSize = true;
            this.lblFillPercentageTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFillPercentageTitle.Location = new System.Drawing.Point(20, 165);
            this.lblFillPercentageTitle.Name = "lblFillPercentageTitle";
            this.lblFillPercentageTitle.Size = new System.Drawing.Size(109, 15);
            this.lblFillPercentageTitle.TabIndex = 5;
            this.lblFillPercentageTitle.Text = "Заполняемость:";
            // 
            // gbMainInfo
            // 
            this.gbMainInfo.Controls.Add(this.txtDescription);
            this.gbMainInfo.Controls.Add(this.lblDescriptionTitle);
            this.gbMainInfo.Controls.Add(this.lblTeacher);
            this.gbMainInfo.Controls.Add(this.lblTeacherTitle);
            this.gbMainInfo.Controls.Add(this.lblParticipants);
            this.gbMainInfo.Controls.Add(this.lblParticipantsTitle);
            this.gbMainInfo.Controls.Add(this.lblPrice);
            this.gbMainInfo.Controls.Add(this.lblPriceTitle);
            this.gbMainInfo.Controls.Add(this.lblAgeRange);
            this.gbMainInfo.Controls.Add(this.lblAgeTitle);
            this.gbMainInfo.Controls.Add(this.lblCategory);
            this.gbMainInfo.Controls.Add(this.lblCategoryTitle);
            this.gbMainInfo.Controls.Add(this.lblName);
            this.gbMainInfo.Controls.Add(this.lblNameTitle);
            this.gbMainInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbMainInfo.Location = new System.Drawing.Point(20, 70);
            this.gbMainInfo.Name = "gbMainInfo";
            this.gbMainInfo.Size = new System.Drawing.Size(450, 320);
            this.gbMainInfo.TabIndex = 0;
            this.gbMainInfo.TabStop = false;
            this.gbMainInfo.Text = "Основная информация";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(150, 210);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(280, 90);
            this.txtDescription.TabIndex = 13;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTeacher.Location = new System.Drawing.Point(150, 180);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(12, 15);
            this.lblTeacher.TabIndex = 12;
            this.lblTeacher.Text = "-";
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblParticipants.Location = new System.Drawing.Point(150, 150);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(12, 15);
            this.lblParticipants.TabIndex = 11;
            this.lblParticipants.Text = "-";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrice.Location = new System.Drawing.Point(150, 120);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(12, 15);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "-";
            // 
            // lblAgeRange
            // 
            this.lblAgeRange.AutoSize = true;
            this.lblAgeRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAgeRange.Location = new System.Drawing.Point(150, 90);
            this.lblAgeRange.Name = "lblAgeRange";
            this.lblAgeRange.Size = new System.Drawing.Size(12, 15);
            this.lblAgeRange.TabIndex = 9;
            this.lblAgeRange.Text = "-";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(150, 60);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(12, 15);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "-";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(150, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(12, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "-";
            // 
            // gbSchedule
            // 
            this.gbSchedule.Controls.Add(this.dgvSchedule);
            this.gbSchedule.Controls.Add(this.lblScheduleTitle);
            this.gbSchedule.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbSchedule.Location = new System.Drawing.Point(490, 70);
            this.gbSchedule.Name = "gbSchedule";
            this.gbSchedule.Size = new System.Drawing.Size(350, 200);
            this.gbSchedule.TabIndex = 1;
            this.gbSchedule.TabStop = false;
            this.gbSchedule.Text = "Расписание занятий";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(15, 40);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(320, 145);
            this.dgvSchedule.TabIndex = 1;
            // 
            // gbStatistics
            // 
            this.gbStatistics.Controls.Add(this.lblFillPercentage);
            this.gbStatistics.Controls.Add(this.lblRejectedRegistrations);
            this.gbStatistics.Controls.Add(this.lblFillPercentageTitle);
            this.gbStatistics.Controls.Add(this.lblPendingRegistrations);
            this.gbStatistics.Controls.Add(this.lblRejectedRegistrationsTitle);
            this.gbStatistics.Controls.Add(this.lblApprovedRegistrations);
            this.gbStatistics.Controls.Add(this.lblPendingRegistrationsTitle);
            this.gbStatistics.Controls.Add(this.lblTotalRegistrations);
            this.gbStatistics.Controls.Add(this.lblApprovedRegistrationsTitle);
            this.gbStatistics.Controls.Add(this.lblStatsTitle);
            this.gbStatistics.Controls.Add(this.lblTotalRegistrationsTitle);
            this.gbStatistics.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbStatistics.Location = new System.Drawing.Point(490, 280);
            this.gbStatistics.Name = "gbStatistics";
            this.gbStatistics.Size = new System.Drawing.Size(350, 200);
            this.gbStatistics.TabIndex = 2;
            this.gbStatistics.TabStop = false;
            this.gbStatistics.Text = "Статистика кружка";
            // 
            // lblFillPercentage
            // 
            this.lblFillPercentage.AutoSize = true;
            this.lblFillPercentage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFillPercentage.Location = new System.Drawing.Point(150, 165);
            this.lblFillPercentage.Name = "lblFillPercentage";
            this.lblFillPercentage.Size = new System.Drawing.Size(12, 15);
            this.lblFillPercentage.TabIndex = 10;
            this.lblFillPercentage.Text = "-";
            // 
            // lblRejectedRegistrations
            // 
            this.lblRejectedRegistrations.AutoSize = true;
            this.lblRejectedRegistrations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRejectedRegistrations.Location = new System.Drawing.Point(150, 135);
            this.lblRejectedRegistrations.Name = "lblRejectedRegistrations";
            this.lblRejectedRegistrations.Size = new System.Drawing.Size(12, 15);
            this.lblRejectedRegistrations.TabIndex = 9;
            this.lblRejectedRegistrations.Text = "-";
            // 
            // lblPendingRegistrations
            // 
            this.lblPendingRegistrations.AutoSize = true;
            this.lblPendingRegistrations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPendingRegistrations.Location = new System.Drawing.Point(150, 105);
            this.lblPendingRegistrations.Name = "lblPendingRegistrations";
            this.lblPendingRegistrations.Size = new System.Drawing.Size(12, 15);
            this.lblPendingRegistrations.TabIndex = 8;
            this.lblPendingRegistrations.Text = "-";
            // 
            // lblApprovedRegistrations
            // 
            this.lblApprovedRegistrations.AutoSize = true;
            this.lblApprovedRegistrations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblApprovedRegistrations.Location = new System.Drawing.Point(150, 75);
            this.lblApprovedRegistrations.Name = "lblApprovedRegistrations";
            this.lblApprovedRegistrations.Size = new System.Drawing.Size(12, 15);
            this.lblApprovedRegistrations.TabIndex = 7;
            this.lblApprovedRegistrations.Text = "-";
            // 
            // lblTotalRegistrations
            // 
            this.lblTotalRegistrations.AutoSize = true;
            this.lblTotalRegistrations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistrations.Location = new System.Drawing.Point(150, 45);
            this.lblTotalRegistrations.Name = "lblTotalRegistrations";
            this.lblTotalRegistrations.Size = new System.Drawing.Size(12, 15);
            this.lblTotalRegistrations.TabIndex = 6;
            this.lblTotalRegistrations.Text = "-";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(860, 50);
            this.panelHeader.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(820, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 13);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(155, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Детали кружка";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(570, 500);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "🖨 Печать";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(710, 500);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 35);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "📤 Экспорт";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // CircleDetailsForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 550);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gbStatistics);
            this.Controls.Add(this.gbSchedule);
            this.Controls.Add(this.gbMainInfo);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CircleDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Детали кружка";
            this.gbMainInfo.ResumeLayout(false);
            this.gbMainInfo.PerformLayout();
            this.gbSchedule.ResumeLayout(false);
            this.gbSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.gbStatistics.ResumeLayout(false);
            this.gbStatistics.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.Label lblAgeTitle;
        private System.Windows.Forms.Label lblPriceTitle;
        private System.Windows.Forms.Label lblParticipantsTitle;
        private System.Windows.Forms.Label lblTeacherTitle;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.Label lblScheduleTitle;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblTotalRegistrationsTitle;
        private System.Windows.Forms.Label lblApprovedRegistrationsTitle;
        private System.Windows.Forms.Label lblPendingRegistrationsTitle;
        private System.Windows.Forms.Label lblRejectedRegistrationsTitle;
        private System.Windows.Forms.Label lblFillPercentageTitle;
        private System.Windows.Forms.GroupBox gbMainInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAgeRange;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbSchedule;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.GroupBox gbStatistics;
        private System.Windows.Forms.Label lblFillPercentage;
        private System.Windows.Forms.Label lblRejectedRegistrations;
        private System.Windows.Forms.Label lblPendingRegistrations;
        private System.Windows.Forms.Label lblApprovedRegistrations;
        private System.Windows.Forms.Label lblTotalRegistrations;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;



    }
}