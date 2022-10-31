using OOP_lab7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab7
{//Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть.
    public interface ICollection<T>
    {
        public void enterData(List<T> list);
        public void addData(T element);
        public void printData();
        public void deleteData(T element);
    }
    public class CollectionType<T> : ICollection<T>
    {
        public List<T> list { get; set; }
        public CollectionType()
        {
            list = new List<T>();
        }
        public void enterData(List<T> list)
        {
            this.list = list;
        }
        public void addData(T element)
        {
            list.Add(element);
        }
        public void printData()
        {
            foreach (T element in this.list)
            {
                Console.Write(element + "\t");
            }
            Console.WriteLine("\n");
        }
        public void deleteData(T deleteEl)
        {
            list.Remove(deleteEl);
        }


        //ПЕРЕГРУЗКИ
        //Класс - Одномерный массив. Дополнительно перегрузить следующие операции:
        //* - умножение массивов; true - истина если массив не сдержит отрицательных элементов,
        //int() - операция приведения – - возвращает размер массива;
        //== - проверка на равенство; < - сравнение.

        /// ////////////
        public static CollectionType<T> operator *(CollectionType<T> collection1, CollectionType<T> collection2)
        {
            CollectionType<T> temp = new CollectionType<T>();
            if (collection1.list is List<int> && collection2.list is List<int>)
            {
                for (int i = 0; i < collection1.list.Count; i++)
                {
                    temp.list.Add((dynamic)collection1.list[i] * (dynamic)collection2.list[i]);//dynamic. Это ключевое слово позволяет опустить проверку типов во время компиляции.
                }
            }
            if (collection1.list is List<string> && collection2.list is List<string>)
            {
                for (int i = 0; i < collection1.list.Count; i++)
                {
                    temp.list.Add((dynamic)collection1.list[i] + (dynamic)collection2.list[i]);
                }
            }
            if (collection1.list is List<Trans>) {
                List<Trans> transList1 = new List<Trans>();
                transList1 = collection1.list as List<Trans>;
                List<Trans> transList2 = new List<Trans>();
                transList2 = collection2.list as List<Trans>;
                List<Trans> carListOut = new List<Trans>();

                for (int i = 0; i < collection1.list.Count; i++)
                {
                    carListOut.Add(transList1[i]);
                }
                for (int i = 0; i < carListOut.Count; i++)
                {
                    carListOut[i].Power = transList1[i].Power * transList2[i].Power;
                }
            }
            return temp;
        }
        ////////////////////////////////////
        public static bool operator >(CollectionType<T> c1, CollectionType<T> c2)
        {
            {
                if (c1.list.Count > c2.list.Count)
                    return true;
                else
                    return false;

            }
        }
        public static bool operator <(CollectionType<T> c1, CollectionType<T> c2)
        {
            {
                if (c1.list.Count < c2.list.Count)
                    return true;
                else
                    return false;

            }
        }
        public static bool operator ==(CollectionType<T> c1, CollectionType<T> c2)
        {
            {
                if (c1.list.Count == c2.list.Count)
                    return true;
                else
                    return false;

            }
        }
        public static bool operator !=(CollectionType<T> c1, CollectionType<T> c2)
        {
            {
                if (c1.list.Count != c2.list.Count)
                    return true;
                else
                    return false;

            }
        }
        public static bool operator true(CollectionType<T> c1)
        {
            {
                if (c1.list is List<int>)
                {
                    List<int> intList = new List<int>();
                    intList = c1.list as List<int>;
                    for (int i = 0; i < intList.Count; i++)
                    {
                        if (intList[i] < 0)
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool operator false(CollectionType<T> c1)
        {
            {
                if (c1.list is List<int>)
                {
                    List<int> intList = new List<int>();
                    intList = c1.list as List<int>;
                    for (int i = 0; i < intList.Count; i++)
                    {
                        if (intList[i] < 0)
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }
        }
    }

    
}
   

    
