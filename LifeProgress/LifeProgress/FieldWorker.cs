using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model2;

namespace LifeProgress
{
    public class FieldWorker
    {
        /// <summary>
        /// Creates new field (or restores existing) 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="selWeek"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Field createFieldForWeek(string name, Week week, ModelEntities model)
        {
            Field res = getField(name, model);        // find or create
            week.addFieldReference(res, model);

            EventProcessor.getInstance().onFieldCreatedHandler(res, week);

            return res;
        }

        /// <summary>
        /// Gets field by name. If the field is not in DB,
        /// function creates it and add to DB
        /// </summary>
        /// <returns>not null</returns>
        private static Field getField(string name, ModelEntities model)
        {
            Field res;
            Field existing = findField(name, model);
            if (existing == null)
                res = _createNewField(name, model);
            else
                res = existing;
            return res;
        }

        private static Field _createNewField(string name, ModelEntities model)
        {
 	        Field res = new Field();
            res.Name = name;
            res.generateKey(model);
            model.Field.AddObject(res);
            model.SaveChanges();

            return res;
        } 

        public static Field findField(string name, ModelEntities model)
        {
            var res = model.Field.Where(f => f.Name == name);
            if (res.Count() == 1)
                return res.First();
            else
                return null;
        }

        //public static void removeFieldfromWeek(Field field, Week week, ModelEntities model)
        //{
        //    FieldMap fm = week.FieldMaps.Where(fm1 => fm1.Field.ID == field.ID).Single();
        //    model.CoefMapBundle.DeleteObject(fm);
        //    model.SaveChanges();
        //}
    }
}
