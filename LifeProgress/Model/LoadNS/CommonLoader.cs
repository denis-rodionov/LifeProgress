using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using ModelNS.Interfaces;

namespace ModelNS.LoadNS
{
    class CommonLoader
    {
        //---------------------------------------------------------------------------
        public static ArrayList readIdArray(BinaryReader br)
        {
            ArrayList res = new ArrayList();
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
                res.Add(br.ReadInt32());
            return res;
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// расстановка ссылок
        /// </summary>
        /// <param name="refArr">заполняемый массив ссылок</param>   
        /// <param name="idArr">массив идентификаторов, по которым необходимо установить ссылки</param> 
        /// <param name="refs">массив всех объектов, на которые устанавливаем ссылки</param>
        public static void fillRefArr(ArrayList refArr, ArrayList idArr, ArrayList refs)
        {
            foreach (int id in idArr)
                refArr.Add(findObjectById(id, refs));
        }

        //---------------------------------------------------------------------------
        public static object findObjectById(int id, ArrayList refs)
        {
            object res = null;
            foreach (ISaved item in refs)
                if (item.getItemId() == id)
                {
                    res = item;
                    break;
                }
            if (res == null)
                throw new Exception("Объект не найден!");
            return res;
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// установка ссылочной целостности
        /// </summary>
        /// <param name="arrayList">выходной массив ссылок</param>
        /// <param name="refs">входной массив ссылок</param>
        /// <param name="br">читатель выходного потока</param>
        internal static void setRefArray(ArrayList arrayList, ArrayList refs, BinaryReader br)
        {
            ArrayList idArr = readIdArray(br);
            CommonLoader.fillRefArr(arrayList, idArr, refs);
        }
    }
}
