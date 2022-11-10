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
using OOP_lab9;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////// Car
            Car car1 = new Car("Mers", 4800);
            Car car2 = new Car("Nissan", 19000);
            Car car3 = new Car("BMW", 3900);
            Car car4 = new Car("Toyota", 16500);


            ////////////// Методы для работы с коллекцией
            MyDictionary<Car> carCollection = new MyDictionary<Car>();
            carCollection.Add(1, car1);
            carCollection.Add(2, car2);
            carCollection.Add(3, car3);
            carCollection.Add(4, car4);
            carCollection.Remove(3);
            Console.WriteLine("\n----------------------------Объекты словаря:--------------------------------\n");
            carCollection.Print();
            Console.WriteLine("Резултат поиска объекта {0} в словаре:{1}\n", car3.Name, carCollection.Contains(car3));

            ///////////// Заполнить коллекцию данными встроенного типа
            Console.WriteLine("\n----------------------------Коллекция типа int:--------------------------------\n");
            Dictionary<int,int> intCollection = new Dictionary<int, int>();
            
            for (int i = 0; i < 10; i++)
            {
                intCollection.Add(i, i);
            }

            foreach (var person in intCollection)
            {
                Console.WriteLine(person.Key + ". " + person.Value);
            }

            /////////////Удалите из коллекции n последовательных элементов
            Console.WriteLine("\n----------------------------Удаление последовательных элементов:--------------------------------\n");
            int n = 3;
            bool flag;
            while (n >= 0)
            {
                intCollection.Remove(n);
                /* intCollection.Remove(intCollection.Count - 1);*/
                n--;
            }
            
            foreach (var person in intCollection)
            {
                Console.WriteLine(person.Key + ". " + person.Value);
            }
            
            /////////////используйте все возможные методы добавления для вашего типа коллекции
            Console.WriteLine("\n----------------------------Добавление элементов разными способами:--------------------------------\n");
            intCollection.Add(0, 11);
            intCollection.TryAdd(2, 2);
            intCollection[1] = 13;

            /////////////Создайте вторую коллекцию (из таблицы выберите другой тип коллекции) и заполните ее данными из первой коллекции
            Console.WriteLine("\n----------------------------Вторая коллекция:--------------------------------\n");
            List<int> list = intCollection.Values.ToList();
            foreach (int item in list)
                Console.WriteLine(item);

            Console.WriteLine("\nНайти в списке элемент 2:");
            foreach (int item in list)
                if (item == 2)
                    Console.WriteLine("В списке есть элемент 2\n");

            /////////////Создайте объект наблюдаемой коллекции ObservableCollection.
            Console.WriteLine("\n----------------------------События:--------------------------------\n");
            ObservableCollection<Car> coll = new ObservableCollection<Car>();
            coll.CollectionChanged += CollectionChanged;

            coll.Add(car1);
            coll.Remove(car1);

        }
        private static void CollectionChanged(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый объект");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален объект");
                    break;
            }
        }
    }
}
