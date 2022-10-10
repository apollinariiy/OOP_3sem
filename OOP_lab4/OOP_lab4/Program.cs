using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Car car = new Car("BMW", "Car");
            Car ccar = new Car("Audi", "Car");
            Motor motor = new Motor("BMW", "Car", "1000");
            Human human1 = new Human("Mers", "Car", "Лицензия", "Человек","Петя");
            Human human2 = new Human("Mers", "Car", "Лицензия", "Человек", "Катя");

            human1.ToString();
            //is
            object Is = new Human("Audi", "Car", "Лицензия", "Человек", "Вася");
            if (Is is Human)
            {
                Console.WriteLine("Объект принадлежит классу Human");
            }
            else
            {
                Console.WriteLine("Объект не принадлежит классу Human");
            }
            //as
            Trans As = car as Trans;
            if (As == null) Console.WriteLine("Преобразование прошло не успешно.");
            else As.ToString();

            ICloneable user1 = new User();
            user1.DoClone();
            BaseClone user2 = new User();
            user2.DoClone(false);

            if (car.Equals(ccar))
                Console.WriteLine("\nМашины идентичны\n");
            else Console.WriteLine("\nМашины не идентичны\n");

            Printer print = new Printer();
            Console.WriteLine(print.IAmPrinting(car));
            Console.WriteLine(print.IAmPrinting(human1));
        }
        
    }
}