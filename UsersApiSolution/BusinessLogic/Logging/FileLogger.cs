using System;
using System.IO;

namespace BusinessLogic.Logging
{
    public class FileLogger : ILogger
    {
        public bool LogMessage(string msg)
        {
            msg = Environment.NewLine + msg;
            File.AppendAllText("logs.txt", msg);
            Console.WriteLine("The log has been saved to a file.");

            return true;
        }
    }
}
