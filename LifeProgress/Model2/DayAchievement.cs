using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public partial class DayAchievement : IKeyAutogeneration
    {
        const string PK_GEN = "DayAchievement";

        public DayOfWeek getDayOfWeek()
        {
            return Date.DayOfWeek;
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
            if (model.DayAchievement.Count() == 0)
                return 0;
            else
                return model.DayAchievement.AsEnumerable().Last().ID;
        }

        public override string ToString()
        {
            return "DayAchievement: " + Date.DayOfWeek + ", week = " + Week.Number;
        }
    }
}
