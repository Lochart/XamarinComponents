using System;
using Android.Widget;
using Xamarin.Forms;

namespace XamarinComponents.Droid
{
    /// <summary>
    /// Native сервисы Toast
    /// </summary>
    public static class Untils
    {
        /// <summary>
        /// Показываем временное окошко 
        /// </summary>
        /// <param name="message"></param>
        public static void Toast(string message) => Android.Widget.Toast.MakeText(
            MainActivity.mainActivity, message, ToastLength.Long).Show();
    }
}

