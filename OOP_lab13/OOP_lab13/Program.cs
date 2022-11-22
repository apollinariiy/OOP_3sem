
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

            /*//ЗАДАНИЕ 1. Выполните сериализацию/десериализацию объекта используя форматы(Binary, SOAP, JSON, XML)
            Car forBin = new Car();
            Car forSoap = new Car();
            Car forXml = new Car();
            Car forJson = new Car();
            Car car = new Car("Audi", 1000);

            Console.WriteLine("\n--------------------- deserialization ---------------------\n");

            CustomSerializer.SerializeAll(car);

            CustomSerializer.DeserializeFromBinary(ref forBin);
            CustomSerializer.DeserializeFromJson(ref forJson);
            CustomSerializer.DeserializefromXml(ref forXml);
            CustomSerializer.SerializeToSoap(forSoap);


            Console.WriteLine($"(.JSON){forJson.ToString()}\nNonSerialized:{forJson.ThisNonSerialized}\n");
            Console.WriteLine($"(.BIN){forBin.ToString()}\nNonSerialized:{forBin.ThisNonSerialized}\n");
            Console.WriteLine($"(.XML){forXml.ToString()}\nNonSerialized:{forXml.ThisNonSerialized}\n");
            Console.WriteLine($"(.SOAP){forSoap.ToString()}\nNonSerialized:{forSoap.ThisNonSerialized}\n");

            //ЗАДАНИЕ 2. Создайте коллекцию (массив) объектов и выполните сериализацию/десериализацию – возможность сохранения и загрузки спсика объектов в/из файла.
            Console.WriteLine("\n--------------------- collection deserialization ---------------------\n");
            List<Car> forCollXml = new List<Car>();
            List<Car> cars = new List<Car>()
            {
                new Car("Audi", 1000),
                new Car("BMW", 2000),
                new Car("Mercedes", 3000),
                new Car("Lada", 4000)
            };

            CustomSerializer.SerializeToXml(cars);
            CustomSerializer.DeserializefromXml(ref forCollXml);
            foreach (var item in forCollXml)
            {
                Console.WriteLine(item.ToString());
            }*/

            //ЗАДАНИЕ 3. Используя XPath напишите два селектора для вашего XML документа.
            //InnerText возвращает текстовое значение узла
            Console.WriteLine("\n--------------------- XPath 1 селектор ---------------------\n");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab13\OOP_lab13\XML.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            
            XmlNodeList childnodes = xRoot.SelectNodes("Car");//SelectNodes(): выборка по запросу коллекции узлов в виде объекта XmlNodeList
            foreach (XmlNode n in childnodes)//XPath
            {
                Console.WriteLine(n.InnerText);//InnerText возвращает текстовое значение узла
            }
            Console.WriteLine("\n--------------------- XPath 2 селектор ---------------------\n");

            XmlNodeList childnode = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnode)
            {
                Console.WriteLine(n.Name); //Name возвращает название узла.
            }
        }


    }
}