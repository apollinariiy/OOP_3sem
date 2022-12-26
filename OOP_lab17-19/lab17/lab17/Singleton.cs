using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует, что для определенного класса будет создан только один объект,
//а также предоставит к этому объекту точку доступа.
namespace lab17
{
    class Abitur
    {
        public Inform Inform { get; set; }
        public void FIO(string InformName)
        {
            Inform = Inform.getInstance(InformName);
        }
    }
    class Inform
    {
        private static Inform instance;
        
        public string Name { get; private set; }

        protected Inform(string name)
        {
            this.Name = name;
        }

        public static Inform getInstance(string name)
        {
            if (instance is null)
                instance = new Inform(name);
            return instance;
        }
    }
}
