using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab11
{
    public class Object { }
    class Program
    {
        static void Main(string[] args)
        {
            
            Program program = new Program();
            Console.WriteLine("\n--------------------------------- Reflector for class Test ---------------------------------\n");
            Console.WriteLine("\t---- СБОРКА: ----");
            Reflector.GetName("OOP_lab11.Test");
            Console.WriteLine("\t---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("OOP_lab11.Test");
            Console.WriteLine("\t---- МЕТОДЫ: ----");
            Reflector.GetMethod("OOP_lab11.Test");
            Console.WriteLine("\t---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("OOP_lab11.Test");
            Console.WriteLine("\t---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterfece("OOP_lab11.Test");
            Console.WriteLine();
            Console.WriteLine("\t---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("OOP_lab11.Test", "String");
            Console.WriteLine();
           

            Console.WriteLine("\n\n--------------------------------- Reflector for class Trans ---------------------------------\n");
            Console.WriteLine("\t---- СБОРКА: ----");
            Reflector.GetName("OOP_lab11.Trans");
            Console.WriteLine("\t---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("OOP_lab11.Trans");
            Console.WriteLine("\t---- МЕТОДЫ: ----");
            Reflector.GetMethod("OOP_lab11.Trans");
            Console.WriteLine("\t---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("OOP_lab11.Trans");
            Console.WriteLine("\t---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterfece("OOP_lab11.Trans");
            Console.WriteLine("\t---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("OOP_lab11.Trans", "String");
            Console.WriteLine();

            Console.WriteLine("\n\n--------------------------------- Reflector for class Human ---------------------------------\n");
            Console.WriteLine("\t---- СБОРКА: ----");
            Reflector.GetName("OOP_lab11.Human");
            Console.WriteLine("\t---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("OOP_lab11.Human");
            Console.WriteLine("\t---- МЕТОДЫ: ----");
            Reflector.GetMethod("OOP_lab11.Human");
            Console.WriteLine("\t---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("OOP_lab11.Human");
            Console.WriteLine("\t---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterfece("OOP_lab11.Human");
            Console.WriteLine("\t---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("OOP_lab11.Human", "String");
            Console.WriteLine();

            Console.WriteLine("\n\n--------------------------------- Reflector for System.Object ---------------------------------\n");
            Console.WriteLine("\t---- СБОРКА: ----");
            Reflector.GetName("OOP_lab11.Object");
            Console.WriteLine("\t---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("System.Object");
            Console.WriteLine("\t---- МЕТОДЫ: ----");
            Reflector.GetMethod("System.Object");
            Console.WriteLine("\t---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("System.Object");
            Console.WriteLine("\t---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterfece("System.Object");
            Console.WriteLine("\t---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("System.Object", "String");
            Console.WriteLine();

            Reflector.InfoToFile("OOP_lab11.Test");
            Reflector.InfoToFile("OOP_lab11.Human");
            Reflector.InfoToFile("OOP_lab11.Trans");

            Console.WriteLine("\t---- СЧИТЫВАНИЕ ИНФОРМАЦИИ  ИЗ ФАЙЛА: ----");
            Reflector.Invoke("OOP_lab11.Test", "Toconsole");
            Console.WriteLine();
            Console.WriteLine("\t---- СОЗДАНИЕ ОБЪЕКТА ПЕРЕДАННОГО ТИПА: ----");
            Reflector.Create("OOP_lab11.Test", "Polina");


        }
    }
}