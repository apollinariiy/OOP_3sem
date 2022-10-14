using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
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
            Motor motor = new Motor("BMW", "легковая", 1000);
            Human human1 = new Human("Mers", "Грузовая","Человек", "Петя", 234567);
            Human human2 = new Human("Грузовая", "Mers", "Человек", "Андрей", 348791);
            car.ToString();
            motor.ToString();
            human2.ToString();
            
            
            //IS
            object Is = new Human("грузовая", "Mers", "Человек", "Андрей", 348791);
            if (Is is Human)
            {
                Console.WriteLine("Объект принадлежит классу Human");
            }
            else
            {
                Console.WriteLine("Объект не принадлежит классу Human");
            }
            //AS
            Trans As = car as Trans;
            if (As == null) Console.WriteLine("Преобразование прошло не успешно.");
            else As.ToString();

         
            //EQUALS
            if (human1.Equals(human2))
                Console.WriteLine("\nМашины идентичны\n");
            else Console.WriteLine("\nМашины не идентичны\n");
            
            //PRINTER
            Vehicle[] tech1 = { car, motor, human1 };  // массив, содержащий ссылки на разнотипные объекты классов
            Printer printer = new Printer();                        // создание объекта класса Printer
            foreach (var item in tech1)
            {
                Console.Write("Тип объекта: ");
                printer.IAmPrinting(item);
            }
            Console.ReadKey();
        }

    }
}
