using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Plugin.LocalNotification;
using Xamarin.Forms;

namespace XamarinComponents
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>ListSendingAccounts
        protected override async void OnAppearing()
        {
            Debug.WriteLine("MainPage OnAppearing");

            var viewModel = BindingContext as VMMainPage;

            viewModel.ViewNavigationPage(Navigation);

            viewModel?.OnAppearing();
        }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            Debug.WriteLine("MainPage OnDisappearing");
            var viewModel = BindingContext as VMMainPage;

            viewModel?.OnDisappearing();
        }

        /// <summary>
        /// Нажание по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemTappedCell(object sender, ItemTappedEventArgs e)
        {
            var cell = e.Item as ModelComponents;

            if (cell == null)
                return;

            switch (cell.Id)
            {
                case 0:
                    NextPage(new ButtonPage());
                    break;
                case 1:
                    NextPage(new PageLabel());
                    break;
                case 2:
                    NextPage(new PageInfoUser());
                    break;
                case 3:
                    NextPage(new PageAnimationLottie
                    {
                        BindingContext = new VMAnimationLottie()
                    });
                    break;
                case 4:
                    NextPage(new PageVideoPlayers
                    {
                        BindingContext = new VMVideoPlayer()
                    });
                    break;
                case 5:
                    NextPage(new PageEntry());
                    break;
                case 6:
                    NextPage(new PageScrollHeaderFloatingAndListView());
                    break;
                case 7:
                    NextPage(new PageEasyScrollHeader());
                    break;
                case 8:
                    if(Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IAuthSocialNetworks>().SendAuthApp("com.vkontakte.account");
                    break;
                case 9:
                    NextPage(new PageChat
                    {
                        BindingContext = new VMMessageChat()
                    });
                    break;
                case 10:
                    var downloader = DependencyService.Get<IDownloader>();
                    downloader.DownloadFile(
                        "http://www.dada-data.net/uploads/image/hausmann_abcd.jpg",
                        "XF_Downloads");

                    downloader.OnFileDownloaded += EventOnFileDownloaded;
                    break;
                case 11:
                    SendLocalNotification();
                    break;
                case 12:
                    NextPage(new PageRealm
                    {
                        BindingContext = new VMRealm()
                    });
                    break;
            }

            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// Отправка локального уведомления
        /// </summary>
        private void SendLocalNotification()
        {
            var notificationId = 1;
            var title = "Test";

            var list = new List<string>
            {
                "Component Xaxarin",
                notificationId.ToString(),
                title,
                "1"
            };
            var serializeReturningData = ObjectSerializer.SerializeObject(list);

            var everyDay = false;

            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = title,
                Description = $"Tap Count: 1",
                BadgeNumber = 1,
                ReturningData = serializeReturningData,
                Repeats = everyDay ? NotificationRepeat.Daily : NotificationRepeat.No, // Ежедневно или нет
                Android =
                {
                    IconName = "icon1",
                    Color = 33468,
                    //AutoCancel = false,
                    //Ongoing = true
                },
                
            };

            /*
             * Если не указан, будет воспроизводиться звук по умолчанию.
             */
            if (true)
            {
                request.Sound = Device.RuntimePlatform == Device.Android
                    ? "good_things_happen"
                    : "good_things_happen.aiff";
            }

            /*
             * Если не указано, уведомление будет показано немедленно.
             */
            //if (false)
            //{
            //    var notifyDateTime = NotifyDatePicker.Date.Add(NotifyTimePicker.Time);
            //    if (notifyDateTime <= DateTime.Now)
            //    {
            //        notifyDateTime = DateTime.Now.AddSeconds(10);
            //    }
            //    request.NotifyTime = notifyDateTime;
            //}

            NotificationCenter.Current.Show(request);
        }

        /// <summary>
        /// Событие скачивание файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventOnFileDownloaded(object sender, DownloadEventArgs e)
        {
            string status = e.FileSaved ? "File Saved Successfully" : "Error while saving the file";

            DisplayAlert("XF Downloader", status, "Close");
        }

        /// <summary>
        /// Метод перехода на след. страницу
        /// </summary>
        /// <param name="page"></param>
        private void NextPage(Page page) => Navigation.PushAsync(page);
    }
}
