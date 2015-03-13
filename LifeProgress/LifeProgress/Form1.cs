using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using TaskLibrary;
using System.Collections;
using Microsoft.VisualBasic;
using Manager;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using Model2;
using Model2.Factories;

namespace LifeProgress
{
    public partial class frmMain : Form
    {
        const string CLEAR_DB = "CLEAR_DATABASE";
        const string APP_FOLDER = @"\LifeProgress";
        // const string SAVE_FILE = "data.dat";
        const string TODAY_TEXT = "Сегодня";
        const string DATE_FORMAT = "dd.MM.yyyy";
        const string LABEL = "Life Progress";
        const string VER_LABEL = " (версия 2.0)";
        const string ERROR_CAPTION = "Ошибка";
        const string DB_FILE = "DB.sdf";
        const string BACKUP_FILE = "DB_backup.sdf";
        const string WIDTH_SETTING = "WIDTH";
        const string HEIGHT_SETTING = "HEIGHT";

        ModelEntities _model;       // refference to the model
        Week _selWeek;              // week on the screen

        // for context menu operating
        Field _lastSelField;
        Task _lastSelTask;
        int _windowWidth;                 
        int _windowHeight;    

        #region Init

        //---------------------------------------------------------------------------
        public frmMain()
        {
            InitializeComponent();                    
        }

        //---------------------------------------------------------------------------
        // Form load
        private void frmMain_Load(object sender, EventArgs e)
        {
            backupDB();
            _model = new ModelEntities();
            //loadSize();
            mainStat.setModel(_model);
            if (bool.Parse(ConfigurationManager.AppSettings[CLEAR_DB]))
                ModelWorker.clearDB(_model);
            EventProcessor.createInstance(_model);
            _selWeek = WeekWorker.getCurrentWeek(_model);
            initFieldMaper();
            showAll();
            string filename = LogManager.Instance.getMainLog();
            loadSettingPage();
            DoubleBuffered = true;
            
        }

        private void loadSize()
        {
            _windowWidth = int.Parse(ConfigurationManager.AppSettings[WIDTH_SETTING]);
            _windowHeight = int.Parse(ConfigurationManager.AppSettings[HEIGHT_SETTING]);
        }

        private void backupDB()
        {
            if (File.Exists(BACKUP_FILE))
                File.Delete(BACKUP_FILE);

            File.Copy(DB_FILE, BACKUP_FILE);
        }

        /// <summary>
        /// init fields mapper
        /// </summary>
        private void initFieldMaper()
        {
            FieldMapper.createInstance(tabWeek);
            FieldMapper maper = FieldMapper.instance();
        }

        #endregion Init

        #region Show

