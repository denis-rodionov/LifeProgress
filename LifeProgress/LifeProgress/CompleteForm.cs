using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LifeProgress
{
    public partial class CompleteForm : Form
    {
        int _result = 0;

        public CompleteForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _result = int.Parse(txbValue.Text);
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Значением поля может быть число от 0 до 100", "Неверный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trkValue_Scroll(object sender, EventArgs e)
        {
            txbValue.Text = trkValue.Value.ToString();
        }

        public int getPercents() { return _result; }

        public void setPercents(int value) { _result = value; }

        private void CompleteForm_Load(object sender, EventArgs e)
        {
            if (_result == 0)
                _result = 100;         // предлагаем

            txbValue.Text = _result.ToString();
            trkValue.Value = _result;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            txbValue.Text = "100";
            btnOk_Click(sender, e);
        }
    }
}