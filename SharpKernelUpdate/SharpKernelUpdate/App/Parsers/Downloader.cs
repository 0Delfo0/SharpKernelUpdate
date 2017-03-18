using Gtk;
using SharpKernelUpdate.App.Model;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers
{
    class Downloader
    {
        private ProgressBar progressBar;
        private UrlItem urlItem;
        private ManualResetEvent reset;

        public Downloader(UrlItem urlItem)
        {
            this.urlItem = urlItem;
            this.progressBar = new ProgressBar();
        }

        public bool DownloadFile(UrlItem urlItem)
        {
            return DownloadFile(urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        public bool DownloadFile(string uri, string filePath, string fileName)
        {
            bool downloadComplete = false;
            reset = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(uri), Files.AddPathSeparator(filePath) + fileName);

            reset.WaitOne();

            downloadComplete = true;

            return downloadComplete;
        }

        void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs args)
        {
            progressBar.Fraction = (args.ProgressPercentage / 100);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs args)
        {
            urlItem.IsReady = true;
            reset.Set();
        }


    }


}
