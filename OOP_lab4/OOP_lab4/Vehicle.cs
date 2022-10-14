using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_4
{
    public interface IDo {
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

    public abstract class Intelligent : carManagement, IDo
    {
        public void Count() {
            Console.WriteLine("Количество объектов: " + number);
        }
        private string typeIntelligent;
        public string TypeIntelligent
        {
            get { return typeIntelligent; }
            set { typeIntelligent = value; }
        }
        public int number { get; set; }
        public Intelligent( string TypeIntelligent, string nameCar, string typeVehicle, int license) : base( nameCar, typeVehicle, license)
        {
            this.typeIntelligent = TypeIntelligent;
            number++;
        }

        public override void ToString()
        {
         
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("License: " + License);
            Console.WriteLine("Type Intelligent: " + TypeIntelligent);
        }
        public abstract void DoClone();
    }
    public sealed class Human : Intelligent, IDo
    {
        public string nameHuman;
        public string NameHuman
        {
            get { return nameHuman; }
            set { nameHuman = value; }
        }
        public int number { get; set; }
        public Human(string nameCar, string typeVehicle, string TypeIntelligent, string nameHuman, int license) : base(nameCar, typeVehicle, TypeIntelligent, license)
        {
            this.NameHuman = nameHuman;
            number++;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("Type Intelligent: " + TypeIntelligent);
            Console.WriteLine("Name Human: " + NameHuman);
            Console.WriteLine("License: " + License);
        }

        //методы от обжект
        public override int GetHashCode()       // Метод GetHashCode() позволяет возвратить некоторое числовое значение, соответствующее объекту или, как ещё говорят, его хэш-код
        {
            return License.GetHashCode();
        }

        public override bool Equals(object obj)  // Позволяет проверить два объекта на равенство, используя собственный алгоритм сравнения
        {
            if (obj.GetType() != this.GetType()) return false;

            Human hu = (Human)obj;
            return (this.nameHuman == hu.nameHuman);
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
        private string nameTrans;
        public string NameTrans
        {
            get { return nameTrans; }
            set { nameTrans = value; }
            
        }
        public Trans( string nameCar, string typeVehicle, string TypeIntelligent, string nameTrans, int license) : base(nameCar, typeVehicle, TypeIntelligent, license)
        {
            this.NameTrans = nameTrans;
            number++;
        }
        public override void ToString()
        {
            Console.WriteLine("Name Car: " + NameCar);
            Console.WriteLine("Type Vehicle: " + TypeVehicle);
            Console.WriteLine("License: " + License);
            Console.WriteLine("Type Intelligent: " + TypeIntelligent);
            Console.WriteLine("Type Intelligent: " + NameTrans);
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
    public class Printer
    {
            public virtual void IAmPrinting(Vehicle tech)
            {
                Console.WriteLine(tech.GetType().Name);     // определение типа объекта
            }
    }
}