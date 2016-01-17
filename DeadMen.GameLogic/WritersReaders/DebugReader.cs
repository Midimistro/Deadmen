using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DeadMen.GameLogic.WritersReaders
{
    public class DebugReader : IReader
    {
        public static string rootDataDirectory = @"%AppData%\DeadMen\";
        public static string saveDataDirectory = rootDataDirectory + @"saves\";
        public static string gameDataDirectory = rootDataDirectory + @"data\";

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string Read(string fileFullPath)
        {
            return File.ReadAllBytes(fileFullPath).ToString();
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
