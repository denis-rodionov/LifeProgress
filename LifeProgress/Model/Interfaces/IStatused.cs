using System;
using System.Collections.Generic;
using System.Text;

namespace ModelNS.Interfaces
{
    interface IStatused
    {
        int getStatus();        // статус в процентах
        float getCoef();        // коэффициент важности задачи
        bool isEmpty();
    }
}
