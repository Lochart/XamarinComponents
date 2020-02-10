using System;

namespace XamarinComponents
{
    /// <summary>
    /// Пользовательский интерфейс по локальным уведомлений
    /// Инструкция по ссылке https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/app-fundamentals/local-notifications
    /// </summary>
    public interface INotificationManager 
    {
        /// <summary>
        /// События нажатия уведомлений
        /// </summary>
        event EventHandler NotificationReceived;

        /// <summary>
        /// Инициализация увдомлений
        /// </summary>
        void Initialize();

        /// <summary>
        /// Кол-во уведомлений
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        int ScheduleNotification(string title, string message);

        /// <summary>
        /// Отправка уведомлений
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        void ReceiveNotification(string title, string message);
    }
}