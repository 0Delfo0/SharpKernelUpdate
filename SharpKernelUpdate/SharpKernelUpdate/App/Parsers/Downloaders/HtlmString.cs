using SharpKernelUpdate.App.Model;
using System;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    class HtmlString : KUDownloaders
    {
        ManualResetEvent reset;
        string htmlString;

        public HtmlString(KUUrlItem urlItem) : base(urlItem)
        {
        }

        public string DownloadHtlmString(string uri)
        {
            reset = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            client.DownloadDataCompleted += DownloadDataCompleted;            
            client.DownloadStringAsync(new Uri(uri));

            reset.WaitOne();
            
            return htmlString;
        }

        void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            htmlString = System.Text.Encoding.Default.GetString(e.Result);
            reset.Set();            
        }

    }
}
