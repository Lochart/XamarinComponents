using System;

namespace XamarinComponents
{
    /// <summary>
    /// Пользовательский интерфейс по списку контактов из телефона
    /// Инструкция по ссылке https://www.c-sharpcorner.com/article/how-to-download-files-in-xamarin-forms/
    /// </summary>
    public interface IDownloader
    {
        /// <summary>
        /// Метод скачивания
        /// </summary>
        /// <param name="url">ссылка скачивания</param>
        /// <param name="folder">папка</param>
        void DownloadFile(string url, string folder);

        /// <summary>
        /// Событие на файл скачивания
        /// </summary>
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
    }
}