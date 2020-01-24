using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class ComponentsLine : ContentView
    {
        /// <summary>
        /// Фон линий
        /// </summary>
        public static readonly BindableProperty BackgroundColorLineProperty =
            BindableProperty.Create(
                "BackgroundColorLine",
                typeof(Color),
                typeof(ComponentsLine));

        public Color BackgroundColorLine
        {
            get => (Color)GetValue(BackgroundColorLineProperty);
            set => SetValue(BackgroundColorLineProperty, value);
        }

        public ComponentsLine()
        {
            InitializeComponent();
        }
    }
}
