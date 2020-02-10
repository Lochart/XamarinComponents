using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinComponents
{
    /// <summary>
    /// Класс UI представления ввода сообщения и кнопки отправки сообщения
    /// </summary>
    public partial class ChatInputBarView : ContentView
    {
        /// <summary>
        /// Команда открытия всплывающего меню
        /// </summary>
        public static readonly BindableProperty CommandOpenPopupMenuContextProperty =
            BindableProperty.Create("CommandOpenPopupMenuContext", typeof(ICommand), typeof(ChatInputBarView));

        public ICommand CommandOpenPopupMenuContext
        {
            get => (ICommand)GetValue(CommandOpenPopupMenuContextProperty);
            set => SetValue(CommandOpenPopupMenuContextProperty, value);
        }

        public static readonly BindableProperty MessageTextProperty =
            BindableProperty.Create(
                "MessageText",
                typeof(string),
                typeof(ChatInputBarView),
                null,
                BindingMode.TwoWay);

        public string MessageText
        {
            get => (string)GetValue(MessageTextProperty);
            set => SetValue(MessageTextProperty, value);
        }

        public ChatInputBarView()
        {
            InitializeComponent();

            txtMessage.SetBinding(Editor.TextProperty, "MessageText", BindingMode.TwoWay);

            if (Device.RuntimePlatform == Device.iOS)
                this.SetBinding(HeightRequestProperty,
                    new Binding(
                        "Height",
                        BindingMode.OneWay,
                        null,
                        null,
                        null,
                        txtMessage));
        }

        public void Handle_Completed(object sender, EventArgs e)
        {
            (this.Parent.Parent.BindingContext as VMMessageChat).SendMessage.Execute(null);
            txtMessage.Focus();
        }

        /// <summary>
        /// Фокус на элементе Editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMessage_Focused(object sender, FocusEventArgs e)
        {
            //if (PageChat.viewModel.Messages.Count > 0)
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        PageChat.messagesListView.ScrollTo(
            //            PageChat.viewModel.Messages[PageChat.viewModel.Messages.Count - 1],
            //            ScrollToPosition.End,
            //            true);
            //    });
        }

        public void UnFocusEntry() => txtMessage?.Unfocus();
    }
}
