using System.Net;
using Gtk;
using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    internal class KuDownloaders : IDowloaders
    {
        private readonly ProgressBar _progressBar;
        private readonly KuUrlItem _urlItem;

        public KuDownloaders(ProgressBar progressBar, KuUrlItem urlItem)
        {
            _progressBar = progressBar;
            _urlItem = urlItem;
        }

        public bool DownloadFile(KuUrlItem urlItem)
        {
            var downloader = new File(_progressBar, urlItem);
            return downloader.Download(urlItem);
        }

        public bool DownloadFile(string uri, string filePath, string fileName)
        {
            var downloader = new File(_progressBar, _urlItem);
            return downloader.Download(uri, filePath, fileName);
        }

        public string DownloadHtmlString(string uri)
        {
            var downloader = new HtmlString(_progressBar, _urlItem);
            return downloader.Download(uri);
        }

        //
        protected void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs args)
        {
            _progressBar.Fraction = (args.ProgressPercentage / 100);
        }
    }
}