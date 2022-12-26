using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    interface InewLesson
    {
        void GetLesson();
    }
    // класс машины
    class Chemistry : InewLesson
    {
        public void GetLesson()
        {
            Console.WriteLine("Вы проходите на курс по химии");
        }
    }
    class Abiturient
    {
        public void State(InewLesson lesson)
        {
            lesson.GetLesson();
        }

    }
    // интерфейс животного
    interface ISubject
    {
        void Move();
    }
    // класс верблюда
    class Geography : ISubject
    {
        public void Move()
        {
            Console.WriteLine("Вы проходите на курс географии");
        }
    }
    // Адаптер от Camel к ITransport
    class GeographyTonewCourseAdapter : InewLesson
    {
        Geography lesson2;
        public GeographyTonewCourseAdapter(Geography c)
        {
            lesson2 = c;
        }

        public void GetLesson()
        {
            lesson2.Move();
        }
    }
}
