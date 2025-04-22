using System;
using System.Collections.Generic;
using System.Text;

namespace ООП10Library
{
    public class ClassNotHierarchy: IInit
    {
        string init;
        void IInit.Init()
        {
            Console.Write("Введите строку для Init: ");
            init = "Инициализация класса не из иерархии " + UserInput.InputString();
        }
        void IInit.RandomInit()
        {
            Random random = new Random();
            init = "Инициализация класса не из иерархии " + random.Next(0,10);
        }
        public override string ToString()
        {
            return init;
        }
    }
}
