using System;

using Xamarin.Forms;

namespace XamarinComponents
{
    public class Function : ViewModel
    {

        /// <summary>
        /// Проверка текста на пустоту
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool ChackedTextNull(string message) => !string.IsNullOrEmpty(message) && !string.IsNullOrWhiteSpace(message);

    }
}

