using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircleRegistrationSystem.Forms
{
    public partial class PeriodSelectionForm : Form
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public PeriodSelectionForm()
        {
            InitializeComponent();

            // Устанавливаем разумные значения по умолчанию
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;

            StartDate = dtpStartDate.Value;
            EndDate = dtpEndDate.Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpStartDate.Focus();
                return;
            }

            StartDate = dtpStartDate.Value;
            EndDate = dtpEndDate.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Если начальная дата позже конечной, автоматически обновляем конечную
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value;
            }
        }

        private void btnLastWeek_Click(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
        }

        private void btnLastQuarter_Click(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddMonths(-3);
        }

        private void btnCurrentMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
        }
    }
}