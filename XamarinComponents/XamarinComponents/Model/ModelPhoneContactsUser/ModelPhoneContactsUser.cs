namespace XamarinComponents
{
    /// <summary>
    /// Модель представления списка контактов пайщика из телефона
    /// </summary>
    public class ModelPhoneContactsUser 
    {
        /// <summary>
        /// Аватар
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Показываем Имя Фамилия
        /// </summary>
        public string DisplayName { get => $"{FirstName} {LastName}"; }
    }
}

