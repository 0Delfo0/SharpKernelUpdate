using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    class File : KUDownloaders
    {
        ManualResetEvent reset;
        string htmlString;

        public File(KUUrlItem urlItem) : base(urlItem)
        {
        }

        public bool DownloadFile(KUUrlItem urlItem)
        {
            return DownloadFile(urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        public bool DownloadFile(string uri, string filePath, string fileName)
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
