using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LifeProgress
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public static bool inputString(string text, string caption, ref string output)
        {
            bool res = false;
            InputBox newForm = new InputBox();
            newForm.Text = caption;
            newForm.lblDesc.Text = text;
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                output = newForm.textBox1.Text;
                res = true;
            }
            return res;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}