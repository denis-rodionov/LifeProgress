using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.TaskNS;

namespace ModelNS.LoadNS
{
    class NumberTaskLoader : ILoader
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
                case 3:
                    res = load_3(id, br, refs);
                    break;
                default:
                    throw new Exception("не найден загрузчик для данной версии NumberTask");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        // isDebted
        private object load_3(int id, BinaryReader br, ArrayList refs)
        {
            int cur = br.ReadInt32();
            string unit = br.ReadString();
            int max = br.ReadInt32();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());
            bool once = br.ReadBoolean();

            NumberTask res = new NumberTask(name, max, unit, coef, day, once);
            res.setCur(cur);
            res.setItemId(id);
            res.setDebtStatus(br.ReadBoolean());
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_2(int id, BinaryReader br, ArrayList refs)
        {
            int cur = br.ReadInt32();
            string unit = br.ReadString();
            int max = br.ReadInt32();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());
            bool once = br.ReadBoolean();

            NumberTask res = new NumberTask(name, max, unit, coef, day, once);
            res.setCur(cur);
            res.setItemId(id);
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            int cur = br.ReadInt32();
            string unit = br.ReadString();
            int max = br.ReadInt32();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());

            NumberTask res = new NumberTask(name, max, unit, coef, day, false);
            res.setCur(cur);
            res.setItemId(id);
            return res;
        }
    }
}
