using Xamarin.Forms;

namespace XamarinComponents
{
    /// <summary>
    /// UI представление Editor
    /// </summary>
    public class StyleEditorChat : Editor     {
        /// <summary>
        /// dЗаполнить
        /// </summary>         public static readonly BindableProperty PlaceholderProperty =             BindableProperty.Create<StyleEditorChat, string>(view => view.Placeholder, "Введите сообщение"); //string.Empty);

        public string Placeholder         {             get => (string)GetValue(PlaceholderProperty);             set => SetValue(PlaceholderProperty, value);         }          /// <summary>
        /// Цвет заполнить
        /// </summary>         public static readonly BindableProperty PlaceholderColorProperty =             BindableProperty.Create<StyleEditorChat, Color>(view => view.PlaceholderColor, Color.Gray);

        public Color PlaceholderColor         {             get => (Color)GetValue(PlaceholderColorProperty);             set => SetValue(PlaceholderColorProperty, value);         }          /// <summary>
        /// Цвет границы
        /// </summary>         public static readonly BindableProperty BorderColorProperty =             BindableProperty.Create<StyleEditorChat, Color>(view => view.BorderColor, Color.Silver);

        public Color BorderColor         {             get => (Color)GetValue(BorderColorProperty);             set => SetValue(BorderColorProperty, value);         }          /// <summary>
        /// Окружность границы
        /// </summary>         public static readonly BindableProperty CornerRadiusProperty =             BindableProperty.Create<StyleEditorChat, int>(view => view.CornerRadius, 15);          public int CornerRadius         {             get => (int)GetValue(CornerRadiusProperty);             set => SetValue(CornerRadiusProperty, value);         }     } }