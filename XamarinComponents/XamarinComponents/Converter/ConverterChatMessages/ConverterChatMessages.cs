using Xamarin.Forms;

namespace XamarinComponents
{
    public class ConverterChatMessages : DataTemplateSelector
    {
        /// <summary>
        /// Приходящие данные
        /// </summary>
        private readonly DataTemplate incomingDataTemplate;

        /// <summary>
        /// Отправленные данные
        /// </summary>
        private readonly DataTemplate outgoingDataTemplate;

        public ConverterChatMessages()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(MessageIncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(MessageOutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) =>
            !(item is ModelChatMessages messageVm) ? null : messageVm.IsIncoming ? this.incomingDataTemplate : this.outgoingDataTemplate;
    }
}