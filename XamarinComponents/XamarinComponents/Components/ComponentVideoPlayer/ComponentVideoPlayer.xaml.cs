using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using MediaManager;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinComponents
{
    /// <summary>
    /// URL - https://github.com/pro777s/Xam.Forms.VideoPlayer
    /// URL - https://www.youtube.com/watch?reload=9&v=luDyX0kYzY4
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComponentVideoPlayer : ContentView
    {
        public ICommand CommandEventsButton { get; set; }
        public ICommand CommandVideoEventsButton { get; set; }

        /// <summary>
        /// Статус возвпроизведения
        /// </summary>
        public static readonly BindableProperty VideoUrlProperty =
        BindableProperty.Create("VideoUrl", typeof(string), typeof(ComponentVideoPlayer), "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4");

        public string VideoUrl
        {
            get => (string)GetValue(VideoUrlProperty);
            set => SetValue(VideoUrlProperty, value);
        }

        /// <summary>
        /// Статус возвпроизведения
        /// </summary>
        public static readonly BindableProperty StatusButtonProperty =
            BindableProperty.Create("StatusButton", typeof(string), typeof(ComponentVideoPlayer), "Play");

        public string StatusButton
        {
            get => (string)GetValue(StatusButtonProperty);
            set => SetValue(StatusButtonProperty, value);
        }

        /// <summary>
        /// Статус возвпроизведения
        /// </summary>
        public static readonly BindableProperty UriVideoSourceProperty =
            BindableProperty.Create("StatusButton", typeof(UriVideoSource), typeof(ComponentVideoPlayer), new UriVideoSource
            {
                Uri = "https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4"
            });

        public UriVideoSource UriVideoSource
        {
            get => (UriVideoSource)GetValue(UriVideoSourceProperty);
            set => SetValue(UriVideoSourceProperty, value);
        }

        public ComponentVideoPlayer()
        {
            CommandEventsButton = new Command(EventsButton);
            CommandVideoEventsButton = new Command(VideoEventsButton);
            InitializeComponent();
        }

        private async void EventsButton()
        {
            if (StatusButton.Equals("Play"))
            {
                //await CrossMediaManager.Current.Play("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4");
                StatusButton = "Stop";//, MediaFileType.Video);
            }
            else
            {
                //await CrossMediaManager.Current.Stop();
                StatusButton = "Play";
            }
        }

        private async void VideoPlayer_PlayCompletion(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void VideoPlayer_PlayError(object sender, VideoPlayer.PlayErrorEventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void VideoEventsButton()
        {
            Debug.WriteLine(videoPlayer.Status);
            //if(videoPlayer.Status.)
            //videoPlayer.Stop();
        }
    }
}
