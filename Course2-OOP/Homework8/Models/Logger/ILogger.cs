using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models.Logger
{
    interface ILogger
    {
        public void Log(string msg);
        public void Close();
    }
}
