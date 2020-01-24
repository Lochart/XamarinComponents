using System;

using Xamarin.Forms;

namespace XamarinComponents
{
    public class CustomEntry : Entry
    {
        /// <summary>
        /// Цвет границ Entry
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor),
            typeof(Color), typeof(CustomEntry), Color.Gray);

        /// <summary>
        /// Цвет границ Entry
        /// </summary>
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        /// <summary>
        /// Ширина границ Entry
        /// </summary>
        [Obsolete]
        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(int),
            typeof(CustomEntry), Device.OnPlatform<int>(1, 2, 2));

        [Obsolete]
        /// <summary>
        /// Ширина границ Entry
        /// </summary>
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        /// <summary>
        /// Радиус округления границ Entry
        /// </summary>
        [Obsolete]
        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius),
            typeof(double), typeof(CustomEntry), Device.OnPlatform<double>(6, 7, 7));

        /// <summary>
        /// Радиус округления границ Entry
        /// </summary>
        [Obsolete]
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// Статус огругления Entry
        /// </summary>
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
        BindableProperty.Create(nameof(IsCurvedCornersEnabled),
            typeof(bool), typeof(CustomEntry), true);

        /// <summary>
        /// Статус огругления Entry
        /// </summary> 
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
    }
}

