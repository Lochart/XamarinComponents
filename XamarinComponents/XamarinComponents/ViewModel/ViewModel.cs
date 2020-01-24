using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinComponents
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static INavigation NavigationPage;

        public ViewModel()
        {

        }

        protected virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

