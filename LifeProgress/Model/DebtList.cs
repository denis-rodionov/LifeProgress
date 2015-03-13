using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.TaskNS;
using ModelNS.Interfaces;

namespace ModelNS
{
    class DebtList : ISaved
    {
        const int VERSION = 1;

        int _itemId;
        ArrayList _lstTask;

        //---------------------------------------------------------------------------
        public DebtList()
        {
            _itemId = Model.getCurId();
            _lstTask = new ArrayList();
        }


        //---------------------------------------------------------------------------
        public int getCount() { return _lstTask.Count; }
        //---------------------------------------------------------------------------
        public Task get(int index) { return (Task)_lstTask[index]; }
        //---------------------------------------------------------------------------
        public void add(Task task) { _lstTask.Add(task); }
        //---------------------------------------------------------------------------
        public void clearResolved()
        {
            foreach (Task t in _lstTask)
                if (t.isDone())
                    _lstTask.Remove(t);
        }

        //---------------------------------------------------------------------------
        internal void refresh(Week _last)
        {
        }

        //---------------------------------------------------------------------------
        // for save purposes
        public ArrayList getArray() { return _lstTask; }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.DEBT_LIST; }

        #endregion
    }
}
