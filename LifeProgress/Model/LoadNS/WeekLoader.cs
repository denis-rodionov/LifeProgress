using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.FieldNS;

namespace ModelNS.LoadNS
{
    class WeekLoader : ILoader
    {
        //---------------------------------------------------------------------------
        public object load(int id, BinaryReader br, int ver, ArrayList refs)
        {
            object res = null;
            switch (ver)
            {
                case 1:
                    res = load_1(id, br, refs);
                    break;
                default:
                    throw new Exception("не найден загрузчик для данной версии Week");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            int number = br.ReadInt32();
            int year = br.ReadInt32();

            Week res = new Week(Week.makeId(number, year), true);

            res.setItemId(id);
            res.SetWeekField((WeekField)CommonLoader.findObjectById(br.ReadInt32(), refs));
            CommonLoader.setRefArray(res.getWorkFields(), refs, br);

            return res;
        }
    }
}
