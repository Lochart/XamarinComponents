using System;

namespace XamarinComponents
{
    public class ModelHistoryChatMessages 
    {
        /// <summary>
        /// От кого сообщение
        /// </summary>
        public string UserFrom { get; set; }

        /// <summary>
        /// От кого сообщение. Полное имя
        /// </summary>
        public string UserFromName { get; set; }

        /// <summary>
        /// Кому сообщение
        /// </summary>
        public string UserTo { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }
    }
}