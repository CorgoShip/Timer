using System;
using System.Windows.Input;

namespace Timer.ViewModels.Commands
{
    public class TimeSetCMD : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<string> _execute;

        public TimeSetCMD(Action<string> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter) 
        {
            return true; // prikaz je mozno vzdy vykonat
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as string);
        }
    }
}
