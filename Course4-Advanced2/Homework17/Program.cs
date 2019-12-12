using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Homework17
{
    class Program
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(4); // to limit the number or consumer threads
        static BlockingCollection<string> bFileCollection = new BlockingCollection<string>(boundedCapacity: 10); // to limit the initial feed of files to process
        static ConcurrentDictionary<string,string> cDictionary = new ConcurrentDictionary<string,string>(); // to output the file name and char count 

        static CancellationTokenSource cSource = new CancellationTokenSource(); // to signal the cancel when we have reached 10 files processed

        private static int filesProcessed = 0;

        static void Main(string[] args)
        {
            List<Task> _appTasks = new List<Task>();
            var cToken = cSource.Token;

            // Producer Task
            _appTasks.Add(Task.Factory.StartNew(() =>
            {
                string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\data";
                foreach (string file in Directory.EnumerateFiles(dir, "*.dat"))
                {
                    // we simulate the 'wait' for files ..
                    Thread.Sleep(TimeSpan.FromMilliseconds(new Random().Next(100, 500)));

                    Console.WriteLine($"[{DateTime.Now.ToString()}] Producer[{Thread.CurrentThread.ManagedThreadId}] Adding {file} to be processed");
                    bFileCollection.TryAdd(file, TimeSpan.FromSeconds(1));
                }

                bFileCollection.CompleteAdding();
            }));


            // Prepare the Consumers Tasks - up to 10 consumers locked by semaphoreSlim(4)
            for (int i = 0; i < 10; i++)
            {
                _appTasks.Add(Task.Factory.StartNew(() =>
                {
                    // Wait to get the lock; max 4
                    _sem.Wait(cToken);// cancellation token given

                    // While we have not closed the collection or cancellation was not requested
                    while (!bFileCollection.IsCompleted && !cToken.IsCancellationRequested)
                    {
                        string file;
                        if (bFileCollection.TryTake(out file, TimeSpan.FromSeconds(1)))
                        {
                            Console.WriteLine($"[{DateTime.Now.ToString()}] Consumer {Thread.CurrentThread.ManagedThreadId} is processing file {file}");

                            // Add to the concurrent dictionary
                            cDictionary.TryAdd(file, File.ReadAllText(file));

                            // Increment the filesProcessed
                            Interlocked.Increment(ref filesProcessed);

                            if(filesProcessed >= 10)
                            {
                                cSource.Cancel();
                            }
                            
                            Thread.Sleep(TimeSpan.FromSeconds(4));
                        }
                    }

                    _sem.Release();

                }, cToken));
            }

            try
            {
                Task.WaitAll(_appTasks.ToArray());
            }
            catch (AggregateException ex)
            {
                ex.Flatten().Handle(ex =>
                {
                    if (ex is TaskCanceledException)
                    {
                        Console.WriteLine("TaskCanceledException was handled ");
                        return true; // This exception is "handled"
                    }

                    return false; // All other exceptions will get rethrown
                });
            }
            
            
            Console.WriteLine("\n\n Files: ");
            foreach (var item in cDictionary)
            {
                Console.WriteLine($"File {item.Key} file is processed. Char count in file: {item.Value.Length}");
            }

        }
        
    }
}
