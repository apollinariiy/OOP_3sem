using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10
{
    class Program
    {
        static void Main(string[] args)
            
        {
            //ЗАДАНИЕ 1
            string[] months = { "December", "January", "February", "March", "April", "May", "September", "October", "November", "June", "July", "August", };

            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nПоследовательность месяцев с длиной строки равной n:");
            var monthsWithNLength = from m in months
                                    where m.Length == n
                                    select m;
            foreach (var m in monthsWithNLength)
            {
                Console.WriteLine(m);
            }
            
            Console.WriteLine("\nЗапрос возвращающий только летние и зимние месяцы:");
            var summerAndWinterMonths = from m in months
                                        where Array.IndexOf(months, m) < 3  || Array.IndexOf(months, m) > 8
                                        select m;
            foreach (var m in summerAndWinterMonths)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос вывода месяцев в алфавитном порядке:");
            var monthsInAlphabetOrder = from m in months
                                        orderby m
                                        select m;
            foreach (var m in monthsInAlphabetOrder)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х:");
            var monthsWithU = from m in months
                              where (m.Contains("u") || m.Contains("U")) && m.Length >= 4
                              select m;
            foreach (var m in monthsWithU)
            {
                Console.WriteLine(m);
            }


        }
    }
}