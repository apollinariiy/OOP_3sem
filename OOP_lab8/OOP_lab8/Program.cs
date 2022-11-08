using System;
using System.Security.Principal;

namespace OOP_lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Director worker = new Director("Director", 1000);
            Director worker1 = new Director("Student", 100);
            Director worker2 = new Director("Programmer", 1500);
            Director worker3 = new Director("Electrician", 500);
            Director worker4 = new Director("Builder", 600);

            
            Console.WriteLine("\n--------------------------Cобытия--------------------------\n");


            //объект подписан на два события
            worker2.increase += message => Console.WriteLine(message); //Установка в качестве обработчика лямбда-выражения
            worker2.fine += message => Console.WriteLine(message);
            worker.increase += message => Console.WriteLine(message); 
            worker.fine += message => Console.WriteLine(message);

            //объект подписан на одно событие
            worker1.fine += message => Console.WriteLine(message);
            worker3.increase += message => Console.WriteLine(message);

            //для объекта worker2 вызываются оба события
            worker2.IncreaseSalary(200);
            worker2.FineSalary(100);
            
            worker.FineSalary(500);
            worker.IncreaseSalary(10);

            //для объекта worker1 вызывается только одно событие
            worker1.FineSalary(10);

            worker3.IncreaseSalary(300);

            Console.WriteLine("\n--------------------------Состояние объектов после наступления событий--------------------------\n");
            worker.ToString();
            worker1.ToString();
            worker2.ToString();
            worker3.ToString();
            worker4.ToString();
            Console.ReadKey();

/*            void DisplayMessage(string message) => Console.WriteLine(message);//обработчик*/
           


        }
    }
}
