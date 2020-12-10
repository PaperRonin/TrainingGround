using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesHW
{
    class Lion : Animal
    {
        public Lion(string name) : base(name)
        {
            Hunger = 10;
            IsHungry += (lion) => Console.WriteLine($"Lion with name \"{lion.Name}\" is hungry!");
        
        }

        public void Walk()
        {
            Console.WriteLine("Lion is walking");
            Hunger -= 5;
        }

    }
}
