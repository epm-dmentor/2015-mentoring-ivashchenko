using Zoo.Animals;

namespace Zoo
{
    public interface IAnimalReceiver
    {
        void Receive(IAnimal animal);
    }
}