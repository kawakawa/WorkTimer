using System;
using System.Diagnostics;
using System.Windows.Input;

namespace WorkTImer.Command
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;


        public RelayCommand() { }


        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            //if (execute == null) throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }



        /// <summary>
        /// コマンドが実行可能な状態化どうか問い合わせ
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// CanExecuteの結果に変更があったことを通知するイベント。 
        /// WPFのCommandManagerのRequerySuggestedイベントをラップする形で実装
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        ///  コマンドを実行
        /// </summary>
        /// <param name="parameter"></param>
        public virtual void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }





    }
}
