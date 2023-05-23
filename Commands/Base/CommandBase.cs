using System;
using System.Windows.Input;

namespace WPF_MVVM_2048.Commands.Base
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
    }
}
