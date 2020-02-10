using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class ComponentPopupContextMenu : PopupPage
    {
        private VMPopupContextMenu viewModel;

        public ComponentPopupContextMenu()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("ComponentPopupContextMenu OnAppearing");
            viewModel = BindingContext as VMPopupContextMenu;
            
            viewModel?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine("ComponentPopupContextMenu OnDisappearing");
            viewModel = BindingContext as VMPopupContextMenu;

            viewModel?.OnDisappearing();
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {
            if (!IsAnimationEnabled)
                return;
        }

        protected override async Task OnDisappearingAnimationBeginAsync()
        {
            if (!IsAnimationEnabled)
                return;
        }

        protected override bool OnBackgroundClicked()
        {
            viewModel.CloseAllPopupPage();

            return false;
        }
    }
}
