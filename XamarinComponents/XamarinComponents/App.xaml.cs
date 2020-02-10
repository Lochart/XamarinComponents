using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.LocalNotification;
using Xamarin.Forms;

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

            ManagerLoaderPopup.Init();

            // Получить локальные уведомления после нажатия
            NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            MainPage = new NavigationPage(
                new MainPage
                {
                    BindingContext = new VMMainPage()
                });
        }

        /// <summary>
        /// Обработка данных локальных уведомлений
        /// </summary>
        /// <param name="e"></param>
        private void OnLocalNotificationTapped(NotificationTappedEventArgs e)
        {
            Debug.WriteLine("OnLocalNotificationTapped : " + e.Data);

            if (string.IsNullOrWhiteSpace(e.Data))
                return;

            var list = ObjectSerializer.DeserializeObject<List<string>>(e.Data);

            foreach(var item in list)
                Debug.WriteLine("OnLocalNotificationTapped item : " + item);

            // ...
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
