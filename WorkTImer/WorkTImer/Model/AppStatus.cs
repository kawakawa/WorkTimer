using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.Model
{
    public class AppStatus
    {
        /// <summary>
        /// 現在のタイマー状態
        /// </summary>
        public static Mode NowMode { get; set; }



        public static void Init()
        {
            NowMode = Mode.Stop;
        }
    }
}
