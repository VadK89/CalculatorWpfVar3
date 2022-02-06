using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorWpfVar3.ViewModel
{
    //Что-то на умном
    public class RelayCommanParam : ICommand
    {
        readonly Action<object> _execute;
        readonly Func<bool> _canExecute;

        public RelayCommanParam(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommanParam(Action<object> execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
