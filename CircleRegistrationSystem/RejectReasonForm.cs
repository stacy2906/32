using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircleRegistrationSystem.Forms
{
    public partial class RejectReasonForm : Form
    {
        public string Reason { get; private set; }

        public RejectReasonForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Введите причину отклонения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Reason = txtReason.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}