using Gtk;
using SharpKernelUpdate.App.Model;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    class KUDownloaders : IDowloaders
    {
        protected ProgressBar progressBar;
        protected KUUrlItem urlItem;

        public KUDownloaders(ProgressBar progressBar, KUUrlItem urlItem)
        {
            this.progressBar = progressBar;
            this.urlItem = urlItem;
        }

        public bool DownloadFile(KUUrlItem urlItem)
        {
            var downloader = new File(progressBar, urlItem);
            return downloader.Download(urlItem);
        }

        public bool DownloadFile(string uri, string filePath, string fileName)
        {
            var downloader = new File(progressBar, urlItem);
            return downloader.Download(uri, filePath, fileName);
        }

        public string DownloadHtmlString(string uri)
        {
            var downloader = new HtmlString(progressBar, urlItem);
            return downloader.Download(uri);
        }

        //
        protected void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs args)
        {
            progressBar.Fraction = (args.ProgressPercentage / 100);
        }

    }
}
