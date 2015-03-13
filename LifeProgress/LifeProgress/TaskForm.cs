using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Model2;
using Model2.Factories;
using Manager;

namespace LifeProgress
{
    /// <summary>
    /// Form for task creating/editing
    /// Input parameters:
    ///  * if editing - task for editing
    ///  * else nothing
    /// Output parameters:
    ///  * week parameters: number and year
    ///  * field reference
    ///  * task parameters (isRepeating, onceADay, name, coefficient, etc...) in task class 
    ///  (without week info and ID)
    /// </summary>
    public partial class frmTask : Form
    {
        const float DELTA = (float)0.01;
        const int COEF_LEVELS = 100;


        public bool EditMode { get; private set; }
        public ModelEntities Model { get; set; }
        public Field SelField { get; set; }
        public int WeekYear { get; set; }
        public int WeekNumber { get; set; }
        public Task NewTask { get; set; }

        //---------------------------------------------------------------------------
        public frmTask(ModelEntities model)
        {
            InitializeComponent();
            Model = null;
            SelField = null;
            WeekYear = 0;
            WeekNumber = 0;
            NewTask = null;
            Model = model;
        }

        //---------------------------------------------------------------------------
        // form load
        private void frmTask_Load(object sender, EventArgs e)
        {
            trkLevel.Minimum = 1;
            trkLevel.Maximum = COEF_LEVELS;
            if (NewTask != null) EditMode = true;
            initImportanceColors();
            show();
            showParameters();
        }

        //---------------------------------------------------------------------------
        private void initImportanceColors()
        {
            lblSuperImportant.ForeColor = WeekWorker.createColor10();
            lblImportant.ForeColor = WeekWorker.createColor7();
            lblNormal.ForeColor = WeekWorker.createColor5();
            lblLowImportance.ForeColor = WeekWorker.createColor3();
            lblNotImportant.ForeColor = WeekWorker.createColor1();
        }

        //---------------------------------------------------------------------------
        public void show()
        {
            try
            {
                showTitle();
                showTime();
                showFileds();
                showOkButton();
            }
            catch (Exception ex)
            {
                LogManager.Instance.logException(ex);
                MessageBox.Show("Невозможно отобразить форму добавления/редактирования");
                Close();
            }
        }

        //---------------------------------------------------------------------------
        private void showParameters()
        {
            if (EditMode)
            {
                txbName.Text = NewTask.Name;
                trkLevel.Value = getLevelValue(NewTask);
                chkRepeating.Checked = NewTask.isRepeating();
                chkRepeating.Enabled = false;                   // not editable
                chkNumberTask.Checked = NewTask is NumberTask;
                chkNumberTask.Enabled = false;

                if ((NewTask.isRepeating()))
                {
                    numWeek.Enabled = false;
                    numYear.Enabled = false;
                }

                if (NewTask is PercentTask)
                    cmbField.Enabled = true;
                else
                    cmbField.Enabled = false;

                chkDebt.Checked = NewTask.IsDebted;
                if (NewTask is NumberTask)
                {
                    numCount.Value = ((NumberTask)NewTask).Norma.Value;
                    chkDay.Checked = ((NumberTask)NewTask).OnceADay.Value;
                }
                else
                {
                    numCount.Enabled = false;
                    chkDay.Enabled = false;
                }

            }
        }

        //---------------------------------------------------------------------------
        private int getLevelValue(Task _task)
        {
            int res = (int)(_task.Coefficient * COEF_LEVELS);
            if (res < 1) res = 1;
            else if (res > COEF_LEVELS) res = COEF_LEVELS;

            return res;
        }

        //---------------------------------------------------------------------------
        private float getCoef()
        {
            return (float)trkLevel.Value / COEF_LEVELS;
        }

        //---------------------------------------------------------------------------
        private void onceEnabled(bool p)
        {
            chkDay.Enabled = p;
        }

        //---------------------------------------------------------------------------
        private void countEnabled(bool p)
        {
            numCount.Enabled = p;
        }

        //---------------------------------------------------------------------------
        private void showTitle()
        {
            if (EditMode)
                Text = "Добавление нового задания";
            else
                Text = "Редактирование задания";
        }

        //---------------------------------------------------------------------------
        private void showTime()
        {
            if (WeekYear == 0 && WeekNumber == 0)
            {
                WeekNumber = WeekWorker.getNumber(DateTime.Now);
                WeekYear = DateTime.Now.Year;
            }

            int year = WeekYear;
            int number = WeekNumber;
            
            numYear.Value = year;
            numWeek.Value = number;

            if (WeekWorker.getNumber(DateTime.Now) == WeekNumber && DateTime.Now.Year == WeekYear)
                lblWeek.Text = "Текущая";
            else if (WeekWorker.getNextCalendarWeek(WeekWorker.getCurrentWeek(Model), Model) == 
                        WeekFactory.createFakeWeek(WeekNumber, WeekYear))
                lblWeek.Text = "Следующая";
            else
                lblWeek.Text = "";
        }

