using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    abstract class Speciality
    {
        public Speciality(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetScore();
    }

    class Technical : Speciality
    {
        public Technical() : base("Математика")
        { }
        public override int GetScore()
        {
            return 301;
        }
    }
    class Ecomonic : Speciality
    {
        public Ecomonic() : base("Английский")
        { }
        public override int GetScore()
        {
            return 300;
        }
    }

    abstract class SpecialityDecorator : Speciality
    {
        protected Speciality speciality;
        public SpecialityDecorator(string n, Speciality speciality) : base(n)
        {
            this.speciality = speciality;
        }
    }

    class Humanitarian : SpecialityDecorator
    {
        public Humanitarian(Speciality p)
            : base(p.Name + " с Обществоведением", p)
        { }

        public override int GetScore()
        {
            return speciality.GetScore() + 3;
        }
    }

    class Bio : SpecialityDecorator
    {
        public Bio(Speciality p)
            : base(p.Name + " с Биологией", p)
        { }

        public override int GetScore()
        {
            return speciality.GetScore() + 5;
        }
    }
}
