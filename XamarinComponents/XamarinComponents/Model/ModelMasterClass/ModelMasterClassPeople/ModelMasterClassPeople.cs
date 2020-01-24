using System;

using Xamarin.Forms;

namespace XamarinComponents
{
    /// <summary>
    /// Модель представления из App Master Class
    /// </summary>
    public class ModelMasterClassPeople 
    {
        /// <summary>
        /// Id - пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Картинка людей
        /// </summary>
        public string PeoplaImage { get; set; }

        /// <summary>
        /// Имя фамилия
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Специализируется
        /// </summary>
        public string Specializes { get; set; }
    }
}

