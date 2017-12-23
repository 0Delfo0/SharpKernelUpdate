using System;
using System.Net;
using System.Threading;
using Gtk;
using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    internal class HtmlString : KuDownloaders
    {
        private ManualResetEvent _reset;
        private string _htmlString;

        public HtmlString(ProgressBar progressBar, KuUrlItem urlItem) : base(progressBar, urlItem)
        {
        }

        public string Download(string uri)
        {
            _reset = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += DownloadProgressChanged;
            client.DownloadStringCompleted += DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(uri));

            _reset.WaitOne();

            return _htmlString;
        }

        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine("DownloadStringCompleted");
            _htmlString = e.Result;
            _reset.Set();
        }
    }
}