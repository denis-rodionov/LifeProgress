using System;
using System.Collections.Generic;
using System.Text;

namespace ModelNS.Interfaces
{
    interface ISaved
    {
        int getVersion();
        int getItemId();
        void setItemId(int value);
        int getItemType();
    }
}
