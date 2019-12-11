using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        private static IEnumerable<int> ProperDivisors(int number)
        {
            return
                Enumerable.Range(1, number / 2)
                    .Where(divisor => number % divisor == 0);
        }

        static void Main(string[] args)
        {

            SolutionTaskFactoryContinueWhenAll();

            //SolutionTaskFactoryContinueWithFromParentTask();

            Console.ReadKey();

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
                // Start new Tasks for each segment we need to calculate
                _taskList[i] = tf.StartNew(() =>
                {

                    Record record = Enumerable.Range(i * batchSize, batchSize).Select(number => new Record()
                    {
                        Number = number,
                        DivisorsCount = ProperDivisors(number).Count()
                    }).OrderByDescending(currentRecord => currentRecord.DivisorsCount).First();

                    bag.Add(record);

                });
            }

            // Wait for all to finish then output
            Task.Factory.ContinueWhenAll(_taskList, completedTasks => {
                foreach (var record in bag)
                {
                    Console.WriteLine("{0}: {1}", record.Number, record.DivisorsCount);
                }
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
                    tf.StartNew(() =>
                    {

                        Record record = Enumerable.Range(i * batchSize, batchSize).Select(number => new Record()
                        {
                            Number = number,
                            DivisorsCount = ProperDivisors(number).Count()
                        }).OrderByDescending(currentRecord => currentRecord.DivisorsCount).First();

                        bag.Add(record);

                    });
                }
            });

            // Start the main parent task
            resultsFetcherTask.Start();

            // Wait for the main task to finish and print the results
            var finalTask = resultsFetcherTask.ContinueWith(
                previous =>
                {
                    foreach (var record in bag)
                    {
                        Console.WriteLine("{0}: {1}", record.Number, record.DivisorsCount);
                    }
                });

            finalTask.Wait();
        }

        
    }
}
