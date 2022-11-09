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


            Console.WriteLine("\n--------------------------Обработка строки--------------------------\n");

            Func<string, string> test1;  //обобщенный делегат, второй параметр - возврат 
            Action<string> test2;       //не возвр значений
            Func<string, string> test3;
            Func<string, string> test4;
            Func<string, string> test5;

            //удаление знаков препинания
            test1 = str1 =>
            {
                char[] sign = { '.', ',', '!', '?', '-', ':' };
                for (int i = 0; i < str1.Length; i++)
                {
                    if (sign.Contains(str1[i]))
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                Console.WriteLine(str1);
                return str1;

            };

            //добавление
            test2 = delegate (string str2)   //анонимный метод
            {
                str2 += " World";
                Console.WriteLine(str2);
            };

            //удаление пробелов
            test3 = str3 =>
            {
                str3 = str3.Replace(" ", string.Empty);
                Console.WriteLine(str3);
                return str3;
            };

            //перевод в верхний регистр
            test4 = str4 =>
            {
                str4 = str4.ToUpper();
                Console.WriteLine(str4);
                return str4;
            };
            //перевод в нижний регистр
            test5 = str5 =>
            {
                str5 = str5.ToLower();
                Console.WriteLine(str5);
                return str5;
            };

            string str = "Hel?lo! Wor?ld";
            Console.WriteLine("Строка в начале: " + str);
            Console.WriteLine("Строки в конце: ");
            string s1, s2, s3;
            s1 = StringWork.RemoveS(str, test1);
            StringWork.AddToString(s1, test2);
            s2 = StringWork.RemoveSpaces(s1, test3);
            s3 = StringWork.Upper(s2, test4);
            StringWork.Lower(s3, test5);
        
 
            
        }
    }
}
