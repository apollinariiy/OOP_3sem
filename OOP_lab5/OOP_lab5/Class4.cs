using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab5
{
    public interface IDo
    {
        public static short number = 0;
        void Count();
        void DoClone();
    }
    public abstract class Vehicle
    {
        public abstract void ToString();
        private string typeVehicle;
        public string TypeVehicle
        {
            get { return typeVehicle; }
            set { typeVehicle = value; }
        }
        public Vehicle(string typeVehicle)
        {
            this.TypeVehicle = typeVehicle;
        }
    }

    //PARTIAL CLASS
    public partial class Car : Vehicle
    {
        private string nameCar;
        public string NameCar
        {
            get { return nameCar; }
            set { nameCar = value; }
        }
        
    }

    public class Motor : Car
    {
        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public Motor(string nameCar, string typeVehicle, int power) : base(nameCar, typeVehicle)
        {
            this.Power = power;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("Power: " + Power);
        }
    }

    public class carManagement : Car
    {

        private int license;
        public int License
        {
            get { return license; }
            set { license = value; }
        }
        public carManagement(string nameCar, string typeVehicle, int license) : base(nameCar, typeVehicle)
        {
            this.License = license;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("License: " + License);
        }
    }
    public class Printer
    {
        public virtual void IAmPrinting(Vehicle tech)
        {
            Console.WriteLine(tech.GetType().Name);     // определение типа объекта
        }
    }
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
