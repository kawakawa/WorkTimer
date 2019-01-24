using System;
using System.Diagnostics;

namespace WorkTimer.Model
{
    public class TimeMeasurement
    {

        private readonly Stopwatch _sw;

        public bool IsStarting { get; private set; }

        public TimeMeasurement()
        {
            _sw = new Stopwatch();
        }



        public void Start()
        {
            if(IsStarting)
                return;

            IsStarting = true;
            _sw.Restart();
        }


        public void Stop()
        {
            if(IsStarting != true)
                return;

            IsStarting = false;
            _sw.Stop();
        }


//        public string GetTicksString()
//        {
//            var ts = _sw.Elapsed.Ticks;
//            return ts.ToString(@"dd\.hh\:mm\:ss");
//
//        }

        public TimeSpan GetTicks()
        {
            return _sw.Elapsed;
        }



    }
}
