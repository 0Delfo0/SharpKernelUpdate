using Gtk;
using SharpKernelUpdate.App.Model;
using System;
using System.IO;
using System.Net;

namespace SharpKernelUpdate.App.Parsers
{
    static class Files
    {
        public static bool SaveFile(string filePath, string fileName)
        {
            bool retVal = true;

            var directoryInfo = Directory.CreateDirectory(filePath);
            // TODO: test di directoryInfo 

            return retVal;
        }
                
        public static bool DownloadFile(ProgressBar progressBar, UrlItem urlItem)
        {
            return DownloadFile(progressBar, urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        public static bool DownloadFile(ProgressBar progressBar, string uri, string filePath, string fileName)
        {
            bool retVal = true;

            var client = new WebClient();

            client.DownloadProgressChanged += (s, args) =>
            {
                Console.WriteLine("{0} percent complete", args.ProgressPercentage);
                progressBar.Fraction = (args.ProgressPercentage / 100);
            };

            client.DownloadFileCompleted += (s, args) =>
            {                
                Console.WriteLine("END");
            };

            client.DownloadFileAsync(new Uri(uri), AddPathSeparator(filePath) + fileName);

            return retVal;
        }


        public static bool DeleteDir(string filePath, bool recursive)
        {
            bool retVal = true;

            Directory.Delete(filePath, recursive);

            return retVal;
        }

        public static bool DeleteFile(string filePath, string fileName)
        {
            bool retVal = false;
            string fullPath = null;

            if (filePath != null && fileName != null)
            {
                fullPath = AddPathSeparator(filePath) + fileName;
                File.Delete(fullPath);
                retVal = true;
            }

            return retVal;
        }

        public static string AddPathSeparator(string filePath)
        {
            string fullPath = null;

            if (filePath != null)
            {
                fullPath += filePath;
                if (!filePath.EndsWith(Path.PathSeparator.ToString()))
                {
                    fullPath += Path.PathSeparator.ToString();
                }
            }
            return fullPath;
        }

    }


}
