using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using ModelNS.FieldNS;

namespace ModelNS.LoadNS
{
    class FieldTemplateLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии FieldTemplates");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        // added cur id for fields
        private object load_2(int id, BinaryReader br, ArrayList refs)
        {
            FieldTemplates res = new FieldTemplates();

            res.setItemId(id);
            CommonLoader.setRefArray(res.getFieldList(), refs, br);
            CommonLoader.setRefArray(res.getWeekList(), refs, br);
            FieldTemplates.setCurId(br.ReadInt32());

            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            FieldTemplates res = new FieldTemplates();

            res.setItemId(id);
            CommonLoader.setRefArray(res.getFieldList(), refs, br);
            CommonLoader.setRefArray(res.getWeekList(), refs, br);

            return res;
        }
    }
}
