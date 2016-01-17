using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.GameLogic.WritersReaders
{
    public interface IReader
    {
        string Read(string FilePath);
        bool FileExists(string FilePath);
        string SaveFilePath(string fileName);
        string DataFilePath(string fileName);
        string RecordFilePath(string fileName);
    }
}
