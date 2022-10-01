using OOP_lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{

    public class Massiv
    {
        public int[] massiv;
        private int index;
        public int Index    //свойство класса
        {
            get { return index; }
        }
        public Massiv(int Index)        //конструктор класса
        {
            index = Index;
            massiv = new int[Index];
        }
        public int this[int NumOfElement]   //индексатор класса
        {
            get { return massiv[NumOfElement]; }

            set
            {
                if (NumOfElement <= this.Index + 1)
                {
                    massiv[NumOfElement] = value;
                }
                else
                {
                    Console.WriteLine("Долбаёб превысил количество!!!");
                }
            }
        }
        //перегрузка операторов 
        public static Massiv operator *(Massiv x, Massiv y)     //* - умножение массивов
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.massiv.Length; i++)
            {
                temp.massiv[i] = x.massiv[i] * y.massiv[i];
            }
            return temp;
        }
        public static bool operator >(Massiv x, Massiv y)     //> - сравнение массивов
        {
            if (StatisticOperations.sum(x) > StatisticOperations.sum(y))
                return true; 
            else
                return false;
        }
        public static bool operator <(Massiv x, Massiv y)     //< - сравнение массивов
        {
            if (StatisticOperations.sum(x) < StatisticOperations.sum(y))
                return true;
            else
                return false;
        }
        public static bool operator ==(Massiv x, Massiv y)     //== - сравнение массивов +
        {
            for (int i = 0; i < x.massiv.Length; i++) {
                if (x[i] != y[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(Massiv x, Massiv y)     //== - сравнение массивов -
        {
            for (int i = 0; i < x.massiv.Length; i++)
            {
                if (x[i] != y[i])
                    return true;
            }
            return false;
        }
        public static bool operator true(Massiv x)     //проверка на отрицательный элемент 
        {
 
            for (int i = 0; i < x.massiv.Length; i++)
            {
                if (x.massiv[i] < 0)
                    return false;
            }
            return true;
        }
        public static bool operator false(Massiv x)     //проверка на положительный элемент 
        {
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] > 0)
                    return true;
            }
            return false;
        }
        public static explicit operator int(Massiv x) //int() - операция приведения – - возвращает размер массива;
        {
            int count = 0;
            for (int i = 0; i < x.Index; i++)
            {
                count++;
            }
            return count;
        }
        public void Search(char symbol)    //поиск элемента по символу
        {
            for (int i = 0; i < Index; i++)
            {
                if (massiv[i] == symbol)
                    Console.WriteLine("Элемент найден:", i, " ", massiv[i]);
            }
        }
        public void DeleteMinus()    //удаление отрицательных элементов
        {
            for (int i = 0; i < Index; i++)
            {
                if (massiv[i] < 0)
                    massiv[i] = massiv[i + 1];
            }
        }
        public void Show()//вывод массива
        {
            for (int i = 0; i < massiv.Length; i++)
            {
                Console.WriteLine(massiv[i] + " ");
            }
        }
        public void enterData(params int[] ArrayData)
        {
            this.massiv = ArrayData;
        }

    }
}