        //---------------------------------------------------------------------------
        private void showFileds()
        {
            IEnumerable<Field> fields = null;
            cmbField.Items.Clear();
            Week selWeek = WeekWorker.getWeek(WeekWorker.getWeekStartByNumber(WeekNumber, WeekYear), Model);
            Week prevWeek = selWeek.findPreviousWeekInDB(Model);
            if (selWeek.ID == 0)        // if fake week
                fields = prevWeek.getFields();
            else
                fields = selWeek.getFields();

            foreach (Field f in fields) // add to drop down list
                cmbField.Items.Add(f);

            if (NewTask != null)  // select item in drop down list
                cmbField.SelectedItem = NewTask.Field;
            else
                cmbField.SelectedItem = SelField;
        }

        //---------------------------------------------------------------------------
        private void showOkButton()
        {
            if (NewTask == null)
                btnOk.Text = "Добавить";
            else
                btnOk.Text = "Сохранить";
        }

        //---------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //---------------------------------------------------------------------------
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                checkWeek();
                if (EditMode)
                    editTask();
                else
                    createTask();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить (" + ex + ")!");
            }
        }

        /// <summary>
        /// Checing for past weeks
        /// </summary>
        private void checkWeek()
        {
            if (WeekWorker.isWeekPast(WeekFactory.createFakeWeek(WeekNumber, WeekYear)))
                throw new MyException("Невозможно создать задание для прошедшей недели");
        }

        //---------------------------------------------------------------------------
        private void editTask()
        {
            NewTask.Name = txbName.Text;
            NewTask.Coefficient = getCoef();
            NewTask.IsDebted = chkDebt.Checked;

            if (NewTask is NumberTask)
                editNumberTask((NumberTask)NewTask);
            else if (NewTask is PercentTask)
                editPercentTask((PercentTask)NewTask);

            
        }

        //---------------------------------------------------------------------------
        private void editPercentTask(PercentTask t)
        {
            WeekNumber = (int)numWeek.Value;
            WeekYear = (int)numYear.Value;
            SelField = (Field)cmbField.SelectedItem;
        }

        //---------------------------------------------------------------------------
        private void editNumberTask(NumberTask t)
        {
            t.Norma = (int)numCount.Value;
            t.OnceADay = chkDay.Checked;
        }

        //---------------------------------------------------------------------------
        private void createTask()
        {
            WeekNumber = (int)numWeek.Value;
            WeekYear = (int)numYear.Value;
            if (cmbField.SelectedItem == null)
                throw new Exception("Не задана область");

            SelField = (Field)cmbField.SelectedItem;
            string name = txbName.Text;
            if (name == "") throw new MyException("Не задано имя");

            float coef = getCoef();

            // selector
            if (chkNumberTask.Checked)
                createNumberTask(name, coef);
            else
                createPercentTask(name, coef);
            NewTask.IsDebted = chkDebt.Checked;
            NewTask.Field = SelField;
            NewTask.Current = 0;
            
        }

        //---------------------------------------------------------------------------
        private void createPercentTask(string name, float coef)
        {
            NewTask = new PercentTask();
            NewTask.Name = name;
            NewTask.Coefficient = coef;
            NewTask.RepeatingID = chkRepeating.Checked ? Task.createRepeatingID(Model) : null;
        }

        //---------------------------------------------------------------------------
        private void createNumberTask(string name, float coef)
        {
            int max = (int)numCount.Value;
            NewTask = new NumberTask();
            NewTask.Name = name;
            NewTask.Coefficient = coef;
            NewTask.RepeatingID = chkRepeating.Checked ? Task.createRepeatingID(Model) : null;
            ((NumberTask)NewTask).Norma = max;
            ((NumberTask)NewTask).OnceADay = chkDay.Checked;
            ((NumberTask)NewTask).Unit = "";
        }

        //---------------------------------------------------------------------------
        private void numWeek_ValueChanged(object sender, EventArgs e)
        {
            WeekNumber = (int)numWeek.Value;
            WeekYear = (int)numYear.Value;
            showTime();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numCount.Enabled = chkNumberTask.Checked;
            chkDay.Enabled = chkNumberTask.Checked;
        }

    }
}