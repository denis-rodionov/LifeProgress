using System;
using System.Collections.Generic;
using System.Text;

namespace ModelNS.Exceptions
{
    public class WrongVersionException : Exception
    {
        //---------------------------------------------------------------------------
        public WrongVersionException(string text) : base(text)
        {
        }
    }
}
