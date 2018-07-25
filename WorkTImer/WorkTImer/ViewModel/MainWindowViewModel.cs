using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTImer.View;

namespace WorkTImer.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly View.MainWindow _window;

        public MainWindowViewModel()
        {
            _window =new MainWindow(this);
        }

        public void Show()
        {
            _window.Show();
        }
    }
}
