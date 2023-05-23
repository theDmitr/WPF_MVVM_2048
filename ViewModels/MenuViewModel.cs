using System;

using WPF_MVVM_2048.Commands;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public static NavigationCommand NavigateToGamePage { get => new(NavigateToPage, new Uri("View/Pages/GamePage.xaml", UriKind.RelativeOrAbsolute)); }
        public static NavigationCommand NavigateToStatisticsPage { get => new(NavigateToPage, new Uri("View/Pages/StatisticsPage.xaml", UriKind.RelativeOrAbsolute)); }
        public static RelayCommand QuitApp { get => new(Quit); }

    }
}
