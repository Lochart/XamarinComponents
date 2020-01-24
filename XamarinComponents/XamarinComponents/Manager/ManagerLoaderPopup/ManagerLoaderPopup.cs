using Xamarin.Forms;

namespace XamarinComponents
{
    public static class ManagerLoaderPopup
    {
        /// <summary>
        /// Интерфейс LoaderPopup
        /// </summary>
        private static ILoaderPopup LoaderPopup;

        /// <summary>
        /// Статус загрузки
        /// </summary>
        private static bool StatusLoaded;

        /// <summary>
        /// Инициализируем Loader
        /// </summary>
        public static void Init() => LoaderPopup = LoaderPopup ?? ComponentsLoaderPopup.Init();

        /// <summary>
        /// Показываем Loader
        /// </summary>
        /// <param name="container"></param>
        public static async void ShowLoader(AbsoluteLayout container)
        {
            StatusLoaded = false;

            Device.BeginInvokeOnMainThread(() =>
            {
                if (!StatusLoaded)
                    LoaderPopup.ShowLoader(container);
                else
                    HideLoader();
            });
        }

        /// <summary>
        /// Скрываем Loader
        /// </summary>
        public static void HideLoader()
        {
            LoaderPopup.HideLoader();
            StatusLoaded = true;
        }
    }
}