using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumFurnaceOvenDataRetriever
{
    class Program
    {
        //private static String Ov1 = @"ftp://192.168.1.101/DRV0/DATA0/";
        //private static String Ov2 = @"ftp://192.168.1.100/DRV0/DATA0/";
        //private static String Oven1 = @"ftp://192.168.1.101/DRV0/";
        //private static String Oven2 = @"ftp://192.168.1.100/DRV0/";
        //private static String Ov1Dir = @"C:\dev\TFE_Projects\TFE_VacuumFurnaceScheduler\OvenData\Oven1\Oven1-";
        //private static String Ov2Dir = @"C:\dev\TFE_Projects\TFE_VacuumFurnaceScheduler\OvenData\Oven2\Oven2-";
        
        static void Main(string[] args)
        {
            string fileDate = DateTime.Now.ToShortDateString();
            fileDate = fileDate.Replace("/", "-");
            fileDate = fileDate.Replace(" ", "_");
            fileDate += ".DAD";
            ftp ftpClient = new ftp(@"ftp://192.168.1.101/DRV0/", null, null);
            string[] dirFileListDetailed = ftpClient.directoryListDetailed("DATA0/");
            string newestOven1FileName = dirFileListDetailed.Last();
            string []dirFileList = newestOven1FileName.Split(' ');
            ftpClient = null;
            newestOven1FileName = dirFileList.Last();
            ftpClient = new ftp(@"ftp://192.168.1.101/DRV0/DATA0/", null, null);
            ftpClient.download(newestOven1FileName, @"C:\dev\TFE_Projects\TFE_VacuumFurnaceScheduler\OvenData\Oven1\Oven1-" + fileDate);

            ftpClient = null;
            ftpClient = new ftp(@"ftp://192.168.1.100/DRV0/", null, null);
            dirFileListDetailed = ftpClient.directoryListDetailed("DATA0/");
            string newestOven2FileName = dirFileListDetailed.Last();
            dirFileList = newestOven2FileName.Split(' ');
            ftpClient = null;
            newestOven2FileName = dirFileList.Last();
            ftpClient = new ftp(@"ftp://192.168.1.100/DRV0/DATA0/", null, null);
            ftpClient.download(newestOven2FileName, @"C:\dev\TFE_Projects\TFE_VacuumFurnaceScheduler\OvenData\Oven2\Oven2-" + fileDate);
            ftpClient = null;            
        }       
    }
}
