using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo
{
    public class EarthLiveTicker: ILiveTicker
    {
        private static readonly EarthLiveTicker LiveTiker = new EarthLiveTicker();

        private readonly object _syncObj = new object();
        private readonly IList<ITickListener> _listeners = new List<ITickListener>();
        public const int Interval = 10;

        private readonly System.Timers.Timer tickTimer;

        private EarthLiveTicker()
        {
            tickTimer = new System.Timers.Timer(Interval);
            tickTimer.Elapsed += (o, e) => RunClock();
            tickTimer.AutoReset = true;
            tickTimer.Start();
        }

        public static ILiveTicker LiveTicker { get { return LiveTiker; } }

        public void Subscribe(ITickListener tickListener)
        {
            lock (_syncObj)
            {
                if (tickListener != null)
                    _listeners.Add(tickListener);
            }
        }

        public void Unsubscribe(ITickListener tickListener)
        {
            lock (_syncObj)
            {
                _listeners.Remove(tickListener);
            }
        }

        private void RunClock()
        {
            new Task(() =>
            {
                lock (_syncObj)
                {
                    var snapshot = _listeners.ToList();
                    foreach (var tickListener in snapshot)
                    {
                        tickListener.OnTick();
                    }
                }                
            }).Start();
        }
    }
}