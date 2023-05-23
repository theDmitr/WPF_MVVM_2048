using System;
using WPF_MVVM_2048.Commands.Base;

namespace WPF_MVVM_2048.Commands
{
    public class RelayCommand : CommandBase
    {
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public override void Execute(object parameter)
        {
            execute.Invoke();
        }
    }
}
