
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters;
using System.Net.Sockets;
using System.Net;

namespace OOP_lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
      
        }
        public static void Task1() {
         //ЗАДАНИЕ 1. Выполните сериализацию/десериализацию объекта используя форматы(Binary, SOAP, JSON, XML)
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
        }
        public static void Task2() {
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
            }
        }
        public static void Task3() {
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

        public static void Task4() {
            //ЗАДАНИЕ 4 Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - документ и напишите несколько запросов.
            Console.WriteLine("\n--------------------- Linq to XML ---------------------\n");

            XDocument xdoc = new XDocument();
            XElement person1 = new XElement("person");
            XAttribute NameAttr1 = new XAttribute("name", "Ваня");
            XElement SurElem1 = new XElement("surname", "Иванов");
            XElement AgeElem1 = new XElement("age", 37);
            person1.Add(NameAttr1);
            person1.Add(SurElem1);
            person1.Add(AgeElem1);


            XElement person2 = new XElement("person");
            XAttribute NameAttr2 = new XAttribute("name", "Вася");
            XElement SurElem2 = new XElement("surname", "Петров");
            XElement AgeElem2 = new XElement("age", 41);
            person2.Add(NameAttr2);
            person2.Add(SurElem2);
            person2.Add(AgeElem2);

            // создаем корневой элемент
            XElement people = new XElement("people");
            people.Add(person1);
            people.Add(person2);
            xdoc.Add(people);
            xdoc.Save(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab13\OOP_lab13\NewXML.xml");

            Console.WriteLine("Введите возраст для поиска");
            string ageXML = Console.ReadLine();
            var allAlbums = people.Elements("person");

            foreach (var item in allAlbums)
            {
                if (item.Element("age").Value == ageXML)
                {
                    Console.WriteLine(item.Value);
                }
            }

            Console.WriteLine("Введите имя для поиска");
            string nameXML = Console.ReadLine();
            foreach (var item in allAlbums)
            {
                if (item.Attribute("name").Value == nameXML)
                {
                    Console.WriteLine(item.Value);
                }
            }
        }
        public static void Task5() {
            //Создайте клиент и сервер на синхронных сокетах. Нужно сериализованные данные(объект) отправить по сокету и десериализовать на стороне клиента.
            Console.WriteLine("\n--------------------- Сервер ---------------------\n");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipPoint = new IPEndPoint(ip, 8080);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                Socket handler = listenSocket.Accept();
                Console.WriteLine("Подключен клиент");
                Car car = new Car("Lada", 4000);
                CustomSerializer.SerializeToXml(car);
                byte[] data = File.ReadAllBytes(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab13\OOP_lab13\XML.xml");
                handler.Send(data);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }




    }
}