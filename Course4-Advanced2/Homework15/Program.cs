using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Homework15
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Having the 10 files at some location (containing words), read the data using tasks and use TPL in order to:
                count of all words
                count of distinct words
                search for a specific words (contains)

                group words per categories
                    xs (0-5 chars)
                    s (5-10 chars)
                    m (10-15 chars)
                    l (larger than 15)

                you have files here: https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/advanced.day.02.threading.home/data
                you can generate own files also using https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/advanced.day.02.threading.home/sln/WordGenerator (just run the console)
            */

            // Create a concurrent collection for adding results
            ConcurrentBag<string> bag = new ConcurrentBag<string>();

            // Create the Task Factory and add all the Tasks from 0 to threadsNumber to process different ranges in parallel 
            TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

            for (int i = 0; i < 10; i++)
            {
                // Start new Tasks for each segment we need to calculate
                tf.StartNew(() =>
                {

                    bag.Add("");

                });
            }

           

            Console.WriteLine("Hello World!");
        }

        private async Task<string> DownloadString(string url)
        {
            return await new WebClient().DownloadStringTaskAsync(url);
        }
    }
}
