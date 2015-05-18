namespace Zoo.Animals
{
    public class Dog: Animal
    {
        public Dog(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
        }

        public override int LifeInterval
        {
            get { return 3; }
        }

        public override int EatInterval
        {
            get { return 5; }
        }

        public override int HungerDeathInterval
        {
            get { return 10; }
        }
    }
}