using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2.Factories
{
    public class WeekFactory
    {
        public static Week createFakeWeek(DateTime date)
        {
            return createFakeWeek(WeekWorker.getNumber(date), date.Year);
        }

        public static Week createFakeWeek(int number, int year)
        {
            Week res = new Week();
            res.Number = number;
            res.Year = year;
            return res;
        }

        /// <summary>
        /// Creates new week (current or future)
        /// </summary>
        /// <param name="time">date, when to create week</param>
        /// <returns>created week</returns>
        public static Week createNewWeek(DateTime time, ModelEntities model)
        {
            checkForPrevious(time);     // previous week cannot be created

            Week newWeek = new Week();
            newWeek.Year = time.Year;
            newWeek.Number = WeekWorker.getNumber(time);
            newWeek.Active = false;
            newWeek.generateKey(model);

            model.Week.AddObject(newWeek);
            model.SaveChanges();

            addFields(newWeek, model);
            addRepeatingTasks(newWeek, model);

            return newWeek;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void addRepeatingTasks(Week newWeek, ModelEntities model)
        {
            Week previousWeek = newWeek.findPreviousWeekInDB(model);
            if (previousWeek != null)
            {
                foreach (Task t in previousWeek.Tasks)
                    if (t.isRepeating())
                    {
                        Task newTask = t.Clone();
                        newTask.Current = 0;
                        newTask.Week = newWeek;
                        newTask.generateKey(model);
                        model.Task.AddObject(newTask);
                        newWeek.Tasks.Add(newTask);
                    }
                model.SaveChanges();
            }
        }

        /// <summary>
        /// Adds refferences to fields for created week (from previous week)
        /// </summary>
        private static void addFields(Week newWeek, ModelEntities model)
        {
            Week previousWeek = newWeek.findPreviousWeekInDB(model);
            if (previousWeek != null)
            {
                foreach (FieldMap fm in previousWeek.FieldMaps)
                    newWeek.addFieldReference(fm.Field, model);
            }
        }

        private static void checkForPrevious(DateTime time)
        {
            if (time.Year <= DateTime.Now.Year && WeekWorker.getNumber(time) < WeekWorker.getNumber(DateTime.Now))
                throw new Exception("we cannot create previous week");
        }
    }
}
