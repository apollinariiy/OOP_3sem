using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOP_lab12
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                GPALog.WriteLogInfo();
                GPADiskInfo.GetDiskInfo();
                GPAFileInfo.GetFileInfo();
                GPADirInfo.GetDirInfo();
                GPAFileManager.GetList(@"D:\");
                GPAFileManager.CreateDir(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect");
                GPAFileManager.CreateFile(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect\gpadirinfo.txt");
                GPAFileManager.CopyFile(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect\gpadirinfo.txt", @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect\gpadirinfo_copy.txt");
                GPAFileManager.CopyFiles(@"D:\3sem\ООП", @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAFiles", @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect");
                GPAFileManager.ZipFiles(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect\GPAFiles", @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\GPAInspect\GPAFiles.zip", @"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\ForZip");
                GPALog.Count();
                /* GPALog.ReadLog();
                 GPALog.SearchLog();*/
                GPALog.FindLogInfo("GPAFileManager");
                GPALog.FindLogInfoDay(new DateTime(2022, 11, 20, 0, 14, 29));
                GPALog.FindLogInfoTime(new DateTime(2022, 11, 20, 0, 14, 29), new DateTime(2022, 11, 20, 0, 18, 38));
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Ошибка! Директорий не найден.\n" + e.Message);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Ошибка! Файл уже существует или используется другим процессом.\n" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Непредвиденная ошибка!\n" + e.Message);
            }


        }
       
       
        }
    }

