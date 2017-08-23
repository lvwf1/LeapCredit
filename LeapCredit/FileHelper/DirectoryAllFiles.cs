using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SlarkInc.Models;


namespace SlarkInc.FileHelper
{
    public class DirectoryAllFiles
    {
        static List<FileInformationModel> FileList = new List<FileInformationModel>();
        public static List<FileInformationModel> GetAllFiles(DirectoryInfo dir)
        {
            FileInfo[] allFile = dir.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                FileList.Add(new FileInformationModel { FileName = fi.Name, FilePath = fi.FullName });
            }
            DirectoryInfo[] allDir = dir.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                GetAllFiles(d);
            }
            return FileList;
        }
    }

   
}