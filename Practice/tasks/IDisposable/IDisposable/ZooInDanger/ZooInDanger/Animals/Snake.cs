namespace Zoo.Animals
{
    public class Snake: Animal
    {
        public Snake(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
        }

        public override int LifeInterval
        {
            get { return 1; }
        }

        public override int InfectionResistance
        {
            get { return 80; }
        }
    }
}