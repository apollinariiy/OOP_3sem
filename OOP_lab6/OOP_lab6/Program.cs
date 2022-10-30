using OOP_lab6;
using OOP_Lab6;
using System;
using static OOP_lab6.ArmyContainer;

namespace OOP_Lab6
{
    class Program
    {
        static void Main()
        {
            Num check = new Num(10);
            check.Omnomnom();

            FileLogger fileLogger = new FileLogger();
            ConsoleLogger consoleLogger = new ConsoleLogger();
            try
            {
                ArmyController army = new ArmyController();
                Trans trans1 = new Trans("YU2345", new Date(2022), 8700);
                Trans trans2 = new Trans("YU22", new Date(20222), 8710);
                Human hu1 = new Human("Антон", new Date(2002));
                Human hu2 = new Human("Андрей", new Date(2006));

                army.Add(trans1);
                army.Add(trans2);
                army.Add(hu1);
                army.Add(hu2);

                army.Display();
                army.Count();
                army.SearchDate(new Date(2002));
                army.SearchPower(8700);
            }
            catch (MyException ex)
            {
                fileLogger.WriteLog(ex);
               
            }
            finally {
                Console.WriteLine("Программа завершена");
            }
        
            
            
            /// Деление на 0
            try
            {
                int x = 5, y = 0;
                int c = x / y;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            
            try
            {

                int[] arr = new int[8];
                arr[10] = 10;
            }
            catch (Exception e) when (e.Source.Length < 8)
            {
                Console.WriteLine("ок\n");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message + "\n");
               
            }
            
           
        }
    }
}