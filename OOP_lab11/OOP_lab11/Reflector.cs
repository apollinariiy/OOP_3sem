using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace OOP_lab11
{
    static class Reflector
    {
        static public void GetName(object obj)                         // Определение имени сборки, в которой определен класс
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(obj.ToString());
            Assembly assembly1 = type.Assembly;

            Console.WriteLine($" Name: {assembly1.FullName}\n CodeBase: {assembly1.CodeBase} \n");
        }

        static public void GetConstructors(object obj)                  // есть ли публичные конструкторы
        {
            ConstructorInfo[] constructorInfo = Type.GetType(obj.ToString()).GetConstructors();
            if (constructorInfo.Length > 0)
                Console.WriteLine("Конструкторы есть!\n");
            else Console.WriteLine("Конструкторов нет(\n");
        }

        static public void GetMethod(object obj)                        // извлекает все общедоступные публичные методы класса
        {
            Type type = Type.GetType(obj.ToString());
            foreach (MethodInfo methodInfo in type.GetMethods())
                Console.WriteLine(methodInfo.Name);
            Console.WriteLine("\n");

        }

        static public void GetField(object obj)                         // получает информацию о полях и свойствах класса
        {
            Type type = Type.GetType(obj.ToString());

            foreach (FieldInfo fieldInfo in type.GetFields())
                Console.WriteLine(fieldInfo);
            foreach (PropertyInfo propertyInfo in type.GetProperties())
                Console.WriteLine(propertyInfo);
        }

        static public void GetInterfece(object obj)                     // получает все реализованные классом интерфейсы 
        {
            Type type = Type.GetType(obj.ToString());

            foreach (Type interfaceMapping in type.GetInterfaces())
                Console.WriteLine(interfaceMapping);

        }

        static public void MethodForType(object obj, string parametr)   // выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра
        {
            Type type = Type.GetType(obj.ToString());
            MethodInfo[] methodInfo = type.GetMethods();
            Console.WriteLine($"Метод из класса: {obj} с параметрами :{parametr}");
            for (int i = 0; i < methodInfo.Length; i++)
            {
                ParameterInfo[] param = methodInfo[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (parametr == param[j].ParameterType.Name)
                        Console.WriteLine(methodInfo[i].Name);
                }
            }
        }


        static public void Invoke(string classname, string methode)         /* вызывает метод класса; для его параметров необходимо:
                                                                             * 1) прочитать из текстового файла (имя класса и имя метода передаются в качестве аргументов) */
        {
            Type type = Type.GetType(classname);
            List<string> list = File.ReadAllLines("D:\\3sem\\ООП\\лабы\\лр1\\OOP_3sem\\OOP_lab11\\OOP_lab11\\out.txt").ToList();
            List<string>[] list2 = new List<string>[] { list };
            try
            {
                object obj = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod(methode);
                Console.WriteLine(methodInfo.Invoke(obj, list2));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        public static void Create(string classname, string parm)        /* создает объект переданного типа (на основе имеющихся публичных конструкторов)
                                                                         * и возвращает его пользователю. */
        {
            Type type = Type.GetType(classname);
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            object obj = Activator.CreateInstance(type, args: parm);
            Console.WriteLine(obj.ToString());
        }
    }
}