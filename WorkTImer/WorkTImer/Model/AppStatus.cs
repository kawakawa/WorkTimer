using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.Model
{
    public class AppStatus
    {
        public static Mode NowMode { get; set; }



        public static void Init()
        {
            NowMode = Mode.Stop;
        }
    }
}
