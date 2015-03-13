using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.Interfaces;

namespace ModelNS.FieldNS
{
    public class WeekField : Field, ISaved
    {
        // const       
        const int VERSION = 1;
        public const string DEFAULT_NAME = "Еженедельные задачи";
        public const int ID = 1;

        // attributes
        int _itemId;

        //---------------------------------------------------------------------------
        public WeekField(Templates tl) : base(DEFAULT_NAME, ID)
        {
            _itemId = Model.getCurId();
            _taskList = tl.getTemplatesCopy();
        }

        //---------------------------------------------------------------------------
        internal WeekField()
            : base(DEFAULT_NAME, ID)
        {
            _itemId = Model.getCurId();
            _taskList = new ArrayList();
        }

        //---------------------------------------------------------------------------
        public override Field clone()
        {
            throw new Exception("Недопустимый код");
        }

        //---------------------------------------------------------------------------
        public static WeekField getTemplate()
        {
            return new WeekField();
        }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.WEEK_FIELD; }

        #endregion

        internal void setId(int p) { _id = p; }
    }
}
