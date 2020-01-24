using Xamarin.Forms;

namespace XamarinComponents
{
    /// <summary>
	/// Пользовательский интерфейс по визуальному загрузке данных
	/// </summary>
    public interface ILoaderPopup
    {
        void ShowLoader(AbsoluteLayout container);
        void HideLoader();
    }
}

