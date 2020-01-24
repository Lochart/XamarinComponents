using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinComponents
{
    public partial class App : Application
    {
        /// <summary>
        /// Высота экрана устройства
        /// </summary>
        public static int DeviceWindowHeight { get; set; }

        /// <summary>
        /// Ширина экрана устройства
        /// </summary>
        public static int DeviceWindowWidth { get; set; }

        public App()
        {
            InitializeComponent();

            //Overall.Add("DeviceWindowHeight", DeviceWindowHeight);
            //Overall.Add("DeviceWindowWidth", DeviceWindowWidth);
            ManagerLoaderPopup.Init();

            MainPage = new NavigationPage(
                new MainPage
                {
                    BindingContext = new VMMainPage()
                });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
