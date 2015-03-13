using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manager;

namespace Model2
{
    public partial class FieldMap : IKeyAutogeneration
    {
        const string PK_GEN = "FieldMap";

        public int getPercentCoefficient()
        {
            return (int)Math.Round(Coefficient * 100);
        }

        public void setPercentCoefficient(int p)
        {
            Coefficient = (float)p / 100;
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
            if (model.CoefMapBundle.Count() == 0)
                return 0;
            else
                return model.CoefMapBundle.Select(fm => fm.ID).Max();
        }

        public override string ToString()
        {
            return "FieldMap: field = " + Field.Name + ", week = " + Week.Number;
        }
    }
}
