using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace XamarinComponents
{
    public class VMMessageChat : Function
    {
        public ClientWebSocket client;

        /// <summary>
        /// Объект состояния соеднинения с ws
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Объект о возможности действие отправки сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>
        bool CanSendMessage(string message) => IsConnected && ChackedTextNull(message);


        Command<string> sendMessageCommand;

        public Command CommandOpenPopupMenuContext => new Command(OpenPopupMenuContext);

        public Command SendMessage => sendMessageCommand ??
            (sendMessageCommand = new Command<string>(SendMessageAsync, CanSendMessage));

        /// <summary>
        /// Список сообщений чата
        /// </summary>
        public ObservableCollection<ModelChatMessages> Messages { get; set; }

        public bool VisibleBarView => true;

        public VMMessageChat()
        {
            Messages = new ObservableCollection<ModelChatMessages>();

            Messages.Add(new ModelChatMessages
            {

            });
        }

        private async void OpenPopupMenuContext()
        {
            await NavigationPage.PushPopupAsync(new ComponentPopupContextMenu
            {
                BindingContext = new VMPopupContextMenu()
            });
        }

        /// <summary>
        /// Метод отправки сообщение в чат
        /// </summary>
        /// <param name="message">Сообщение</param>
        async void SendMessageAsync(string message)
        {
            //var dataMessage = new ChatSendMessage
            //{
            //    Token = getAccessToken,
            //    Message = message,
            //};

            //var segmnet = new ArraySegment<byte>(
            //    Encoding.UTF8.GetBytes(
            //        JsonConvert.SerializeObject(dataMessage)
            //        )
            //    );

            //await client.SendAsync(
            //    segmnet,
            //    WebSocketMessageType.Text,
            //    true,
            //    CancellationToken.None
            //    );

            //MessageText = string.Empty;
        }

        /// <summary>
        /// Соеднинение с ws и обработка получение сообщения
        /// </summary>
        /// <param name="messagesListView"></param>
        public async void ConnectToServerAsync(ListView messagesListView)
        {
            Messages.Clear(); // Очещаем список сообщений

            // Структура авторизаций пользователя чата
            var authChat = new ModelChatAuth
            {
                TypeMethod = "Auth",
                Token = ""//getAccessToken,
            };

            using (client = new ClientWebSocket())
            {
                client.Options.SetRequestHeader("authorization", "Bearer " + "TokenUser"); // - Token пользователя
                client.Options.SetRequestHeader("content-type", "application/json");

                await client.ConnectAsync(new Uri("wss://online.host/api/messages/ws/"), CancellationToken.None); // host нужен адрес чата

                IsConnected = client.State == WebSocketState.Open;

                while (client.State == WebSocketState.Open)
                {
                    var byteMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(authChat));

                    var segmnet = new ArraySegment<byte>(byteMessage);

                    await client.SendAsync(segmnet, WebSocketMessageType.Text, true, CancellationToken.None);

                    sendMessageCommand.ChangeCanExecute();
                    Debug.WriteLine("IsConnected 1 : " + IsConnected);
                    while (IsConnected)
                    {
                        WebSocketReceiveResult result;
                        var message = new ArraySegment<byte>(new byte[4096]);

                        try
                        {
                            do
                            {
                                Debug.WriteLine("Messages Chat Websocket state " + client.State);

                                if (client.State != WebSocketState.Open)
                                {
                                    //SubVisible = true;
                                    IsConnected = false;
                                    Debug.WriteLine("close");
                                    //Alert_Display("", "Неизвестная ошибка, обратитесь в службу поддержки", "Ок");

                                    break;
                                }

                                Debug.WriteLine("start");
                                //throw new Exception("Произошла непредвиденная ошибка при получение сообщения");

                                result = await client.ReceiveAsync(message, CancellationToken.None);
                                Debug.WriteLine("result.EndOfMessage : " + result.EndOfMessage);

                                if (result.MessageType != WebSocketMessageType.Text)
                                    break;

                                var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();
                                string receivedMessage = Encoding.UTF8.GetString(messageBytes);
                                Debug.WriteLine("receivedMessage : " + receivedMessage);


                                var msg = JsonConvert.DeserializeObject<ModelChatMessages>(receivedMessage);

                                /*
                                 * Если история сообщений равна null, то добавляем в список сообщений
                                 * или же обрабатываем историю сообщений по пользователю
                                 */
                                if (msg.History == null)
                                    Messages.Add(msg);
                                else
                                {
                                    foreach (var item in msg.History)
                                    {
                                        var userMessage = new ModelChatMessages();

                                        //if (!item.UserFrom.Equals(GetUserIdChat.ToString()))
                                        //    userMessage.Message = item.Message;
                                        //else
                                        //{
                                        //    userMessage.Token = getAccessToken;
                                        //    userMessage.Message = item.Message;
                                        //}

                                        Messages.Add(userMessage);
                                    }

                                    //SubVisible = false;
                                }

                                /*
                                 * Если у нас сообщений не равно нулю, то
                                 * опускаем scroll ListView то низу
                                 */
                                if (Messages.Count > 0)
                                {
                                    Device.BeginInvokeOnMainThread(() =>
                                    {
                                        messagesListView.ScrollTo(
                                            Messages[Messages.Count - 1],
                                            ScrollToPosition.End,
                                            true);
                                    });
                                }
                            }
                            while (!result.EndOfMessage);

                            OnPropertyChanged("");

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error");
                            //Alert_Display(
                            //    "",
                            //    "Произошла непредвиденная ошибка при получение сообщения",
                            //    "Ок");
                        }

                        //LoaderPopupManager.Hide();

                        //if (SubVisible)
                        //{
                        //    UpdateVisibleBarView(false);
                        //}
                        //else
                        //{
                        //    UpdateVisibleBarView(true);
                        //}
                    }
                }
            }
        }
    }
}