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

		private static SortedList<string, List<Item>> mainVersionsList = new SortedList<string, List<Item>>();

		public static string GetCall(Parser instance, string Url)
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

		//public List<Item> getItems()
		public void getItems()
		{
			try
			{
				var htmlParser = new HtmlParser();
				var iHtmlDocument = htmlParser.Parse(Parser.GetCall(this, BaseUrl));
				var links = iHtmlDocument.Links;

				Item item;

				foreach (IElement link in links)
				{
					string fullName = link.TextContent;
					var tmp = fullName.Split('.');

					if (tmp[0].StartsWith("v", StringComparison.CurrentCultureIgnoreCase))
					{
						tmp[0] = Filter.FormatFirst(tmp[0]);

						string mainVersion = tmp[0];

						item = new Item();

						item.fullName = fullName;
						item.splitName = tmp;

						var listItem = new List<Item>();
						if (mainVersionsList.ContainsKey(mainVersion))
						{
							mainVersionsList.TryGetValue(mainVersion, out listItem);
							listItem.Add(item);
						}
						else
						{
							listItem.Add(item);
							mainVersionsList.Add(mainVersion, listItem);
						}
					}
				}

				//foreach (var s in MainVersionsList.Values)
				//{
				//	foreach (var q in s) {
				//		Program.LOG.Info(q.ToString());
				//	}
				//}

			}
			catch (Exception e)
			{
				Program.LOG.Error("Error", e);
			}

		}

	

	}
}
