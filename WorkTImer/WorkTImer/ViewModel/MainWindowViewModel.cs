using WorkTimer.Command;
using WorkTimer.Model;
using WorkTimer.View;

namespace WorkTimer.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly MainWindow _window;
        private readonly TimeMeasurement _timeMeasurement;
        private readonly TimerList _workTimeList;
        private readonly TimerList _relaxTimerList;
        private readonly System.Timers.Timer _viewTimer;




        public MainWindowViewModel()
        {
            _window =new MainWindow(this);
            _timeMeasurement = new TimeMeasurement();
            _viewTimer = new System.Timers.Timer
            {
                Interval = 1000
            };
            _viewTimer.Elapsed += _viewTimer_Elapsed;
            


            _workTimeList = new TimerList(Mode.Work);
            _relaxTimerList = new TimerList(Mode.Relax);
            AppStatus.NowMode = Mode.Stop;

        }



        //Command

        #region Command

        //仕事ボタン
        private WorkCommand _buttonWorkCommand;
        public WorkCommand ButtonWorkCommand =>
            _buttonWorkCommand ?? (_buttonWorkCommand = new WorkCommand(WorkTimerStart));
        

        //Relaxボタン
        private RelaxCommand _buttonRelaxCommand;

        public RelaxCommand ButtonRelaxCommand =>
            _buttonRelaxCommand ?? (_buttonRelaxCommand = new RelaxCommand(RelaxTimerStart));



        //TimerStopボタン
        private StopTimerCommand _buttonStopTimerCommand;

        public StopTimerCommand ButtonStopTimerCommand =>
            _buttonStopTimerCommand ?? (_buttonStopTimerCommand = new StopTimerCommand(TimerStop));


        #endregion


        private string _timerCountStr;
        public string TimerCountStr
        {
            get => _timerCountStr;
            set
            {
                _timerCountStr = value;
                OnPropertyChanged("TimerCountStr");
            }
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


        private string _relaxTImerSum = string.Empty;

        public string RelaxTimeSum
        {
            get => _relaxTImerSum;
            set
            {
                _relaxTImerSum = value;
                OnPropertyChanged("RelaxTimeSum");
            }
        }

        private string _wokerTimeListStr = null;

        public string WokerTimeList
        {
            get => _wokerTimeListStr;
            set
            {
                _wokerTimeListStr = value;
                OnPropertyChanged("WokerTimeList");

            }
        }

        private string _relaxTimeListStr = null;

        public string RelaxTimeList
        {
            get => _relaxTimeListStr;
            set
            {
                _relaxTimeListStr = value;
                OnPropertyChanged("RelaxTimeList");
            }
        }








        private void WorkTimerStart(object obj)
        {
            if(_timeMeasurement.IsStarting)
                TimerStop();


            AppStatus.NowMode = Mode.Work;
            _timeMeasurement.Start();
            _viewTimer.Start();
            
        }




        private void RelaxTimerStart(object obj)
        {
            if (_timeMeasurement.IsStarting)
                TimerStop();

            AppStatus.NowMode = Mode.Relax;
            _timeMeasurement.Start();
            _viewTimer.Start();
        }

        private void _viewTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var ts = _timeMeasurement.GetTicks();
            TimerCountStr = ts.ToString(@"dd\.hh\:mm\:ss");
        }



        private void TimerStop(object obj=null)
        {
            _viewTimer.Stop();


            var ts = _timeMeasurement.GetTicks();
            TimerCountStr = ts.ToString(@"dd\.hh\:mm\:ss");

            _timeMeasurement.Stop();

            if(AppStatus.NowMode == Mode.Work)
                _workTimeList.Add(_timeMeasurement.GetTicks());
            else if (AppStatus.NowMode == Mode.Relax)
                _relaxTimerList.Add(_timeMeasurement.GetTicks());


            AppStatus.NowMode = Mode.Stop;

            ListViewChanged();
        }







        private void ListViewChanged()
        {
            WokerTimeSum = _workTimeList.GetSumString();
            RelaxTimeSum = _relaxTimerList.GetSumString();

            WokerTimeList = _workTimeList.GetListStr();
            RelaxTimeList = _relaxTimerList.GetListStr();
        }


        public void Show()
        {
            _window.Show();
        }
    }
}
