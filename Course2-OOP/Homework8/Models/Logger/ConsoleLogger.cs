using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models.Logger
{
    class ConsoleLogger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
        public void Close()
        {
            Console.WriteLine("Bye Bye !");
        }
    }
}
