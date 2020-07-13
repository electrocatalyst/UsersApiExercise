using System;

namespace BusinessLogic.Logging
{
    public class EmailLogger : ILogger
    {
        public void LogMessage(string msg)
        {
            msg = Environment.NewLine + msg;
            SendLogEmail("admin@logserver.com", msg);
            Console.WriteLine("The log has been sent to an email address.");
        }

        void SendLogEmail(string address, string msg)
        {
            (string, string) unused = (address, msg);
        }
    }
}
