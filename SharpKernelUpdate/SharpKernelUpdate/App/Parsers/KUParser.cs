using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using SharpKernelUpdate.App.Gui;
using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace SharpKernelUpdate.App.Parsers
{
    static class KUParser
    {
        static List<KUUrlItem> MAIN_LIST;

        public static List<KUUrlItem> GetMainList()
        {
            if (MAIN_LIST == null)
            {
                GetUrlItems();
            }
            return MAIN_LIST;
        }

        static string GetCall(string Url)
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

        static void GetUrlItems()
        {
            MAIN_LIST = new List<KUUrlItem>();

            try
            {
                var htmlParser = new HtmlParser();
                var iHtmlDocument = htmlParser.Parse(GetCall(KUConfigurator.baseUrl));
                var links = iHtmlDocument.Links;

                foreach (IElement link in links)
                {
                    string fullName = link.TextContent;
                    var tmp = fullName.Split('.');

                    var isStableVersion = KUFilter.StableVersion(tmp);

                    if (tmp[0].StartsWith("v", StringComparison.CurrentCultureIgnoreCase) && isStableVersion)
                    {
                        tmp[0] = KUFilter.FormatFirst(tmp[0]);

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
