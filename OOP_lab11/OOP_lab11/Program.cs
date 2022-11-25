using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("\t---- СБОРКА: ----");
            Reflector.GetName("OOP_lab11.Test");
            Console.WriteLine("\t---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("OOP_lab11.Test");
            Console.WriteLine("\t---- МЕТОДЫ: ----");
            Reflector.GetMethod("OOP_lab11.Test");
            Reflector.GetMethod("OOP_lab11.Program");
            Console.WriteLine("\t---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("OOP_lab11.Test");
            Console.WriteLine("\t---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterfece("OOP_lab11.Test");
            Console.WriteLine();
            Console.WriteLine("\t---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("OOP_lab11.Test", "String");
            Console.WriteLine();
            Console.WriteLine("\t---- СЧИТЫВАНИЕ ИНФОРМАЦИИ  ИЗ ФАЙЛА: ----");
            Reflector.Invoke("OOP_lab11.Test", "Toconsole");
            Console.WriteLine();
            Console.WriteLine("\t---- СОЗДАНИЕ ОБЪЕКТА ПЕРЕДАННОГО ТИПА: ----");
            Reflector.Create("OOP_lab11.Test", "Kristina");
            Console.ReadKey();
        }
    }
}