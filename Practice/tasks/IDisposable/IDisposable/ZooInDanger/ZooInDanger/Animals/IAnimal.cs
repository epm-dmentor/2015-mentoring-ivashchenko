namespace Zoo.Animals
{
    //Inheriting IDisposable is overdesign, but every our animal is need to be disposed!!!
    public interface IAnimal//: IDisposable
    {
        void Eat(string eatName);
        int Age { get; }
        bool IsAlive { get; }
        void Kill();
        void Infect();
    }
}