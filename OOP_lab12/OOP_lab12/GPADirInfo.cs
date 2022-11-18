using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab12
{
    public static class GPADirInfo
    {
           
            public static void GetDirInfo()
            {
                string path = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem");
                string DirInfoLog = "";

                DirectoryInfo dirInfo = new DirectoryInfo(path);

                if (dirInfo.Exists)
                    DirInfoLog = "\n-----------------------   GPAFileInfo   -----------------------\n" +
                    "             \nИмя директории:           " + dirInfo.Name +
                                 "\nКоличество файлов:        " + dirInfo.GetFiles().Length +
                                 "\nВремя создания:           " + dirInfo.LastWriteTime +
                                 "\nКол-во поддиректориев:    " + dirInfo.GetDirectories().Length +
                                 "\nРодительский директорий:  " + dirInfo.Parent.Name;

                GPALog.WriteInLog(DirInfoLog);
            }
    }
}
