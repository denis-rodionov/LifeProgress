using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.FieldNS;

namespace ModelNS.LoadNS
{
    class WorkFieldLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии WorkField");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int itemId, BinaryReader br, ArrayList refs)
        {
            int id = br.ReadInt32();
            string name = br.ReadString();

            WorkField res = new WorkField(name, id);

            res.setItemId(itemId);
            CommonLoader.setRefArray(res.getTaskList(), refs, br);

            return res;
        }
    }
}
