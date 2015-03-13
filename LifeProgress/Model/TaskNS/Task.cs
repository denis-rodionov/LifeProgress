using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.Drawing;

namespace ModelNS.TaskNS
{
    public abstract class Task : IStatused, INamed, ICloneable
    {
        // consts
        public const int PERCENT_100 = 100;
        public const double DELTA = 0.01;

        // attributes
        string _name;
        float _coef;
        MyDayOfWeek _day;           // день недели  (0 - не задан, 1 - понедельник)
        bool _isDebted;             // переносится в долг

        // methods
        public abstract object Clone();
        public abstract int getStatus();
        public abstract void changeData(Task task); // изменяет всё, кроме _cur
        public abstract void setNullCur();          // обнуляет счётчик выполнения задания
        public abstract int getItemId();            // for save purposes


        public string getName() { return _name; }
        public void setName(string value) { _name = value; }
        public bool isDone() { return getStatus() == PERCENT_100; }
        public float getCoef() { return _coef; }
        public void setCoef(float value) { _coef = value; }
        public MyDayOfWeek getDay() { return _day; }
        public void setDay(MyDayOfWeek value) { _day = value; }
        public bool isDebted() { return _isDebted; }
        public void setDebtStatus(bool value) { _isDebted = value; }
        public bool isEmpty() { return false; }

        //---------------------------------------------------------------------------
        public Task(string name, float coef, MyDayOfWeek day) 
        {
            _day = day;
            _name = name; 
            _coef = coef;
        }

        //---------------------------------------------------------------------------
        public int getCoefLevel()
        {
            int res = 1;
            float val = _coef;
            if (val > 5 - DELTA)
                res = 5;
            else if (val > 4 - DELTA)
                res = 4;
            else if (val > 3 - DELTA)
                res = 3;
            else if (val > 2 - DELTA)
                res = 2;

            return res;
        }

        //---------------------------------------------------------------------------
        public Color getColor()
        {
            Color res = Color.Black;
            int coefClass = getCoefLevel();

            switch (coefClass)
            {
                case 1: res = Color.Orange; break;
                case 2: res = Color.LimeGreen; break;
                case 3: res = Color.Green; break;
                case 4: res = Color.Blue; break;
                case 5: res = Color.Navy; break;
            }

            return res;
        }

        //---------------------------------------------------------------------------
        public void commonChangeData(Task t)
        {
            setName(t.getName());
            setCoef(t.getCoef());
            setDebtStatus(t.isDebted());
        }
    }
}
