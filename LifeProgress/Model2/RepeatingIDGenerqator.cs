using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    class RepeatingIDGenerqator
    {
        static int _current = 0;

        public static int next(ModelEntities model)
        {
            if (_current == 0)
                _current = getLastID(model);
            return ++_current;
        }

        private static int getLastID(ModelEntities model)
        {
            int res = 0;
            foreach (Task t in model.Task)
                if (t.RepeatingID.HasValue && t.RepeatingID.Value > res)
                    res = t.RepeatingID.Value;
            return res;
        }
    }
}
