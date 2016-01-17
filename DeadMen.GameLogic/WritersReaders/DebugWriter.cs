﻿using System.Text;
using System.IO;
using DeadMen.API.Models;

namespace DeadMen.GameLogic.WritersReaders
{
    public class DebugWriter : IWriter
    {
        public static string rootDataDirectory = @"%AppData%\DeadMen\";
        public static string saveDataDirectory = rootDataDirectory + @"saves\";
        public static string gameDataDirectory = rootDataDirectory + @"data\";

        static DebugWriter()
        {

        }

        public void Write(string data, string fileFullPath)
        {
            File.WriteAllBytes(fileFullPath, Encoding.UTF8.GetBytes(data));
        }

        public string SaveFilePath(string fileName)
        {
            return string.Format("{0}{1}.DMsv_debug", rootDataDirectory, fileName);
        }

        public string DataFilePath(string fileName)
        {
            return string.Format("{0}{1}.DMgd_debug", gameDataDirectory, fileName);
        }

        public string RecordFilePath(string fileName)
        {
            return string.Format("{0}{1}.DMrec_debug", saveDataDirectory, fileName);
        }
    }
}
