using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//Паттерн Прототип (Prototype) позволяет создавать объекты на основе уже ранее созданных объектов-прототипов.
//То есть по сути данный паттерн предлагает технику клонирования объектов.
namespace lab17
{
    [Serializable]
    class FioAdmin
    {
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
    [Serializable]
    class InfAdmin
    {

        public FioAdmin FioAdmin { get; set; }
        public InfAdmin(string x, string y)
        {

            this.FioAdmin = new FioAdmin { Name = x, Patronymic = y };
        }

        public object DeepCopy()
        {
            object admin = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                admin = binFormatter.Deserialize(tempStream);
            }
            return admin;
        }
        public void GetInfo()
        {
            Console.WriteLine("Имя и отчество перподавателя:" + FioAdmin.Name + " " + FioAdmin.Patronymic);
        }
    }
}
