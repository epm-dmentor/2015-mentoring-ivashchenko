using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Zoo.Animals;

namespace Zoo
{

    public class Zoo : IAnimalStatusTracker, IAnimalReceiver, ITickListener
    {
        private readonly Random _rnd = new Random();
        private readonly object _syncObj = new object();

        private const int infectionFrequency = 5;
        private const int infoFrequency = 5;

        private int _lastInfection;
        private int _lastInfo;

        private int _receivedAll;
        private int _dead;
        public static int NumCorpses = 0;
        private const int MaxAnimals = 1000;


        private readonly IList<IAnimal> _animals = new List<IAnimal>();

        public AnimalProvider Provider { get; set; }

        private void LiveOrganizer()
        {
            Interlocked.Increment(ref _lastInfection);
            Interlocked.Increment(ref _lastInfo);

            lock (_syncObj)
            {
                StatisticalInfection();
                CheckCriticalTroopsNumber();
            }
        }

        //As per statistic we have some level of infection each day. This funtion artifitially infects animals
        private void StatisticalInfection()
        {
            if (_lastInfection > infectionFrequency)
            {
                Interlocked.Exchange(ref _lastInfection, 0);
                _lastInfection = 0;
                InfectionInZoo();
            }
        }

        //Infect statictical number of animals in random positions
        private void InfectionInZoo()
        {
            lock (_syncObj)
            {
                var number = _rnd.Next(1, 10);

                while (number > 0 && _animals.Count > 0)
                {
                    var infectedPosition = _rnd.Next(0, _animals.Count - 1);
                    _animals[infectedPosition].Infect();
                    number--;
                }
            }
        }

        //Checks if number of troops (dead object with no references anywhere) is higher that accepted value
        private void CheckCriticalTroopsNumber()
        {
            if (_lastInfo > infoFrequency)
            {
                Interlocked.Exchange(ref _lastInfo, 0);
                ShowStatus();
                if (NumCorpses%1000 == 0 && NumCorpses > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Critical corpse number: {0}", NumCorpses);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Running CG collect");
                    Console.Beep();
                    GC.Collect();
                    Thread.Sleep(200);
                    Console.ResetColor();
                }
            }
        }


        //Show alive animals count, troops and few other params
        private void ShowStatus()
        {
            Logger.Log("Total received: {0}, Total dead: {1}, Now in zoo: {2}, corpses in zoo: {3}", _receivedAll, _dead, _animals.Count, NumCorpses);
        }


        //Processing in humger event of animal. Does feed animal if there is resources (based on random)
        public void IsInHunger(IAnimal animal)
        {
            //emulating feeding animal with some random values
            
            var foodProb = _rnd.Next(1, 100);
            if (foodProb < 96)
                animal.Eat(foodProb.ToString(CultureInfo.InvariantCulture));
        }


        //react on animal death
        public void Died(IAnimal animal)
        {
            lock (_syncObj)
            {
                //removed dead animals from registration book
                _animals.Remove(animal);

                //updated counters/statistic book, it is possible to use Interlocked.Increment for that needs
                //but as we locked syncObj we don't need that
                _dead++;
                NumCorpses++;

                //give more animals
                if (_animals.Count < MaxAnimals && Provider != null)
                    Provider.Resume();
            }
        }


        //Receives new animals from providers
        public void Receive(IAnimal animal)
        {
            lock (_syncObj)
            {
                //statistic
                _receivedAll++;

                //kill animal if no space for new one
                if (_animals.Count >= MaxAnimals)
                {
                    var toKill = _animals.OrderBy(a => a.Age).FirstOrDefault();
                    if (toKill != null)
                    {
                        toKill.Kill();
                        _animals.Remove(toKill);
                    }
                }

                //add need animal to the ZOO
                _animals.Add(animal);

                //if no space ask provider to stop sending new animals
                if (_animals.Count >= MaxAnimals && Provider != null)
                    Provider.Pause();
            }
        }


        //React on time tick on earth or other planed if chosen
        public void OnTick()
        {
            LiveOrganizer();
        }
    }
}