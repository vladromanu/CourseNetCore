using Homework9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace HomeworkTests
{
    [TestClass]
    public class Homework9Tests
    {
        private List<string> TimerCallsStack { get; set; }
        public int TimerIncrement { get; set; }

        public Homework9Tests()
        {
            this.TimerIncrement = 0;
        }

        [TestMethod]
        public void TestTimmerIncrements()
        {
            HomeworkTimer timer = new HomeworkTimer(50, 10, 0, new HomeworkCallback(invokeCount => 
            {
                TimerCallsStack.Add($"Timer invoked ! #{(invokeCount).ToString()}");
                TimerIncrement++;
            }));

            timer.Start();

            Thread.Sleep(1000);

            // after ther timer stops check the timer increment and the timer call stack
            Assert.AreEqual(10, this.TimerIncrement);
            Assert.AreEqual(10, this.TimerCallsStack.Count);
        }
    }
}