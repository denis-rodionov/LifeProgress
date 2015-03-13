using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manager;

namespace Model2
{
    class KeyGenerator
    {
        const string DEBUG = "KeyGenerator";

        //static KeyGenerator _instance = null;
        static Dictionary<string, int> _initValues = new Dictionary<string,int>();

        //private KeyGenerator()
        //{
        //}

        //private static KeyGenerator getInstance()
        //{
        //    if (_instance == null)
        //        _instance = new KeyGenerator();
        //    return _instance;
        //}

        /// <summary>
        /// Creates new sequence connected with name 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="initValue">Pass here start sequence value</param>
        public static void createNewGenerator(string name, int initValue)
        {
            _initValues.Add(name, initValue);
            LogManager.Instance.log(DEBUG, name + " : new generator starts from " + initValue);
        }

        /// <summary>
        /// True if sequence connected with the name already exists
        /// </summary>
        public static bool exist(string name)
        {
            return _initValues.ContainsKey(name);
        }

        /// <summary>
        /// Returns current sequence value and makes increment
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int getNewValue(string name)
        {
            if (!_initValues.ContainsKey(name))
                throw new Exception("Call createNewGenerator for the name = " + name);

            int res = _initValues[name];
            _initValues[name]++;

            LogManager.Instance.log(DEBUG, name + " : new ID = " + res);

            return res;
        }
    }
}
