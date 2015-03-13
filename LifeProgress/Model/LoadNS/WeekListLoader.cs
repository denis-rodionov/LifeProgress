using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;

namespace ModelNS.LoadNS
{
    class WeekListLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии WeekList");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            WeekList res = new WeekList();
            res.setItemId(id);
            CommonLoader.setRefArray(res.getAllWeeks(), refs, br);
            return res;
        }
    }
}
