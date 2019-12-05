using System;
using System.Threading;

namespace Homework9
{
    public class HomeworkTimer
    {
        private int Period { get; set; }
        private int Runs { get; set; }
        private int StartTime { get; set; }
        private HomeworkCallback Callback { get; set; }

        private int invokeCount = 0;
        private Timer timer; 


        public HomeworkTimer() : this(500, 10, 0,(invokeCO) => { }) { }
        public HomeworkTimer(int miliseconds, int runs, int start, HomeworkCallback d)
        {
            this.Period = miliseconds;
            this.Runs = runs;
            this.StartTime = start;
            this.Callback = d;
        }

        public void Start()
        {
            // this.CheckState is also a TimerCallback delegate so this can also be fed in the constructor but the check invokeCount should be universal
            this.timer = new System.Threading.Timer(this.CheckState, new AutoResetEvent(false), this.StartTime, this.Period);
        }

        private void CheckState(object state)
        {
            // Invoke the callback with params 
            this.Callback(invokeCount);

            Console.WriteLine("Tiggered at [{0}]", DateTime.Now.ToString("h:mm:ss.fff"));

            // Stop when we're reached the limit 
            if (++this.invokeCount >= this.Runs)
            {
                invokeCount = 0;

                if (timer != null)
                {
                    this.timer.Dispose();
                    Console.WriteLine("Dispose timer..\n");
                }
            }
        }
    }
}