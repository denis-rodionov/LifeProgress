using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;

namespace ModelNS.TaskNS
{
    public class NumberTask : Task, ISaved
    {
        const int VERSION = 3;

        static int _cur_id = 0;

        int _id;
        int _cur;
        string _unit;
        int _max;
        bool _onceInDay;

        //---------------------------------------------------------------------------
        public NumberTask(string name, int max, string unit, float coef, MyDayOfWeek day, bool once)
            : base(name, coef, day)
        {
            _id = Model.getCurId();
            _unit = unit;
            _max = max;
            _cur = 0;
            _onceInDay = once;
        }

        //---------------------------------------------------------------------------
        public override object Clone()
        {
            NumberTask newTask = new NumberTask(getName(), _max, _unit, getCoef(), getDay(), isOnce());
            newTask.setDebtStatus(isDebted());
            return newTask;
        }

        //---------------------------------------------------------------------------
        public bool isOnce() { return _onceInDay;  }

        //---------------------------------------------------------------------------
        public override void changeData(Task task)
        {
            NumberTask nt = (NumberTask)task;
            commonChangeData(task);
            _max = nt._max;
            _unit = nt._unit;
            _onceInDay = nt.isOnce();
        }

        //---------------------------------------------------------------------------
        public override int getStatus()
        {
            int res = (int)((float)_cur / (float)_max * 100);
            return res > 100 ? 100 : res;
        }

        //---------------------------------------------------------------------------
        public override string ToString()
        {
            return "{ " + getName() + ", " + _cur.ToString() + " из " +
                _max.ToString() + " " + _unit + " } ";
        }

        //---------------------------------------------------------------------------
        public override void setNullCur() { _cur = 0; }

        //---------------------------------------------------------------------------
        public int getMaxCount() { return _max; }
        //---------------------------------------------------------------------------
        public int getCur() { return _cur; }
        //---------------------------------------------------------------------------
        public string getUnit()
        {
            return _unit == null ? "" : _unit;
        }

        //---------------------------------------------------------------------------
        #region ISaved Members

        //---------------------------------------------------------------------------
        public int getVersion() { return VERSION; }
        //---------------------------------------------------------------------------
        public override int getItemId() { return _id; }
        //---------------------------------------------------------------------------
        public void setItemId(int value) { _id = value; }
        //---------------------------------------------------------------------------
        public int getItemType() { return (int)ItemType.NUMBER_TASK; }

        #endregion

        //---------------------------------------------------------------------------
        public void setCur(int cur) { _cur = cur; }

        //---------------------------------------------------------------------------
        public void setMaxCount(int p) { _max = p; }
        //---------------------------------------------------------------------------
        public void setOnce(bool p) { _onceInDay = p; }
    }
}
