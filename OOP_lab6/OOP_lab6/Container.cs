using OOP_lab6;
using OOP_Lab6;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab6
{
    enum Operation
    {
        Add = 1,
        Delete,
        Display,
        SearchDate,
        SearchPower,
        Count

    }
    public struct Date
    {
        public int Year;
        public Date(int year)
        {
            this.Year = year;
            if (this.Year > 2022 || this.Year < 0)
            {
                throw new DateException("Ошибка! Некорректо введена дата:", this.Year);
            }
        }
    }

    public class ArmyContainer
    {
        public List<Intelligent> Armiya;
        public ArmyContainer()
        {
            Armiya = new List<Intelligent>();
        }
        public void Delete(int index)
        {
            Armiya.RemoveAt(index);
        }
        public void Add(Intelligent item)
        {
            Armiya.Add(item);
        }
        public void Display()
        {
            foreach (Intelligent item in Armiya)
            {
                Console.WriteLine("Единица армии:");
                item.ToString();
                Console.WriteLine("-------------------------");
            }
        }
        public class ArmyController : ArmyContainer
        {
            public int Count()
            {
                Console.WriteLine("\nКол-во единиц армии: " + Armiya.Count);
                return Armiya.Count;
            }
            public void SearchDate(Date date)
            {
                int flagSearch = 0;
                Console.WriteLine("\nПоиск даты...   " + date.Year);
                for (int i = 0; i < Armiya.Count; i++)
                {
                    if (Armiya[i] is Human)
                    {
                        if (Armiya[i].Date.Year == date.Year)
                        {
                            Console.WriteLine("Найден объект с датой " + date.Year + ": " + Armiya[i].Name);
                            flagSearch = 1;
                        }
                    }
                }
            }
            public void SearchPower(int power)
            {
                Console.WriteLine("\nПоиск мощности...   " + power);
                for (int i = 0; i < Armiya.Count; i++)
                {
                    if (Armiya[i] is Trans)
                    {
                        Trans temp = Armiya[i] as Trans;
                        if (temp.Power == power)
                        {
                            Console.WriteLine("Найден объект с мощностью " + power + ": " + Armiya[i].Name);
                        }
                    }
                }
            }
        }
    }

}
