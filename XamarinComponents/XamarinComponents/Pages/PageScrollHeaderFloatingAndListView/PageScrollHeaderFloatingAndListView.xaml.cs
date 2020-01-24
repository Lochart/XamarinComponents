using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinComponents
{
    public partial class PageScrollHeaderFloatingAndListView : ContentPage
    {
        private double PositionPanelOverall = 0;

        public PageScrollHeaderFloatingAndListView()
        {
            InitializeComponent();
            TestView.HeightRequest = App.DeviceWindowHeight;
            //ScrollTwo.HeightRequest = App.DeviceWindowHeight/2;
        }

        private void PanelOverallSizeChanged(object sender, EventArgs e)
        {
            var panelOverall = sender as StackLayout;
            PositionPanelOverall = panelOverall.Y;
            Debug.WriteLine("panelOverall Y : " + panelOverall.Y);
        }

        private void ScollViewScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = sender as ScrollView;

            //double scrollingSpace = scrollView.ContentSize.Height - scrollView.Height;

            if (e.ScrollY > PositionPanelOverall)
            {
                scrollView.ScrollToAsync(0, PositionPanelOverall, false);
                //TestView.IsEnabled = true;
            }
            else
            {
                //TestView.IsEnabled = false;
            }

            Debug.WriteLine("ContentSize.Height : " + scrollView.ContentSize.Height + " scrollView.Height " + scrollView.Height);
            //Debug.WriteLine("scrollingSpace : " + scrollingSpace);
            Debug.WriteLine("ScrollY : " + e.ScrollY + " ScrollX " + e.ScrollX);
        }
    }
}
