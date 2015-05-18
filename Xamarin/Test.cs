using System;
using System.Threading;

namespace PriorityTest
{
    public class Test
    {
        static int count = 0;

        public void Run()
        {
            var lowestThread = new Thread(Low);
            lowestThread.Priority = ThreadPriority.Lowest;
            lowestThread.Start();
            Thread.Sleep(1000);   //makes sure that the lowest priority thread starts first

            for (int i = 0; i < 20; i++) {
                var highestThread = new Thread(Normal);
                highestThread.Start();
            }
        }


        public void Low()
        {
            System.Console.WriteLine("Low priority task started");

            while (true) {
                Thread.Sleep(1000);
                System.Console.WriteLine("low prio task can still process stuff " + count);
            }
        }

        public void Normal()
        {
            System.Console.WriteLine("normal priority task started");

            while (true)
                count++;

        }
    }
}

