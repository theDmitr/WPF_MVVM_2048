using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPF_MVVM_2048.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected static void NavigateToPage(NavigationInfo navigationInfo)
        {
            NavigationService.GetNavigationService(navigationInfo.CurrentPage).Navigate(navigationInfo.Uri);
        }

        protected static void Quit()
        {
            Application.Current.Shutdown();
        }
    }

    public class NavigationInfo
    {
        public Page CurrentPage { get; }
        public Uri Uri { get; }
        public NavigationInfo(Page currentPage, Uri uri)
        {
            CurrentPage = currentPage;
            Uri = uri;
        }
    }
}
