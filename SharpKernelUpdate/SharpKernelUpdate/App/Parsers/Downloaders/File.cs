using SharpKernelUpdate.App.Model;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    class File : KUDownloaders
    {
        ManualResetEvent reset;
        string htmlString;

        public File(Gtk.ProgressBar progressBar, KUUrlItem urlItem) : base(progressBar, urlItem)
        {
        }

        public bool Download(KUUrlItem urlItem)
        {
            return Download(urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        public bool Download(string uri, string filePath, string fileName)
        {
            reset = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(uri), KUFiles.AddPathSeparator(filePath) + fileName);

            reset.WaitOne();

            return true;
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs args)
        {
            reset.Set();
        }
    }
}
