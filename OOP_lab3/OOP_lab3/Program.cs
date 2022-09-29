using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
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
            set { massiv[NumOfElement] = value; }
        }
        //перегрузка операторов 
        public static Massiv operator *(Massiv x, Massiv y)     //* - умножение массивов
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.Index; i++)
                temp[i] = x[i] * y[i];
            return temp;
        }
        public static Massiv operator >(Massiv x, Massiv y)     //> - сравнение массивов
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.Index; i++)
                if (x[i] > y[i])
                    temp[i] = x[i];
                else
                    temp[i] = y[i];
            return temp;
        }
        public static Massiv operator <(Massiv x, Massiv y)     //< - сравнение массивов
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.Index; i++)
                if (x[i] < y[i])
                    temp[i] = x[i];
                else
                    temp[i] = y[i];
            return temp;
        }
        public static Massiv operator ==(Massiv x, Massiv y)     //== - сравнение массивов +
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.Index; i++)
                if (x[i] == y[i])
                    temp[i] = 1;
                else
                    temp[i] = 0;
            return temp;
        }
        public static Massiv operator !=(Massiv x, Massiv y)     //== - сравнение массивов -
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.Index; i++)
                if (x[i] != y[i])
                    temp[i] = 1;
                else
                    temp[i] = 0;
            return temp;
        }
        public static bool operator true(Massiv x)     //проверка на отрицательный элемент 
        {
            bool flag = false; ;
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] > 0)
                    flag = true;
            }
            return flag;
        }
        public static bool operator false(Massiv x)     //проверка на положительный элемент 
        {
            bool flag = false; ;
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] < 0)
                    flag = false;
            }
            return flag;
        }
        public static explicit operator int(Massiv x) //int() - операция приведения – - возвращает размер массива;
        {
            int count=0;
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
                    Console.WriteLine("Элемент найден:", i," ", massiv[i]);
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
    }
}