using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manager;

namespace Model2
{
    public partial class Task : IKeyAutogeneration
    {
        const string PK_GEN = "Task";

        /// <summary>
        /// Progress of the task (coefficient is not taken in account)
        /// </summary>
        /// <returns>double value (0..1)</returns>
        public virtual float getProgress()
        {
            return Current / (float)100;
        }

        /// <summary>
        /// Has task finished
        /// </summary>
        public virtual bool isDone()
        {
            return Current == 100;
        }

        public override string ToString()
        {
            return "Task: " + Name;
        }

        /// <summary>
        /// Create copy of the task
        /// </summary>
        public virtual Task Clone()
        {
            Task res = new PercentTask();
            res.Coefficient = Coefficient;
            res.Current = Current;
            res.RepeatingID = RepeatingID;
            res.Name = Name;
            res.IsDebted = IsDebted;
            res.ID_Field = ID_Field;
            res.ID_Week = ID_Week;
            res.ID = ID;

            return res;
        }

        public void taskChanged()
        {
            EventProcessor.getInstance().onTaskChangedHandler(this);
        }

        public void taskAdded()
        {
            EventProcessor.getInstance().onTaskAddedHandler(this);
        }

        public void taskDeleted()
        {
            EventProcessor.getInstance().onTaskDeletedHandler(this);
        }

        /// <summary>
        /// Find LoggedWork entity for the task
        /// </summary>
        /// <returns>null if not found</returns>
        public LoggedWork findLoggedWork(DateTime date)
        {
            var res = LoggedWork.Where(l => l.DayAchievement.Date.Date == date.Date);
            return res.Count() == 0 ? null : res.First();
        }

        /// <summary>
        /// Finds Logged work entity to the task.
        /// Created if not found
        /// </summary>
        /// <returns>LoggedWork in any case</returns>
        public LoggedWork getLoggedWork(DateTime date, ModelEntities model)
        {
            LoggedWork res = findLoggedWork(date);
            if (res == null)
            {
                res = new LoggedWork();
                res.ID_Task = ID;
                res.ID_DayAcievement = WeekWorker.getWeek(date, model).getDayAchievement(date, model).ID;
                res.Value = 0;
                res.generateKey(model);
                model.LoggedWork.AddObject(res);
                model.SaveChanges();
            }

            return res;
        }

        public bool isRepeating()
        {
            return RepeatingID != null;
        }

        public void changeData(Task task)
        {
            this.ID_Field = task.ID_Field;
            //this.ID_Week = task.ID_Week;
            this.IsDebted = task.IsDebted;
            this.Name = task.Name;
            this.RepeatingID = task.RepeatingID;
            this.Coefficient = task.Coefficient;
            this.Current = task.Current;
            if (task is NumberTask)
            {
                ((NumberTask)this).Norma = ((NumberTask)task).Norma;
                ((NumberTask)this).OnceADay = ((NumberTask)task).OnceADay;
                ((NumberTask)this).Unit = ((NumberTask)task).Unit;
            }
        }

        /// <summary>
        /// Returns list of future tasks in db, which repeats the current task.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> getRepeates(ModelEntities model)
        {
            return model.Task.Where(t => t.RepeatingID == RepeatingID && t.ID != ID);
        }

        /// <summary>
        /// Creates repeating ID by last repeatingID in DB + 1
        /// </summary>
        public static int? createRepeatingID(ModelEntities model)
        {
            return RepeatingIDGenerqator.next(model);
        }

        /// <summary>
        /// IKeyAutogeneration implementation
        /// </summary>
        public void generateKey(ModelEntities model)
        {
            if (!KeyGenerator.exist(PK_GEN))
                KeyGenerator.createNewGenerator(PK_GEN, getLastID(model) + 1);

            ID = KeyGenerator.getNewValue(PK_GEN);
        }

        public int getLastID(ModelEntities model)
        {
            if (model.Task.Count() == 0)
                return 0;
            else
                return model.Task.Select(t => t.ID).Max();
        }

        public void deleteLoggedWork(ModelEntities model)
        {
            List<LoggedWork> list = new List<LoggedWork>();
            list.AddRange(LoggedWork);
            foreach (LoggedWork lw in list)
                model.LoggedWork.DeleteObject(lw);
            model.SaveChanges();
        }

        public virtual int limit()
        {
            return int.MaxValue;
        }
    }
}
