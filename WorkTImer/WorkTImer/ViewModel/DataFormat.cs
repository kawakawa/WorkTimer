using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.ViewModel
{
    public static class DataFormat
    {
        public static string ToTicks(TimeSpan ts)
        {
            return ts.ToString(@"dd\.hh\:mm\:ss");
        }
    }
}
