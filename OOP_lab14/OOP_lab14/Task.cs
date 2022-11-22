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

            using (StreamWriter sw = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\EvenOddNumbers.txt", false, System.Text.Encoding.Default))
            {
                for (var i = 1; i <= 12; i++)
                {
                    if (i % 2 == 0)
                    {
                        sw.WriteLine(i);
                        Thread.Sleep(600);
                    }
                }
            }
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

            using (StreamWriter sw = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\EvenOddNumbers.txt", true, System.Text.Encoding.Default))
            {
                for (var i = 1; i <= 12; i++)
                {
                    if (i % 2 != 0)
                    {
                        sw.WriteLine(i);
                        Thread.Sleep(400);
                    }
                }
            }
            for (var i = 1; i <= 12; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(600);
                }
            }
        }

       /* public static void WriteData()
        {
            using (StreamWriter sw = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab14\EvenOddNumbers.txt", true, System.Text.Encoding.Default))
            {
                for (var i = 1; i <= 12; i++)
                {
                    if (i % 2 != 0)
                    {
                        sw.WriteLine(i);
                        Thread.Sleep(400);
                    }
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i + " четное");
                        Thread.Sleep(400);
                    }
                }

            }

        }*/


    }
   
}


