using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model2;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Data.Objects;
using Manager;

namespace Model2
{
    public partial class Week : IKeyAutogeneration
    {
        const string PK_GEN = "Week";

        /// <summary>
        /// Returns progress of the week (int value 0..100)
        /// </summary>
        public int getProgress()
        {
            if (FieldMaps.Count() == 0)
                return 0;

            double res = 0;
            float coefSum = 0;
            foreach (FieldMap f in FieldMaps)
                if (getTasks(f.Field).Count() != 0)
                {
                    res += f.Coefficient * getFieldProgress(f.Field);
                    coefSum += f.Coefficient;
                }

            if (res ==0)
                return 0;
            else
                return (int)Math.Round(res * 100 / coefSum);
        }

        private float getFieldProgress(Field field)
        {
            float res = 0;
            var tasks = Tasks.Where(t => t.Field.ID == field.ID);
            float coefSum = sumCoef(tasks);
            foreach (Task t in tasks)
                res += t.Coefficient * t.getProgress() / coefSum;
            return res;
        }

        private float sumCoef(IEnumerable<Task> tasks)
        {
            float sum = 0;
            foreach (Task t in tasks)
                sum += t.Coefficient;
            return sum;
        }

        public override string ToString()
        {
            return "Week: number " + Number + ", " + Year + " year";
        }

        /// <summary>
        /// Returns all days (days of week) when work was logged
        /// </summary>
        public IEnumerable<DayOfWeek> getFilledDays()
        {
            List<DayOfWeek> res = new List<DayOfWeek>();

            foreach (DayAchievement d in DayAchievements)
                res.Add(d.getDayOfWeek());

            return res;
        }

        /// <summary>
        /// Returns list of fields, refferenced from the week
        /// </summary>
        public IEnumerable<Field> getFields()
        {
            List<Field> res = new List<Field>();
            foreach (FieldMap fm in FieldMaps)
                res.Add(fm.Field);

            return res;
        }

        /// <summary>
        /// Returns list of tasks from specific field
        /// </summary>
        public IEnumerable<Task> getTasks(Field f)
        {
            List<Task> res = new List<Task>();
            foreach (Task t in Tasks)
                if (t.Field.ID == f.ID)
                    res.Add(t);

            return res;
        }

        /// <summary>
        /// Is it past week?
        /// </summary>
        public bool isOld()
        {
            return WeekWorker.isWeekPast(this);
        }

        /// <summary>
        /// Greater operator
        /// </summary>
        public static bool operator>(Week week1, Week week2)
        {
            return week1.isGreater(week2);
        }

        public bool isGreater(Week other)
        {
            if (Year > other.Year)
                return true;
            if (Year == other.Year && Number > other.Number)
                return true;

            return false;
        }


        /// <summary>
        /// Less operator
        /// </summary>
        public static bool operator <(Week week1, Week week2)
        {
            return week1.isLess(week2);    
        }

        public bool isLess(Week other)
        {
            if (Year < other.Year)
                return true;
            if (Year == other.Year && Number < other.Number)
                return true;

            return false;
        }

        public Color getTaskColor(Task task)
        {
            return WeekWorker.createColor(task.Coefficient);
        }

        /// <summary>
        /// Finds the newarest previous week, which exists in db
        /// </summary>
        public Week findPreviousWeekInDB(ModelEntities model)
        {
            Week res = null;
            foreach (Week w in model.Week)
                if (w < this)
                {
                    if (res == null)
                        res = w;
                    else if (w > res)
                        res = w;                         
                }
            return res;
        }

        private int yearPlusNumber()
        {
            return Year * 100 + Number;
        }

        /// <summary>
        /// Activates the week. Rise WeekActivated event or weekDeactivated, if necessary.
        /// Condition: field must be formed.
        /// </summary>
        public void activate(ModelEntities model)
        {
            //deactivatePrevious(model);
            _activate(model);
            _prepareCoefficients(model);

            EventProcessor.getInstance().onWeekActivated(this);
        }

        /// <summary>
        /// Deactivate the week
        /// </summary>
        public void deactivate(ModelEntities model)
        {
            Active = false;
            model.SaveChanges();
        }

        /// <summary>
        /// Copies coefficients from previous active week week and consider new fields.
        /// </summary>
        private void _prepareCoefficients(ModelEntities model)
        {
            if (FieldMaps.Count() == 0)
                return;

            Week prev = findPreviousWeekInDB(model);
            float normalCoef = 1 / FieldMaps.Count();           // sum = 1

            foreach (FieldMap fm in FieldMaps)
            {
                if (prev == null)
                    fm.Coefficient = normalCoef;     // equial coefficients (sum = 1)
                else if (prev.containsField(fm.Field))
                    fm.Coefficient = prev.getFieldMap(fm.Field.ID).Coefficient;
                else
                    fm.Coefficient = normalCoef;
            }
        }

        public FieldMap getFieldMap(int fieldID)
        {
            return FieldMaps.Where(fm => fm.Field.ID == fieldID).Single(); ;
        }

        private void _activate(ModelEntities model)
        {
            Active = true;
            model.SaveChanges();
        }

        /// <summary>
        /// Returns the first day of week
        /// </summary>
        public DateTime getWeekStart()
        {
            return WeekWorker.getWeekStartByNumber(Number, Year);
        }        