        private void showError(Exception ex)
        {
            string message = "Ошибка программы : " + ex.Message + ",\n" +
                "пожалуйста отправьте файл отчёта об ошибке: \n\n" +
                LogManager.Instance.getMainLog() + "\n\nпо адресу:\n" +
                "den.iu7@gmail.com";
            MessageBox.Show(message, ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //---------------------------------------------------------------------------
        public void showAll()
        {
            try
            {
                Text = LABEL + VER_LABEL;
                //showWindow();
                showInfoBar();
                showTaskFields();
                showTime();
            }
            catch (Exception ex)
            {
                LogManager.Instance.logException(ex);
                showError(ex);
            }
        }

        private void showWindow()
        {
            Width = _windowWidth;
            Height = _windowHeight;
        }

        //---------------------------------------------------------------------------
        public void showTime()
        {
            lblTime.Text = DateTime.Now.ToString("t");
        }

        //---------------------------------------------------------------------------
        private void showTaskFields()
        {
            showGroupBars(_selWeek);
            showFields(_selWeek);
        }

        //---------------------------------------------------------------------------
        private void showGroupBars(Week week)
        {
            FieldMapper.instance().disableAll();
            int height = tabWeek.Size.Height - 20;
            int width = tabWeek.Width - grpWeek.Width - 20;
            int left = grpWeek.Right + 10;
            int unitHeight = 0;

            if (week.FieldMaps.Count() != 0)
                unitHeight = height / week.FieldMaps.Count();

            int count = 0;
            foreach (FieldMap fm in week.FieldMaps)
            {
                Control cont = FieldMapper.instance().getControl(fm.Field);

                cont.Size = new Size(width, unitHeight);
                cont.Top = grpWeek.Top + unitHeight * count++;
                cont.Left = left;
                cont.Visible = true;
            }
        }

        //---------------------------------------------------------------------------
        private void showFields(Week week)
        {
            TaskMaper.instance().clear();

            foreach (Field f in week.getFields())
            {
                Panel pan = FormWorker.createPanelInside(FieldMapper.instance().getControl(f));

                List<Control> contrList = new List<Control>();
                IEnumerable<Task> taskList = week.getTasks(f);
                int index = 1;
                foreach (Task t in taskList)
                {
                    Control control = null;
                    if (t is NumberTask)
                        control = createProgressTask((NumberTask)t, index);
                    else
                        control = createCheckTask((PercentTask)t, index, week.isOld());

                    TaskMaper.instance().add((Control)control, t, pan);
                    contrList.Add(control);
                    index++;
                }

                FormWorker.addControls(contrList, pan);
            }
        }

        //---------------------------------------------------------------------------
        private void showInfoBar()
        {
            int progress = _selWeek.getProgress();
            lblNumber.Text = _selWeek.Number.ToString();
            lblYear.Text = _selWeek.Year.ToString();
            lblStatus.Text = progress + "%";           // статус окончания недели
            prgStatus.Value = progress;                // прогрес бар
            weekView.init(_selWeek.getFilledDays());                 // отображает введённые дни

            if (_selWeek.Active)                                     // текущая неделя
            {
                lblNumber.ForeColor = Color.Red;
                prgWeek.Value = Week.getWeekPercent(DateTime.Now);
                btnCurrent.Enabled = false;
            }
            else
            {
                lblNumber.ForeColor = Color.Black;
                prgWeek.Value = 0;
                btnCurrent.Enabled = true;
            }
        }

        //---------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            showTime();
        }

        //---------------------------------------------------------------------------
        private void tabWeek_Enter(object sender, EventArgs e)
        {
            showAll();
        }

        //---------------------------------------------------------------------------
        private Control createProgressTask(NumberTask ntask, int num)
        {
            ProgressTask task = new ProgressTask(ntask, num);
            task.Height = ProgressTask.HEIGHT;
            return task;
        }

        //---------------------------------------------------------------------------
        private Control createCheckTask(PercentTask ptask, int num, bool old)
        {
            ProgressTask task = new ProgressTask(ptask, num);
            task.Height = CheckTask.HEIGHT;
            return task;
        }

        private void tabWeek_SizeChanged(object sender, EventArgs e)
        {
            //showTaskFields();
            //saveSizeToConfig();
        }

        private void saveSizeToConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _windowWidth = Width;
            _windowHeight = Height;
            config.AppSettings.Settings[WIDTH_SETTING].Value = Width.ToString();
            config.AppSettings.Settings[HEIGHT_SETTING].Value = Height.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        #endregion Show       
                
        #region WeekSelector

        //---------------------------------------------------------------------------
        private void btnCurrent_Click(object sender, EventArgs e)
        {
            _selWeek = WeekWorker.getCurrentWeek(_model);
            showAll();
        }

        //---------------------------------------------------------------------------
        private void btnPrev_Click(object sender, EventArgs e)
        {
            _selWeek = WeekWorker.getPrevCalendarWeek(_selWeek, _model);
            showAll();
        }

        //---------------------------------------------------------------------------
        private void btnNext_Click(object sender, EventArgs e)
        {
            _selWeek = WeekWorker.getNextCalendarWeek(_selWeek, _model);
            showAll();
        }

        //---------------------------------------------------------------------------
        // calendar - date selected
        private void calMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime newDate = calMain.SelectionStart;
            setSuccessForm(newDate);
        }

        #endregion WeekSelector
                
        #region Tasks

        //---------------------------------------------------------------------------
        private void addTask(Field defaultField)
        {
            frmTask newForm = new frmTask(_model);

            newForm.SelField = defaultField;
            newForm.WeekNumber = _selWeek.Number;
            newForm.WeekYear = _selWeek.Year;

            if (newForm.ShowDialog() == DialogResult.OK)  // garantee output parameters
            {
                Week week = WeekWorker.getWeek(newForm.WeekNumber, newForm.WeekYear, _model);

                newForm.NewTask.ID_Week = week.ID;
                newForm.NewTask.Field = newForm.SelField;
                newForm.NewTask.generateKey(_model);

                _model.Task.AddObject(newForm.NewTask);
                _model.SaveChanges();
                newForm.NewTask.taskAdded();
            }
            showAll();
        }

        //---------------------------------------------------------------------------
        private void cmiAddTask_Click(object sender, EventArgs e)
        {
            addTask(_lastSelField);
        }

