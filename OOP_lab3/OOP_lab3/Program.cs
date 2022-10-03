using Lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_3.Massiv;

namespace OOP_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Massiv arr1 = new Massiv(5);
            arr1[0] = 5;
            arr1[1] = 6;
            arr1[2] = 7;
            arr1[3] = -111;
            arr1[4] = 500;

            Massiv arr2 = new Massiv(5);
            arr2[0] = 4;
            arr2[1] = 9;
            arr2[2] = -7;
            arr2[3] = 12;
            arr2[4] = -2;
          
            //перегрузка
            //*
            Massiv arr3 = arr2 * arr1;
            Console.WriteLine("1)Перегрузка оператора * - умножение массивов");
            arr3.Show();
            //true
           if(arr1)
            {
                Console.WriteLine("2)Массив arr1 вернул true");
            }
            else
            {
                Console.WriteLine("2)Массив arr1 вернул false");
            }
           //int()
            Console.WriteLine("3)Перегрузка оператора int() -операция приведения – - возвращает размер массива arr1: " + (int)arr1);
            //==
            if (arr1 == arr2)
            {
                Console.WriteLine("4)Перегрузка оператора == - проверка на равенство: arr1==arr2");
            }
            else {
                Console.WriteLine("4)Перегрузка оператора == - проверка на равенство: arr1!=arr2");
            }
            //>
            if (arr1 > arr2)
            {
                Console.WriteLine("5)Перегрузка оператора < - сравнение: arr1>arr2");
            }
            else
            {
                Console.WriteLine("5)Перегрузка оператора < - сравнение: arr1<arr2");
            }

            //методы расширения 
            //1
            Console.WriteLine("6.1)Методы расширения - удаление отрицательных элементов");
            Massiv PlusArr = new Massiv(5);
            PlusArr = arr1.DeleteMinus();
            PlusArr.Show();
            //2
            Massiv StrArr = new Massiv(6);
            StrArr.str = "String";
            string symbol = "S";
            StrArr.Symbol(symbol);

            Console.WriteLine("StatisticOperation:");
            Console.WriteLine("MAX:" + arr1.max());
            Console.WriteLine("MIN:" + arr1.min());
            Console.WriteLine("Delta:" + arr1.delta());
            Console.WriteLine("Size:" + arr1.size());

            Console.WriteLine("Date, Developer, Organization:");
            Developer ownerArr = new Developer(1, "Polina", "Developer");
            ownerArr.Show();

            Production prodArr = new Production(2, "LABA");
            prodArr.Show();

            Massiv.Date date = new Massiv.Date();
            date.showDate();
        }

        
    }
}
