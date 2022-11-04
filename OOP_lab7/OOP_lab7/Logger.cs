using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OOP_Lab7;
using OOP_lab7;

namespace OOP_Lab7
{
    public class ConsoleLogger
    {
        public ConsoleLogger() { }
        public void WriteLog(MyException exception)
        {
            PowerException PowerEx = exception as PowerException;
            NameException NameEx = exception as NameException;

            Console.WriteLine("\n" + DateTime.Now);

            if (PowerEx != null)
            {
                Console.WriteLine("{0}{1} {2}", PowerEx.ErrorClass, PowerEx.Message, PowerEx.Power);
            }
            if (NameEx != null)
            {
                Console.WriteLine("{0}{1} {2}", NameEx.ErrorClass, NameEx.Message, NameEx.Name);
            }
        }
    }


    public class FileLogger
    {
        public FileLogger() { }
        public void WriteLog(MyException exception)
        {
            PowerException PowerEx = exception as PowerException;
            NameException NameEx = exception as NameException;

            string filePath = @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab7\OOP_lab7\log.txt";
            using StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default);
            streamWriter.WriteLine(DateTime.Now);

            if (PowerEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", PowerEx.ErrorClass, PowerEx.Message, PowerEx.Power);
            }
            if (NameEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", NameEx.ErrorClass, NameEx.Message, NameEx.Name);
            }
        }
    }
    public class FileWriter<Car>//запись в файл
    {
        public FileWriter() { }
        public void WriteLog(List<Car> car)
        {
            string filePath = @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab7\OOP_lab7\out.txt";
            using StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default);
            streamWriter.WriteLine(DateTime.Now);
            foreach (Car c in car)
            {
                streamWriter.WriteLine(c);
            }
        }
    }
        
    public class ReadFile
    {
        public void LoadFromFile()             // Чтение из файла
        {
            using (FileStream fstream = File.OpenRead(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab7\OOP_lab7\in.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
    }



}