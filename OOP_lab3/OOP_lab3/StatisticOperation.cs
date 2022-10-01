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
    }
}