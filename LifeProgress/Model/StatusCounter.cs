using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelNS.Interfaces;

namespace ModelNS
{
    class StatusCounter
    {
        //---------------------------------------------------------------------------
        public static int countStatus(ArrayList arr)
        {
            int total = 0;
            int cur = 0;

            foreach (IStatused item in arr)
            {
                if (!item.isEmpty())
                {
                    float coef = item.getCoef();
                    total += (int)(100 * coef);
                    cur += (int)(item.getStatus() * coef);
                }
            }

            if (total == 0) total = 100;
            if (cur > total) cur = total;

            return (int)(cur / (float)total * 100);
        }
    }
}
