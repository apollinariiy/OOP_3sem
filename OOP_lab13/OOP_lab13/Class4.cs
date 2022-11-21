using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace OOP_lab13
{
    public interface IDo
    {
        public static short number = 0;
        void Count();
        void DoClone();
    }
    [Serializable]
    public abstract class Vehicle
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

    [Serializable]
    public class Car : Vehicle
    {
        [NonSerialized]
        public int ThisNonSerialized = 1;
        /*private string nameCar;
        public string NameCar
        {
            get { return nameCar; }
            set { nameCar = value; }
        }*/
        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        
        public Car(string typeVehicle, int nameCar) : base(typeVehicle)
        {
            this.Power = nameCar;
        }
        //конструктор без параметроов
        public Car() : base("Car")
        {
            this.Power = 0;
        }

        public override string ToString()
        {
            return "\nНазвание машины: " + TypeVehicle + "\nМощность двигателя: " + Power;
         
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