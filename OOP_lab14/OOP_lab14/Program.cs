using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using OOP_lab14;

namespace OOP_Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.

            Console.WriteLine("\n------------------------------Все запущенные процессы------------------------------\n");
            foreach (Process process in Process.GetProcesses())//Метод GetProcesses(): возвращает массив всех запущенных процессов
            {
                Console.WriteLine($"ID: {process.Id} | Name: {process.ProcessName} | Priority: {process.BasePriority} | Memory: {process.WorkingSet64}");
            }

            //ЗАДАНИЕ 2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки, загруженные в домен. Создайте новый домен. Загрузите туда сборку. Выгрузите домен.

            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"\n------------------------------Текущий домен------------------------------\n");
            Console.WriteLine($"Name: {domain.FriendlyName} \nBase Directory: {domain.BaseDirectory} \nConfiguration File: {domain.SetupInformation}");
            Assembly[] assemblies = domain.GetAssemblies();
            Console.WriteLine("All assemblies:");
            foreach (Assembly assembly in assemblies)
            {
                Console.WriteLine(assembly.GetName().Name);
            }

          /*  var newDomain = AppDomain.CreateDomain("Domain"); ??????
            newDomain.Load(Assembly.GetExecutingAssembly().GetName());//Creating and unloading AppDomains is not supported and throws an exception.??
            AppDomain.Unload(newDomain);*/

            //ЗАДАНИЕ 3. Создайте в отдельном потоке следующую задачу расчета.
            
            Thread threadNumber = new Thread(Tasks.Numbers);
            threadNumber.Start();
            Console.WriteLine($"\n------------------------------Информация о потоке------------------------------\n");
            Console.WriteLine($"Name: {threadNumber.Name} | Priority: {threadNumber.Priority} | ID: {threadNumber.ManagedThreadId} | Status: {threadNumber.ThreadState}");
            threadNumber.Join();

            //ЗАДАНИЕ 4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.


            Thread evenThread = new Thread(Tasks.evenNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;          
            evenThread.Start();             
            /*evenThread.Join();*///закоментировать для работы потоков вместе             

            Console.WriteLine();
            Thread oddThread = new Thread(Tasks.oddNumbers);
            oddThread.Priority = ThreadPriority.BelowNormal;
            oddThread.Start();
            oddThread.Join();

           





        }
    }
}
