using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using ModelNS.Exceptions;
using System.IO;
using System.Collections;
using ModelNS.TaskNS;
using ModelNS.FieldNS;

namespace ModelNS.SaverNS
{
    class Saver
    {
        const int _version = 3;
        

        //---------------------------------------------------------------------------
        public Saver()
        {
        }

        //---------------------------------------------------------------------------
        public void saveModel(Model mod, string fName)
        {
            if (mod.getVersion() != getVersion())
                throw new WrongVersionException("Не удалось сохранить (модуль Saver имеет более младшую версию)"); 

            lock (fName)
            {
                FileStream fs = new FileStream(fName, FileMode.Create);
                BinaryWriter br = new BinaryWriter(fs);
                writeVersion(mod, br);
                writeTasks(mod, br);
                writeFields(mod, br);
                writeWeeks(mod, br);
                writeFieldTempaltes(mod, br);
                writeTaskTemplates(mod, br);
                writeWeekList(mod, br);
                writeDebtList(mod, br);
                writeDayData(mod, br);
                writeInputData(mod, br);
                writeModelData(mod, br);                                

                br.Close();
                fs.Close();
            }
        }

        //---------------------------------------------------------------------------
        private void writeDayData(Model mod, BinaryWriter br)
        {
            ArrayList arr = mod.getInputData().getAllDayInput();
            foreach (DayInput di in arr)
                ItemSaver.saveItem(di, br);
        }

        //---------------------------------------------------------------------------
        private void writeInputData(Model mod, BinaryWriter br)
        {
            ItemSaver.saveItem(mod.getInputData(), br);
        }

        //---------------------------------------------------------------------------
        private void writeDebtList(Model mod, BinaryWriter br)
        {
            ItemSaver.saveItem(mod.getDebts(), br);
        }

        //---------------------------------------------------------------------------
        private void writeWeekList(Model mod, BinaryWriter br)
        {
            ItemSaver.saveItem(mod.getWeeks(), br);
        }

        //---------------------------------------------------------------------------
        private void writeVersion(Model mod, BinaryWriter br)
        {
            br.Write(mod.getVersion());
        }

        //---------------------------------------------------------------------------
        private void writeTasks(Model mod, BinaryWriter br)
        {
            ArrayList tasks = mod.getWeeks().getAllTasks();
            tasks.AddRange(mod.getTemplates().getAllTasks());
            tasks.AddRange(mod.getDebts().getArray());

            foreach (Object ob in tasks)
                if (ob is NumberTask)
                    ItemSaver.saveItem((NumberTask)ob, br);
                else if (ob is PlainTask)
                    ItemSaver.saveItem((PlainTask)ob, br);
                else if (ob is PercentTask)
                    ItemSaver.saveItem((PercentTask)ob, br);
        }

        ////---------------------------------------------------------------------------
        //private void writeNumberTasks(ArrayList tasks, BinaryWriter br)
        //{
            
        //}

        ////---------------------------------------------------------------------------
        //private void writePlainTasks(ArrayList tasks, BinaryWriter br)
        //{
        //    foreach (Object ob in tasks)
        //        if (ob is PlainTask)
        //            ItemSaver.saveItem((PlainTask)ob, br);
        //}

        ////---------------------------------------------------------------------------
        //private void writePercentTasks(ArrayList tasks, BinaryWriter br)
        //{
        //    foreach (Object ob in tasks)
        //        if (ob is PercentTask)
        //            ItemSaver.saveItem((PercentTask)ob, br);
        //}

        //---------------------------------------------------------------------------
        private void writeFields(Model mod, BinaryWriter br)
        {
            ArrayList fields = mod.getWeeks().getAllFields();
            fields.AddRange(mod.getFieldTemplates().getFieldList());

            foreach (Object ob in fields)
                if (ob is WeekField)
                    ItemSaver.saveItem((WeekField)ob, br);
                else if (ob is WorkField)
                    ItemSaver.saveItem((WorkField)ob, br);
        }

        //---------------------------------------------------------------------------
        private void writeWeeks(Model mod, BinaryWriter br)
        {
            ArrayList weeks = mod.getWeeks().getAllWeeks();
            foreach (Week w in weeks)
                ItemSaver.saveItem(w, br);
        }

        //---------------------------------------------------------------------------
        private void writeFieldTempaltes(Model mod, BinaryWriter br)
        {
            ItemSaver.saveItem(mod.getFieldTemplates(), br);
        }

        //---------------------------------------------------------------------------
        private void writeTaskTemplates(Model mod, BinaryWriter br)
        {
            Templates temp = mod.getTemplates();
            foreach (TemplateTask t in temp.getArray())
                ItemSaver.saveItem(t, br);
            ItemSaver.saveItem(temp, br);
        }

        //---------------------------------------------------------------------------
        private void writeModelData(Model mod, BinaryWriter br)
        {
            ItemSaver.saveItem(mod, br);
        }

        //---------------------------------------------------------------------------
        public int getVersion() { return _version; }
    }
}
