using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class ComponentEntryBorderTitle : ContentView
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(ComponentEntryBorderTitle));

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Описание Entry
        /// </summary>
        public static readonly BindableProperty PlaceholderTextProperty =
        BindableProperty.Create("PlaceholderText", typeof(string), typeof(ComponentEntryBorderTitle));

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        /// <summary>
        /// Текст Entry
        /// </summary>
        public static readonly BindableProperty TextProperty =
        BindableProperty.Create("Text", typeof(string), typeof(ComponentEntryBorderTitle));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public ComponentEntryBorderTitle()
        {
            InitializeComponent();
        }
    }
}
