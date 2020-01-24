using System.ComponentModel;
using System.Diagnostics;
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
            }

            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// Метод перехода на след. страницу
        /// </summary>
        /// <param name="page"></param>
        private void NextPage(Page page) => Navigation.PushAsync(page);
    }
}
