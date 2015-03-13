using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.Exceptions;

namespace ModelNS.LoadNS
{
    class DebtListLoader : ILoader
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
                    throw new MyException("не найден загрузчик для данной версии DebtList");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            DebtList res = new DebtList();

            res.setItemId(id);
            CommonLoader.setRefArray(res.getArray(), refs, br);

            return res;
        }
    }
}
