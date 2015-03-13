using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.Interfaces;
using ModelNS.FieldNS;
using ModelNS.TaskNS;

namespace ModelNS
{
    public class Templates : ISaved
    {
        const int VERSION = 1;

        int _itemId;
        ArrayList _arr;

        //---------------------------------------------------------------------------
        public Templates()
        {
            _arr = new ArrayList();
            _itemId = Model.getCurId();
        }

        //---------------------------------------------------------------------------
        public void add(TemplateTask temp)
        {
            _arr.Add(temp);
            addReferenceToAllWeeks(temp);
        }

        //---------------------------------------------------------------------------
        public void addReferenceToAllWeeks(TemplateTask temp)
        {
            int curId = Week.makeId(DateTime.Now);
            foreach (Week w in Model.instance().getWeeks().getAllWeeks())
                if (w.getId() >= curId)
                {
                    w.getWeekField().add(temp.getCopy());
                }
        }

        //---------------------------------------------------------------------------
        public void remove(TemplateTask temp)
        {
            foreach (TemplateTask t in _arr)
                if (t == temp)
                {
                    t.close();
                    _arr.Remove(t);
                    break;
                }
        }

        //---------------------------------------------------------------------------
        public void removeOldReferences(Week curWeek)
        {
            foreach (TemplateTask t in _arr)
                t.removeOldReferences(curWeek);
        }

        //---------------------------------------------------------------------------
        public ArrayList getTemplatesCopy()
        {
            ArrayList res = new ArrayList();
            foreach (TemplateTask temp in _arr)
                res.Add(temp.getCopy());
            return res;
        }

        //---------------------------------------------------------------------------
        public override string ToString() { return "Количество шаблонов: " + _arr.Count; }

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getAllTasks()
        {
            ArrayList res = new ArrayList();
            foreach (TemplateTask t in _arr)
                res.Add(t.getTask());
            return res;
        }

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getArray() { return _arr; }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.TEMPLATES; }

        #endregion

        //---------------------------------------------------------------------------
        public TemplateTask findTemplateTask(Task task)
        {
            TemplateTask res = null;
            foreach (TemplateTask tt in _arr)
                if (tt.hasReference(task))
                {
                    res = tt;
                    break;
                }
            return res;
        }
    }
}
