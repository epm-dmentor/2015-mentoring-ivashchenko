namespace Zoo.Animals
{
    public class Elephant: Animal
    {
        public Elephant(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
        }

        public override int LifeInterval
        {
            get { return 100; }
        }
    }
}