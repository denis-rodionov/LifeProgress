using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.Interfaces;

namespace ModelNS.FieldNS
{
    public class WorkField : Field, ISaved
    {
        // const
        const int VERSION = 1;
        const string DEFAULT_NAME = "Работа";

        // attribute
        int _itemId;

        //---------------------------------------------------------------------------
        public WorkField(string name, int id) : base(name, id)
        {
            _taskList = new ArrayList();
            _itemId = Model.getCurId();
        }

        //---------------------------------------------------------------------------
        public override Field clone()
        {
            return new WorkField(getName(), getId());
        }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.WORK_FIELD; }

        #endregion
    }
}
