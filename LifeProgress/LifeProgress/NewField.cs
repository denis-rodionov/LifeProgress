using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model2;

namespace LifeProgress
{
    public partial class NewFieldForm : Form
    {
        public string FieldName { get; private set; }

        public NewFieldForm()
        {
            InitializeComponent();
        }

        // create
        private void button1_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "")
            {
                MessageBox.Show("Задайте имя области!", "Опаньки...", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                createFiled();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        // create field
        private void createFiled()
        {
            FieldName = txbName.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}