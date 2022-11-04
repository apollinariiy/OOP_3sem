using OOP_lab7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab7
{//Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть.where T : IComparable<T>
    public interface ICollection<T> where T:Car
    {
        public void enterData(List<T> list);
        public void addData(T element);
        public void printData();
        public void deleteData(T element);
        public void searchIndex(int index);
    }
   
    public class CollectionType<T> /*where T : Car*/
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

        public void searchIndex(int index)
        {
           list[index].ToString();
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
            if (collection1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = collection1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = collection2.list as List<Car>;
                List<Car> carListOut = new List<Car>();

                for (int i = 0; i < collection1.list.Count; i++)
                {
                    carListOut.Add(carList1[i]);
                }
                for (int i = 0; i < carListOut.Count; i++)
                {
                    carListOut[i].Power = carList1[i].Power * carList2[i].Power;
                    Console.WriteLine(carListOut[i].ToString());
                }
           
        }
            return temp;
        }
        ////////////////////////////////////
        public static bool operator >(CollectionType<T> c1, CollectionType<T> c2)
        {
            if (c1.list is List<int> && c2.list is List<int>)
            {
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if ((dynamic)c1.list[i] < (dynamic)c2.list[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            if (c1.list is List<string> && c2.list is List<string>)
            {
                List<string> tempList1 = new List<string>();
                tempList1 = c1.list as List<string>;
                List<string> tempList2 = new List<string>();
                tempList2 = c2.list as List<string>;
                {
                    for (int i = 0; i < c1.list.Count; i++)
                    {
                        if (tempList1[i].Length < tempList2[i].Length)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            if (c1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = c1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = c2.list as List<Car>;
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if (carList1[i].Power < carList2[i].Power)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool operator <(CollectionType<T> c1, CollectionType<T> c2)
        {
            if (c1.list is List<int> && c2.list is List<int>)
            {
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if ((dynamic)c1.list[i] > (dynamic)c2.list[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            if (c1.list is List<string> && c2.list is List<string>)
            {
                List<string> tempList1 = new List<string>();
                tempList1 = c1.list as List<string>;
                List<string> tempList2 = new List<string>();
                tempList2 = c2.list as List<string>;
                {
                    for (int i = 0; i < c1.list.Count; i++)
                    {
                        if (tempList1[i].Length > tempList2[i].Length)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            if (c1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = c1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = c2.list as List<Car>;
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if (carList1[i].Power > carList2[i].Power)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        /// ///////////////////////////
        public static bool operator ==(CollectionType<T> c1, CollectionType<T> c2)
        {
            if(c1.list is List<int> || c1.list is List<string>)
            {
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if (c1.list[i].Equals(c2.list[i]))
                        return true;
                }

            }
            if (c1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = c1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = c2.list as List<Car>;
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if (carList1[i].Power == carList2[i].Power)//разобрать
                        return true;
                }
            }
            return false;
        }
        public static bool operator !=(CollectionType<T> c1, CollectionType<T> c2)
        {
            if (c1.list is List<int> || c1.list is List<string>)
            {
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if (!c1.list[i].Equals(c2.list[i]))
                        return true;
                }
                
            }
            if (c1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = c1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = c2.list as List<Car>;
                for (int i = 0; i < c1.list.Count; i++)
                {
                    if (carList1[i].Power != carList2[i].Power)
                        return true;
                }
            }
            return false;
        }
        /// /////////////////////
        public static bool operator true(CollectionType<T> c1)
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

            }
            if (c1.list is List<string>)
            {
                List<string> stringList = new List<string>();
                stringList = c1.list as List<string>;
                for (int i = 0; i < stringList.Count; i++)
                {
                    if (stringList[i].Length < 0)
                        return false;
                }
            }

            if (c1.list is List<Car>)
            {
                List<Car> carList = new List<Car>();
                carList = c1.list as List<Car>;
                for (int i = 0; i < carList.Count; i++)
                {
                    if (carList[i].Power < 0)
                        return false;
                }
            }
            return true;

        }
        public static bool operator false(CollectionType<T> c1)
        {
            
                if (c1.list is List<int>)
                {
                    List<int> intList = new List<int>();
                    intList = c1.list as List<int>;
                    for (int i = 0; i < intList.Count; i++)
                    {
                        if (intList[i] > 0)
                            return false;
                    }
                  
                }
            if (c1.list is List<string>)
            {
                List<string> stringList = new List<string>();
                stringList = c1.list as List<string>;
                for (int i = 0; i < stringList.Count; i++)
                {
                    if (stringList[i].Length > 0)
                        return false;
                }
            }

            if (c1.list is List<Car>)
            {
                List<Car> carList = new List<Car>();
                carList = c1.list as List<Car>;
                for (int i = 0; i < carList.Count; i++)
                {
                    if (carList[i].Power > 0)
                        return false;
                }
            }
            return true;

        }
        
    }

    
}
   

    
