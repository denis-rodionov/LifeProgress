using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.Collections;
using System.IO;
using ModelNS.TaskNS;

namespace ModelNS.LoadNS
{
    class TemplateTaskLoader : ILoader
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
                    throw new Exception("не найден загрузчик для данной версии TemplateTask");
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private object load_1(int id, BinaryReader br, ArrayList refs)
        {
            Task task = (Task)CommonLoader.findObjectById(br.ReadInt32(), refs);

            TemplateTask res = new TemplateTask(task);

            res.setItemId(id);
            CommonLoader.setRefArray(res.getInstances(), refs, br);

            return res;
        }
    }
}
