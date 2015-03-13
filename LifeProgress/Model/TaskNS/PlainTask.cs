using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;

namespace ModelNS.TaskNS
{
    public class PlainTask : Task, ISaved
    {
        const int VERSION = 2;

        int _id;
        bool _isDone;

        //---------------------------------------------------------------------------
        public PlainTask(string name, float coef, MyDayOfWeek day)
            : base(name, coef, day)
        {
            _id = Model.getCurId();
            _isDone = false;            
        }

        //---------------------------------------------------------------------------
        public override int getStatus()
        {
            return _isDone ? 100 : 0;
        }

        //---------------------------------------------------------------------------
        public override object Clone()
        {
            PlainTask newTask = new PlainTask(getName(), getCoef(), getDay());
            newTask.setDone(getDone()) ;
            newTask.setDebtStatus(isDebted());
            return newTask;
        }

        //---------------------------------------------------------------------------
        public void setDone(bool status) { _isDone = status; }
        //---------------------------------------------------------------------------
        public bool getDone() { return _isDone; }
        //---------------------------------------------------------------------------
        public override string ToString()
        {
            return getName() + " : " + _isDone.ToString();
        }
        //---------------------------------------------------------------------------
        public override void changeData(Task task)
        {
            PlainTask pt = (PlainTask)task;
            commonChangeData(task);
        }

        //---------------------------------------------------------------------------
        public override void setNullCur() { _isDone = false; }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public override int getItemId() { return _id; }
        public void setItemId(int value) { _id = value; }
        public int getItemType() { return (int)ItemType.PLAIN_TASK; }

        #endregion

    }
}
