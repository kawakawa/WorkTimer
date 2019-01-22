using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
                sumTs=sumTs.Add(timeSpan);
            }

            return sumTs.ToString(@"dd\.hh\:mm\:ss");
        }

        public string GetListStr()
        {
            var list = new List<string>();

            foreach (var timeSpan in _timerList)
            {
                list.Add(timeSpan.ToString(@"dd\.hh\:mm\:ss"));
            }

            list.Reverse();


            return string.Join(Environment.NewLine, list.ToArray());
        }
    }
}
