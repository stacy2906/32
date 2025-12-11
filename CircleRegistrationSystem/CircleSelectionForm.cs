using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircleRegistrationSystem.Models;

namespace CircleRegistrationSystem.Forms
{
    public partial class CircleSelectionForm : Form
    {
        public Circle SelectedCircle { get; private set; }

        public CircleSelectionForm(List<Circle> circles, string title = "Выберите кружок")
        {
            InitializeComponent();
            Text = title;

            // Настройка DataGridView
            dgvCircles.AutoGenerateColumns = false;
            dgvCircles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Название",
                Width = 200
            });
            dgvCircles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Категория",
                Width = 100
            });

            dgvCircles.DataSource = circles;
            dgvCircles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvCircles.Rows.Count > 0)
                dgvCircles.Rows[0].Selected = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvCircles.SelectedRows.Count > 0)
            {
                var selectedCircle = dgvCircles.SelectedRows[0].DataBoundItem as Circle;
                if (selectedCircle != null)
                {
                    SelectedCircle = selectedCircle;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите кружок", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}