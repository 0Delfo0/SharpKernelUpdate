using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace SharpKernelUpdate.App.Parser
{
    class Parser
    {
        public static string BaseUrl = "http://kernel.ubuntu.com/~kernel-ppa/mainline/";

        private static SortedList<string, List<Item>> MainVersionsList = new SortedList<string, List<Item>>();
        private static CultureInfo CI = new CultureInfo("it-IT");


        public Parser()
        {
            MainVersionsList = new SortedList<string, List<Item>>();
        }

        public string GetCall(String Url)
        {
            WebRequest request = WebRequest.Create(Url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }


        public void MainVersion()
        {

        }

        //public List<Item> getItems()
        public void getItems()
        {


            HtmlParser HtmlParser = new HtmlParser();
            IHtmlDocument IHtmlDocument = HtmlParser.Parse(GetCall(BaseUrl));
            IHtmlCollection<IElement> Links = IHtmlDocument.Links;

            Item Item;



            foreach (IElement Link in Links)
            {

                string FullName = Link.TextContent;
                string[] Tmp = FullName.Split('.');

                if (Tmp[0].StartsWith("v", true, CI))
                {
                    Tmp[0] = formatFirst(Tmp[0]);

                    string MainVersion = Tmp[0];

                    Item = new Item();


                    Item.FullName = FullName;
                    Item.SplitName = Tmp;


                    List<Item> ListItem = new List<Item>();
                    if (MainVersionsList.ContainsKey(MainVersion))
                    {
                        MainVersionsList.TryGetValue(MainVersion, out ListItem);
                        ListItem.Add(Item);
                    }
                    else
                    {
                        ListItem.Add(Item);
                        MainVersionsList.Add(MainVersion, ListItem);
                    }

                }

            }
        }

        private string formatFirst(string value)
        {
            return value.Trim('v');

        }

    }
}
