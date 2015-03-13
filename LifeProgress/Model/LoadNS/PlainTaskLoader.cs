using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.TaskNS;

namespace ModelNS.LoadNS
{
    class PlainTaskLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии PlainTask");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        // isDebted
        private object load_2(int id, BinaryReader br, ArrayList refs)
        {
            bool isDone = br.ReadBoolean();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());

            PlainTask res = new PlainTask(name, coef, day);
            res.setDone(isDone);
            res.setItemId(id);
            res.setDebtStatus(br.ReadBoolean());
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            bool isDone = br.ReadBoolean();
            float coef = (float)br.ReadDouble();
            string name = br.ReadString();
            MyDayOfWeek day = new MyDayOfWeek(br.ReadInt32());

            PlainTask res = new PlainTask(name, coef, day);
            res.setDone(isDone);
            res.setItemId(id);
            return res;
        }
    }
}
