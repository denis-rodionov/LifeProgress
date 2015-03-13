using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskLibrary
{
    /// <summary>
    /// Для заполнения выпадающего списка
    /// </summary>
    class ListItem
    {
        public ListItem(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
