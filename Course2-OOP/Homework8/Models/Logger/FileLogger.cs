using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework8.Models.Logger
{
    class FileLogger : ILogger
    {
        private string docPath;

        public FileLogger()
        {
            this.docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public void Log(string msg)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AppLog.txt"), true))
            {
                outputFile.WriteLine(msg);
            }
        }

        public void Close()
        {
            try
            {   
                using (StreamReader sr = new StreamReader(Path.Combine(docPath, "AppLog.txt")))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

    }
}
