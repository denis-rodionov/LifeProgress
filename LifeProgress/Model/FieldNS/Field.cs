using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.Collections;
using ModelNS.TaskNS;

namespace ModelNS.FieldNS
{
    public abstract class Field : INamed, IStatused
    {
        const int COEF = 1;

        protected int _id;
        protected string _name;
        protected ArrayList _taskList;

        public abstract Field clone();

        //---------------------------------------------------------------------------
        protected Field(string name, int id)
        {
            _id = id;
            _name = name; 
        }

        public int getId() { return _id; }
        public string getName() { return _name; }
        public void setName(string value) { _name = value; }        
        public ArrayList getTaskList() { return _taskList; }
        public float getCoef() { return (float)_taskList.Count; }

        //---------------------------------------------------------------------------
        public int getStatus()
        {
            return StatusCounter.countStatus(_taskList);
        }

        //---------------------------------------------------------------------------
        public void remove(Task t)
        {
            foreach (Task tsk in _taskList)
                if (tsk == t)
                {
                    _taskList.Remove(tsk);
                    break;
                }
        }

        //---------------------------------------------------------------------------
        public override string ToString() 
        {
            return getName();
        }

        //---------------------------------------------------------------------------
        public void add(Task task) { _taskList.Add(task); }

        //---------------------------------------------------------------------------
        public bool isEmpty()
        {
            return _taskList.Count == 0;
        }

        //---------------------------------------------------------------------------
        public Task getTask(string p)
        {
            Task res = null;

            foreach (Task t in _taskList)
                if (t.getName() == p)
                    res = t;

            return res;
        }
    }
}
