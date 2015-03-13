using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.TaskNS;
using System.Collections;
using ModelNS.Interfaces;

namespace ModelNS
{
    public class TemplateTask : ISaved
    {
        const int VERSION = 1;

        int _itemId;
        Task _template;         // шаблон для создания заданий (_cur в шаблоне - долг по текущему заданию)
        ArrayList _instances;        

        //---------------------------------------------------------------------------
        public TemplateTask(Task task)
        {
            _itemId = Model.getCurId();
            _instances = new ArrayList();
            _template = task;
        }

        //---------------------------------------------------------------------------
        public Task getDebt() { return _template; }

        //---------------------------------------------------------------------------
        public void addReference(Task task)
        {
            _instances.Add(task);
        }

        //---------------------------------------------------------------------------
        public bool hasReference(Task task)
        {
            bool res = false;

            foreach (Task t in _instances)
            {
                if (t == task)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        //---------------------------------------------------------------------------
        public void changeTemplate(Task task)
        {
            _template.changeData(task);
            foreach (Task t in _instances)
                t.changeData(task);
        }

        //---------------------------------------------------------------------------
        internal void close()
        {
            WeekList wl = Model.instance().getWeeks();
            foreach (Task t in _instances)
                wl.remove(t);
        }

        //---------------------------------------------------------------------------
        internal void removeOldReferences(Week cur)
        {
            ArrayList wl = Model.instance().getWeeks().getArr();
            foreach(Week w in wl)
                if (w.getId() < cur.getId())
                {
                    ArrayList tasks = w.getWeekField().getTaskList();
                    foreach (Task t1 in tasks)
                        for (int i = 0; i < _instances.Count; i++)
                            if (t1 == _instances[i])
                                _instances.Remove(_instances[i]);
                }
        }

        //---------------------------------------------------------------------------
        internal Task getCopy()
        {
            Task res = (Task)_template.Clone();
            res.setNullCur();
            addReference(res);
            return res;
        }

        //---------------------------------------------------------------------------
        // for save purposes
        internal Task getTask() { return _template; }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.TEMPLATE_TASK; }

        #endregion

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getInstances() { return _instances; }
    }
}
