using System.Collections.Generic;

namespace XamarinComponents
{
    public class ModelChatMessages 
    {
        /// <summary>
        /// Имя отправителя/от кого
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сообщение отправителя/от кого
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Токен пользователя
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// История сообщений
        /// </summary>
        public List<ModelHistoryChatMessages> History { get; set; }

        /// <summary>
        /// Пришедшие - фильтруем растоновку по токену пользователю
        /// </summary>
        public bool IsIncoming => Token != "fsf";//getAccessToken;
    }
}