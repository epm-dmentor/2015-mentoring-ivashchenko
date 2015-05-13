using System;
using System.Collections.Generic;
using System.Threading;

namespace Zoo.Animals
{
    /// <summary>
    /// Stays alive if less than 200 corpses in zoo.
    /// </summary>
    public class Cat : Animal
    {
        private static List<Cat> _cats = new List<Cat>();
        private int _nth = 0;

        public Cat(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
        }

        public override int LifeInterval
        {
            get { return 13; }
        }

        public override int InfectionDeathInterval
        {
            get { return 300; }
        }

        ~Cat()
        {
            Logger.LogYellow("Finalizing cat!");

            if (Zoo.Troops < 200)
            {
                Logger.LogYellow("Zoo Troops/Cats Counts (" + Zoo.Troops + "/" + _cats.Count + ") Saving cat! " + ++_nth + " time");
                Interlocked.Increment(ref Zoo.Troops);

                _cats.Add(this);
                GC.ReRegisterForFinalize(this);
            }
            else 
            {
                Logger.LogYellow("Zoo Troops/Cats Counts (" + Zoo.Troops + "/" + _cats.Count + ") Finalizing cat! " + _nth + " time");

                _cats.Clear();
            }

            //Releasea object only in case troops number > 100
            //while (Zoo.Troops > 200) { }
        }
    }
}