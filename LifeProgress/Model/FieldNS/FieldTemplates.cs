using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.Interfaces;

namespace ModelNS.FieldNS
{
    public class FieldTemplates : ISaved
    {
        const int VERSION = 2;

        int _itemId;
        ArrayList _fields;
        ArrayList _weekRef;
        static int _curId = 2;

        //---------------------------------------------------------------------------
        public FieldTemplates()
        {
            _itemId = Model.getCurId();
            _fields = new ArrayList();
            _weekRef = new ArrayList();
        }

        //---------------------------------------------------------------------------
        public static int getNextId()
        {
            return _curId++;
        }

        //---------------------------------------------------------------------------
        public void addFieldsToWeek(Week w) 
        {
            foreach (Field f in _fields)
                w.addField(f.clone());

            _weekRef.Add(w);
        }

        //---------------------------------------------------------------------------
        public void add(Field field) 
        { 
            _fields.Add(field); 
            foreach (Week w in _weekRef)
                w.addField(field.clone());
        }

        //---------------------------------------------------------------------------
        public void rename(int id, string name)
        {
            foreach (Week w in _weekRef)
            {
                Field f = w.getField(id);
                f.setName(name);
            }
            getTemplateField(id).setName(name);
        }

        //---------------------------------------------------------------------------
        private Field getTemplateField(int id)
        {
            Field res = null;
            foreach (Field f in _fields)
                if (f.getId() == id)
                    res = f;
            return res;
                    
        }

        //---------------------------------------------------------------------------
        public void remove(Field field)
        {
            bool isRemoved = delField(field);
            if (isRemoved)
                delFromWeeks(field);
        }

        //---------------------------------------------------------------------------
        private void delFromWeeks(Field field)
        {
            foreach (Week w in _weekRef)
                w.removeField(field);
        }

        //---------------------------------------------------------------------------
        private bool delField(Field field)
        {
            bool res = false;
            foreach (Field f in _fields)
                if (f.getId() == field.getId())
                {
                    _fields.Remove(f);
                    res = true;
                    break;
                }
            return res;
        }

        //---------------------------------------------------------------------------
        public void removeOldReferences(Week curWeek)
        {
            for (int i = 0; i < _weekRef.Count; i++)
                if (((Week)_weekRef[i]).getId() < curWeek.getId())
                    _weekRef.Remove(_weekRef[i]);
        }

        //---------------------------------------------------------------------------
        #region ISaved Members

        public int getVersion() { return VERSION; }
        public int getItemId() { return _itemId; }
        public void setItemId(int value) { _itemId = value; }
        public int getItemType() { return (int)ItemType.FIELD_TEMPLATE; }

        #endregion

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getFieldList() { return _fields; }

        //---------------------------------------------------------------------------
        // for save purposes
        internal ArrayList getWeekList() { return _weekRef; }
        //---------------------------------------------------------------------------
        internal static int getCurIdWithoutInc() { return _curId; }
        //---------------------------------------------------------------------------
        internal static void setCurId(int p) { _curId = p; }
    }
}
