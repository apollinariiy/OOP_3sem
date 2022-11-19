using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab12
{
    public class GPAFileManager
    {

        //Прочитать список файлов и папок заданного диска.
        public static void GetList(string path)
        {
            string classLogInfo = "\n-----------------------   GPAFileManager   -----------------------\n";
            string FileList = "";
            
            DriveInfo[] drives = DriveInfo.GetDrives();
            string[] dirs = System.IO.Directory.GetDirectories(path);
            string[] files = System.IO.Directory.GetFiles(path);

            FileList = "\nПапки:\n";
            foreach (string dir in dirs)
            {
                FileList += dir + "\n";
            }

            FileList += "\nФайлы:\n";
            foreach (string file in files)
            {
                FileList += file + "\n";
            }

            string FileListLog = classLogInfo + FileList;

            GPALog.WriteInLog(FileListLog);
        }
        //Создать директорий XXXInspect
        public static void CreateDir(string path)
        {
            string classLogInfo = "\n-----------------------   GPAFileManager - 2   -----------------------\n";
            string CreateDirLog = "";

            try
            {
                Directory.CreateDirectory(path);
                CreateDirLog = classLogInfo + "\nДиректорий создан";
            }
            catch (Exception e)
            {
                CreateDirLog = classLogInfo + "\nОшибка создания директория: " + e.Message;
            }

            GPALog.WriteInLog(CreateDirLog);
        }
        //создать текстовый файл xxxdirinfo.txt и сохранить туда информацию.
        public static void CreateFile(string path)
        {
            string classLogInfo = "\n-----------------------   GPAFileManager - 3   -----------------------\n";
            string CreateFileLog = "";

            FileInfo fileInfo = new FileInfo(path);                 
            using (StreamWriter sw = fileInfo.CreateText())            
            {
                sw.WriteLine("Файл создан");
                sw.Close();                                             
            }
            CreateFileLog = classLogInfo + "\nФайл создан";
        }
        //Создать копию файла и переименовать его. Удалить первоначальный файл.
        public static void CopyFile(string path, string path2)
        {
            string classLogInfo = "\n-----------------------   GPAFileManager - 4   -----------------------\n";
            string CopyFileLog = "";

            try
            {
                File.Copy(path, path2);
                
                CopyFileLog = classLogInfo + "\nФайл скопирован";
            }
            catch (Exception e)
            {
                CopyFileLog = classLogInfo + "\nОшибка копирования файла: " + e.Message;
            }
            //удалить файл
            FileInfo delete = new FileInfo(path);
            delete.Delete();
            GPALog.WriteInLog(CopyFileLog);
        }
        //Создать еще один директорий XXXFiles. Скопировать в него все файлы с заданным расширением из заданного пользователем директория. Переместить XXXFiles в XXXInspect.
        public static void CopyFiles(string path, string path2, string path3)
        {
            string classLogInfo = "\n-----------------------   GPAFileManager - 5   -----------------------\n";
            string CopyFilesLog = "";

            try
            {
                Directory.CreateDirectory(path2);
                
                string[] files = Directory.GetFiles(path, "*.docx");
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(path2, fileName);
                    File.Copy(file, destFile, true);
                }
                CopyFilesLog = classLogInfo + "\nФайлы скопированы";
            }
            catch (Exception e)
            {
                CopyFilesLog = classLogInfo + "\nОшибка копирования файлов: " + e.Message;
            }
            //переместить XXXFiles в XXXInspect
            try
            {
                string path4 = path3 + @"\GPAFiles";

               
                DirectoryInfo destDir = new DirectoryInfo(path4);
                if (destDir.Exists)
                    destDir.Delete(true);
                Directory.Move(path2, path4);
                CopyFilesLog = classLogInfo + "\nФайлы перемещены";
            }
            catch (Exception e)
            {
                CopyFilesLog = classLogInfo + "\nОшибка перемещения файлов: " + e.Message;
            }
            GPALog.WriteInLog(CopyFilesLog);
        }
        //Сделайте архив из файлов директория XXXFiles. Разархивируйте его в другой директорий.
        public static void ZipFiles(string path, string path2, string path3)
        {
            string classLogInfo = "\n-----------------------   GPAFileManager - 6   -----------------------\n";
            string ZipFileLog = "";

            try
            {
                ZipFile.CreateFromDirectory(path, path2);
                ZipFileLog = classLogInfo + "\nАрхив создан";
            }
            catch (Exception e)
            {
                ZipFileLog = classLogInfo + "\nОшибка создания архива: " + e.Message;
            }
            //Разархивируйте его в другой директорий.
            try
            {
                ZipFile.ExtractToDirectory(path2, path3);
                ZipFileLog = classLogInfo + "\nАрхив разархивирован";
            }
            catch (Exception e)
            {
                ZipFileLog = classLogInfo + "\nОшибка разархивирования архива: " + e.Message;
            }
            GPALog.WriteInLog(ZipFileLog);
        }

    }
}
