using System;
using System.Collections.Concurrent;
using System.Threading;

namespace CallCenter.Helpers
{
    static class Data
    {
        public static void GenerateCalls(ConcurrentQueue<ICall> calls)
        {
            Random callTimeGenerator = new Random();
            while (true)
            {
                int timeGenerator = callTimeGenerator.Next(3, 5);
                Thread.Sleep(timeGenerator * 1000);
                ICall call = new Call();
                calls.Enqueue(call);
                Console.WriteLine("New incomming call. Total number of calls: {0}", calls.Count);
            }
        }        
    }
}
