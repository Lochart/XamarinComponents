using System;
using System.ComponentModel;
using System.Windows.Input;
using Realms;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace XamarinComponents
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static INavigation NavigationPage;

        /// <summary>
        /// Вызов базы данных Realm
        /// </summary>
        public Realm RealmDB = Realm.GetInstance();

        /// <summary>
        /// Комманда закрытия всех всплывающих окон
        /// </summary>
        public ICommand CommandCloseAllPopupPage => new Command(CloseAllPopupPage);


        public ViewModel()
        {

        }

        //new Command(CloseAllPopupPage);

        /// <summary>
        /// Закрытия всех всплывающих окон
        /// </summary>
        /// <param name="sender"></param>
        public async void CloseAllPopupPage()
        {
           await PopupNavigation.Instance.PopAllAsync();
        }

        /// <summary>
        /// Called when page is appearing.
        /// </summary>
        public virtual void OnAppearing() { }

        /// <summary>
        /// Called when the view model is disappearing. View Model clean-up should be performed here.
        /// </summary>
        public virtual void OnDisappearing() { }

        protected virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

