using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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

        public void Write(string data,string fileFullPath)
        {
            File.WriteAllBytes(fileFullPath, Encoding.UTF8.GetBytes(data));
        }
    }
}
