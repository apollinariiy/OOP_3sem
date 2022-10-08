
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_4
{
    public interface IDo
    {
        /*void ToString();*/
        string Type { get { return Type; } set { this.Type = value; } }
    }
    public class Vehicle
    {
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


    public class Car : Vehicle
    {
        private string nameCar;
        public string NameCar
        {
            get { return nameCar; }
            set { nameCar = value; }
        }

        public Car(string nameCar, string typeVehicle) : base(typeVehicle)
        {
            this.NameCar = nameCar;
            this.TypeVehicle = typeVehicle;
        }
    }

    public class Motor : Car
    {
        private string power;
        public string Power
        {
            get { return power; }
            set { power = value; }
        }
        public Motor(string nameCar, string typeVehicle, string power) : base(nameCar, typeVehicle)
        {
            this.NameCar = nameCar;
            this.TypeVehicle = typeVehicle;
            this.Power = power;
        }
    }

    public class carManagement : Car
    {
        private string license;
        public string License
        {
            get { return license; }
            set { license = value; }
        }
        public carManagement(string nameCar, string typeVehicle, string license) : base(nameCar, typeVehicle)
        {
            this.NameCar = nameCar;
            this.TypeVehicle = typeVehicle;
            this.License = license;
        }
    }

    public abstract class Intelligent : carManagement, IDo
    {
        public abstract void ToString();
        public string Type { get; set; }
        public Intelligent(string nameCar, string typeVehicle, string license) : base(nameCar, typeVehicle, license)
        {
            this.NameCar = nameCar;
            this.TypeVehicle = typeVehicle;
            this.License = license;
        }
    }
    public sealed class Human : Intelligent
    {
        public string nameHuman;
        public string NameHuman
        {
            get { return nameHuman; }
            set { nameHuman = value; }
        }
        public Human(string nameCar, string typeVehicle, string license, string type, string nameHuman) : base(nameCar, typeVehicle, license)
        {
            this.NameCar = nameCar;
            this.TypeVehicle = typeVehicle;
            this.License = license;
            this.Type = type;
            this.NameHuman = nameHuman;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("License: " + License);
            Console.WriteLine("Type Intelligent: " + Type);
            Console.WriteLine("Name Human: " + NameHuman);
        }
    }

    public sealed class Trans : Intelligent, IDo
    {
        private string nameTrans;
        public string NameTrans
        {
            get { return nameTrans; }
            set { nameTrans = value; }

        }
        public Trans(string nameCar, string typeVehicle, string license, string type, string nameTrans) : base(nameCar, typeVehicle, license)
        {
            this.NameCar = nameCar;
            this.TypeVehicle = typeVehicle;
            this.License = license;
            this.Type = type;
            this.NameTrans = nameTrans;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("License: " + License);
            Console.WriteLine("Type Intelligent: " + Type);
            Console.WriteLine("Type Intelligent: " + NameTrans);
        }
    }
    public class Printer
    {
        public string IAmPrinting(Vehicle obj)
        {
            if (obj is Car)
            {
                Car c = (Car)obj;
                return "Тип объекта: " + c.GetType().Name + "\nНазвание машины: " + c.NameCar + new String('-', 50);
            }
            if (obj is Human)
            {
                Human t = (Human)obj;
                return "Тип объекта: " + t.GetType().Name + "\nНазвание танка: " + t.NameHuman  + new String('-', 50);
            }
            if (obj is Trans)
            {
                Trans b = (Trans)obj;
                return "Тип объекта: " + b.GetType().Name + "\nНазвание байка: " + b.NameTrans  + new String('-', 50);
            }
            return "qq";
        }
    }
}