using System;

namespace Zoo.Animals
{
    public class Cat : Animal
    {
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

            // Release the object only in case number of corpses > 100
            while (Zoo.NumCorpses > 200) { }
        }
    }
}