using System;
using WorkTImer.Model;

namespace WorkTImer.Command
{
    public class ButtonRelaxCommand: RelayCommand
    {
        public ButtonRelaxCommand(Action<object> execute)
            : base(execute) { }


        public override bool CanExecute(object parameter)
        {
            return AppStatus.NowMode != Mode.Relax;
        }
    }
}
