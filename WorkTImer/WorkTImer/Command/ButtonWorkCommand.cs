using System;
using WorkTimer.Model;

namespace WorkTimer.Command
{
    public class ButtonWorkCommand:RelayCommand
    {

        public ButtonWorkCommand(Action<object> execute)
            : base(execute) { }


        public override bool CanExecute(object parameter)
        {
            return AppStatus.NowMode != Mode.Work;
        }
    }
}
