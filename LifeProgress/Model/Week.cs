using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.Interfaces;
using System.Globalization;
using ModelNS.TaskNS;
using ModelNS.FieldNS;
using ModelNS.Exceptions;

namespace ModelNS
{
    public class Week : INamed, IStatused, ISaved
    {
        // consts 
        const int VERSION = 1;
        public const int MAX_NUMBER = 52;
        //public const double WEEK_PART = 0.6;

        // attributes
        int _itemId;
        int _number;
        int _year;
        WeekField _wField;
        ArrayList _fieldList;           // кроме еженедельной области

        //---------------------------------------------------------------------------
        public Week(int id, bool isOld)
        {
            _itemId = Model.getCurId();
            _fieldList = new ArrayList();
            decodeId(id, ref _number, ref _year);
            if (!isOld)
            {
                _wField = new WeekField(Model.instance().getTemplates());
                addTemplateFields();
            }
            else
                _wField = new WeekField();
        }

        //---------------------------------------------------------------------------
        private void addTemplateFields()
        {
            FieldTemplates temp = Model.instance().getFieldTemplates();
            temp.addFieldsToWeek(this);
        }

        //---------------------------------------------------------------------------
        public Field getField(int id)
        {
            Field res = null;
            ArrayList list = getFields();
            foreach (Field f in list)
                if (f.getId() == id)
                {
                    res = f;
                    break;
                }
            return res;
        }

        //---------------------------------------------------------------------------
        public static void decodeId(int id, ref int number, ref int year)
        {
            number = id % 100;
            year = id / 100;
        }

        //---------------------------------------------------------------------------
        public static int makeId(int number, int year)
        {
            return year * 100 + number;
        }

        //---------------------------------------------------------------------------
        public static int makeId(DateTime dateTime)
        {
            int number = getNumber(dateTime);           
            int year = dateTime.Year;
            if (number == 53)
            {
                number = 1;
                year++;
            }
            return makeId(number, year);
        }
                
        //---------------------------------------------------------------------------
        /// <summary>
        /// Номер недели по дате
        /// </summary>
        /// <returns></returns>
        public static int getNumber(DateTime date)
        {
            CultureInfo myCI = new CultureInfo("ru-RU");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myCal.GetWeekOfYear(date, myCWR, myFirstDOW);                     
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Вычисляет первый день недели
        /// </summary>
        public static DateTime getWeekStart(int number, int year)
        {
            CultureInfo myCI = new CultureInfo("ru-RU");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            if (myCWR != CalendarWeekRule.FirstDay) 
                throw new Exception("Не стандартное определение недель");

            DateTime firstJan = new DateTime(year, 1, 1);
            int dow = (new MyDayOfWeek(myCal.GetDayOfWeek(firstJan))).Id;
            return firstJan.AddDays(-dow + 1 + (number - 1) * 7);
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Вычисляет последний день недели
        /// </summary>
        public static DateTime getWeekFinish(int number, int year)
        {
            DateTime start = getWeekStart(number, year);
            return start.AddDays(6);
        }

        //---------------------------------------------------------------------------
        public static DayOfWeek getDayOfWeek(DateTime dateTime)
        {
            CultureInfo myCI = new CultureInfo("ru-RU");
            Calendar myCal = myCI.Calendar;
            return myCal.GetDayOfWeek(dateTime);
        }

        //---------------------------------------------------------------------------
        public int getId()       {            return makeId(_number, _year);        }

        //---------------------------------------------------------------------------
        public float getCoef() { return 1; }

        //---------------------------------------------------------------------------
        public string getName()
        {
            return "Неделя " + _number + " ( " + _year + "г. )";
        }

        //---------------------------------------------------------------------------
        public void setName(string value)
        {
            throw new MyException("Невозможно присвоить имя объекту Week");
        }

        //---------------------------------------------------------------------------
        public override string ToString() { return getName(); }

        //---------------------------------------------------------------------------
        public WeekField getWeekField() { return _wField; }

        //---------------------------------------------------------------------------
        public void remove(Task t)
        {
            ArrayList fields = getFields();
            foreach (Field f in fields)
                f.remove(t);
        }

        //---------------------------------------------------------------------------
        public ArrayList getFields()
        {
            ArrayList res = new ArrayList();
            if (_wField != null)
                res.Add(_wField);
            res.AddRange(_fieldList);
            return res;
        }

        //---------------------------------------------------------------------------
        public int getNumber() { return _number; }

        //---------------------------------------------------------------------------
        public int getYear() { return _year; }

        //---------------------------------------------------------------------------
        public int getStatus()
        {                        
            int workFields = StatusCounter.countStatus(_fieldList);
            int weekField = _wField.getStatus();
            double weekPart = Model.instance().getWeekPart();           // процент выжности еженедельных заданий
            
            return (int)Math.Round((weekField * weekPart + workFields * (1 - weekPart)));
        }

        //---------------------------------------------------------------------------
        public static int getCurrent()
        {
            int number = getNumber(DateTime.Now);
            int year = DateTime.Now.Year;
            return makeId(number, year);
        }

        //---------------------------------------------------------------------------
        public static int getNext(int id)
        {
            int res = id + 1;
            int number = 0, year = 0;
            decodeId(res, ref number, ref year);
            if (number > MAX_NUMBER)
            {
                number = 1;
                year++;
                res = makeId(number, year);
            }
            return res;
        }

        //---------------------------------------------------------------------------
        public static int getPrev(int id)
        {
            int res = id - 1;
            int number = 0, year = 0;
            decodeId(res, ref number, ref year);
            if (number == 0)
            {
                number = MAX_NUMBER;
                year--;
                res = makeId(number, year);
            }
            return res;
        }

        //---------------------------------------------------------------------------
        public void removeField(Field field)
        {
            Field f = getField(field.getId());
            _fieldList.Remove(f);
        }

        //---------------------------------------------------------------------------
        internal void addField(Field field)
        {
            _fieldList.Add(field);
        }

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getAllTasks()
        {
            ArrayList res = new ArrayList();
            foreach (Field f in getFields())
                res.AddRange(f.getTaskList());
            return res;
        }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.WEEK; }

        #endregion

        //---------------------------------------------------------------------------
        public ArrayList getWorkFields() { return _fieldList; }
        //---------------------------------------------------------------------------
        internal void SetWeekField(WeekField weekField) { _wField = weekField; }

        //---------------------------------------------------------------------------
        public bool isEmpty()
        {
            return getFields().Count == 0;
        }

        //---------------------------------------------------------------------------
        public WorkField getWorkField(int id)
        {
            WorkField res = null;
            foreach (WorkField f in _fieldList)
                if (f.getId() == id)
                {
                    res = f;
                    break;
                }
            return res;
        }

        //---------------------------------------------------------------------------
        public void addTask(Task task, int fieldId)
        {
            getField(fieldId).add(task);
        }

        
    }
}
