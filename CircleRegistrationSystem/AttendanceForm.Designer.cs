namespace CircleRegistrationSystem.Forms
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblCircleName;
        private System.Windows.Forms.Label lblParticipantsCount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSaveAttendance;
        private System.Windows.Forms.Button btnMarkAllPresent;
        private System.Windows.Forms.Button btnMarkAllAbsent;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMarkedCount;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMarkedCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblParticipantsCount = new System.Windows.Forms.Label();
            this.lblCircleName = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnMarkAllAbsent = new System.Windows.Forms.Button();
            this.btnMarkAllPresent = new System.Windows.Forms.Button();
            this.btnSaveAttendance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendance.Location = new System.Drawing.Point(0, 150);
            this.dgvAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RowHeadersWidth = 51;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(800, 300);
            this.dgvAttendance.TabIndex = 0;

            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.lblMarkedCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblParticipantsCount);
            this.panel1.Controls.Add(this.lblCircleName);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 150);
            this.panel1.TabIndex = 1;

            // lblMarkedCount
            // 
            this.lblMarkedCount.AutoSize = true;
            this.lblMarkedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarkedCount.Location = new System.Drawing.Point(400, 100);
            this.lblMarkedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarkedCount.Name = "lblMarkedCount";
            this.lblMarkedCount.Size = new System.Drawing.Size(85, 18);
            this.lblMarkedCount.TabIndex = 10;
            this.lblMarkedCount.Text = "Отмечено:";

            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(400, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Дата по:";

            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(500, 70);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(150, 22);
            this.dtpToDate.TabIndex = 8;

            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(400, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Дата с:";

            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(500, 40);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(150, 22);
            this.dtpFromDate.TabIndex = 6;

            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblDate.Location = new System.Drawing.Point(20, 100);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(58, 20);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Дата:";

            // lblParticipantsCount
            // 
            this.lblParticipantsCount.AutoSize = true;
            this.lblParticipantsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblParticipantsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblParticipantsCount.Location = new System.Drawing.Point(20, 70);
            this.lblParticipantsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParticipantsCount.Name = "lblParticipantsCount";
            this.lblParticipantsCount.Size = new System.Drawing.Size(114, 20);
            this.lblParticipantsCount.TabIndex = 4;
            this.lblParticipantsCount.Text = "Участников:";

            // lblCircleName
            // 
            this.lblCircleName.AutoSize = true;
            this.lblCircleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCircleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCircleName.Location = new System.Drawing.Point(20, 20);
            this.lblCircleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCircleName.Name = "lblCircleName";
            this.lblCircleName.Size = new System.Drawing.Size(94, 25);
            this.lblCircleName.TabIndex = 3;
            this.lblCircleName.Text = "Кружок:";

            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(150, 100);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 22);
            this.dtpDate.TabIndex = 2;

            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnGenerateReport);
            this.panel2.Controls.Add(this.btnMarkAllAbsent);
            this.panel2.Controls.Add(this.btnMarkAllPresent);
            this.panel2.Controls.Add(this.btnSaveAttendance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 50);
            this.panel2.TabIndex = 2;

            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(660, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(530, 10);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 30);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Отчет";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // btnMarkAllAbsent
            // 
            this.btnMarkAllAbsent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnMarkAllAbsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAllAbsent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMarkAllAbsent.ForeColor = System.Drawing.Color.White;
            this.btnMarkAllAbsent.Location = new System.Drawing.Point(270, 10);
            this.btnMarkAllAbsent.Margin = new System.Windows.Forms.Padding(4);
            this.btnMarkAllAbsent.Name = "btnMarkAllAbsent";
            this.btnMarkAllAbsent.Size = new System.Drawing.Size(120, 30);
            this.btnMarkAllAbsent.TabIndex = 2;
            this.btnMarkAllAbsent.Text = "Все отсут.";
            this.btnMarkAllAbsent.UseVisualStyleBackColor = false;
            this.btnMarkAllAbsent.Click += new System.EventHandler(this.btnMarkAllAbsent_Click);

            // btnMarkAllPresent
            // 
            this.btnMarkAllPresent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnMarkAllPresent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAllPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMarkAllPresent.ForeColor = System.Drawing.Color.White;
            this.btnMarkAllPresent.Location = new System.Drawing.Point(140, 10);
            this.btnMarkAllPresent.Margin = new System.Windows.Forms.Padding(4);
            this.btnMarkAllPresent.Name = "btnMarkAllPresent";
            this.btnMarkAllPresent.Size = new System.Drawing.Size(120, 30);
            this.btnMarkAllPresent.TabIndex = 1;
            this.btnMarkAllPresent.Text = "Все прист.";
            this.btnMarkAllPresent.UseVisualStyleBackColor = false;
            this.btnMarkAllPresent.Click += new System.EventHandler(this.btnMarkAllPresent_Click);

            // btnSaveAttendance
            // 
            this.btnSaveAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSaveAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveAttendance.ForeColor = System.Drawing.Color.White;
            this.btnSaveAttendance.Location = new System.Drawing.Point(10, 10);
            this.btnSaveAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAttendance.Name = "btnSaveAttendance";
            this.btnSaveAttendance.Size = new System.Drawing.Size(120, 30);
            this.btnSaveAttendance.TabIndex = 0;
            this.btnSaveAttendance.Text = "Сохранить";
            this.btnSaveAttendance.UseVisualStyleBackColor = false;
            this.btnSaveAttendance.Click += new System.EventHandler(this.btnSaveAttendance_Click);

            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttendanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отметка посещаемости";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}