using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComponentsLoaderPopup : ContentView, ILoaderPopup
    {
        /// <summary>
        /// Комопнент Loader
        /// </summary>
        private static ComponentsLoaderPopup _instance;

        /// <summary>
        /// Текущая страница
        /// </summary>
        private AbsoluteLayout _root;

        /// <summary>
        /// Статус отображения
        /// </summary>
        private bool _isShown;

        /// <summary>
        /// Инициализация компонента
        /// </summary>
        /// <returns></returns>
        public static ILoaderPopup Init()
        {
            if (_instance == null)
                _instance = new ComponentsLoaderPopup();

            return _instance;
        }

        public ComponentsLoaderPopup()
        {
            InitializeComponent();

            Overlay.WidthRequest = App.DeviceWindowWidth;
            Overlay.HeightRequest = App.DeviceWindowHeight;
        }

        /// <summary>
        /// Добавляем Loader
        /// </summary>
        public void ShowLoader(AbsoluteLayout root)
        {
            if (_isShown)
                return;

            _root = root;
            _root.Children.Add(this);

            _isShown = true;
        }

        /// <summary>
        /// Удаляем Loader
        /// </summary>
        public void HideLoader()
        {
            _isShown = false;

            if (_root != null && _root.Children.Contains(this))
            {
                _root.Children.Remove(this);
                _root = null;
            }
        }
    }
}
