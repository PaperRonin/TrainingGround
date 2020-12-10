using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesHW
{
    abstract class Animal
    {
        #region fields

        private int _hunger;

        #endregion

        #region events

        public event Action<Animal> IsHungry;

        #endregion

        #region properties

        

        public string Name { get; }

        public int Hunger
        {
            get => _hunger;
            set
            {
                if (value <= 0)
                {
                    _hunger = 0;
                    IsHungry?.Invoke(this);
                }
                else
                {
                    _hunger = value;
                }
            }
        }

        #endregion

        protected Animal()
        {
            Name = "Unknown";
        }
        protected Animal(string name)
        {
            Name = name;
        }
    }
}
