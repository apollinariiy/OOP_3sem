using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Паттерн Стратегия (Strategy) представляет шаблон проектирования, который определяет набор алгоритмов,
//инкапсулирует каждый из них и обеспечивает их взаимозаменяемость.
namespace lab17
{
    interface IStudy
    {
        void Study();
    }
    //разные реализации интерфейса 
    class NeedStudy : IStudy
    {
        public void Study()
        {
            Console.WriteLine("Сегодня надо учится");
        }
    }

    class DontNeedStudy : IStudy
    {
        public void Study()
        {
            Console.WriteLine("Сегодня не надо учится");
        }
    }
    //хранилище реализаций
    class Study
    {

        protected string model; 
        
        public Study( string model, IStudy st)
        {
          
            this.model = model;
            Studing = st;
        }
        public IStudy Studing { private get; set; }
        public void Need()
        {
            Studing.Study();
        }
    }
}