        //---------------------------------------------------------------------------
        private void cmiEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selWeek.isOld())
                    editTask(_lastSelTask, _lastSelField, _selWeek);
                else
                    MessageBox.Show("Невозможно отредактировать прошедшее задание!", "Проехали",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //---------------------------------------------------------------------------
        private void editTask(Task task, Field field, Week week)
        {
            if (task == null || field == null || week == null)
                throw new Exception("Невозможно редактировать");

            frmTask newForm = new frmTask(_model);
            newForm.SelField = field;
            newForm.WeekNumber = week.Number;
            newForm.WeekYear = week.Year;
            newForm.NewTask = task;

            if (newForm.ShowDialog() == DialogResult.OK)
            {
                task.Field = newForm.SelField;
                task.Week = WeekWorker.getWeek(newForm.WeekNumber, newForm.WeekYear, _model);
                _model.SaveChanges();
                task.taskChanged();
            }
            showAll();
        }

        //---------------------------------------------------------------------------
        private void cmiRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selWeek.isOld())
                {
                    if (MessageBox.Show("Удалить задание '" + _lastSelTask.Name +
                            "'?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        _lastSelTask.taskDeleted();
                        _lastSelTask.deleteLoggedWork(_model);
                        _model.Task.DeleteObject(_lastSelTask);
                        _model.SaveChanges();
                        showAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //---------------------------------------------------------------------------
        private void cmiComplete_Click(object sender, EventArgs e)
        {
            if (_lastSelTask is PercentTask)
            {
                CompleteForm newForm = new CompleteForm();

                int progress = (int)Math.Round(_lastSelTask.getProgress() * 100);
                newForm.setPercents(progress);
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    LoggedWork lw = _lastSelTask.getLoggedWork(DateTime.Now, _model);
                    lw.logWork(newForm.getPercents(), _model);
                    showAll();
                }
            }
            else if (_lastSelTask is NumberTask)
            {
                // complete form for number task
                // ...
            }
        }

        #endregion Tasks

        #region Fields

        //---------------------------------------------------------------------------
        private void cmiRenameField_Click(object sender, EventArgs e)
        {
            string newName = null;
            if (InputBox.inputString("Введите новое название", "Ввод", ref newName))
            {
                _lastSelField.Name = newName;
                _model.SaveChanges();
                showAll();
            }
        }

        //---------------------------------------------------------------------------
        private void cmiNewField_Click(object sender, EventArgs e)
        {
            NewFieldForm frmNewField = new NewFieldForm();
            frmNewField.ShowDialog();
            if (frmNewField.DialogResult == DialogResult.OK)
            {
                Field newField = FieldWorker.createFieldForWeek(frmNewField.FieldName, _selWeek, _model);
                showAll();
            }
        }

        //---------------------------------------------------------------------------
        private void cmiRemoveField_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("При удалении, область '" + _lastSelField.Name +
                            "' пропадёт со страницы текущей\n" +
                            "недели и всех будующих недель!", "Внимание", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //FieldWorker.removeFieldfromWeek(_lastSelField, _selWeek, _model);
                _selWeek.removeFieldReference(_lastSelField, _model);
                EventProcessor.getInstance().onFieldRemoveHandler(_lastSelField);
                showAll();
            }
        }

        #endregion Fields

        #region ContextMenu

        //---------------------------------------------------------------------------
        private void ctxCommon_Opening(object sender, CancelEventArgs e)
        {
            Point coord = getMouseCoord();  // getMenuCoord();
            _lastSelField = FieldMapper.instance().getField(coord, _model);
            _lastSelTask = TaskMaper.instance().getTask(coord);
            cmiAddTask.Enabled = cmiNewField.Enabled = !_selWeek.isOld();
            cmiComplete.Enabled = _lastSelTask != null;
            cmiAddTask.Enabled = cmiRenameField.Enabled = _lastSelField != null;
            editMenu(_lastSelField, _lastSelTask);
        }

        //---------------------------------------------------------------------------
        private Point getMouseCoord()
        {
            return new Point(MousePosition.X, MousePosition.Y);
        }

        //---------------------------------------------------------------------------
        private void editMenu(Field field, Task task)
        {
            const string DEL_TEXT = "Удалить";
            const string EDIT_TEXT = "Редактировать";

            cmiRemoveField.Visible = true;
            if (field != null)
                cmiRemoveField.Text = DEL_TEXT + " '" + field.Name + "'";
            else
                cmiRemoveField.Visible = false;

            if (task != null)
            {
                cmiRemoveTask.Text = DEL_TEXT + " задание '" + task.Name + "'";
                cmiEditTask.Visible = true;
                cmiEditTask.Text = EDIT_TEXT + " задание '" + task.Name + "'";
                cmiRemoveTask.Visible = true;
            }
            else
            {
                cmiEditTask.Visible = false;
                cmiRemoveTask.Visible = false;
            }
        }

        #endregion ContextMenu

        #region SettingsTab

        //---------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            fmControl.rejectChanges(_model);
        }

        /// <summary>
        /// Save settings
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            fmControl.saveSettings(_model);
        }

        private void tabSettings_Enter(object sender, EventArgs e)
        {
            loadSettingPage();
        }

        private void loadSettingPage()
        {
            fmControl.reset();
            var fieldMaps = WeekWorker.getCurrentWeek(_model).FieldMaps;
            foreach (FieldMap fm in fieldMaps)
                fmControl.addFieldMap(fm);
        }

        #endregion SettingsTab

        #region SuccessForm

        //---------------------------------------------------------------------------
        private void btnToday_Click(object sender, EventArgs e)
        {
            if (_selWeek.Tasks.Count() > 0)
                setSuccessForm(DateTime.Now);
            else
                MessageBox.Show("Добавьте хотябы одну задачу!");
        }

        //---------------------------------------------------------------------------
        private void setSuccessForm(DateTime dateTime)
        {
            SuccessForm frmNew = new SuccessForm(dateTime, _model);
            frmNew.ShowDialog();
            showAll();
        }

        #endregion SuccessForm

        

        

        }
}