namespace CircleRegistrationSystem.Forms
{
    partial class RegistrationManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRegistrations;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

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
            this.dgvRegistrations = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrations)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // 
            // dgvRegistrations
            // 
            this.dgvRegistrations.AllowUserToAddRows = false;
            this.dgvRegistrations.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvRegistrations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistrations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistrations.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistrations.Location = new System.Drawing.Point(0, 120);
            this.dgvRegistrations.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRegistrations.Name = "dgvRegistrations";
            this.dgvRegistrations.ReadOnly = true;
            this.dgvRegistrations.RowHeadersWidth = 51;
            this.dgvRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistrations.Size = new System.Drawing.Size(900, 380);
            this.dgvRegistrations.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.btnApplyFilters);
            this.panel1.Controls.Add(this.btnClearFilters);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 120);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дата по:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(120, 70);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(150, 22);
            this.dtpToDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата с:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 40);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(150, 22);
            this.dtpFromDate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(120, 10);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 2;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilters.Location = new System.Drawing.Point(350, 10);
            this.btnApplyFilters.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(120, 35);
            this.btnApplyFilters.TabIndex = 1;
            this.btnApplyFilters.Text = "Применить";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(350, 55);
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(120, 35);
            this.btnClearFilters.TabIndex = 0;
            this.btnClearFilters.Text = "Сбросить";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnViewDetails);
            this.panel2.Controls.Add(this.btnReject);
            this.panel2.Controls.Add(this.btnApprove);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 100);
            this.panel2.TabIndex = 2;
            // 
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
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(620, 30);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 40);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(480, 30);
            this.btnViewDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 40);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "Детали";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(340, 30);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 40);
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
            this.btnApprove.Location = new System.Drawing.Point(200, 30);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(120, 40);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Подтвердить";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 40);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(63, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Всего:";
            // 
            // RegistrationManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvRegistrations);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление заявками";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrations)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}