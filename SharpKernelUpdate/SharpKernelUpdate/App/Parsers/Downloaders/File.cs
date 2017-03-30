using SharpKernelUpdate.App.Model;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    internal class File : KuDownloaders
    {
        private ManualResetEvent _reset;

        public File(Gtk.ProgressBar progressBar, KuUrlItem urlItem) : base(progressBar, urlItem)
        {
        }

        public bool Download(KuUrlItem urlItem)
        {
            return Download(urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        public bool Download(string uri, string filePath, string fileName)
        {
            _reset = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += DownloadProgressChanged;
            client.DownloadFileCompleted += DownloadFileCompleted;
            client.DownloadFileAsync(new Uri(uri), KuFiles.AddPathSeparator(filePath) + fileName);

            _reset.WaitOne();

            return true;
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs args)
        {
            _reset.Set();
        }
    }
}