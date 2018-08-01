using System;
using WorkTImer.Model;

namespace WorkTImer.Command
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
