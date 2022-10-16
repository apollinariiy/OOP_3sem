using OOP_lab5;
using static OOP_lab5.ArmyContainer;
using System;
namespace OOP_lab5
{
    class Program
    {
        static void Main()
        {
            ArmyController army = new ArmyController();
            Trans Optimus = new Trans("YU2345", new Date(2022), 8700);
            Human Antoxa = new Human("Антон", new Date(2002));
            army.Add(Optimus);
            army.Add(Antoxa);
            army.Display();
            army.Count();
            army.SearchDate(new Date(2002));
            army.SearchPower(8700);
        }
    }
}