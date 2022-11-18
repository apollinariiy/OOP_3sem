using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab12
{
    public static class GPAFileInfo
    {
        public static void GetFileInfo()
        {
            string path = Path.GetFullPath(@"D:\3sem\ООП\лабы\лр1\OOP_3sem\OOP_lab12\OOP_lab12\gpalog.txt");
            string classLogInfo = "\n-----------------------   GPAFileInfo   -----------------------\n";
            string fileInfoLog = "";

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
                fileInfoLog = classLogInfo +
                              "\nПолный путь:              " + path +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;

            GPALog.WriteInLog(fileInfoLog);
        }
    }
}
