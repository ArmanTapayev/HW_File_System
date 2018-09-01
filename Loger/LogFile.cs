using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger
{
    public enum message { Error, Exeption, TestMessage, InfoMessage, Warning }
    public class LogFile
    {
        public DateTime DateTimeData { get; private set; }
        public message MessageType { get; private set; }
        public string Name { get; private set; }
        public string MessageText { get; private set; }

        public LogFile(DateTime dateTime, message msg, string name, string msgText)
        {
            DateTimeData = dateTime;
            MessageType = msg;
            Name = name;
            MessageText = msgText;
        }
    }
}
