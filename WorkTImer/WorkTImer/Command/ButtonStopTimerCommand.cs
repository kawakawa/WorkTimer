using System;
using WorkTimer.Model;

namespace WorkTimer.Command
{
    public class ButtonStopTimerCommand:RelayCommand
    {
        public ButtonStopTimerCommand(Action<object> execute)
            : base(execute) { }


        public override bool CanExecute(object parameter)
        {
            return AppStatus.NowMode != Mode.Stop;
        }
    }
}
