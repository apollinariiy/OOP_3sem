using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab5
{
    enum Operation
    {
        Add=1,
        Delete,
        Display,
        SearchDate,
        SearchPower,
        Count

    }
    public struct Date {
        public int Year;
        public Date(int year)
        {
            this.Year = year;
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
                Console.WriteLine("Армия:");
                item.ToString();
                Console.WriteLine("-------------------------");
            }
        }
        public class ArmyController : ArmyContainer
        {
            public void SearchDate(Date date)
            {
                int flagSearch = 0;
                Console.WriteLine("\nПоиск даты...", date.Year);
                foreach (Intelligent item in Armiya)
                {
                    if (item.Date.Equals(date))
                    {
                        Console.WriteLine("Дату рождения имеет", date.Year, item.Name);
                        flagSearch++;
                    }
                    else if (flagSearch != 0)
                        Console.WriteLine("Дата не найдена.");
                }
            }
            public int Count()
            {
                Console.WriteLine("\nКол-во единиц армии: " + Armiya.Count);
                return Armiya.Count;
            }
            public void SearchPower(int power)
            {
                for (int i = 0; i < Armiya.Count; i++)
                {
                    if (Armiya[i] is Trans)
                    {
                        Console.WriteLine("\nМощность " + power + " имеет " + Armiya[i].Name);
                    }
                }
            }
        }
    }

}
