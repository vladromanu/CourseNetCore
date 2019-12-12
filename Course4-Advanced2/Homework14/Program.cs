using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Homework14
{
    // Integer with the largest number of divisors.
    //  - Write a program that uses multiple threads to find the integer in the range 1 to 100 000 that has the largest number of divisors.
    //  - By using threads, your program will should take less time to do the computation when it is run on a multiprocessor computer.
    //  - At the end of the program, output the elapsed time, the integer that has the largest number of divisors, and the number of divisors that it has.
    class Program
    {
        private static int maxNumber = 100000;
        private static int _batchSize = 10000;

        private static ConcurrentBag<Record> _staticBag = new ConcurrentBag<Record>();

        private static IEnumerable<int> ProperDivisors(int number)
        {
            return
                Enumerable.Range(1, number / 2)
                    .Where(divisor => number % divisor == 0);
        }

        static void Main(string[] args)
        {
            SolutionThreads();

            //SolutionTaskFactoryContinueWhenAll();

            //SolutionTaskFactoryContinueWithFromParentTask();

            Console.ReadKey();
        }

        private static void SolutionThreads()
        {
            List<Thread> _threadList = new List<Thread>();

            for (int i = 0; i < maxNumber/_batchSize; i++)
            {
                var thread = new Thread(FindMaxDivisors);
                _threadList.Add(thread);

                thread.Start(i);
            }

            foreach (var task in _threadList)
            {
                task.Join();
            }

            Record result = (from record in _staticBag
                             orderby record.DivisorsCount descending
                             select record).First();

            Console.WriteLine($"Number: {result.Number} \nDivisors: {result.DivisorsCount}");

        }

        public static void FindMaxDivisors(object start)
        {
            Record record = Enumerable.Range((int) start * _batchSize, _batchSize).Select(number => new Record()
            {
                Number = number,
                DivisorsCount = ProperDivisors(number).Count()
            }).OrderByDescending(currentRecord => currentRecord.DivisorsCount).First();

            _staticBag.Add(record);
        }


        private static void SolutionTaskFactoryContinueWhenAll()
        {
            int threadsNumber = 10;
            int batchSize = maxNumber / threadsNumber;

            // Keep the task List and a Record List 
            Task[] _taskList = new Task[threadsNumber];

            // Create a concurrent collection for adding results
            ConcurrentBag<Record> bag = new ConcurrentBag<Record>();

            // Create the Task Factory and add all the Tasks from 0 to threadsNumber to process different ranges in parallel 
            TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                      
            for (int i = 0; i < threadsNumber; i++)
            {
                // Start new Tasks for each segment we need to calculate; pass in the index 
                _taskList[i] = tf.StartNew((object obj) =>
                {
                    Record record = Enumerable.Range((int)obj * batchSize, batchSize).Select(number => new Record()
                    {
                        Number = number,
                        DivisorsCount = ProperDivisors(number).Count()
                    }).OrderByDescending(currentRecord => currentRecord.DivisorsCount).First();

                    bag.Add(record);
                }, i );
            }

            // Wait for all to finish then output
            Task.Factory.ContinueWhenAll(_taskList, completedTasks => {
                Record result = (from record in bag
                                 orderby record.DivisorsCount descending
                                 select record).FirstOrDefault();

                Console.WriteLine($"Number: {result.Number} \nDivisors: {result.DivisorsCount}");
            });

        }



        private static void SolutionTaskFactoryContinueWithFromParentTask()
        {
            int threadsNumber = 10;
            int batchSize = maxNumber / threadsNumber;

            // Create a concurrent collection for adding results
            ConcurrentBag<Record> bag = new ConcurrentBag<Record>();

            // Create main task to merge the results from separate tasks
            Task resultsFetcherTask = new Task(() =>
            {
                // Create the Task Factory and add all the Tasks from 0 to threadsNumber to process different ranges in parallel 
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                for (int i = 0; i < threadsNumber; i++)
                {
                    // Start new Tasks for each segment we need to calculate
                    tf.StartNew((object obj) =>
                    {
                        Record record = Enumerable.Range((int)obj * batchSize, batchSize).Select(number => new Record()
                        {
                            Number = number,
                            DivisorsCount = ProperDivisors(number).Count()
                        }).OrderByDescending(currentRecord => currentRecord.DivisorsCount).First();

                        bag.Add(record);
                    }, i);
                }
            });

            // Start the main parent task
            resultsFetcherTask.Start();

            // Wait for the main task to finish and print the results
            var finalTask = resultsFetcherTask.ContinueWith(
                previous =>
                {
                    Record result = (from record in bag
                                  orderby record.DivisorsCount descending
                                  select record).FirstOrDefault();

                    Console.WriteLine($"Number: {result.Number} \nDivisors: {result.DivisorsCount}");

                });

            finalTask.Wait();
        }
    }
}
