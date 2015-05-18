namespace Zoo.Animals
{
    public class Rat: Animal
    {
        public Rat(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
        }

        public override int LifeInterval
        {
            get { return 3; }
        }

        public override int InfectionResistance
        {
            get { return 101; }
        }

        public override int HungerDeathInterval
        {
            get { return 100; }
        }
    }
}