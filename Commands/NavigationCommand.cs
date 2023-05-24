using System;
using System.Windows.Controls;

using WPF_MVVM_2048.Commands.Base;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.Commands
{
    public class NavigationCommand : BaseCommand
    {
        private readonly Action<Page, Uri> execute;
        private readonly Uri uri;

        public NavigationCommand(Action<Page, Uri> execute, Uri uri)
        {
            this.execute = execute;
            this.uri = uri;
        }
        public override void Execute(object parameter)
        {
            execute.Invoke((Page) parameter, uri);
        }
    }
}
