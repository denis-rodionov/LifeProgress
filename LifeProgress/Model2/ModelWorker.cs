using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public class ModelWorker
    {
        public static void clearDB(ModelEntities model)
        {
            List<object> all = new List<object>();
            all.AddRange(model.CoefMapBundle.AsEnumerable());
            all.AddRange(model.LoggedWork.AsEnumerable());
            all.AddRange(model.DayAchievement.AsEnumerable());
            all.AddRange(model.Task.AsEnumerable());
            all.AddRange(model.Week.AsEnumerable());
            all.AddRange(model.Field.AsEnumerable());
            foreach (object ob in all)
                model.DeleteObject(ob);
            model.SaveChanges();
        }
    }
}
