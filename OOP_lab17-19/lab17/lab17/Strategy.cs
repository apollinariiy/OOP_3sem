using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    interface IStudy
    {
        void Study();
    }

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
