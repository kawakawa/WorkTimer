using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WorkTimer.Model;

namespace WorkTimer.ViewModel
{
    public class ModeChangeVm
    {

        private Window _window;

        public ModeChangeVm(Window window)
        {
            _window = window;
        }



        public void Stop()
        {
            _window.Background = GetStatusBrush("#FF6C6A6A");
            AppStatus.NowMode = Mode.Stop;
        }



        public void Work()
        {
            _window.Background = GetStatusBrush("#FF0000cd");
            AppStatus.NowMode = Mode.Work;
        }




        public void Relax()
        {
            _window.Background = GetStatusBrush("#FF800000");
            AppStatus.NowMode = Mode.Relax;
        }








        private SolidColorBrush GetStatusBrush(string str)
        {
            object obj = System.Windows.Media.ColorConverter.ConvertFromString(str);
            var ret = new SolidColorBrush((System.Windows.Media.Color)obj);
            return ret;
        }
    }
}
