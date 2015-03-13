using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Model2
{
    public class MyDayOfWeek
    {
        const int UNDEF = 0;

        int _id;            

        //---------------------------------------------------------------------------
        public MyDayOfWeek()
        {
            _id = UNDEF;
        }

        //---------------------------------------------------------------------------
        public MyDayOfWeek(int id)
        {
            _id = id;
        }

        //---------------------------------------------------------------------------
        public MyDayOfWeek(DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Sunday: _id = 7; break;
                default: _id = (int)dow; break;
            }
        }

        //---------------------------------------------------------------------------
        public override string ToString()
        {
            string res = "";
            switch (_id)
            {
                case 1:
                    res = "�����������";
                    break;
                case 2:
                    res = "�������";
                    break;
                case 3:
                    res = "�����";
                    break;
                case 4:
                    res = "�������";
                    break;
                case 5:
                    res = "�������";
                    break;
                case 6:
                    res = "�������";
                    break;
                case 7:
                    res = "�����������";
                    break;
                default:
                    res = "�� ����������";
                    break;
            }
            return res;
        }

        //---------------------------------------------------------------------------
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //---------------------------------------------------------------------------
        public bool isUndef() { return _id == UNDEF; }
        //---------------------------------------------------------------------------
        public void setUndef() { _id = UNDEF; }

        //---------------------------------------------------------------------------
        public static MyDayOfWeek [] genAllList()
        {
            MyDayOfWeek[] res = new MyDayOfWeek[8];
            for (int i = 0; i < res.Length; i++)
                res[i] = new MyDayOfWeek(i);
            return res;
        }

        //---------------------------------------------------------------------------
        public static MyDayOfWeek undefDay() { return new MyDayOfWeek(UNDEF); }

        //---------------------------------------------------------------------------
        public static bool operator ==(MyDayOfWeek d1, MyDayOfWeek d2)
        {
            return d1._id == d2._id;
        }

        //---------------------------------------------------------------------------
        public static bool operator !=(MyDayOfWeek d1, MyDayOfWeek d2)
        {
            return !(d1 == d2);
        }

    }
}
