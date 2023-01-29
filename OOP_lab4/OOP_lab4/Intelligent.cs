using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab4
{
    public abstract class Intelligent : IDo
    {
        public abstract void ToString();
        public void Count()
        {
            Console.WriteLine("Количество объектов: " + number);
        }
        private string typeIntelligent;
        public string TypeIntelligent
        {
            get { return typeIntelligent; }
            set { typeIntelligent = value; }
        }
        public int number { get; set; }
        public Intelligent(string TypeIntelligent)
        {
            this.typeIntelligent = TypeIntelligent;
            number++;
        }

        public abstract void DoClone();
    }
    public sealed class Human : Intelligent, IDo
    {
        private string nameHuman;
        private int year;
        public string NameHuman
        {
            get { return nameHuman; }
            set { nameHuman = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int number { get; set; }
        public Human(string TypeIntelligent, string nameTrans, int Year) : base(TypeIntelligent)
        {
            NameHuman = nameTrans;
            year = Year;
            number++;
        }
        public override void ToString()
        {
            Console.WriteLine("Type Intelligent: " + TypeIntelligent);
            Console.WriteLine("Name Human: " + NameHuman);
            Console.WriteLine("Year: " + Year);
        }

        //методы от обжект
        public override int GetHashCode()       // Метод GetHashCode() позволяет возвратить некоторое числовое значение, соответствующее объекту или, как ещё говорят, его хэш-код
        {
            return year.GetHashCode();
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
        private int year;
        private int power;
        private string nameTrans;
        public string NameTrans
        {
            get { return nameTrans; }
            set { nameTrans = value; }

        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public Trans(string TypeIntelligent, string nameTrans, int Year, int Power) : base(TypeIntelligent)
        {
            NameTrans = nameTrans;
            year = Year;
            power = Power;
            number++;
        }
        public override void ToString()
        {
            Console.WriteLine("Type Intelligent: " + TypeIntelligent);
            Console.WriteLine("Name: " + NameTrans);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Power: " + Power);
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
}
