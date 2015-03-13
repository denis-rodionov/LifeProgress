using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public partial class LoggedWork : IKeyAutogeneration
    {
        const string PK_GEN = "LoggedWork";

        /// <summary>
        /// Logs work for specific task. Erase previous value; 
        /// </summary>
        /// <param name="value">Logged work in task units (percents for PercentTask)</param>
        public void logWork(int value, ModelEntities model)
        {
            if (Value != value)
            {
                int newWork = value - Value;
                if (newWork + Task.Current > Task.limit())
                {
                    Value += Task.limit() - Task.Current;
                    Task.Current = Task.limit();
                }
                else
                {
                    Value = value;
                    Task.Current += newWork;
                }
                model.SaveChanges();
            }            
        }

        public override string ToString()
        {
            return "LoggedWork: task = " + Task.Name + ", value = " + Value;
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
            if (model.LoggedWork.Count() == 0)
                return 0;
            else
                return model.LoggedWork.AsEnumerable().Last().ID;
        }
    }
}
