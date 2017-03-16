using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace SharpKernelUpdate.App.Parsers
{
    static class Parser
    {
        public static string BaseUrl = "http://kernel.ubuntu.com/~kernel-ppa/mainline/";

        private static List<UrlItem> MAIN_LIST;

        public static List<UrlItem> GetMainList()
        {
            if (MAIN_LIST == null)
            {
                GetUrlItems();
            }
            return MAIN_LIST;
        }

        private static string GetCall(string Url)
        {
            var request = WebRequest.Create(Url);
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();

            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }

        private static void GetUrlItems()
        {
            MAIN_LIST = new List<UrlItem>();

            try
            {
                var htmlParser = new HtmlParser();
                var iHtmlDocument = htmlParser.Parse(GetCall(BaseUrl));
                var links = iHtmlDocument.Links;

                foreach (IElement link in links)
                {
                    string fullName = link.TextContent;
                    var tmp = fullName.Split('.');

                    if (tmp[0].StartsWith("v", StringComparison.CurrentCultureIgnoreCase))
                    {
                        tmp[0] = Filter.FormatFirst(tmp[0]);

                        var urlItem = new UrlItem()
                        {
                            fullName = fullName,
                            splitName = tmp
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
