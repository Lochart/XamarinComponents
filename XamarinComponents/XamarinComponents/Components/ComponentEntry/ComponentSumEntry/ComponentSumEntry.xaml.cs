using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class ComponentSumEntry : ContentView
    {
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

        public ComponentSumEntry()
        {
            InitializeComponent();
        }

        private void FocusedEntry(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
        }

        private void UnfocusedEntry(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
        }

        private void TextChangedEntry(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            var oldValue = e.OldTextValue;
            var newValue = e.NewTextValue;

            if (!string.IsNullOrEmpty(newValue) && !string.IsNullOrWhiteSpace(newValue))
            {
                if (!newValue[0].Equals(",") || !newValue[0].Equals("."))
                {

                }
            }
        }
    }
}
