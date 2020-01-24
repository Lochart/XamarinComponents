using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class ComponentsTitleAndDescription : ContentView
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(ComponentsTitleAndDescription));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Описание
        /// </summary>
        public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create("Description", typeof(string), typeof(ComponentsTitleAndDescription));

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public ComponentsTitleAndDescription()
        {
            InitializeComponent();
        }
    }
}
