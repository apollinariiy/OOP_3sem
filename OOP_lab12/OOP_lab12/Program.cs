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
       
        public static void FindInfo()
        {
            //Немного шиткода и танцев с бубном ради странного функционала,но его люди обычно вообще не делают,так что я хоть попытался и оно працуе 
            var output = new StringBuilder();

            using (var stream = new StreamReader(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt"))
            {
                var textline = "";
                var isActual = false;
                while (stream.EndOfStream == false)
                {
                    isActual = false;
                    textline = stream.ReadLine();
                    if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                    {
                        isActual = true;
                        textline += "\n";
                        output.AppendFormat(textline);
                    }

                    textline = stream.ReadLine();
                    while (textline != "------------------------------")
                    {
                        if (isActual)
                        {
                            textline += "\n";
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                    }

                    if (isActual) output.AppendFormat("------------------------------\n");
                }
            }

            using (var stream = new StreamWriter(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt"))
            {
                stream.WriteLine(output.ToString());
            }
        }
    }
}
