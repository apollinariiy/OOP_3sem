﻿using OOP_lab5;
using static OOP_lab5.ArmyContainer;
using System;
namespace OOP_lab5
{
    class Program
    {
        static void Main()
        {
            ArmyController army = new ArmyController();
            Trans trans1 = new Trans("YU2345", new Date(2022), 8700);
            Trans trans2 = new Trans("YU2", new Date(2022), 8710);
            Human hu1 = new Human("Антон", new Date(2002));
            Human hu2 = new Human("Андрей", new Date(2006));
            
            army.Add(trans1);
            army.Add(trans2);
            army.Add(hu1);
            army.Add(hu2);
            
            army.Display();
            army.Count();
            army.SearchDate(new Date(2002));
            army.SearchPower(8700);
        }
    }
}