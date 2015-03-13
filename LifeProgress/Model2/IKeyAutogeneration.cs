using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public class Consts
    {
        public const string DEBUG_FILE = "PK";
    }

    interface IKeyAutogeneration
    {
        /// <summary>
        /// Generate and assign new primary key for the entity 
        /// </summary>
        void generateKey(ModelEntities model);

        int getLastID(ModelEntities model);
    }
}
