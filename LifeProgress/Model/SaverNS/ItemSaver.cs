using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.TaskNS;
using System.IO;
using ModelNS.Interfaces;
using ModelNS.FieldNS;
using System.Collections;

namespace ModelNS.SaverNS
{
    class ItemSaver
    {
        //---------------------------------------------------------------------------
        private static void saveHeader(ISaved item, BinaryWriter br)
        {
            br.Write(item.getItemType());
            br.Write(item.getVersion());
            br.Write(item.getItemId());
        }

        //---------------------------------------------------------------------------
        private static void saveIdArray(ArrayList arr, BinaryWriter br)
        {
            br.Write(arr.Count);
            foreach (ISaved item in arr)
                br.Write(item.getItemId());
        }
        
        //---------------------------------------------------------------------------
        internal static void saveItem(NumberTask numberTask, BinaryWriter br)
        {
            saveHeader(numberTask, br);
            br.Write(numberTask.getCur());
            br.Write(numberTask.getUnit());
            br.Write(numberTask.getMaxCount());
            br.Write((double)numberTask.getCoef());
            br.Write(numberTask.getName());
            br.Write(numberTask.getDay().Id);
            br.Write(numberTask.isOnce());
            br.Write(numberTask.isDebted());
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(PlainTask plainTask, BinaryWriter br)
        {
            saveHeader(plainTask, br);
            br.Write(plainTask.isDone());
            br.Write((double)plainTask.getCoef());
            br.Write(plainTask.getName());
            br.Write(plainTask.getDay().Id);
            br.Write(plainTask.isDebted());
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(PercentTask percentTask, BinaryWriter br)
        {
            saveHeader(percentTask, br);
            br.Write(percentTask.getCur());
            br.Write((double)percentTask.getCoef());
            br.Write(percentTask.getName());
            br.Write(percentTask.getDay().Id);
            br.Write(percentTask.isDebted());
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(WeekField field, BinaryWriter br)
        {
            saveHeader(field, br);
            br.Write(field.getId());
            br.Write(field.getName());
            saveIdArray(field.getTaskList(), br);
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(WorkField field, BinaryWriter br)
        {
            saveHeader(field, br);
            br.Write(field.getId());
            br.Write(field.getName());
            saveIdArray(field.getTaskList(), br);
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(Week week, BinaryWriter br)
        {
            saveHeader(week, br);
            br.Write(week.getNumber());
            br.Write(week.getYear());
            br.Write(week.getWeekField().getItemId());  // weekField
            saveIdArray(week.getWorkFields(), br);          // arr work fields
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(FieldTemplates ft, BinaryWriter br)
        {
            saveHeader(ft, br);
            saveIdArray(ft.getFieldList(), br);         // fields list
            saveIdArray(ft.getWeekList(), br);          // week list
            br.Write(FieldTemplates.getCurIdWithoutInc());
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(Templates item, BinaryWriter br)
        {
            saveHeader(item, br);
            saveIdArray(item.getArray(), br);
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(TemplateTask item, BinaryWriter br)
        {
            saveHeader(item, br);
            br.Write(item.getTask().getItemId());       // task
            saveIdArray(item.getInstances(), br);       // instances
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(WeekList item, BinaryWriter br)
        {
            saveHeader(item, br);
            saveIdArray(item.getAllWeeks(), br);
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(Model item, BinaryWriter br)
        {
            saveHeader(item, br);
            br.Write(item.getCurIdWithoutInc());            // curId
            br.Write(item.getWeeks().getItemId());          // weekList
            br.Write(item.getTemplates().getItemId());      // templates
            br.Write(item.getFieldTemplates().getItemId()); // field templates
            br.Write(item.getDebts().getItemId());          // debts
            br.Write(item.getSelWeek().getItemId());        // selWeek
            br.Write(item.getLastWeek().getItemId());       // last week
            br.Write(item.getWeekPart());                   // week part
            br.Write(item.getInputData().getItemId());
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(DebtList item, BinaryWriter br)
        {
            saveHeader(item, br);
            saveIdArray(item.getArray(), br);
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(DayInput item, BinaryWriter br)
        {
            saveHeader(item, br);
            br.Write(item.Date.Day);
            br.Write(item.Date.Month);
            br.Write(item.Date.Year);
        }

        //---------------------------------------------------------------------------
        internal static void saveItem(InputData item, BinaryWriter br)
        {
            saveHeader(item, br);
            saveIdArray(item.getAllDayInput(), br);
        }
    }
}

