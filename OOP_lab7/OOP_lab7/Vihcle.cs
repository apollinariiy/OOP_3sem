using OOP_Lab7;
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


    public class Car
    {
        private string nameCar;
        public string NameCar
        {
            get { return nameCar; }
            set { nameCar = value; }
        }
        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public Car(string nameCar, int power)

        {
            if (nameCar.Length < 2) throw new NameException("Оишбка! Неверно введено название:", nameCar);
            if (power < 0) throw new PowerException("Ошибка! Неверно введена мощность:", power);
            this.NameCar = nameCar;
            this.power = power;

        }

        public override string ToString()
        {
            return "\nНазвание машины: " + nameCar + "\nМощность двигателя: " + Power;
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