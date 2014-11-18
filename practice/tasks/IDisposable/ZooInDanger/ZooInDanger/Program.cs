using System;
using System.Threading;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log("Starting program");

            var thread = new Thread(() =>
            {                
                var zoo = new Zoo();
                EarthLiveTicker.LiveTicker.Subscribe(zoo);
                var animalProvider = new AnimalProvider(zoo);
                EarthLiveTicker.LiveTicker.Subscribe(animalProvider);
            });
            thread.Start();

            Logger.Log("Animan provider started working");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
