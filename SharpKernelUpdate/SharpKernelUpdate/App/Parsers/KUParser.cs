using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Configuration;
using SharpKernelUpdate.App.Parsers.Downloaders;
using Gtk;

namespace SharpKernelUpdate.App.Parsers
{
    static class KUParser
    {
        private static char[] DELIMITER = new char[] { '.' };

        static List<KUUrlItem> MAIN_LIST;

        public static List<KUUrlItem> GetMainList(ProgressBar progressBar)
        {
            if (MAIN_LIST == null)
            {
                GetUrlItems(progressBar);
            }

            foreach (KUUrlItem i in MAIN_LIST)
            {
                Program.LOG.Debug(i.ToString());
            }

            return MAIN_LIST;
        }


        static string GetCall(ProgressBar progressBar, string uri)
        {
            var urlItem = new KUUrlItem();
            var kUDownloaders = new KUDownloaders(progressBar, urlItem);
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

        static void GetUrlItems(ProgressBar progressBar)
        {
            MAIN_LIST = new List<KUUrlItem>();
            try
            {
                var htmlParser = new HtmlParser();

                var iHtmlDocument = htmlParser.Parse(GetCall(progressBar, ConfigurationManager.AppSettings["BaseUrl"]));
                var links = iHtmlDocument.Links;

                foreach (IElement link in links)
                {
                    string fullName = link.TextContent;

                    var tmp = new List<string>(fullName.Split(DELIMITER, 3));

                    tmp = KUFilter.Normalize(tmp);

                    var isStableVersion = KUFilter.StableVersion(tmp);

                    if (tmp.Count > 0 && isStableVersion)
                    {
                        var urlItem = new KUUrlItem()
                        {
                            FullName = fullName,
                            SplitName = tmp
                        };

                        MAIN_LIST.Add(urlItem);
                    }
                }
            }
            catch (Exception e)
            {
                Program.LOG.Error("Error", e);
            }
        }
    }
}
