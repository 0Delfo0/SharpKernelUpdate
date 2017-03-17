using Gtk;
using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Parsers
{
    class Downloader
    {
        ProgressBar progressBar;
        UrlItem urlItem;

        public Downloader(UrlItem urlItem)
        {
            this.urlItem = urlItem;
            this.progressBar = new ProgressBar();
        }

        public bool DownloadFile(ProgressBar progressBar, UrlItem urlItem)
        {
            return DownloadFile(progressBar, urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        public bool DownloadFile(ProgressBar progressBar, string uri, string filePath, string fileName)
        {
            bool downloadComplete = false;

            var client = new WebClient();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(uri), Files.AddPathSeparator(filePath) + fileName);


            // TODO: while 
            //while (!downloadComplete)
            //{
            //    //Application.DoEvents();
            //}

            downloadComplete = false;

            return downloadComplete;
        }

        void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs args)
        {
            progressBar.Fraction = (args.ProgressPercentage / 100);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs args)
        {
            urlItem.IsReady = true;
        }


    }


}
