using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.TaskNS;
using ModelNS.Exceptions;
using ModelNS.Interfaces;

namespace ModelNS
{
    public class WeekList : ISaved
    {
        const int VERSION = 1;

        int _itemId;
        ArrayList _lstWeeks;

        //---------------------------------------------------------------------------
        public WeekList()
        {
            _itemId = Model.getCurId();
            _lstWeeks = new ArrayList();
        }

        //---------------------------------------------------------------------------
        public Week get(DateTime date)
        {
            int id = Week.makeId(Week.getNumber(date), date.Year);
            return get(id);
        }

        //---------------------------------------------------------------------------
        public Week get(int id)
        {
            Week res = null;
            foreach (Week w in _lstWeeks)
            {
                if (w.getId() == id)
                {
                    res = w;
                    break;
                }
            }

            if (res == null)
                if (id < Week.makeId(DateTime.Now))
                    res = new Week(id, true);
                else 
                    res = createWeek(id);

            return res;
        }

        //---------------------------------------------------------------------------
        // create and add
        private Week createWeek(int id)
        {
            Week newWeek = new Week(id, false);

            add(newWeek);
            return newWeek;
        }

        //---------------------------------------------------------------------------
        public void add(Week week)
        {
            if (isContain(week))
                throw new MyException("Неделя уже добавлена в список");
            else
                _lstWeeks.Add(week);
        }

        //---------------------------------------------------------------------------
        public bool isContain(Week week)
        {
            bool res = false;

            foreach (Week w in _lstWeeks)
            {
                if (w.getId() == week.getId())
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        //---------------------------------------------------------------------------
        internal void remove(Task t)
        {
            foreach (Week w in _lstWeeks)
                w.remove(t);
        }

        //---------------------------------------------------------------------------
        internal ArrayList getArr() {    return _lstWeeks;      }

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getAllTasks()
        {
            ArrayList res = new ArrayList();
            foreach (Week w in _lstWeeks)
                res.AddRange(w.getAllTasks());
            return res;
        }
        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getAllFields()
        {
            ArrayList res = new ArrayList();
            foreach (Week w in _lstWeeks)
                res.AddRange(w.getFields());
            return res;
        }

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getAllWeeks() { return _lstWeeks; }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.WEEK_LIST; }

        #endregion
    }
}
