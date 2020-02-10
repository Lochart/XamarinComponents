using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class PageRealm : ContentPage
    {
        private VMRealm viewModel;

        public PageRealm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>ListSendingAccounts
        protected override async void OnAppearing()
        {
            Debug.WriteLine("VideoPlayer OnAppearing");
            viewModel = BindingContext as VMRealm;
            viewModel?.OnAppearing();
        }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            Debug.WriteLine("VideoPlayer OnDisappearing");
            viewModel = BindingContext as VMRealm;
            viewModel?.OnDisappearing();
        }

        /// <summary>
        /// Выбор ячейки из списка выбора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listOptions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ModelOptionItems;

            if (item != null)
                viewModel.ChoiceOption(item);
        }

        /// <summary>
        /// Выбор ячейки из списка студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listStudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as StudentTable;

            if (item != null)
                viewModel.LoadOptionItems(item);

        }
    }
}