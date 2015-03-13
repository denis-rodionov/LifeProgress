using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Model2;
using Manager;

namespace LifeProgress
{
    /// <summary>
    /// Form for input repeating tasks.
    /// </summary>
    public partial class SuccessForm : Form
    {
        const int MANAGE_HEIGHT = 20;
        const int MANAGE_WIDTH = 40;
        const int OFFSET = 25;

        Week _week;
        DateTime _date;
        ModelEntities _model;
        Dictionary<Control, Task> _controlTaskMatch;

        public SuccessForm(DateTime date, ModelEntities model)
        {
            InitializeComponent();
            _model = model;
            _week = WeekWorker.getWeek(date, _model);
            _date = date;
            _controlTaskMatch = new Dictionary<Control, Task>();
        }

        private void SuccessForm_Load(object sender, EventArgs e)
        {
            IEnumerable<Task> taskList = _week.Tasks;

            int offset = OFFSET;
            int curY = offset, curX = offset;

            int count = 0;
            foreach (Field f in _week.getFields())
                foreach (Task t in _week.getTasks(f))
                {
                    if (!t.isDone() || t.getLoggedWork(_date, _model).Value != 0)
                    {
                        string unit = (t is NumberTask) ? ((NumberTask)t).Unit : "%";
                        Label lCur = FormWorker.createLabel(t.Name + (unit != "" ? " ( " + unit + " )" : ""));
                        lCur.Location = new Point(curX, curY);
                        Controls.Add(lCur);

                        Control mc = manageControl(t, curY, count++);
                        Controls.Add(mc);

                        _controlTaskMatch.Add(mc, t);

                        curY += offset;
                    }
                }
            buttonsInit(curY, offset);
            Text = "Ввод данных за " + _date.Date.ToString("D");
        }

        private Control manageControl(Task task, int curY, int p)
        {
            Control res = null;
            if ((task is NumberTask) && ((NumberTask)task).OnceADay.Value)
                res = new CheckBox();
            else
                res = new TextBox();

            fillControl(res, task);

            res.Size = new Size(MANAGE_WIDTH, MANAGE_HEIGHT);
            res.Location = new Point(this.Width - OFFSET - res.Size.Width, curY);
            res.Name = "_" + p;
            res.TabIndex = p;
            

            return res;
        }

        private void fillControl(Control res, Task task)
        {
            LoggedWork lw = task.findLoggedWork(_date);
            int value = lw == null ? 0 : lw.Value;
            if (res is CheckBox)
                ((CheckBox)res).Checked = value != 0;
            else
                ((TextBox)res).Text = value.ToString();
        }

        private void buttonsInit(int curY, int offset)
        {
            btnSubmit.Location = new Point(offset, curY);
            btnSubmit.Width = (this.Width - 4 * offset) / 2;
            btnCancel.Location = new Point(3 * offset + btnSubmit.Width, curY);
            btnCancel.Width = btnSubmit.Width;
        }

        internal void setWeek(Week week)
        {
            _week = week;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                    if (c is CheckBox || c is TextBox)
                    {
                        int index = getIndex(c);
                        int value = getValue(c);
                        
                        Task task = _controlTaskMatch[c];
                        LoggedWork lw = task.getLoggedWork(_date, _model);
                        lw.logWork(value, _model);
                    }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.logException(ex);
                MessageBox.Show("Некоректные значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private int getValue(Control c)
        {
            int res = 0;
            if (c is CheckBox)
                res = ((CheckBox)c).Checked ? 1 : 0;
            else
                res = int.Parse(((TextBox)c).Text);
            return res;
        }

        private int getIndex(Control c)
        {
            string name = c.Name;
            name = name.Remove(0, 1);
            return int.Parse(name);
        }
    }
}