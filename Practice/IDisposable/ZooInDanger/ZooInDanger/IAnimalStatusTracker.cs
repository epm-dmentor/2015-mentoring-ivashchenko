using Zoo.Animals;

namespace Zoo
{
    public interface IAnimalStatusTracker
    {
        void IsInHunger(IAnimal animal);
        void Died(IAnimal animal);
    }
}