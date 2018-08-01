using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTImer.Command;
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

        //Command

        //仕事ボタン
        private ButtonWorkCommand _buttonWorkCommand;
        public ButtonWorkCommand ButtonWorkCommand => 
            _buttonWorkCommand ?? (_buttonWorkCommand = new ButtonWorkCommand(WorkTimerCountStart));

        private void WorkTimerCountStart(object obj)
        {
            throw new NotImplementedException();
        }



        //Relaxボタン
        private ButtonRelaxCommand _buttonRelaxCommand;

        public ButtonRelaxCommand ButtonRelaxCommand =>
            _buttonRelaxCommand ?? (_buttonRelaxCommand = new ButtonRelaxCommand(WorkTimerCountStart));



        //TimerStopボタン
        private ButtonStopTimerCommand _buttonStopTimerCommand;

        public ButtonStopTimerCommand ButtonStopTimerCommand =>
            _buttonStopTimerCommand ?? (_buttonStopTimerCommand = new ButtonStopTimerCommand(WorkTimerCountStart));







        public void Show()
        {
            _window.Show();
        }
    }
}
