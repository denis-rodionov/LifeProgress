using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.Collections;
using System.Data.Linq;
using System.Data.Entity;
using System.Data;

namespace ModelNS
{
    public class InputData : ISaved
    {
        const int _version = 1;

        int _id;
        ArrayList _list = new ArrayList();  // DayInput

        //---------------------------------------------------------------------------
        public InputData()
        {
            _id = Model.getCurId();
        }

        public DayInput getDayInput(DateTime date)
        {
            foreach (DayInput di in _list)
                if (di.Date == date.Date)
                    return di;
            return null;
        }

        public void addDayInput(DayInput dayInput)
        {
            _list.Add(dayInput);
        }

        internal IEnumerable<DayInput> getDayInput(DateTime start, DateTime finish)
        {            
            List<DayInput> res = new List<DayInput>();
            foreach (DayInput di in _list)
                if (di.Date >= start && di.Date <= finish)
                    res.Add(di);
            
            return res;
        }

        public static IEnumerable<DayOfWeek> toDaysOfWeek(IEnumerable<DayInput> inputs)
        {
            List<DayOfWeek> res = new List<DayOfWeek>();
            foreach (DayInput d in inputs)
                res.Add(Week.getDayOfWeek(d.Date));

            return res;
        }

        public int getVersion()
        {
            return _version;
        }

        public int getItemId()
        {
            return _id;
        }

        public void setItemId(int value)
        {
            _id = value;
        }

        public int getItemType()
        {
            return (int)ItemType.INPUT_DATA;
        }

        public ArrayList getAllDayInput()
        {
            return _list;
        }
    }
}
