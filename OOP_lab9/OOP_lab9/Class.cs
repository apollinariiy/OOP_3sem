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
    interface IOrderedDictionary
    {
        void Add(int key, Car value); // добавление элемента в коллекцию
        void Clear(); // очистка коллекции
        bool Contains(Car value); // проверка наличия элемента в коллекции
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
    public class CarDictionary: IOrderedDictionary
    {
        public Dictionary<int, Car> list { get; set; }
        public CarDictionary()
        {
            list = new Dictionary<int, Car>();
        }
        public int Count => list.Count; // количество элементов в коллекции
        public void Clear()
        {
            list.Clear();
        }
        public void Print()
        {
            foreach (KeyValuePair<int, Car> item in list)
                Console.WriteLine("{0}. {1} – {2}$", item.Key, item.Value.Name, item.Value.Price);
        }
        public void Add(int key, Car value)
        {
            list.Add(key, value);
        }
        public void Remove(int key)
        {
            list.Remove(key);
        }
        public bool Contains(Car carSearch)
        {
                if(list.FirstOrDefault(x => x.Value == carSearch).Value != null)  { return true; }
            return false;
        }
      
        public ICollection Keys => list.ToArray();

        public ICollection Values => list.ToArray();
    }

}
