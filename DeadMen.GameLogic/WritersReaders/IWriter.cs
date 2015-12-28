using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.GameLogic.WritersReaders
{
    public interface IWriter
    {
        void Write(string data, string fileFullPath);
    }
}
