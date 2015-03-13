using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.FieldNS;
using ModelNS.SaverNS;
using ModelNS.Interfaces;
using ModelNS.LoadNS;
using ModelNS.TaskNS;

namespace ModelNS
{
    public class Model : ISaved
    {        
        const int _version = 3;
        const double STD_WEEK_PART = 0.6;

        static int _curId = 1;
        static Model _instance = null;   // singletone

        WeekList _weeks;                // недени
        Templates _templates;           // шаблоны заданий
        FieldTemplates _wTemp;          // шаблон недели
        DebtList _debts;                // долги
        Week _selWeek;                  // выбранная неделя
        Week _last;                     // текущая неделя при последнем запрос
        InputData _input;               // ежедневно вводимая информация
        double _weekPart;               // доля важности еженедельных заданий к остальным

        //---------------------------------------------------------------------------        
        public static Model instance()
        {
            if (_instance == null)
                lock ("model")
                {
                    if (_instance == null)
                        _instance = new Model();
                }
            return _instance;
        }

        //---------------------------------------------------------------------------
        private Model()
        {
            init();
        }

        //---------------------------------------------------------------------------
        private void init()
        {
            _weeks = new WeekList();
            _templates = new Templates();
            _debts = new DebtList();
            _selWeek = null;
            _last = null;
            _wTemp = new FieldTemplates();
            _weekPart = STD_WEEK_PART;
            _input = new InputData();
        }

        //---------------------------------------------------------------------------
        public Week getWeek(DateTime date)  { return  _weeks.get(date);        }
        //---------------------------------------------------------------------------
        public Week getWeek(int id) { return _weeks.get(id); }

        //---------------------------------------------------------------------------
        public Week getCurWeek()            
        { 
            Week res = getWeek(DateTime.Now);
            if (res != _last)
                eventNewWeek(res);
            _last = res;
            return res;
        }

        //---------------------------------------------------------------------------
        // еженедельные операции над моделью ( в начале новой недели )
        public void eventNewWeek(Week newWeek)
        {
            _templates.removeOldReferences(newWeek);
            _wTemp.removeOldReferences(newWeek);
            _selWeek = newWeek;

            // долги
            // _debts.refresh(_last);
            relocateDebts(newWeek);
        }

        //---------------------------------------------------------------------------
        private void relocateDebts(Week newWeek)
        {
            Week old = _weeks.get(Week.getPrev(newWeek.getId()));
            foreach (Field f in old.getFields())
                foreach (Task t in f.getTaskList())
                    if (t.isDebted() && !t.isDone())
                    {                        
                        Field newF = newWeek.getField(f.getId());
                        if (newF is WeekField)
                        {
                            NumberTask newT = (NumberTask)newF.getTask(t.getName());
                            newT.setMaxCount(newT.getMaxCount() + ((NumberTask)t).getMaxCount() - ((NumberTask)t).getCur());
                        }
                        else
                        {
                            Task cl = (Task)t.Clone();
                            cl.setNullCur();
                            newF.add(cl);
                        }
                    }
        }

        //---------------------------------------------------------------------------
        public void addWeek(Week item)      { _weeks.add(item);   }
        //---------------------------------------------------------------------------
        public Week getSelWeek() 
        {
            if (_selWeek == null)
                _selWeek = getCurWeek();
            return _selWeek;
        }


        //---------------------------------------------------------------------------
        public void addTemplate(TemplateTask item)
        {
            _templates.add(item);
        }

        //---------------------------------------------------------------------------
        public void load(string fileName)
        {
            Loader loader = new Loader();
            loader.loadModel(this, fileName);
        }

        //---------------------------------------------------------------------------
        public void save(string filename)
        {
            // условия несохранения
            if (!(this.getWeeks().getAllWeeks().Count == 1 &&
                this.getCurWeek().getAllTasks().Count == 0 ||
                this.getWeeks().getAllWeeks().Count == 0))    
            {
                Saver saver = new Saver();
                saver.saveModel(this, filename);
            }
        }

        //---------------------------------------------------------------------------
        public WeekList getWeeks() { return _weeks; }

        //---------------------------------------------------------------------------
        public WeekInfo getWeekInfo()
        {
            WeekInfo res;
            Week cur = getCurWeek();
            Week sel = getSelWeek();
            
            TimeSpan time = curTime.TimeOfDay;
            int day = dayToInt(curTime.DayOfWeek);

            res.WeekNumber = sel.getNumber();
            res.IsCurrent = sel.getNumber() == cur.getNumber() ? true : false;
            res.Year = sel.getYear();
            res.WeekPercent = (int)((day * 24 + time.Hours) / (float)168 * 100);
            res.Status = sel.getStatus();

            return res;
        }

        //---------------------------------------------------------------------------
        private int dayToInt(DayOfWeek day)
        {
            return day == DayOfWeek.Sunday ? 6 : (int)day - 1;
        }

        //---------------------------------------------------------------------------
        public Templates getTemplates() { return _templates; }

        //---------------------------------------------------------------------------
        public void setSel(int id) { _selWeek = _weeks.get(id); }

        //---------------------------------------------------------------------------
        public FieldTemplates getFieldTemplates() { return _wTemp; }
        //---------------------------------------------------------------------------
        public static int getCurId() { return _curId++; }


        #region ISaved Members

        public int getItemId() { return 0; }
        public int getVersion() { return _version; }
        public void setItemId(int value) { throw new Exception("assign model id"); }
        public int getItemType() { return (int)ItemType.MODEL; }

        #endregion

        //---------------------------------------------------------------------------
        internal DebtList getDebts() { return _debts; }
        //---------------------------------------------------------------------------
        internal int getCurIdWithoutInc() { return _curId; }
        //---------------------------------------------------------------------------
        internal Week getLastWeek() { return _last; }

        //---------------------------------------------------------------------------
        // for save purposes
        //---------------------------------------------------------------------------
        internal void setCurId(int p) { _curId = p; }
        internal void setWeekList(WeekList weekList) { _weeks = weekList; }
        internal void setTemplates(Templates templates) { _templates = templates; }
        internal void setFieldTemplates(FieldTemplates fieldTemplates) { _wTemp = fieldTemplates; }
        internal void setDebtList(DebtList debtList) { _debts = debtList; }
        internal void setSelWeek(Week week) { _selWeek = week; }
        internal void setLastWeek(Week week) { _last = week ;}

        // процент выжности еженедельных заданий
        //---------------------------------------------------------------------------
        public double getWeekPart() { return _weekPart; }
        public void setWeekPart(double value) { _weekPart = value; }

        public IEnumerable<DayInput> getInputData(WeekInfo week)
        {
            DateTime start = Week.getWeekStart(week.WeekNumber, week.Year);
            DateTime finish = Week.getWeekFinish(week.WeekNumber, week.Year);

            return _input.getDayInput(start, finish);
        }

        public void setInputData(InputData inputData)
        {
            _input = inputData;
        }

        public InputData getInputData()
        {
            return _input;
        }
    }
}
