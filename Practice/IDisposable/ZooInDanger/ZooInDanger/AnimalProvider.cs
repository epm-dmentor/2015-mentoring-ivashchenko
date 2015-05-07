using System;
using Zoo.Animals;

namespace Zoo
{
    public class AnimalProvider: ITickListener
    {
        private readonly object _sync = new object();
        private int _lastGeneration;
        private bool _wait = true;
        private readonly Zoo _zoo;
        private const int GenerationInterval = 5;

        public AnimalProvider(Zoo zoo)
        {
            _zoo = zoo;
            _zoo.Provider = this;

            for (var i = 0; i < 1000; i++)
                GenerateAnimal();
        }

        private void OnGeneration()
        {
            if (!_wait)
            {
                var rnd = new Random();
                var number = rnd.Next(1, 10);

                while (number > 0)
                {
                    GenerateAnimal();
                    number--;
                }
            }

        }

        private void GenerateAnimal()
        {
            var rnd = new Random();

            var prob = rnd.Next(0, 100);
            Animal newAnimal = null;
            if (prob < 25)
            {
                newAnimal= new Rat(_zoo);
            }
            else if (prob < 35)
            {
                newAnimal = new Elephant(_zoo);
            }
            else if (prob < 70)
            {
                newAnimal = new Cat(_zoo);
            }
            else if (prob < 95)
            {
                newAnimal = new Dog(_zoo);
            }
            else if (prob < 100)
            {
                newAnimal = new Snake(_zoo);
            }

            EarthLiveTicker.LiveTicker.Subscribe(newAnimal);
            _zoo.Receive(newAnimal);
        }

        public void Pause()
        {
            lock (_sync)
            {
                if (!_wait)
                {
                    //Logger.Log("Provider: Animal providing has been stopped");
                    _wait = true;
                }
            }
        }

        public void Resume()
        {
            lock (_sync)
            {
                if (_wait)
                {
                    //Logger.Log("Provider: Animal providing has been started");
                    _wait = false;
                }
            }
        }

        public void OnTick()
        {
            _lastGeneration++;
            if (_lastGeneration >= GenerationInterval)
            {
                _lastGeneration = 0;
                OnGeneration();
            }

        }
    }
}
