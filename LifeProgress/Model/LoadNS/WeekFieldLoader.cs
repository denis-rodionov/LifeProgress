using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using ModelNS.FieldNS;
using System.IO;
using System.Collections;

namespace ModelNS.LoadNS
{
    class WeekFieldLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии WeekField");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            WeekField res = new WeekField();
            res.setItemId(id);
            res.setId(br.ReadInt32());
            res.setName(br.ReadString());
            CommonLoader.setRefArray(res.getTaskList(), refs, br);
            return res;
        }
    }
}
