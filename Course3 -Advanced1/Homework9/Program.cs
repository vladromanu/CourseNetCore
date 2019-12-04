using System;
using System.Threading;

namespace Homework9
{
    public delegate void HomeworkCallback(int invokeCount);

    class Program
    {
        /// <summary>
        /// 1. Using delegates write a class Timer that can execute certain method at each t seconds.
        /// </summary>
        static void Main(string[] args)
        {
            // Tick - Tock Competing 
            HomeworkTimer timer = new HomeworkTimer(500, 5, 0, (invokeCount) =>
            {
                Console.WriteLine($"Tick ! #{(invokeCount).ToString()}");
            });
            timer.Start();


            HomeworkCallback hc = new HomeworkCallback(Tock);
            HomeworkTimer timer2 = new HomeworkTimer(500, 10, 0, hc);
            timer2.Start();


            // Offset timer 
            HomeworkTimer timer3 = new HomeworkTimer(500, 3, 5000, new HomeworkCallback(invokeCount => {
                Console.WriteLine($"Tzac - Pac ! #{(invokeCount).ToString()}");
            }));
            timer3.Start();



            Console.ReadKey();
        }

        static void Tock(int invokeCount)
        {
            Console.WriteLine($"Tock ! #{(invokeCount).ToString()}");
        }
    }
}