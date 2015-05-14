using System;
using System.Threading;

namespace PriorityTest
{
    public class Test
    {
        object resourselock = new object();

        public void Run()
        {
            var lowestThread = new Thread(Low);
            lowestThread.Priority = ThreadPriority.Lowest;

            var highestThread = new Thread(High);
            highestThread.Priority = ThreadPriority.Highest;

            lowestThread.Start();
            Thread.Sleep(1000);   //makes sure that the lowest priority thread starts first
            highestThread.Start();
        }


        public void Low()
        {
            System.Console.WriteLine("Low priority task executed");

            lock (resourselock) {
                System.Console.WriteLine("Low priority task will never release the lock!");

                while (true)
                    ; //infinite empty statement!
            }
        }

        public void High()
        {
            System.Console.WriteLine("High priority task executed");

            lock (resourselock) {
                System.Console.WriteLine("High priority task got the lock!"); //this will never be reached!
            }
        }
    }
}

