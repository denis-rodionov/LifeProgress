using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;

namespace ModelNS.LoadNS
{
    class DayInputLoader : ILoader
    {
        object ILoader.load(int id, BinaryReader br, int ver, ArrayList refs)
        {
            object res = null;
            switch (ver)
            {
                case 1:
                    res = load_1(id, br, refs);
                    break;
                default:
                    throw new Exception("не найден загрузчик для данной версии DayInputLoader");
            }
            return res;
        }

        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            int day = br.ReadInt32();
            int month = br.ReadInt32();
            int year = br.ReadInt32();

            DayInput res = new DayInput();
            res.Date = new DateTime(year, month, day);
            res.setItemId(id);

            return res;
        }
    }
}
