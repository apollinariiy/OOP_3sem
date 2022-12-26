using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Паттерн Хранитель (Memento) позволяет выносить внутреннее состояние объекта за его пределы для последующего
//возможного восстановления
//объекта без нарушения принципа инкапсуляции.
namespace lab17
{
    // Originator(создает объект хранителя для сохранения своего состояния)
    class Graduate
    {
        private int labs = 5; // кол-во лаб
        private int time = 3; // кол-во дней

        public void GetLabs()
        {
            if (labs > 0)
            {
                labs--;
                time--;

                Console.WriteLine("Делаем лабу. Осталось {0} лабы", labs);
            }
            else
                Console.WriteLine("Лаб больше нет");
        }
        // сохранение состояния
        public GraduateMemento SaveState()
        {
            Console.WriteLine("Сделали лабу, пошли ее сдавать. Параметры: {0} лабы надо сделать, {1} дней осталось", labs, time);
            return new GraduateMemento(labs, time);
        }

        // восстановление состояния
        public void RestoreState(GraduateMemento memento)
        {
            this.labs = memento.labs;
            this.time = memento.time;
            Console.WriteLine("Лабу не приняли, надо переделать. Параметры: {0} лабы надо сделать, {1} дней осталось", labs, time);
        }
    }
    // Memento(хранитель, который сохраняет состояние объекта Originator и предоставляет полный доступ только этому объекту Originator)
    class GraduateMemento
    {
        public int labs { get; private set; }
        public int time { get; private set; }

        public GraduateMemento(int labs, int time)
        {
            this.labs = labs;
            this.time = time;
        }
    }

    // Caretaker(выполняет только функцию хранения объекта Memento)
    class LabsHistory
    {
        public Stack<GraduateMemento> History { get; private set; }
        public LabsHistory()
        {
            History = new Stack<GraduateMemento>();
        }
    }
}
