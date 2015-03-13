using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskLibrary
{
    public partial class WeekView : UserControl
    {
        Color active = Color.Lime;
        Color std = Color.FromKnownColor(KnownColor.Control);

        public WeekView()
        {
            InitializeComponent();
        }

        private void WeekView_Load(object sender, EventArgs e)
        {
        }

        public void init(IEnumerable<DayOfWeek> days)
        {
            lblMonday.BackColor = days.Any(d => d == DayOfWeek.Monday) ? active : std;
            lblTuesday.BackColor = days.Any(d => d == DayOfWeek.Tuesday) ? active : std;
            lblWednesday.BackColor = days.Any(d => d == DayOfWeek.Wednesday) ? active : std;
            lblThursday.BackColor = days.Any(d => d == DayOfWeek.Thursday) ? active : std;
            lblFriday.BackColor = days.Any(d => d == DayOfWeek.Friday) ? active : std;
            lblSaturday.BackColor = days.Any(d => d == DayOfWeek.Saturday) ? active : std;
            lblSunday.BackColor = days.Any(d => d == DayOfWeek.Sunday) ? active : std;
        }
    }
}
