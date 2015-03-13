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
        /// ����������� ������
        /// </summary>
        /// <param name="refArr">����������� ������ ������</param>   
        /// <param name="idArr">������ ���������������, �� ������� ���������� ���������� ������</param> 
        /// <param name="refs">������ ���� ��������, �� ������� ������������� ������</param>
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
                throw new Exception("������ �� ������!");
            return res;
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// ��������� ��������� �����������
        /// </summary>
        /// <param name="arrayList">�������� ������ ������</param>
        /// <param name="refs">������� ������ ������</param>
        /// <param name="br">�������� ��������� ������</param>
        internal static void setRefArray(ArrayList arrayList, ArrayList refs, BinaryReader br)
        {
            ArrayList idArr = readIdArray(br);
            CommonLoader.fillRefArr(arrayList, idArr, refs);
        }
    }
}
