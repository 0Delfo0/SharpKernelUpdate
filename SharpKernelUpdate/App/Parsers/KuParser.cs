using System;
using System.Collections.Generic;
using AngleSharp.Parser.Html;
using Gtk;
using Microsoft.Extensions.Logging;
using SharpKernelUpdate.App.Gui;
using SharpKernelUpdate.App.Model;
using SharpKernelUpdate.App.Parsers.Downloaders;

namespace SharpKernelUpdate.App.Parsers
{
    internal static class KuParser
    {
        private static readonly char[] Delimiter = new char[] {'.'};

        private static List<KuUrlItem> _mainList;

        public static List<KuUrlItem> GetMainList(ProgressBar progressBar)
        {
            if(_mainList == null)
            {
                GetUrlItems(progressBar);
            }

            foreach(var i in _mainList)
            {
                Program.Log.LogDebug(i.ToString());
            }

            return _mainList;
        }

        static string GetCall(ProgressBar progressBar, string uri)
        {
            var urlItem = new KuUrlItem();
            var kUDownloaders = new KuDownloaders(progressBar, urlItem);
            return kUDownloaders.DownloadHtmlString(uri);
        }

        //static string GetCall(string Url)
        //{
        //    var request = WebRequest.Create(Url);
        //    var response = request.GetResponse();
        //    var dataStream = response.GetResponseStream();

        //    var reader = new StreamReader(dataStream);
        //    var responseFromServer = reader.ReadToEnd();
        //    reader.Close();
        //    response.Close();
        //    return responseFromServer;
        //}

        private static void GetUrlItems(ProgressBar progressBar)
        {
            _mainList = new List<KuUrlItem>();
            try
            {
                var htmlParser = new HtmlParser();

                var iHtmlDocument = htmlParser.Parse(GetCall(progressBar, KuConfigurator.BaseUrl));
                var links = iHtmlDocument.Links;

                foreach(var link in links)
                {
                    var fullName = link.TextContent;

                    var tmp = new List<string>(fullName.Split(Delimiter, 3));

                    tmp = KuFilter.Normalize(tmp);

                    var isStableVersion = KuFilter.StableVersion(tmp);

                    if(tmp.Count <= 0 || !isStableVersion)
                        continue;
                    var urlItem = new KuUrlItem
                    {
                        FullName = fullName,
                        SplitName = tmp
                    };

                    _mainList.Add(urlItem);
                }
            }
            catch(Exception e)
            {
                Program.Log.LogError("Error", e);
            }
        }
    }
}