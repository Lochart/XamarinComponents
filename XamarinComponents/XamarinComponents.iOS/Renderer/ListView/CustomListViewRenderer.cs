using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinComponents;
using XamarinComponents.iOS;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace XamarinComponents.iOS
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ShowsVerticalScrollIndicator = false;
            }
        }
    }
}

