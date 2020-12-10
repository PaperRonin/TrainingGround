using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsHW
{
    class Counter
    {
        public int Count { get; set; }
    }

    class Program
    {
        private static void Incrementer(object obj)
        {
            if (!(obj is Counter counter))
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                lock (counter)
                {
                    counter.Count++;
                    Console.WriteLine($"Tread with ID {Thread.CurrentThread.ManagedThreadId} incremented counter up to {counter.Count}");
                }
            }
        }
        static void Main(string[] args)
        {
            var counter = new Counter();
            for (int i = 0; i < 3; i++)
            {
                new Thread(Incrementer).Start(counter);
            }

            Console.ReadKey();
        }
    }
}
