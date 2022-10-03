using Lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    static class StatisticOperations
    {
        public static int sum(this Massiv array)
        {
            int sum = 0;
            for (int i = 0; i < array.massiv.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        public static int max(this Massiv array)
        {
            int max = array[0];
            for (int i = 0; i < array.massiv.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
        public static int min(this Massiv array)
        {
            int min = array[0];
            for (int i = 0; i < array.massiv.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
        public static int delta(this Massiv array)
        {
            return array.max() - array.min();
        }
        public static int size(this Massiv array)
        {
            return array.massiv.Length;
        }


        //методы расширения

        public static Massiv DeleteMinus(this Massiv array)
        {
            int count = 0;
            int j = 0;
            foreach (int i in array.massiv) 
            {
                if(i < 0)
                {
                    count++;
                }

            }

            Massiv newArr = new Massiv(array.size() - count);
            for (int i = 0; i < array.massiv.Length; i++)
            {
                if (array.massiv[i] > 0)
                {
                    if (i > 0 && newArr.massiv[i - 1] == array.massiv[i]) { }
                    else
                        newArr.massiv[i] = array.massiv[i];
                }
                else if (array.massiv[i] < 0)
                {
                    newArr.massiv[i] = array.massiv[i + 1];

                }
            }
            return newArr;
        }

        public static void Symbol(this Massiv array, string c)
        {
            int index = array.str.IndexOf(c);
            if (index == -1)
                Console.WriteLine("6.2)Методы расширения - проверка на содержание определённого символа в строке. Такого символа нет в строке!");
            else Console.WriteLine("\"6.2)Методы расширения - проверка на содержание определённого символа в строке. Символ " + c + " присутсвует в строке под индексом " + index);
        }
    } 
    }
