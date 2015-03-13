using System;
using System.Collections.Generic;
using System.Text;

namespace ModelNS
{
    public struct WeekInfo
    {
        public int WeekNumber;
        public bool IsCurrent;
        public int Year;
        public int WeekPercent;            // завершение недели в процентах
        public int Status;
    }
}
