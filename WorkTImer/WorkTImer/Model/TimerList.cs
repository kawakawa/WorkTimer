using System;
using System.Collections.Generic;

namespace WorkTimer.Model
{
    public class TimerList
    {



        private readonly List<TimeSpan> _timerList = new List<TimeSpan>();



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

            return ViewModel.DataFormat.ToTicks(sumTs);
        }

        public string GetListStr()
        {
            var list = new List<string>();

            foreach (var timeSpan in _timerList)
            {
                list.Add(ViewModel.DataFormat.ToTicks(timeSpan));
            }

            list.Reverse();


            return string.Join(Environment.NewLine, list.ToArray());
        }
    }
}
