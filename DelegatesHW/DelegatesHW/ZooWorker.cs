using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesHW
{
    class ZooWorker
    {
        private int FoodAmount { get; set; }

        public ZooWorker(ushort foodAmount)
        {
            FoodAmount = foodAmount;
        }

        public void Feed(Animal animal)
        {
            animal.Hunger += FoodAmount;
            Console.WriteLine($"Worker has fed {animal.GetType().Name} with name \"{animal.Name}\"");
        }
    }
}
