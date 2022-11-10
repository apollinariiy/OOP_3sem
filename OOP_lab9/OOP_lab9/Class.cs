using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab9
{
    interface IOrderedDictionary<T>
    {
        void Add(int key, T value); // добавление элемента в коллекцию
        void Clear(); // очистка коллекции
        bool Contains(T value); // проверка наличия элемента в коллекции
        void Remove(int key); // удаление элемента из коллекции
        int Count { get; } // количество элементов в коллекции
        ICollection Keys { get; } // возвращает список ключей
        ICollection Values { get; } // возвращает список значений
        
    }
    public class Car
    {
        public string Name { get; set; }
        public int Price { get; set; }
        
        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }

    }
    public class MyDictionary<T>: IOrderedDictionary<T>
    {
        public Dictionary<int, T> list { get; set;}

        public MyDictionary()
        {
            list = new Dictionary<int, T>();
        }
        public int Count => list.Count; // количество элементов в коллекции
        public void Clear()
        {
            list.Clear();
        }
        public void Print()
        {
            foreach (KeyValuePair<int, T> item in list)
                if (item.Value is Car)
                {
                    Car car = item.Value as Car;
                    Console.WriteLine("{0}. {1} – {2}$", item.Key, car.Name, car.Price);
                }
                else
                {
                    Console.WriteLine("{0}. {1}", item.Key, item.Value);
                }
            
        }
        public void Add(int key, T value)
        {
            list.Add(key, value);
        }
        public void Remove(int key)
        {
            list.Remove(key);
        }
        public bool Contains(T carSearch) // проверка наличия элемента в коллекции
        {
            foreach (KeyValuePair<int, T> item in list)
            {
                if (item.Value.Equals(carSearch))
                    return true;
            }
            return false;
        }
       
        public ICollection Keys => list.ToArray();

        public ICollection Values => list.ToArray();
    }

}
