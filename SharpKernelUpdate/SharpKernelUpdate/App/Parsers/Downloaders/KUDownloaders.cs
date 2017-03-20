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
		protected ProgressBar progressBar;
		protected KUUrlItem urlItem;

		public KUDownloaders(ProgressBar progressBar, KUUrlItem urlItem)
		{
			this.progressBar = progressBar;
			this.urlItem = urlItem;
		}

		public string DownloadHtmlString(string uri)
		{
			var htmlString = new HtmlString(progressBar, urlItem);
			return htmlString.DownloadHtmlString1(uri);
		}

		protected void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs args)
		{
			progressBar.Fraction = (args.ProgressPercentage / 100);
		}
	}
}
