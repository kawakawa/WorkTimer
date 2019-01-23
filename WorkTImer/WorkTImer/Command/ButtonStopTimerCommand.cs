using System;
using WorkTimer.Model;

namespace WorkTimer.Command
{
    public class StopTimerCommand:RelayCommand
    {
        public StopTimerCommand(Action<object> execute)
            : base(execute) { }


        public override bool CanExecute(object parameter)
        {
            return AppStatus.NowMode != Mode.Stop;
        }
    }
}
