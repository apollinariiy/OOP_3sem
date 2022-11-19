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

        }
    }
}
