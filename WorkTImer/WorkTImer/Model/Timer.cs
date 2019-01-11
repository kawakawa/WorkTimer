using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.Model
{
    public class Timer
    {

        private Stopwatch _sw;

        public bool IsStarting { get; private set; } = false;

        public Timer()
        {
            _sw = new Stopwatch();
        }



        public void Start()
        {
            if(IsStarting!=false)
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


        public string GetTicksString()
        {
            var ts = _sw.Elapsed.Ticks;
            return ts.ToString(@"dd\.hh\:mm\:ss");

        }

        public TimeSpan GetTicks()
        {
            return _sw.Elapsed;
        }



    }
}
