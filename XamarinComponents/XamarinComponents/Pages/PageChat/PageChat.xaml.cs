using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class PageChat : ContentPage
    {
        public static VMMessageChat viewModel;

        public static Xamarin.Forms.ListView messagesListView;

        public PageChat()
        {
            InitializeComponent();

            messagesListView = null; //MessagesListView;
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("PageChat OnAppearing");
            viewModel = BindingContext as VMMessageChat;
            //ConnectionChat();

            viewModel?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine("PageChat OnDisappearing");
            viewModel = BindingContext as VMMessageChat;

            //if (viewModel.IsConnected)
            //{
            //    DisconnectChat();
            //    Models.ActivePageChat = false;
            //}

            viewModel?.OnDisappearing();
        }
    }
}
