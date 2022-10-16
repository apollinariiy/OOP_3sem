using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab5
{
    public partial class Car : Vehicle
    {
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
}