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
        /// загрузка объекста конкретной версии
        /// </summary>
        /// <param name="id"></param>
        /// id объекта для ссылочной целостности (уже прочитан и должен быть присвоен выходному объекту)
        /// <param name="br"></param>
        /// читатель входного потока
        /// <param name="ver"></param>
        /// версия читаемого объекта
        /// <param name="refs"></param>
        /// массив обеъктов на которые можно устанавливать ссылки
        /// <returns></returns>
        object load(int id, BinaryReader br, int ver, ArrayList refs);
    }
}
