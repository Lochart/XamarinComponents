using System;

using Xamarin.Forms;

namespace XamarinComponents
{
    public class VMVideoPlayer : ViewModel
    {
        public VMVideoPlayer()
        {

        }

        /// <summary>
        /// Called when page is appearing.
        /// </summary>
        public virtual void OnAppearing() { }

        /// <summary>
        /// Called when the view model is disappearing. View Model clean-up should be performed here.
        /// </summary>
        public virtual void OnDisappearing() { }
    }
}

