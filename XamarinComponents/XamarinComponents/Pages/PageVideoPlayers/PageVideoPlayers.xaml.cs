using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class PageVideoPlayers : ContentPage
    {
        public PageVideoPlayers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>ListSendingAccounts
        protected override async void OnAppearing()
        {
            Debug.WriteLine("VideoPlayer OnAppearing");

            var viewModel = BindingContext as VMVideoPlayer;


            viewModel?.OnAppearing();
        }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            Debug.WriteLine("VideoPlayer OnDisappearing");
            var viewModel = BindingContext as VMVideoPlayer;

            viewModel?.OnDisappearing();
        }
    }
}
