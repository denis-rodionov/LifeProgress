using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Model2;

namespace TaskLibrary
{
    public partial class CheckTask : UserControl
    {
        public const int HEIGHT = 20;
        const string DONE_TEXT = "Выполненно";
        const string NOT_DONE_TEXT = "Не выполненно";
        const string PART_TEXT = "Выполненно на ";

        int _number;
        PercentTask _task;
        bool _isOld;
        bool _isDebted;

        //---------------------------------------------------------------------------
        public CheckTask()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------
        public CheckTask(PercentTask task, int num, bool isOld)
        {
            InitializeComponent();
            _number = num;
            _task = task;
            _isOld = isOld;
            _isDebted = task.IsDebted;
            redraw();
        }

        //---------------------------------------------------------------------------
        public void redraw()
        {
            lblNumber.Text = _number.ToString() + ") ";
            lblName.Text = _task.Name;

            int progress = (int)Math.Round(_task.getProgress() * 100);

            if (_isOld)
            {
                if (_task.isDone())
                    doneStatus();
                else if (progress > 0)
                    partDoneStatus(progress);
                else
                    notDone();
            }
            else
            {
                if (_task.isDone())
                    doneStatus();
                else if (progress > 0)
                    partDoneStatus(progress);
                else
                    notDone();
            }
            lblName.ForeColor = _task.Week.getTaskColor(_task);
            lblDebt.Visible = _task.IsDebted;
        }

        //---------------------------------------------------------------------------
        private void noneStatus()
        {
            lblDay.Text = "";
        }

        //---------------------------------------------------------------------------
        private void notDone()
        {
            lblDay.ForeColor = Color.Red;
            lblDay.Text = NOT_DONE_TEXT;
        }

        //---------------------------------------------------------------------------
        private void dayStatus(object _day)
        {
            lblDay.ForeColor = Color.Black;
            lblDay.Text = _day.ToString();
        }

        //---------------------------------------------------------------------------
        private void partDoneStatus(int p)
        {
            lblDay.ForeColor = Color.Goldenrod;
            lblDay.Text = PART_TEXT + p.ToString() + "%";
        }

        //---------------------------------------------------------------------------
        private void doneStatus()
        {
            lblDay.ForeColor = Color.Green;
            lblDay.Text = DONE_TEXT;
        }
    }
}
