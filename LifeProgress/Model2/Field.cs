using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public partial class Field : IKeyAutogeneration
    {
        const string PK_GEN = "Field";

        ///// <summary>
        ///// Progress of the week (double value 0..1)
        ///// </summary>
        //public double getProgress()
        //{
        //    if (Tasks.Count() == 0)
        //        return 0;

        //    double res = 0;
        //    double coefSum = 0;
        //    foreach (Task t in Tasks)
        //    {
        //        res += t.Coefficient * t.getProgress();
        //        coefSum += t.Coefficient;
        //    }
        //    return res / coefSum;
        //}

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
            if (model.Field.Count() == 0)
                return 0;
            else
                return model.Field.AsEnumerable().Last().ID;
        }

        public override string ToString()
        {
            return "Field: " + Name;
        }
    }
}
