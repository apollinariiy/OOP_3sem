using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab14
{
    public static class Tasks
    {
        public static void Numbers()
        {
            Console.WriteLine("Введите n:");
            int n = int.Parse(Console.ReadLine());

            using (StreamWriter sw = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\numbers.txt", false, System.Text.Encoding.Default))
            {
                for (var i = 1; i <= n; i++)
                {
                    sw.WriteLine(i);
                    Thread.Sleep(300);
                }
            }

            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(300);

            }
        }
        public static void evenNumbers()
        {

            /*  using (StreamWriter sw = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\EvenOddNumbers.txt", false, System.Text.Encoding.Default))
              {
                  for (var i = 1; i <= 12; i++)
                  {
                      if (i % 2 == 0)
                      {
                          sw.WriteLine(i);
                          Thread.Sleep(600);
                      }
                  }
              }*/
            for (var i = 1; i <= 12; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " четное");
                    Thread.Sleep(400);
                }
            }

        }
        public static void oddNumbers()
        {

           /* using (StreamWriter sw = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\EvenOddNumbers.txt", true, System.Text.Encoding.Default))
            {
                for (var i = 1; i <= 12; i++)
                {
                    if (i % 2 != 0)
                    {
                        sw.WriteLine(i);
                        Thread.Sleep(400);
                    }
                }
            }*/
            for (var i = 1; i <= 12; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(600);
                }
            }
        }

        public static void Show(object obj)
        {
            Console.WriteLine("\n^.^");
        }



    }
    public static class Car
    {
        public static void Car1()
        {
            string path = @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\product.txt";
            int product = int.Parse(File.ReadAllText(path));

            while (product > 600) {
                product -= 100;
                File.WriteAllText(path, product.ToString());
                Console.WriteLine("Разгружает первая машина по 100: "+product + " товаров осталось");
                Thread.Sleep(1000);
                
            }
        }
        public static void Car2()
        {
            string path = @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\product.txt";
            int product = int.Parse(File.ReadAllText(path));

            while (product > 400)
            {
                product -= 50;
                File.WriteAllText(path, product.ToString());
                Console.WriteLine("Разгружает вторая машина по 50: " + product + " товаров осталось");
                Thread.Sleep(1000);

            }
        }
        public static void Car3()
        {
            string path = @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\product.txt";
            int product = int.Parse(File.ReadAllText(path));

            while (product > 0)
            {
                product -= 200;
                File.WriteAllText(path, product.ToString());
                Console.WriteLine("Разгружает третья машина по 200: " + product + " товаров осталось");
                Thread.Sleep(1000);

            }
            Console.WriteLine("Все товары разгружены");
        }
    }
}


