using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public partial class NumberTask : Task
    {
        public override float getProgress()
        {
            float res = (float)(Current) / (float)Norma;
            if (res > 1)
                res = 1;
            return res;
        }

        public override bool isDone()
        {
            return Norma == Current;
        }

        public override Task Clone()
        {
            NumberTask res = new NumberTask();
            res.Coefficient = Coefficient;
            res.Current = Current;
            res.RepeatingID = RepeatingID;
            res.Name = Name;
            res.IsDebted = IsDebted;
            res.ID_Field = ID_Field;
            res.ID_Week = ID_Week;
            res.ID = ID;

            res.Norma = Norma;
            res.OnceADay = OnceADay;
            res.Unit = Unit;

            return res;
        }
    }
}
