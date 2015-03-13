using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace ModelNS.Interfaces
{
    interface ILoader
    {
        /// <summary>
        /// �������� �������� ���������� ������
        /// </summary>
        /// <param name="id"></param>
        /// id ������� ��� ��������� ����������� (��� �������� � ������ ���� �������� ��������� �������)
        /// <param name="br"></param>
        /// �������� �������� ������
        /// <param name="ver"></param>
        /// ������ ��������� �������
        /// <param name="refs"></param>
        /// ������ �������� �� ������� ����� ������������� ������
        /// <returns></returns>
        object load(int id, BinaryReader br, int ver, ArrayList refs);
    }
}
