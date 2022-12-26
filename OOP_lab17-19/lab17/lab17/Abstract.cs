using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
 
    abstract class Enroll
    {
        public abstract void Enrol_course();
    }

    abstract class Movement
    {
        public abstract void Move();
    }


    class Biology : Enroll
    {
        public override void Enrol_course()
        {
            Console.WriteLine("Записались на биологию");
        }
    }

    class Math : Enroll
    {
        public override void Enrol_course()
        {
            Console.WriteLine("Записались на математику");
        }
    }

    class passing_scoreBio : Movement
    {
        public override void Move()
        {
            Console.WriteLine("360 баллов");
        }
    }

    class passing_scoreMath : Movement
    {
        public override void Move()
        {
            Console.WriteLine("380 баллов"); 
        }
    }
    // класс абстрактной фабрики
    abstract class LeaverFactory
    {
        public abstract Movement CreateMovement();
        public abstract Enroll CreateEnroll();
    }
  
    class BioFactory : LeaverFactory
    {
        public override Movement CreateMovement()
        {
            return new passing_scoreBio();
        }

        public override Enroll CreateEnroll()
        {
            return new Biology();
        }
    }
 
    class MathFactory : LeaverFactory
    {
        public override Movement CreateMovement()
        {
            return new passing_scoreMath();
        }

        public override Enroll CreateEnroll()
        {
            return new Math();
        }
    }

    class Leaver
    {
        private Enroll enroll;
        private Movement movement;
        public Leaver(LeaverFactory factory)
        {
            enroll = factory.CreateEnroll();
            movement = factory.CreateMovement();
        }
        public void passing_score()
        {
            movement.Move();
        }
        public void Enrol_course()
        {
            enroll.Enrol_course();
        }
    }
}
