
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters;

namespace OOP_lab13
{
    class Program
    {
        static void Main(string[] args)
        {

            //ЗАДАНИЕ 1. Выполните сериализацию/десериализацию объекта используя форматы(Binary, SOAP, JSON, XML)
            Car forBin = new Car();
            Car forSoap = new Car();
            Car forXml = new Car();
            Car forJson = new Car();
            Car car = new Car("Audi", 1000);

            Console.WriteLine("\n---------------------deserialization---------------------\n");
            
            CustomSerializer.SerializeAll(car);
            
            CustomSerializer.DeserializeFromBinary(ref forBin);
            CustomSerializer.DeserializeFromJson(ref forJson);
            CustomSerializer.DeserializefromXml(ref forXml);
            CustomSerializer.SerializeToSoap(forSoap);
            
            
            Console.WriteLine($"(.JSON){forJson.ToString()}\nNonSerialized:{forJson.ThisNonSerialized}\n");
            Console.WriteLine($"(.BIN){forBin.ToString()}\nNonSerialized:{forBin.ThisNonSerialized}\n");
            Console.WriteLine($"(.XML){forXml.ToString()}\nNonSerialized:{forXml.ThisNonSerialized}\n");
            Console.WriteLine($"(.SOAP){forSoap.ToString()}\nNonSerialized:{forSoap.ThisNonSerialized}\n");
            
            /* CustomSerializer.DeserializeAll(ref car1);*/


        }
    }


}