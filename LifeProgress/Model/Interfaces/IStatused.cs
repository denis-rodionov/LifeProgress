using System;
using System.Collections.Generic;
using System.Text;

namespace ModelNS.Interfaces
{
    interface IStatused
    {
        int getStatus();        // ������ � ���������
        float getCoef();        // ����������� �������� ������
        bool isEmpty();
    }
}
