using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model2;

namespace TaskLibrary
{
    public delegate void ChangeHandler(FieldMap fm);

    public partial class MyTracker : UserControl
    {
        public FieldMap FM { private set; get; }
        ChangeHandler _onChange;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="fm">FieldMap from which we take name and percents</param>
        /// <param name="onChange">Function which we call when tracker scrolled</param>
        public MyTracker(FieldMap fm, ChangeHandler onChange)
        {
            InitializeComponent();
            FM = fm;
            _onChange = onChange;
            DoubleBuffered = true;
        }

        private void MyTracker_Load(object sender, EventArgs e)
        {
            show();
            Paint += new PaintEventHandler(MyTracker_Paint);
            //lblPercent.TextChanged += new EventHandler(lblPercent_TextChanged);
        }

        void MyTracker_Paint(object sender, PaintEventArgs e)
        {
            show();
        }

        private void show()
        {
            lblName.Text = FM.Field.Name;
            lblPercent.Text = FM.getPercentCoefficient() + "%";
            tracker.Value = FM.getPercentCoefficient();
        }

        void lblPercent_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(lblPercent.Text);
        }

        public void refresh()
        {
            show();
        }

        private void tracker_Scroll(object sender, EventArgs e)
        {
            FM.setPercentCoefficient(tracker.Value);
            _onChange(FM);
        }
    }
}
