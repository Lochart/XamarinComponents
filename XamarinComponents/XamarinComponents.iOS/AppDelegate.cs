using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading;
using FFImageLoading.Forms.Platform;
using Foundation;
using MediaManager;
using UIKit;
using UserNotifications;

namespace XamarinComponents.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Высота экрана устройства
            App.DeviceWindowHeight = (int)UIScreen.MainScreen.Bounds.Height;

            // Ширина экрана устройства
            App.DeviceWindowWidth = (int)UIScreen.MainScreen.Bounds.Width;

            #region Подключение пакетов nuget

            Xam.Forms.VideoPlayer.iOS.VideoPlayerRenderer.Init();

            CrossMediaManager.Current.Init();

            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new CustomLogger(),
            };
            ImageService.Instance.Initialize(config);

            Rg.Plugins.Popup.Popup.Init();

            // Ask the user for permission to show notifications on iOS 10.0+ at startup.
            // If not asked at startup, user will be asked when showing the first notification.
            Plugin.LocalNotification.NotificationCenter.AskPermission();

            UNUserNotificationCenter.Current.Delegate = new IOSNotificationReceiver();

            #endregion

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// Сообщает делегату, что приложение собирается выйти на передний план
        /// </summary>
        /// <param name="uiApplication"></param>
        public override void WillEnterForeground(UIApplication uiApplication)
        {
            Plugin.LocalNotification.NotificationCenter.ResetApplicationIconBadgeNumber(uiApplication);
        }
    }
}