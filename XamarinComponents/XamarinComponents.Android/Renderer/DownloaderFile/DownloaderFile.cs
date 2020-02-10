using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;
using XamarinComponents.Droid;

[assembly: Dependency(typeof(DownloaderFile))]
namespace XamarinComponents.Droid
{
    public class DownloaderFile : IDownloader
    {
        public event EventHandler<DownloadEventArgs> OnFileDownloaded;

        [Obsolete]
        public void DownloadFile(string url, string folder)
        {
            // Путь новой папке
            string pathToNewFolder = Path.Combine(
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,
                folder);

            // Создать директорию папки
            Directory.CreateDirectory(pathToNewFolder);

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);

                // Путь к новому файлу
                string pathToNewFile = Path.Combine(
                    pathToNewFolder,
                    Path.GetFileName(url));

                // Скачивание файла
                webClient.DownloadFileAsync(new Uri(url), pathToNewFile);
            }
            catch (Exception ex)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
        }

        /// <summary>
        /// Метод Выполнен
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
            else
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(true));
            }
        }
    }
}

