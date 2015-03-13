using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.Collections;

namespace ModelNS
{
    /// <summary>
    /// Веедённые за день данные (пока только факт ввода данных)
    /// </summary>
    public class DayInput : ISaved
    {
        const int _version = 1; 

        int _id;

        public DayInput()
        {
            _id = Model.getCurId();
        }

        public DayInput(DateTime date)
        {
            _id = Model.getCurId();
            Date = date;
        }

        public DateTime Date { get; set; }

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
            return (int)ItemType.DAY_INPUT;
        }
    }
}
