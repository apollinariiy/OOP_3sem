/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_4
{
    interface ICloneable
    {
        bool DoClone();
    }
    abstract class BaseClone
    {
        public abstract bool DoClone(bool res);
    }
    class User : BaseClone, ICloneable
    {
        public bool DoClone()
        {
            Console.WriteLine("\nКлонирование прошло успешно!");
            return true;
        }

        public override bool DoClone(bool res)
        {
            if (res)
                Console.WriteLine("Почти одинаковые методы\nКлонировние так же прошло успешно");
            else Console.WriteLine("Почти одинаковые методы\nКлонировние прошло провально!");
            return res;
        }

    }
}*/