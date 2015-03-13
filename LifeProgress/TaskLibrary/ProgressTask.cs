using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Model2;

namespace TaskLibrary
{
    public partial class ProgressTask : UserControl
    {
        public const int HEIGHT = 20;

        string _name;
        int _number;
        string _unit;
        int _maxCount;
        int _cur;
        int _percents;
        bool _debted;
        Task _task;

        //---------------------------------------------------------------------------
        public ProgressTask()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------
        public ProgressTask(Task task, int number)
        {
            InitializeComponent();

            _name = task.Name;
            _number = number;
            _unit = "";
            if (task is NumberTask)
                _maxCount = ((NumberTask)task).Norma.Value;
            else
            {
                _maxCount = 100;
                _unit = "%";
            }
            _cur = task.Current;
            _percents = (int)Math.Round(task.getProgress() * 100);
            _debted = task.IsDebted;
            _task = task;
            redraw();
        }

        //---------------------------------------------------------------------------
        public string Title
        {
            set     
            {
                _name = value;
                redraw();
            }
            get { return _name; }
        }

        //---------------------------------------------------------------------------
        public int Number
        {
            set 
            { 
                _number = value;
                redraw();
            }
            get { return _number; }
        }

        //---------------------------------------------------------------------------
        public int MaxCount
        {
            set 
            { 
                _maxCount = value; 
                redraw();
            }
            get { return _maxCount; }
        }

        //---------------------------------------------------------------------------
        public string Unit
        {
            set 
            { 
                _unit = value;
                redraw();
            }
            get { return _unit; }
        }

        //---------------------------------------------------------------------------
        public int Cur
        {
            set 
            { 
                _cur = value;
                redraw();
            }
            get { return _cur; }
        }

        //---------------------------------------------------------------------------
        public int Percents
        {
            set
            {
                _percents = value;
                redraw();
            }
            get { return _percents; }
        }

        //---------------------------------------------------------------------------
        public void redraw()
        {
            lblNumber.Text = _number + ") ";
            lblName.Text = _name;
            lblCur.Text = _cur.ToString();
            lblTotal.Text = _maxCount.ToString();
            prgStatus.Value = _percents;
            lblPercents.Text = _percents + "%";
            lblName.ForeColor = _task.Week.getTaskColor(_task);
            lblDebt.Visible = _debted;
            if (_task is PercentTask)
            {
                lblCur.Visible = false;
                lblTotal.Visible = false;
                lblFrom.Visible = false;
            }
        }
    }
}