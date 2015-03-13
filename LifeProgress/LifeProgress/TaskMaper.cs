using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Model2;

namespace LifeProgress
{
    //---------------------------------------------------------------------------
    public class MaperTaskUnit
    {
        public Control control = null;
        public Task task = null;
        public Control parent = null;
    }

    //---------------------------------------------------------------------------
    class TaskMaper
    {
        static TaskMaper _instance = null;
        ArrayList _list;

        //---------------------------------------------------------------------------
        internal static TaskMaper instance()
        {
            if (_instance == null)
            {
                lock ("taskMaper")
                {
                    if (_instance == null)
                        _instance = new TaskMaper();
                }
            }
            return _instance;
        }

        //---------------------------------------------------------------------------
        private TaskMaper()
        {
            _list = new ArrayList();
        }

        //---------------------------------------------------------------------------
        public Task getTask(Point coord)
        {
            Task res = null;
            foreach (MaperTaskUnit str in _list)
                if (inControl(str.control, str.parent, coord))
                {
                    res = str.task;
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

        //---------------------------------------------------------------------------
        public void add(Control ctrl, Task task, Control parent)
        {
            MaperTaskUnit str = new MaperTaskUnit();
            str.control = ctrl;
            str.task = task;
            str.parent = parent;
            _list.Add(str);
        }

        //---------------------------------------------------------------------------
        internal void clear()
        {
            _list.Clear();
        }
    }
}
