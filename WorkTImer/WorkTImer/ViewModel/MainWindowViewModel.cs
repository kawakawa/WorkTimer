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
        private System.Timers.Timer _viewTimer;
        private readonly ModeChangeVm _modeChangeVm;




        public MainWindowViewModel()
        {
            //ViewにViewModelのインスタンス渡す
            _window =new MainWindow(this);

            
            _timeMeasurement = new TimeMeasurement();
            
            IniViewTimer();


            _workTimeList = new TimerList();
            _relaxTimerList = new TimerList();

            _modeChangeVm = new ModeChangeVm(_window);
            _modeChangeVm.Stop();

        }

        /// <summary>
        /// 
        /// </summary>
        private void IniViewTimer()
        {
            _viewTimer = new System.Timers.Timer
            {
                Interval = 1000
            };
            _viewTimer.Elapsed += _viewTimer_Elapsed;
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


        #region  表示項目

        


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
        public string WorkerTimeSum
        {
            get => _workerTimerSum;
            set
            {
                _workerTimerSum = value;
                OnPropertyChanged("WorkerTimeSum");
            }
        }


        private string _relaxTimerSum = string.Empty;

        public string RelaxTimeSum
        {
            get => _relaxTimerSum;
            set
            {
                _relaxTimerSum = value;
                OnPropertyChanged("RelaxTimeSum");
            }
        }

        private string _workerTimeListStr;

        public string WorkerTimeList
        {
            get => _workerTimeListStr;
            set
            {
                _workerTimeListStr = value;
                OnPropertyChanged("WorkerTimeList");

            }
        }

        private string _relaxTimeListStr;

        public string RelaxTimeList
        {
            get => _relaxTimeListStr;
            set
            {
                _relaxTimeListStr = value;
                OnPropertyChanged("RelaxTimeList");
            }
        }




        #endregion




        /// <summary>
        /// 仕事タイマースタート
        /// </summary>
        /// <param name="obj"></param>
        private void WorkTimerStart(object obj)
        {
            if(_timeMeasurement.IsStarting)
                TimerStop();


            _modeChangeVm.Work();
            _timeMeasurement.Start();
            _viewTimer.Start();
            
        }

        /// <summary>
        /// リラックスタイマースタート
        /// </summary>
        /// <param name="obj"></param>

        private void RelaxTimerStart(object obj)
        {
            if (_timeMeasurement.IsStarting)
                TimerStop();

            _modeChangeVm.Relax();
            _timeMeasurement.Start();
            _viewTimer.Start();
        }

        /// <summary>
        /// ストップウォッチの表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void _viewTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ViewTimerCount();
        }

        private void ViewTimerCount()
        {
            var ts = _timeMeasurement.GetTicks();
            TimerCountStr = DataFormat.ToTicks(ts);
        }


        /// <summary>
        /// 時計停止
        /// </summary>
        /// <param name="obj"></param>

        private void TimerStop(object obj=null)
        {

            _viewTimer.Stop();
            _timeMeasurement.Stop();


            ViewTimerCount();



            switch (AppStatus.NowMode)
            {
                case Mode.Work:
                    _workTimeList.Add(_timeMeasurement.GetTicks());
                    break;
                case Mode.Relax:
                    _relaxTimerList.Add(_timeMeasurement.GetTicks());
                    break;
            }


            _modeChangeVm.Stop();

            ListViewChanged();
        }







        private void ListViewChanged()
        {
            WorkerTimeSum = _workTimeList.GetSumString();
            RelaxTimeSum = _relaxTimerList.GetSumString();

            WorkerTimeList = _workTimeList.GetListStr();
            RelaxTimeList = _relaxTimerList.GetListStr();
        }


        public void Show()
        {
            _window.Show();
        }
    }
}
