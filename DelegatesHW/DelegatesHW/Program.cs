using System;
using System.Threading;

namespace DelegatesHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion("Scar");
            ZooWorker worker = new ZooWorker(13);

            lion.IsHungry += worker.Feed;

            for (int i = 0; i < 5; i++)
            {
                lion.Walk();
                Thread.Sleep(1000);
            }
        }
    }
}
