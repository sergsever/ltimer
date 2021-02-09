using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace itidea
{
    public class WPFCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Predicate<T> _canexecute;
        private Action<T> _execute;
        private Func<object, bool> p;

        public bool CanExecute(object parameter)
        {
            return _canexecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public WPFCommand(Predicate<T> canexecute, Action<T> execute)
        {
            this._canexecute = canexecute;
            this._execute = execute;
        }

    }
}
