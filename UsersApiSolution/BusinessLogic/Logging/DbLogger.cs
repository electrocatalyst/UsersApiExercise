﻿using System;
using System.IO;

namespace BusinessLogic.Logging
{
    public class DbLogger : ILogger
    {
        public bool LogMessage(string msg)
        {
            msg = Environment.NewLine + msg;
            File.AppendAllText("logs.txt", msg);
            Console.WriteLine("The log has been saved to the database.");

            return true;
        }
    }
}
