using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab12
{
    public static class GPADiskInfo
    {
        public static void GetDiskInfo()
        {
            string classLogInfo = "\n-----------------------   GPADiskInfo   -----------------------\n";  
            string DiskInfo = "";                           

            DriveInfo[] drives = DriveInfo.GetDrives();     /// массив объектов типа DriveInfo с инфой о дисках

            DiskInfo = "\nИмя диска:                " + drives[0].Name +//имя диска
                       "\nФайловая система:         " + drives[0].DriveFormat +//имя файловой системы
                       "\nДоступное место:          " + drives[0].AvailableFreeSpace +//свободное место на диске
                       "\nРазмер диска:             " + drives[0].TotalSize +//размер диска
                       "\nМетка тома диска:         " + drives[0].VolumeLabel + "\n" +//метка тома

                       "\nИмя диска:                " + drives[1].Name +
                       "\nФайловая система:         " + drives[1].DriveFormat +
                       "\nДоступное место:          " + drives[1].AvailableFreeSpace +
                       "\nРазмер диска:             " + drives[1].TotalSize  +
                       "\nМетка тома диска:         " + drives[1].VolumeLabel + "\n" +

                       "\nИмя диска:                " + drives[2].Name +
                       "\nФайловая система:         " + drives[2].DriveFormat +
                       "\nДоступное место:          " + drives[2].AvailableFreeSpace +
                       "\nРазмер диска:             " + drives[2].TotalSize +
                       "\nМетка тома диска:         " + drives[2].VolumeLabel + "\n";



            string DiskInfoLog = classLogInfo + DiskInfo;

            GPALog.WriteInLog(DiskInfoLog);
        }

    }
}
