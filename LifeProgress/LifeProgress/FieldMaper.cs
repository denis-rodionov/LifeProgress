using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Data.Query;
using Model2;

namespace LifeProgress
{
    //---------------------------------------------------------------------------
    class MapperFieldUnit
    {
        public Control control;
        public int fieldId;
        public Control parent;

        public override string ToString()
        {
            return fieldId + " : " + control.Text;
        }
    }

    //---------------------------------------------------------------------------
    /// <summary>
    /// Map Fields to controls
    /// </summary>
    class FieldMapper
    {
        static FieldMapper _instance = null;
        List<MapperFieldUnit> _list;
        Control _commonParent;


        //---------------------------------------------------------------------------
        public static void createInstance(Control commonParent)
        {
            if (_instance == null)
            {
                lock ("Mapper")
                {
                    if (_instance == null)
                        _instance = new FieldMapper(commonParent);
                }
            }
        }

        //---------------------------------------------------------------------------
        public static FieldMapper instance()
        {
            if (_instance == null)
                throw new Exception("Call createInstance before");

            return _instance;
        }        

        //---------------------------------------------------------------------------
        private FieldMapper(Control commonParent)
        {
            _list = new List<MapperFieldUnit>();
            _commonParent = commonParent;
        }

        //---------------------------------------------------------------------------
        public void add(IEnumerable<Field> fields, Control cont, Control parrent)
        {
            foreach (Field f in fields)
                add(f, cont, parrent);
        }

        //---------------------------------------------------------------------------
        public void add(Field field, Control cont, Control parent)
        {
            MapperFieldUnit unit = new MapperFieldUnit();
            unit.control = cont;
            unit.fieldId = field.ID;
            unit.parent = parent;
            _list.Add(unit);
        }

        //---------------------------------------------------------------------------
        public Control getControl(Field field)
        {
            Control res = null;

            foreach (MapperFieldUnit unit in _list)                
                if (unit.fieldId == field.ID)
                {
                    res = unit.control;
                    res.Visible = true;
                    res.Text = field.Name;
                    break;
                }

            if (res == null)
            {
                Control parent = _commonParent;
                res = createControl(field, parent);
                add(field, res, parent);
            }
            
            return res;
        }

        //---------------------------------------------------------------------------
        private Control createControl(Field f, Control parent)
        {
            GroupBox res = new GroupBox();
            res.Text = f.Name;
            FormWorker.addControlDefault(res, parent);
            return res;
        }

        //---------------------------------------------------------------------------
        internal void disableAll()
        {
            foreach (MapperFieldUnit unit in _list)
                unit.control.Visible = false;
        }

        //---------------------------------------------------------------------------
        internal Field getField(Point coord, ModelEntities model)
        {
            Field res = null;
            foreach (MapperFieldUnit unit in _list)
                if (inControl(unit.control, unit.parent, coord) && unit.control.Visible)
                {
                    res = model.Field.Where(f => f.ID == unit.fieldId).Single();
                    break;
                }
            return res;
        }

        //---------------------------------------------------------------------------
        public static bool inControl(Control cont, Control parent, Point coord)
        {
            Point loc = parent.PointToScreen(cont.Location);
            Rectangle rect = new Rectangle(loc.X, loc.Y, cont.Width, cont.Height);
            return rect.Contains(coord);
        }
    }
}
