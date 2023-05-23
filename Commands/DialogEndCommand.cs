using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_2048.Commands.Base;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.Commands
{
    public class DialogEndCommand : BaseCommand
    {
        private readonly Action<string> execute;

        public DialogEndCommand(Action<string> executem)
        {
            this.execute = executem;
        }

        public override void Execute(object parameter)
        {
            execute((string) parameter);
        }
    }
}
