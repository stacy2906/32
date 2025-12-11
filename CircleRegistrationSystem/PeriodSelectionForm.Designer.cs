namespace CircleRegistrationSystem.Forms
{
    partial class PeriodSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLastWeek;
        private System.Windows.Forms.Button btnLastMonth;
        private System.Windows.Forms.Button btnLastQuarter;
        private System.Windows.Forms.Button btnCurrentMonth;

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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCurrentMonth = new System.Windows.Forms.Button();
            this.btnLastQuarter = new System.Windows.Forms.Button();
            this.btnLastMonth = new System.Windows.Forms.Button();
            this.btnLastWeek = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(150, 30);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 22);
            this.dtpStartDate.TabIndex = 0;

            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(150, 70);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 22);
            this.dtpEndDate.TabIndex = 1;

            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата начала:";

            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата конца:";

            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(200, 250);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;

            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(320, 250);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;

            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCurrentMonth);
            this.groupBox1.Controls.Add(this.btnLastQuarter);
            this.groupBox1.Controls.Add(this.btnLastMonth);
            this.groupBox1.Controls.Add(this.btnLastWeek);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(30, 120);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(390, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Быстрый выбор периода:";

            // btnCurrentMonth
            // 
            this.btnCurrentMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.btnCurrentMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCurrentMonth.ForeColor = System.Drawing.Color.White;
            this.btnCurrentMonth.Location = new System.Drawing.Point(200, 60);
            this.btnCurrentMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnCurrentMonth.Name = "btnCurrentMonth";
            this.btnCurrentMonth.Size = new System.Drawing.Size(180, 30);
            this.btnCurrentMonth.TabIndex = 3;
            this.btnCurrentMonth.Text = "Текущий месяц";
            this.btnCurrentMonth.UseVisualStyleBackColor = false;

            // btnLastQuarter
            // 
            this.btnLastQuarter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnLastQuarter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLastQuarter.ForeColor = System.Drawing.Color.White;
            this.btnLastQuarter.Location = new System.Drawing.Point(200, 20);
            this.btnLastQuarter.Margin = new System.Windows.Forms.Padding(4);
            this.btnLastQuarter.Name = "btnLastQuarter";
            this.btnLastQuarter.Size = new System.Drawing.Size(180, 30);
            this.btnLastQuarter.TabIndex = 2;
            this.btnLastQuarter.Text = "Последний квартал";
            this.btnLastQuarter.UseVisualStyleBackColor = false;

            // btnLastMonth
            // 
            this.btnLastMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnLastMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLastMonth.ForeColor = System.Drawing.Color.White;
            this.btnLastMonth.Location = new System.Drawing.Point(10, 60);
            this.btnLastMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(180, 30);
            this.btnLastMonth.TabIndex = 1;
            this.btnLastMonth.Text = "Последний месяц";
            this.btnLastMonth.UseVisualStyleBackColor = false;

            // btnLastWeek
            // 
            this.btnLastWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLastWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLastWeek.ForeColor = System.Drawing.Color.White;
            this.btnLastWeek.Location = new System.Drawing.Point(10, 20);
            this.btnLastWeek.Margin = new System.Windows.Forms.Padding(4);
            this.btnLastWeek.Name = "btnLastWeek";
            this.btnLastWeek.Size = new System.Drawing.Size(180, 30);
            this.btnLastWeek.TabIndex = 0;
            this.btnLastWeek.Text = "Последняя неделя";
            this.btnLastWeek.UseVisualStyleBackColor = false;

            // PeriodSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PeriodSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор периода";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}