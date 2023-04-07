using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Exam2.Model
{
    public class Events:ICommand 
    {
        private Action<object> _Exec;
        private Func<object, bool>? _canExec;

        public event EventHandler? CanExecuteChanged;

        public event EventHandler CanExecChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Events(Action<object> exec, Func<object, bool>? canExec = null)
        {
            _Exec = exec;
            _canExec = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return _canExec == null || _canExec(parameter);
        }
        public void Execute(object parameter)
        {
            _Exec(parameter);
        }

    }
}
