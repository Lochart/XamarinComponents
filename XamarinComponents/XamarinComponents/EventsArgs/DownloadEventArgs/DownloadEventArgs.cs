using System;

namespace XamarinComponents
{
    /// <summary>
    /// Событие
    /// </summary>
    public class DownloadEventArgs : EventArgs
    {
        /// <summary>
        /// Статус сохранения файла
        /// </summary>
        public bool FileSaved;


        public DownloadEventArgs(bool fileSaved) => FileSaved = fileSaved;
    }
}

