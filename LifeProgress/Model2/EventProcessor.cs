using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public class EventProcessor
    {
        static EventProcessor _instance = null;

        ModelEntities _model;

        private EventProcessor(ModelEntities model)
        {
            _model = model;
        }

        public static void createInstance(ModelEntities model)
        {
            lock ("EventHandler")
            {
                if (_instance == null)
                    _instance = new EventProcessor(model);
            }
        }

        public static EventProcessor getInstance()
        {
            if (_instance == null)
                throw new Exception("Call createInstance before");
            return _instance;
        }

        //--------------------------------------------------------------------------
        // Event handling

        /// <summary>
        /// Handles fieldRemoveEvent
        /// removes future and current tasks and refferences on the field
        /// </summary>
        /// <param name="removindField">Удаляемая область</param>
        public void onFieldRemoveHandler(Field removingField)
        {
            var weeks = _model.Week.Where(w => w.FieldMaps.Where(fm => fm.Field.ID == removingField.ID).Count() == 1);
            foreach (Week w in weeks)
                if (!w.isOld() && w.containsField(removingField))
                {
                    w.deleteTasks(removingField, _model);
                    w.removeFieldReference(removingField, _model);
                }
        }

        /// <summary>
        /// Handles fieldCreateEvent
        /// Adds refference to the field to all futher weeks after selected (or current)
        /// </summary>
        /// <param name="week"></param>
        public void onFieldCreatedHandler(Field newField, Week week)
        {
            Week nowWeek = WeekWorker.getCurrentWeek(_model);
            IEnumerable<Week> futherWeeks = _model.Week.Where(w => (w.Year == nowWeek.Year && w.Number >= nowWeek.Number)
                || (w.Year > nowWeek.Year));
            foreach (Week w in futherWeeks)
                if (w != week)
                    w.addFieldReference(newField, _model);
        }

        /// <summary>
        /// Handles event when task information has been changed.
        /// Must change according information in all future repeating tasks.
        /// </summary>
        public void onTaskChangedHandler(Task task)
        {
            if (!task.isRepeating())
                return;

            IEnumerable<Week> weeks = task.Week.getFutureWeeksInDB(_model);
            foreach (Week w in weeks)
            {
                var repTask = w.Tasks.Where(t => t.RepeatingID == task.RepeatingID);
                if (repTask.Count() != 0)
                    repTask.Single().changeData(task);
            }
        }

        /// <summary>
        /// Handles event when task has been created and added to db.
        /// Must add similar tasks for all future weeks in db.
        /// </summary>
        public void onTaskAddedHandler(Task task)
        {
            if (!task.isRepeating())
                return;

            IEnumerable<Week> weeks = task.Week.getFutureWeeksInDB(_model);
            foreach (Week w in weeks)
                w.addRepearingTask(task, _model);
        }

        /// <summary>
        /// Handles task delete event.
        /// Deltes all futher tasks, which repeats deleted task.
        /// </summary>
        public void onTaskDeletedHandler(Task task)
        {
            if (!task.isRepeating())
                return;

            IEnumerable<Week> weeks = task.Week.getFutureWeeksInDB(_model);
            foreach (Week w in weeks)
                w.deleteRepeatingTask(task, _model);
        }

        /// <summary>
        /// Handles event week activated (e.g. week become current)
        /// Deactivetes all other weeks
        /// </summary>
        public void onWeekActivated(Week week)
        {
            var activated = _model.Week.Where(w => w.ID != week.ID && w.Active);
            foreach (Week w in activated)
                w.deactivate();
        }

        //private static void deactivatePrevious(ModelEntities model)
        //{
        //    var past = model.Week.Where(w => w.Active);
        //    if (past.Count() == 1)
        //        past.Single().Active = false;
        //}
    }
}
