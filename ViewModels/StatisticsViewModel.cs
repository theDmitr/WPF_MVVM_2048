using System;
using System.Collections.ObjectModel;

using WPF_MVVM_2048.Commands;
using WPF_MVVM_2048.Models.Statistics;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.ViewModels
{
    public class StatisticsViewModel : ViewModel
    {
        public static NavigationCommand NavigateToMenuPage { get => new(NavigateToPage, new Uri("Views/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute)); }
        public static ObservableCollection<Player> StatisticsCollection { get => Statistics.Players; }
    }
}
