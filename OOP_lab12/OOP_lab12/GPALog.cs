using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab12
{
    public static class GPALog
    {
        public static void WriteLogInfo()               /// запись в файл лога инфы о работе самого логгера
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("\n===========================================   GPALog   ===================================================\n");
                sw.WriteLine("Имя файла лога:           " + Path.GetFileName(logPath));
                sw.WriteLine("Полный путь лога:         " + logPath);
                sw.WriteLine("Время записи лога:        " + DateTime.Now);
            }

        }


        public static void WriteInLog(string message)   /// запись в файл лога инфы из остальных классов
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
                sw.WriteLine(message);
        }



        public static string ReadLog()
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            StreamReader sr = new StreamReader(logPath);
            return sr.ReadToEnd();
        }

        //Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный день/ диапазон времени/по ключевому слову.
        public static void FindLogInfo(string keyWord)
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] keyWordArray = keyWord.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                for (int j = 0; j < keyWordArray.Length; j++)
                {
                    if (logInfoArray[i].Contains(keyWordArray[j]))
                    {
                        logInfoArray2[count] = logInfoArray[i];
                        count++;
                    }
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }
        // //Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный день
        public static void FindLogInfoDay(DateTime date)
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }
        //Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный диапазон времени.
        public static void FindLogInfoTime(DateTime date1, DateTime date2)
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date1.ToString()) && logInfoArray[i].Contains(date2.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }

        //Посчитайте количество записей в нем.
        public static void Count() {
            string logInfo = ReadLog();
            string check = "===========================================   GPALog   ===================================================";
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;
            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(check))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }
            Console.WriteLine("Количесво записей:       " + count);
        }

        //Удалите часть информации, оставьте только записи за текущий час.
        public static void DeleteLogInfo()
        {
            string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;
            DateTime date = DateTime.Now;
            date.AddHours(-1);
            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }
            string logInfo2 = "";
            for (int i = 0; i < count; i++)
                logInfo2 += logInfoArray2[i] + "\n";
            File.WriteAllText(logPath, logInfo2);
        }



        public static void SearchLog()
        {
            /*string logPath = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            string path = "/Users/eugene/Documents/app/note1.txt";
            using (StreamReader reader = new StreamReader(logP))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }
            }*/
            /* string logFile = GPALog.ReadLog();                                  /// string с самим логом полностью
             FileInfo logFileInfo = new FileInfo(logPath);
             DateTime lastHour = DateTime.Now;
             lastHour.AddHours(-1);                                              /// записи за последний час

             if (logFileInfo.LastWriteTime < lastHour)                           /// выводим только записи за час
             {
                 string writes = "\n=";                                          /// подстрока, считающая кол-во записей
                 int i = 0, j = -1, count = -1;
                 while ( logFileInfo.LastWriteTime < lastHour)                                                 /// механизм подсчета вхождений подстроки
                 {
                     i = logFile.IndexOf(writes, j + 1);
                     j = i;
                     count++;
                 }

                 Console.WriteLine("Записей за текущий час: " + (count));    /// -1 т.к. в конце есть еще одна "\n="
                 Console.WriteLine("Вывод этих записей: ");
                 Console.WriteLine(logFile);*/
        }
        }
       
      
    }

