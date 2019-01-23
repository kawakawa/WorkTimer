using System;
using WorkTimer.Model;

namespace WorkTimer.Command
{
    public class RelaxCommand: RelayCommand
    {
        public RelaxCommand(Action<object> execute)
            : base(execute) { }


        public override bool CanExecute(object parameter)
        {
            return AppStatus.NowMode != Mode.Relax;
        }
    }
}
