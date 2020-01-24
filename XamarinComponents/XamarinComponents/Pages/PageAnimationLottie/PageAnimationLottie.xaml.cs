using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class PageAnimationLottie : ContentPage
    {
        public PageAnimationLottie()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>ListSendingAccounts
        protected override async void OnAppearing()
        {
            Debug.WriteLine("AnimationLottie OnAppearing");

            var viewModel = BindingContext as VMAnimationLottie;
            ManagerLoaderPopup.ShowLoader(RootPage);

            viewModel?.OnAppearing();
        }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            Debug.WriteLine("AnimationLottie OnDisappearing");
            var viewModel = BindingContext as VMAnimationLottie;
            ManagerLoaderPopup.HideLoader();
            viewModel?.OnDisappearing();
        }
    }
}
