using OOP_lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab6
{
    public abstract class Intelligent : IDo
    {
        public Date Date;
        public abstract void ToString();
        public void Count()
        {
            Console.WriteLine("Количество объектов: " + number);
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int number { get; set; }
        public Intelligent(string name)
        {
            this.Name = name;
            number++;
        }

        public abstract void DoClone();
    }
    public sealed class Human : Intelligent, IDo
    {
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int number { get; set; }
        public Human(string Name, Date date) : base(Name)
        {
            Date = date;
            number++;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Human: " + Name);
            Console.WriteLine("Year: " + Date.Year);
        }

        //методы от обжект
        public override int GetHashCode()       // Метод GetHashCode() позволяет возвратить некоторое числовое значение, соответствующее объекту или, как ещё говорят, его хэш-код
        {
            return year.GetHashCode();
        }

        public override bool Equals(object obj)  // Позволяет проверить два объекта на равенство, используя собственный алгоритм сравнения
        {
            if (obj.GetType() != this.GetType()) return false;

            Human hu = (Human)obj;
            return (this.Name == hu.Name);
        }
        void IDo.DoClone()
        {
            Console.WriteLine("Одноименный метод интерфейса");
        }
        public override void DoClone()
        {
            Console.WriteLine("Одноименный метод абстрактного класса");
        }
    }

    public sealed class Trans : Intelligent, IDo
    {
        private int year;
        private int power;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public Trans(string Name, Date date, int Power) : base(Name)
        {
            Date = date;
            power = Power;
            number++;
        }
        public override void ToString()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Year: " + Date.Year);
            Console.WriteLine("Power: " + Power);
        }
        void IDo.DoClone()
        {
            Console.WriteLine("Одноименный метод интерфейса");
        }
        public override void DoClone()
        {
            Console.WriteLine("Одноименный метод абстрактного класса");
        }
    }
}

