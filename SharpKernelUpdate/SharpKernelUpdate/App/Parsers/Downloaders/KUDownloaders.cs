using Gtk;
using SharpKernelUpdate.App.Model;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    class KUDownloaders
    {
        private ProgressBar progressBar;
        private KUUrlItem urlItem;
        
        public KUDownloaders(KUUrlItem urlItem)
        {
            this.urlItem = urlItem;
            this.progressBar = new ProgressBar();
        }

        protected void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs args)
        {
            progressBar.Fraction = (args.ProgressPercentage / 100);
        }
    }
}
