using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class ComponentsUserBaner : ContentView
    {
        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public static readonly BindableProperty HeaderProperty =
        BindableProperty.Create("FIO", typeof(string), typeof(ComponentsUserBaner));

        public string FIO
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Кнопка выхода
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("CommandExit", typeof(ICommand), typeof(ComponentsUserBaner));

        public ICommand CommandExit
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public ComponentsUserBaner()
        {
            InitializeComponent();
        }
    }
}
