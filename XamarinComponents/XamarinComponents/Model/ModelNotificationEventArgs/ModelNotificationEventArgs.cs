using System;

namespace XamarinComponents
{
    /// <summary>
    /// Модель представления по локальным уведомления
    /// </summary>
    public class ModelNotificationEventArgs : EventArgs
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }
    }
}