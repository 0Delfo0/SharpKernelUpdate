using SharpKernelUpdate.App.Model;
using System;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    internal class HtmlString : KuDownloaders
    {
        private ManualResetEvent _reset;
        private string _htmlString;

        public HtmlString(Gtk.ProgressBar progressBar, KuUrlItem urlItem) : base(progressBar, urlItem)
        {
        }

        public string Download(string uri)
        {
            _reset = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += DownloadProgressChanged;
            client.DownloadDataCompleted += DownloadDataCompleted;
            client.DownloadStringAsync(new Uri(uri));

            _reset.WaitOne();

            return _htmlString;
        }

        private void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            _htmlString = System.Text.Encoding.Default.GetString(e.Result);
            _reset.Set();
        }
    }
}