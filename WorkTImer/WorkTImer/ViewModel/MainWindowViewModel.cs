using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTimer.Command;
using WorkTimer.Model;
using WorkTimer.View;

namespace WorkTimer.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly View.MainWindow _window;
        private readonly Timer _timer;
        private TimerKbn _timerKbn=TimerKbn.Work;

        private TimerList _workTimeList;
        private TimerList _relaxTimerList;


        public MainWindowViewModel()
        {
            _window =new MainWindow(this);
            _timer = new Timer();

            _workTimeList = new TimerList(TimerKbn.Work);
            _relaxTimerList = new TimerList(TimerKbn.Relax);

        }

        //Command

        #region Command

        //仕事ボタン
        private ButtonWorkCommand _buttonWorkCommand;
        public ButtonWorkCommand ButtonWorkCommand =>
            _buttonWorkCommand ?? (_buttonWorkCommand = new ButtonWorkCommand(WorkTimerStart));




        //Relaxボタン
        private ButtonRelaxCommand _buttonRelaxCommand;

        public ButtonRelaxCommand ButtonRelaxCommand =>
            _buttonRelaxCommand ?? (_buttonRelaxCommand = new ButtonRelaxCommand(RelaxTimerStart));



        //TimerStopボタン
        private ButtonStopTimerCommand _buttonStopTimerCommand;

        public ButtonStopTimerCommand ButtonStopTimerCommand =>
            _buttonStopTimerCommand ?? (_buttonStopTimerCommand = new ButtonStopTimerCommand(TimerStop));


        #endregion


        public string TimerCountStr
        {
            get { return "aaaaaaaaa"; }
        }


        private string _workerTimerSum = string.Empty;
        public string WokerTimeSum
        {
            get => _workerTimerSum;
            set
            {
                _workerTimerSum = value;
                OnPropertyChanged("WokerTimeSum");
            }
        }











        private void WorkTimerStart(object obj)
        {
            if(_timer.IsStarting)
                TimerStop();


            _timerKbn = TimerKbn.Work;
            _timer.Start();
        }




        private void RelaxTimerStart(object obj)
        {
            if (_timer.IsStarting)
                TimerStop();

            _timerKbn = TimerKbn.Relax;
            _timer.Start();
        }





        private void TimerStop(object obj=null)
        {
            var ts = _timer.GetTicks();
            _timer.Stop();

            if(_timerKbn == TimerKbn.Work)
                _workTimeList.Add(_timer.GetTicks());
            else
                _relaxTimerList.Add(_timer.GetTicks());


            ListViewChanged();
        }

        private void ListViewChanged()
        {
            WokerTimeSum = _workTimeList.GetSumString();
        }


        public void Show()
        {
            _window.Show();
        }
    }
}