        public static bool operator==(Week operand1, Week operand2)
        {
            if ((object)operand1 == null && (object)operand2 == null)
                return true;
            else if ((object)operand1 == null || (object)operand2 == null)
                return false;
            else
                return operand1.Year == operand2.Year && operand1.Number == operand2.Number;
        }

        public static bool operator!=(Week operand1, Week operand2)
        {
            return !(operand1 == operand2);
        }

        public IEnumerable<Task> getRepeatingTasks()
        {
            return Tasks.Where(t => t.isRepeating());
        }

        /// <summary>
        /// Gets or creates DayAchievement for certain entity for certain date
        /// </summary>
        public DayAchievement getDayAchievement(DateTime date, ModelEntities model)
        {
            var res = DayAchievements.Where(da => da.Date.Date == date.Date);
            if (res.Count() == 0)
            {
                DayAchievement da = new DayAchievement();
                da.Date = date;
                da.ID_Week = ID;
                da.generateKey(model);
                model.DayAchievement.AddObject(da);
                model.SaveChanges();
                return da;
            }
            else
                return res.First();
        }

        /// <summary>
        /// Removes field refference from the task
        /// </summary>
        /// <param name="removingField"></param>
        public void removeFieldReference(Field field, ModelEntities model)
        {
            var fieldMap = this.FieldMaps.Where(fm => fm.Field.ID == field.ID);
            if (fieldMap.Count() == 1)
            {
                deleteTasks(field, model);
                model.DeleteObject(fieldMap.Single());
                if (isCurrent())
                    normalizeCoeficients();
                model.SaveChanges();
            }
            else
                throw new Exception("Internal error: future current week must have only one field");
        }

        public bool isCurrent()
        {
            return WeekWorker.isCurrent(this);
        }

        /// <summary>
        /// Deletes all tasks from the field
        /// </summary>
        public void deleteTasks(Field field, ModelEntities model)
        {
            List<Task> tasks = new List<Task>(Tasks.Where(t => t.ID_Field == field.ID));
            foreach (Task t in tasks)
            {
                t.deleteLoggedWork(model);
                model.Task.DeleteObject(t);
            }
            model.SaveChanges();
        }

        /// <summary>
        /// Adds field to week (refference)
        /// Creates the FieldMap entity with specific coefficient.
        /// </summary>
        /// <param name="field">Added field</param>
        /// <param name="model"></param>
        public void addFieldReference(Field field, ModelEntities model)
        {
            if (containsField(field))
                return;

            FieldMap fm = new FieldMap();
            fm.Field = field;
            fm.Coefficient = 0;
            fm.generateKey(model);
            FieldMaps.Add(fm);
            if (Active)             // current week
                _adaptCoefficients(fm);
            fm.Week = this;
            model.CoefMapBundle.AddObject(fm);
            model.SaveChanges();
        }

        // for addFieldRefference
        private void _adaptCoefficients(FieldMap fm)
        {
            if (FieldMaps.Count() == 1)
                fm.Coefficient = 1;
            else
            {
                fm.Coefficient = 1 / ((float)FieldMaps.Count() - 1);
                normalizeCoeficients();
            }
        }

        /// <summary>
        /// Normalize fields coefficients (sum = 1)
        /// </summary>
        public void normalizeCoeficients()
        {
            float coefSum = 0;
            foreach (FieldMap fm in FieldMaps)
                coefSum += fm.Coefficient;
            foreach (FieldMap fm in FieldMaps)
                fm.Coefficient = fm.Coefficient / coefSum;
        }

        /// <summary>
        /// Returns whether the week contains specific field
        /// </summary>
        public bool containsField(Field field)
        {
            return FieldMaps.Where(fm => fm.Field.ID == field.ID).Count() != 0;
        }

        /// <summary>
        /// Returns list of weeks following after this week
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public IEnumerable<Week> getFutureWeeksInDB(ModelEntities _model)
        {
            List<Week> res = new List<Week>();
            foreach (Week w in _model.Week)
                if (w > this)
                    res.Add(w);
            return res;
        }

        /// <summary>
        /// Creates copy of the task, change task week to this week adds it to db
        /// </summary>
        public void addRepearingTask(Task task, ModelEntities model)
        {
            Task newOne = task.Clone();
            newOne.ID_Week = ID;
            newOne.Coefficient = task.Coefficient;
            newOne.generateKey(model);
            model.Task.AddObject(newOne);
            model.SaveChanges();
        }

        /// <summary>
        /// Deletes the task which repeats the parameter task in the current week.
        /// </summary>
        public void deleteRepeatingTask(Task task, ModelEntities model)
        {
            var res = Tasks.Where(t => t.RepeatingID == task.RepeatingID);
            if (res.Count() == 1)
            {
                model.Task.DeleteObject(res.Single());
                model.SaveChanges();
            }
        }

        public void deactivate()
        {
            Active = false;
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
            if (model.Week.Count() == 0)
                return 0;
            else
                return model.Week.AsEnumerable().Last().ID;
        }

        /// <summary>
        /// Returns percent of the week
        /// </summary>
        /// <returns>0..100</returns>
        public static int getWeekPercent(DateTime dateTime)
        {
            TimeSpan time = dateTime.TimeOfDay;
            int day = dateTime.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)dateTime.DayOfWeek - 1;
            return (int)((day * 24 + time.Hours) / (float)168 * 100);
        }
    }
}
