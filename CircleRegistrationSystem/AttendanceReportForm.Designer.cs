namespace CircleRegistrationSystem.Forms
{
    partial class AttendanceReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblTotalParticipants;
        private System.Windows.Forms.Label lblTotalPresent;
        private System.Windows.Forms.Label lblTotalAbsent;
        private System.Windows.Forms.Label lblAverageAttendance;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelStatistics;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.lblAverageAttendance = new System.Windows.Forms.Label();
            this.lblTotalAbsent = new System.Windows.Forms.Label();
            this.lblTotalPresent = new System.Windows.Forms.Label();
            this.lblTotalParticipants = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();

            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(0, 100);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvReport.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(900, 350);
            this.dgvReport.TabIndex = 0;

            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelHeader.Controls.Add(this.lblPeriod);
            this.panelHeader.Controls.Add(this.lblReportTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 100);
            this.panelHeader.TabIndex = 1;

            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPeriod.Location = new System.Drawing.Point(20, 60);
            this.lblPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(73, 20);
            this.lblPeriod.TabIndex = 1;
            this.lblPeriod.Text = "Период:";

            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblReportTitle.Location = new System.Drawing.Point(20, 20);
            this.lblReportTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(252, 29);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "Отчет по посещаемости";

            // panelStatistics
            // 
            this.panelStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelStatistics.Controls.Add(this.lblAverageAttendance);
            this.panelStatistics.Controls.Add(this.lblTotalAbsent);
            this.panelStatistics.Controls.Add(this.lblTotalPresent);
            this.panelStatistics.Controls.Add(this.lblTotalParticipants);
            this.panelStatistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatistics.Location = new System.Drawing.Point(0, 450);
            this.panelStatistics.Margin = new System.Windows.Forms.Padding(4);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(900, 50);
            this.panelStatistics.TabIndex = 2;

            // lblAverageAttendance
            // 
            this.lblAverageAttendance.AutoSize = true;
            this.lblAverageAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAverageAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblAverageAttendance.Location = new System.Drawing.Point(650, 15);
            this.lblAverageAttendance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageAttendance.Name = "lblAverageAttendance";
            this.lblAverageAttendance.Size = new System.Drawing.Size(189, 18);
            this.lblAverageAttendance.TabIndex = 3;
            this.lblAverageAttendance.Text = "Средняя посещаемость:";

            // lblTotalAbsent
            // 
            this.lblTotalAbsent.AutoSize = true;
            this.lblTotalAbsent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAbsent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTotalAbsent.Location = new System.Drawing.Point(450, 15);
            this.lblTotalAbsent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAbsent.Name = "lblTotalAbsent";
            this.lblTotalAbsent.Size = new System.Drawing.Size(157, 18);
            this.lblTotalAbsent.TabIndex = 2;
            this.lblTotalAbsent.Text = "Всего отсутствий:";

            // lblTotalPresent
            // 
            this.lblTotalPresent.AutoSize = true;
            this.lblTotalPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPresent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTotalPresent.Location = new System.Drawing.Point(250, 15);
            this.lblTotalPresent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPresent.Name = "lblTotalPresent";
            this.lblTotalPresent.Size = new System.Drawing.Size(172, 18);
            this.lblTotalPresent.TabIndex = 1;
            this.lblTotalPresent.Text = "Всего присутствий:";

            // lblTotalParticipants
            // 
            this.lblTotalParticipants.AutoSize = true;
            this.lblTotalParticipants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalParticipants.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTotalParticipants.Location = new System.Drawing.Point(20, 15);
            this.lblTotalParticipants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalParticipants.Name = "lblTotalParticipants";
            this.lblTotalParticipants.Size = new System.Drawing.Size(110, 18);
            this.lblTotalParticipants.TabIndex = 0;
            this.lblTotalParticipants.Text = "Участников:";

            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.btnClose);
            this.panelFooter.Controls.Add(this.btnPrint);
            this.panelFooter.Controls.Add(this.btnExport);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 500);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(4);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(900, 100);
            this.panelFooter.TabIndex = 3;

            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(760, 30);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(630, 30);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 40);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExport.Enabled = false;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(500, 30);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // AttendanceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.panelStatistics);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttendanceReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчет по посещаемости";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStatistics.ResumeLayout(false);
            this.panelStatistics.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}