using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.TaskNS;

namespace ModelNS.LoadNS
{
    class PercentTaskLoader : ILoader
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
                case 2:
                    res = load_2(id, br, refs);
                    break;
                default:
                    throw new Exception("не найден загрузчик для данной версии PercentTask");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        // isDebted
        private object load_2(int id, BinaryReader br, ArrayList refs)
        {
            int cur = br.ReadInt32();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());

            PercentTask res = new PercentTask(name, coef, day);
            res.setCur(cur);
            res.setItemId(id);
            res.setDebtStatus(br.ReadBoolean());
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            int cur = br.ReadInt32();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());

            PercentTask res = new PercentTask(name, coef, day);
            res.setCur(cur);
            res.setItemId(id);
            return res;
        }
    }
}
