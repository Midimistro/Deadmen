﻿
using System.IO;
using System.Text;

namespace DeadMen.GameLogic.WritersReaders
{
    public interface IWriter
    {
        void Write(string data, string fileFullPath);
        string SaveFilePath(string fileName);
        string DataFilePath(string fileName);
        string RecordFilePath(string fileName);
    }
}
