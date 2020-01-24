using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinComponents
{
    public class VMMainPage : ViewModel
    {
        public ObservableCollection<ModelComponents> SourceComponents { get; set; }

        public VMMainPage()
        {
            SourceComponents = new ObservableCollection<ModelComponents>
            {
                AddModelComponents(0, "Кнопки", "Кнопки"),
                AddModelComponents(1, "Текст", "Текст"),
                AddModelComponents(2, "Информация о пользователе", "Информация о пользователе"),
                AddModelComponents(3, "Анимация Lottie", "Lottie"),
                AddModelComponents(4, "VideoPlayer CrossMediaManager", "VideoPlayer"),
                AddModelComponents(5, "Entry", "Entry"),
                AddModelComponents(6, "MasterClass Sticker Header, ListView", "StickerHeader"),
                AddModelComponents(7, "Easy StickerHeader", "StickerHeader"),
            };

        }

        private ModelComponents AddModelComponents(int id, string name, string tag) => new ModelComponents
        {
            Id = id,
            Name = name,
            Tags = tag
        };

        public void ViewNavigationPage(INavigation navigation) => NavigationPage = navigation;

        /// <summary>
        /// Called when page is appearing.
        /// </summary>
        public virtual void OnAppearing() { }

        /// <summary>
        /// Called when the view model is disappearing. View Model clean-up should be performed here.
        /// </summary>
        public virtual void OnDisappearing() { }
    }
}

