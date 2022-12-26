using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab17
{



    class NeedPay
    { }
    class DontNeedPay
    { }

    class Direction
    {
        public string Name { get; set; }
    }

    class Faculty
    {
        public NeedPay NeedPay { get; set; }
        public  DontNeedPay DontNeedPay { get; set; }

        public Direction Direction { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (DontNeedPay != null)
                sb.Append("Бесплатник \n");
            if (NeedPay != null)
                sb.Append("Платник \n");
            if (Direction != null)
                sb.Append("Факультет: " + Direction.Name + " \n");
            return sb.ToString();
        }
    }

    abstract class FacultyBuilder
    {
        public Faculty Faculty { get; private set; }
        public void CreateFaculty()
        {
            Faculty = new Faculty();
        }
       
        public abstract void Choose_direct();
        public abstract void SetDirection();
    }

    class Student
    {
        public Faculty Facult(FacultyBuilder FacultyBuilder)
        {
            FacultyBuilder.CreateFaculty();
           
            FacultyBuilder.Choose_direct();
            FacultyBuilder.SetDirection();
            return FacultyBuilder.Faculty;
        }
    }
    // строитель для бесплатников, котрые уачться на биологии
    class BiologyBuilder : FacultyBuilder
    {


        public override void Choose_direct()
        {
            this.Faculty.DontNeedPay = new DontNeedPay();
        }

        public override void SetDirection()
        {
            this.Faculty.Direction = new Direction { Name = "Вы учитесь на биологии" };
        }
    }
   // строитель для платников, котрые уачться на математике
    class MathBuilder : FacultyBuilder
    {
       

        public override void Choose_direct()
        {
            this.Faculty.NeedPay = new NeedPay();
        }

        public override void SetDirection()
        {
            this.Faculty.Direction = new Direction { Name = "Вы учитесь на математике" };
        }
    }
}
