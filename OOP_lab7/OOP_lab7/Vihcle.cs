using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_lab7
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
        }

        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
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
}