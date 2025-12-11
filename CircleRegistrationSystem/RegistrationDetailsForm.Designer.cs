namespace CircleRegistrationSystem.Forms
{
    partial class RegistrationDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox gbParticipant;
        private System.Windows.Forms.Label lblParticipantName;
        private System.Windows.Forms.Label lblParticipantEmail;
        private System.Windows.Forms.Label lblParticipantRole;
        private System.Windows.Forms.GroupBox gbCircle;
        private System.Windows.Forms.Label lblCircleName;
        private System.Windows.Forms.Label lblCircleCategory;
        private System.Windows.Forms.Label lblCircleAgeRange;
        private System.Windows.Forms.Label lblCirclePrice;
        private System.Windows.Forms.GroupBox gbRegistration;
        private System.Windows.Forms.Label lblRegistrationId;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblApprovalDate;
        private System.Windows.Forms.Label lblRejectionReason;
        private System.Windows.Forms.Label lblAttendanceStatus;
        private System.Windows.Forms.GroupBox gbAttendance;
        private System.Windows.Forms.Label lblAttendanceHistory;
        private System.Windows.Forms.TextBox txtAttendanceHistory;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Button btnClose;

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
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbAttendance = new System.Windows.Forms.GroupBox();
            this.txtAttendanceHistory = new System.Windows.Forms.TextBox();
            this.lblAttendanceHistory = new System.Windows.Forms.Label();
            this.gbRegistration = new System.Windows.Forms.GroupBox();
            this.lblRejectionReason = new System.Windows.Forms.Label();
            this.lblAttendanceStatus = new System.Windows.Forms.Label();
            this.lblApprovalDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblRegistrationId = new System.Windows.Forms.Label();
            this.gbCircle = new System.Windows.Forms.GroupBox();
            this.lblCirclePrice = new System.Windows.Forms.Label();
            this.lblCircleAgeRange = new System.Windows.Forms.Label();
            this.lblCircleCategory = new System.Windows.Forms.Label();
            this.lblCircleName = new System.Windows.Forms.Label();
            this.gbParticipant = new System.Windows.Forms.GroupBox();
            this.lblParticipantRole = new System.Windows.Forms.Label();
            this.lblParticipantEmail = new System.Windows.Forms.Label();
            this.lblParticipantName = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMarkAttendance = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.gbAttendance.SuspendLayout();
            this.gbRegistration.SuspendLayout();
            this.gbCircle.SuspendLayout();
            this.gbParticipant.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.gbAttendance);
            this.panelMain.Controls.Add(this.gbRegistration);
            this.panelMain.Controls.Add(this.gbCircle);
            this.panelMain.Controls.Add(this.gbParticipant);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelMain.Size = new System.Drawing.Size(531, 325);
            this.panelMain.TabIndex = 0;
            // 
            // gbAttendance
            // 
            this.gbAttendance.Controls.Add(this.txtAttendanceHistory);
            this.gbAttendance.Controls.Add(this.lblAttendanceHistory);
            this.gbAttendance.Location = new System.Drawing.Point(8, 366);
            this.gbAttendance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbAttendance.Name = "gbAttendance";
            this.gbAttendance.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbAttendance.Size = new System.Drawing.Size(420, 122);
            this.gbAttendance.TabIndex = 3;
            this.gbAttendance.TabStop = false;
            this.gbAttendance.Text = "Посещаемость";
            // 
            // txtAttendanceHistory
            // 
            this.txtAttendanceHistory.Location = new System.Drawing.Point(8, 32);
            this.txtAttendanceHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAttendanceHistory.Multiline = true;
            this.txtAttendanceHistory.Name = "txtAttendanceHistory";
            this.txtAttendanceHistory.ReadOnly = true;
            this.txtAttendanceHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAttendanceHistory.Size = new System.Drawing.Size(406, 82);
            this.txtAttendanceHistory.TabIndex = 1;
            // 
            // lblAttendanceHistory
            // 
            this.lblAttendanceHistory.AutoSize = true;
            this.lblAttendanceHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAttendanceHistory.Location = new System.Drawing.Point(8, 16);
            this.lblAttendanceHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAttendanceHistory.Name = "lblAttendanceHistory";
            this.lblAttendanceHistory.Size = new System.Drawing.Size(170, 15);
            this.lblAttendanceHistory.TabIndex = 0;
            this.lblAttendanceHistory.Text = "История посещаемости:";
            // 
            // gbRegistration
            // 
            this.gbRegistration.Controls.Add(this.lblRejectionReason);
            this.gbRegistration.Controls.Add(this.lblAttendanceStatus);
            this.gbRegistration.Controls.Add(this.lblApprovalDate);
            this.gbRegistration.Controls.Add(this.lblStatus);
            this.gbRegistration.Controls.Add(this.lblApplicationDate);
            this.gbRegistration.Controls.Add(this.lblRegistrationId);
            this.gbRegistration.Location = new System.Drawing.Point(8, 244);
            this.gbRegistration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbRegistration.Name = "gbRegistration";
            this.gbRegistration.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbRegistration.Size = new System.Drawing.Size(420, 114);
            this.gbRegistration.TabIndex = 2;
            this.gbRegistration.TabStop = false;
            this.gbRegistration.Text = "Детали заявки";
            // 
            // lblRejectionReason
            // 
            this.lblRejectionReason.AutoSize = true;
            this.lblRejectionReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRejectionReason.ForeColor = System.Drawing.Color.Red;
            this.lblRejectionReason.Location = new System.Drawing.Point(8, 98);
            this.lblRejectionReason.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRejectionReason.Name = "lblRejectionReason";
            this.lblRejectionReason.Size = new System.Drawing.Size(132, 15);
            this.lblRejectionReason.TabIndex = 5;
            this.lblRejectionReason.Text = "Причина отклонения:";
            // 
            // lblAttendanceStatus
            // 
            this.lblAttendanceStatus.AutoSize = true;
            this.lblAttendanceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAttendanceStatus.Location = new System.Drawing.Point(225, 65);
            this.lblAttendanceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAttendanceStatus.Name = "lblAttendanceStatus";
            this.lblAttendanceStatus.Size = new System.Drawing.Size(98, 15);
            this.lblAttendanceStatus.TabIndex = 4;
            this.lblAttendanceStatus.Text = "Посещаемость:";
            // 
            // lblApprovalDate
            // 
            this.lblApprovalDate.AutoSize = true;
            this.lblApprovalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblApprovalDate.Location = new System.Drawing.Point(8, 65);
            this.lblApprovalDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApprovalDate.Name = "lblApprovalDate";
            this.lblApprovalDate.Size = new System.Drawing.Size(136, 15);
            this.lblApprovalDate.TabIndex = 3;
            this.lblApprovalDate.Text = "Дата подтверждения:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(225, 41);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Статус:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblApplicationDate.Location = new System.Drawing.Point(8, 41);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(83, 15);
            this.lblApplicationDate.TabIndex = 1;
            this.lblApplicationDate.Text = "Дата заявки:";
            // 
            // lblRegistrationId
            // 
            this.lblRegistrationId.AutoSize = true;
            this.lblRegistrationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistrationId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblRegistrationId.Location = new System.Drawing.Point(8, 16);
            this.lblRegistrationId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistrationId.Name = "lblRegistrationId";
            this.lblRegistrationId.Size = new System.Drawing.Size(75, 15);
            this.lblRegistrationId.TabIndex = 0;
            this.lblRegistrationId.Text = "ID заявки:";
            // 
            // gbCircle
            // 
            this.gbCircle.Controls.Add(this.lblCirclePrice);
            this.gbCircle.Controls.Add(this.lblCircleAgeRange);
            this.gbCircle.Controls.Add(this.lblCircleCategory);
            this.gbCircle.Controls.Add(this.lblCircleName);
            this.gbCircle.Location = new System.Drawing.Point(8, 122);
            this.gbCircle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCircle.Name = "gbCircle";
            this.gbCircle.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCircle.Size = new System.Drawing.Size(420, 114);
            this.gbCircle.TabIndex = 1;
            this.gbCircle.TabStop = false;
            this.gbCircle.Text = "Информация о кружке";
            // 
            // lblCirclePrice
            // 
            this.lblCirclePrice.AutoSize = true;
            this.lblCirclePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCirclePrice.Location = new System.Drawing.Point(8, 89);
            this.lblCirclePrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCirclePrice.Name = "lblCirclePrice";
            this.lblCirclePrice.Size = new System.Drawing.Size(40, 15);
            this.lblCirclePrice.TabIndex = 3;
            this.lblCirclePrice.Text = "Цена:";
            // 
            // lblCircleAgeRange
            // 
            this.lblCircleAgeRange.AutoSize = true;
            this.lblCircleAgeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCircleAgeRange.Location = new System.Drawing.Point(8, 65);
            this.lblCircleAgeRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCircleAgeRange.Name = "lblCircleAgeRange";
            this.lblCircleAgeRange.Size = new System.Drawing.Size(58, 15);
            this.lblCircleAgeRange.TabIndex = 2;
            this.lblCircleAgeRange.Text = "Возраст:";
            // 
            // lblCircleCategory
            // 
            this.lblCircleCategory.AutoSize = true;
            this.lblCircleCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCircleCategory.Location = new System.Drawing.Point(8, 41);
            this.lblCircleCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCircleCategory.Name = "lblCircleCategory";
            this.lblCircleCategory.Size = new System.Drawing.Size(72, 15);
            this.lblCircleCategory.TabIndex = 1;
            this.lblCircleCategory.Text = "Категория:";
            // 
            // lblCircleName
            // 
            this.lblCircleName.AutoSize = true;
            this.lblCircleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCircleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCircleName.Location = new System.Drawing.Point(8, 16);
            this.lblCircleName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCircleName.Name = "lblCircleName";
            this.lblCircleName.Size = new System.Drawing.Size(67, 17);
            this.lblCircleName.TabIndex = 0;
            this.lblCircleName.Text = "Кружок:";
            // 
            // gbParticipant
            // 
            this.gbParticipant.Controls.Add(this.lblParticipantRole);
            this.gbParticipant.Controls.Add(this.lblParticipantEmail);
            this.gbParticipant.Controls.Add(this.lblParticipantName);
            this.gbParticipant.Location = new System.Drawing.Point(8, 8);
            this.gbParticipant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbParticipant.Name = "gbParticipant";
            this.gbParticipant.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbParticipant.Size = new System.Drawing.Size(420, 106);
            this.gbParticipant.TabIndex = 0;
            this.gbParticipant.TabStop = false;
            this.gbParticipant.Text = "Информация об участнике";
            // 
            // lblParticipantRole
            // 
            this.lblParticipantRole.AutoSize = true;
            this.lblParticipantRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblParticipantRole.Location = new System.Drawing.Point(8, 65);
            this.lblParticipantRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParticipantRole.Name = "lblParticipantRole";
            this.lblParticipantRole.Size = new System.Drawing.Size(39, 15);
            this.lblParticipantRole.TabIndex = 2;
            this.lblParticipantRole.Text = "Роль:";
            // 
            // lblParticipantEmail
            // 
            this.lblParticipantEmail.AutoSize = true;
            this.lblParticipantEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblParticipantEmail.Location = new System.Drawing.Point(8, 41);
            this.lblParticipantEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParticipantEmail.Name = "lblParticipantEmail";
            this.lblParticipantEmail.Size = new System.Drawing.Size(42, 15);
            this.lblParticipantEmail.TabIndex = 1;
            this.lblParticipantEmail.Text = "Email:";
            // 
            // lblParticipantName
            // 
            this.lblParticipantName.AutoSize = true;
            this.lblParticipantName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblParticipantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblParticipantName.Location = new System.Drawing.Point(8, 16);
            this.lblParticipantName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParticipantName.Name = "lblParticipantName";
            this.lblParticipantName.Size = new System.Drawing.Size(83, 17);
            this.lblParticipantName.TabIndex = 0;
            this.lblParticipantName.Text = "Участник:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnMarkAttendance);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnReject);
            this.panelButtons.Controls.Add(this.btnApprove);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 325);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(531, 81);
            this.panelButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(352, 24);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMarkAttendance
            // 
            this.btnMarkAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnMarkAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMarkAttendance.ForeColor = System.Drawing.Color.White;
            this.btnMarkAttendance.Location = new System.Drawing.Point(273, 24);
            this.btnMarkAttendance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(75, 32);
            this.btnMarkAttendance.TabIndex = 4;
            this.btnMarkAttendance.Text = "Посещаемость";
            this.btnMarkAttendance.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(194, 24);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 32);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(114, 24);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(431, 24);
            this.btnReject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 32);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Отклонить";
            this.btnReject.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(15, 24);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(90, 32);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Подтвердить";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // RegistrationDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 406);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegistrationDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Детали заявки";
            this.panelMain.ResumeLayout(false);
            this.gbAttendance.ResumeLayout(false);
            this.gbAttendance.PerformLayout();
            this.gbRegistration.ResumeLayout(false);
            this.gbRegistration.PerformLayout();
            this.gbCircle.ResumeLayout(false);
            this.gbCircle.PerformLayout();
            this.gbParticipant.ResumeLayout(false);
            this.gbParticipant.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}