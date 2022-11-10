using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using OOP_lab9;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            /// ===============  Инициализация экземпляров Car =================
            Car car1 = new Car("Mers", 4800);
            Car car2 = new Car("Nissan", 19000);
            Car car3 = new Car("BMW", 3900);
            Car car4 = new Car("Toyota", 16500);


            /// =========  Методы для работы с коллекцией (словарём)  ==========
            CarDictionary showRoom = new CarDictionary();
            showRoom.Add(1, car1);
            showRoom.Add(2, car2);
            showRoom.Add(3, car3);
            showRoom.Add(4, car4);
            showRoom.Remove(3);
            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n----------------------------Объекты слловаря:--------------------------------\n");
            showRoom.Print();
            Console.WriteLine("Резултат поиска объекта {0} в словаре:{1}\n", car3.Name, showRoom.Contains(car3));
        }
    }
}
