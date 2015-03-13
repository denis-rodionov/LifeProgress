using System;
using System.Collections.Generic;
using System.Text;

namespace Model2
{
    public class MyException : Exception
    {
        // consts
        public const int TEXT = 0;
        public const int UNIMPLEMENTED = 1;

        // attributes
        int _type;

        //---------------------------------------------------------------------------
        public MyException(int type) : base(getMessage(type))
        {
            _type = type;
        }

        //---------------------------------------------------------------------------
        public MyException(string text) : base(text)
        {
            _type = TEXT;
        }

        //---------------------------------------------------------------------------
        public static string getMessage(int type)
        {
            string res = "";
            switch (type)
            {
                case UNIMPLEMENTED: res = "Нереализованный код"; break;
            }
            return res;
        }
    }
}
