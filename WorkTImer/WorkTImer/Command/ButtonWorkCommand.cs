﻿using System;
using WorkTImer.Model;

namespace WorkTImer.Command
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
