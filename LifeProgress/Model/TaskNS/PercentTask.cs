    using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;

namespace ModelNS.TaskNS
{
    public class PercentTask : Task, ISaved
    {
        const int VERSION = 2;

        int _id;
        int _cur;

        //---------------------------------------------------------------------------
        public PercentTask(string name, float coef, MyDayOfWeek day)
            : base(name, coef, day)
        {
            _id = Model.getCurId();
            _cur = 0;
        }

        //---------------------------------------------------------------------------
        public void addPercens(int per)     {            _cur += per;       }
        //---------------------------------------------------------------------------
        public void setPercents(int per) { _cur = per; }
        //---------------------------------------------------------------------------
        public override int getStatus() { return _cur; }
        //---------------------------------------------------------------------------
        public override string ToString()
        {
            return getName() + " : " + _cur.ToString() + " % ";
        }
        //---------------------------------------------------------------------------
        public override object Clone()
        {
            PercentTask newTask = new PercentTask(getName(), getCoef(), getDay());
            newTask.setPercents(_cur);
            newTask.setDebtStatus(isDebted());
            return newTask;
        }

        //---------------------------------------------------------------------------
        public int getPercents() { return _cur; }

        //---------------------------------------------------------------------------
        public override void changeData(Task task)
        {
            PercentTask pt = (PercentTask)task;
            commonChangeData(task);                      
        }

        //---------------------------------------------------------------------------
        public override void setNullCur() { _cur = 0; }

        //---------------------------------------------------------------------------
        internal int getCur() { return _cur; }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public override int getItemId() { return _id; }
        public void setItemId(int value) { _id = value; }
        public int getItemType() { return (int)ItemType.PERCENT_TASK; }

        #endregion

        //---------------------------------------------------------------------------
        internal void setCur(int cur) { _cur = cur; }

        
    }
}
