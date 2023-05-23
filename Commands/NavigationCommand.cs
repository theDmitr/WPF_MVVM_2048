using System;
using System.Windows.Controls;

using WPF_MVVM_2048.Commands.Base;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.Commands
{
    public class NavigationCommand : BaseCommand
    {
        private readonly Action<NavigationInfo> execute;
        private readonly Uri uri;

        public NavigationCommand(Action<NavigationInfo> execute, Uri uri)
        {
            this.execute = execute;
            this.uri = uri;
        }
        public override void Execute(object parameter)
        {
            NavigationInfo info = new((Page) parameter, uri);
            execute.Invoke(info);
        }
    }
}
