using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.Collections;
using System.IO;
using ModelNS.Exceptions;
using ModelNS.FieldNS;

namespace ModelNS.LoadNS
{
    class ModelLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии Model");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_3(int id, BinaryReader br, ArrayList refs)
        {
            Model res = Model.instance();

            res.setCurId(br.ReadInt32());
            res.setWeekList((WeekList)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setTemplates((Templates)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setFieldTemplates((FieldTemplates)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setDebtList((DebtList)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setSelWeek((Week)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setLastWeek((Week)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setWeekPart(br.ReadDouble());
            res.setInputData((InputData)CommonLoader.findObjectById(br.ReadInt32(), refs));

            return res;
        }

        //---------------------------------------------------------------------------
        private object load_2(int id, BinaryReader br, ArrayList refs)
        {
            Model res = Model.instance();

            //res.setItemId(id);
            res.setCurId(br.ReadInt32());
            res.setWeekList((WeekList)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setTemplates((Templates)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setFieldTemplates((FieldTemplates)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setDebtList((DebtList)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setSelWeek((Week)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setLastWeek((Week)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setWeekPart(br.ReadDouble());

            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            Model res = Model.instance();

            //res.setItemId(id);
            res.setCurId(br.ReadInt32());
            res.setWeekList((WeekList)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setTemplates((Templates)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setFieldTemplates((FieldTemplates)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setDebtList((DebtList)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setSelWeek((Week)CommonLoader.findObjectById(br.ReadInt32(), refs));
            res.setLastWeek((Week)CommonLoader.findObjectById(br.ReadInt32(), refs));

            return res;
        }
    }
}
