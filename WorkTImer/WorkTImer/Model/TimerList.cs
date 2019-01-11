using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.Model
{
    public class TimerList
    {


        private TimerKbn _timerKbn;

        private List<TimeSpan> _timerList = new List<TimeSpan>();

        /// <inheritdoc />
        public TimerList(TimerKbn timerKbn)
        {
            this._timerKbn = timerKbn;
        }


        public void Add(TimeSpan ts)
        {
            _timerList.Add(ts);
        }


        public string GetSumString()
        {
            var sumTs = new TimeSpan();
            foreach (var timeSpan in _timerList)
            {
                sumTs.Add(timeSpan);
            }

            return sumTs.ToString(@"dd\.hh\:mm\:ss");
        }
    }
}
