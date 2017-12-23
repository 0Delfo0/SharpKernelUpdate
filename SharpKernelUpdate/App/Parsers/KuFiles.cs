using System;
using System.IO;
using System.Net;
using Gtk;
using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Parsers
{
    internal static class KuFiles
    {
        public static bool SaveFile(string filePath, string fileName)
        {
            bool retVal = true;

            var directoryInfo = Directory.CreateDirectory(filePath);
            // TODO: test di directoryInfo 

            return retVal;
        }

        public static bool DownloadFile(ProgressBar progressBar, KuUrlItem urlItem)
        {
            return DownloadFile(progressBar, urlItem.Uri, urlItem.FilePath, urlItem.FileName);
        }

        private static bool DownloadFile(ProgressBar progressBar, string uri, string filePath, string fileName)
        {
            var retVal = true;

            var client = new WebClient();

            client.DownloadProgressChanged += (s, args) =>
            {
                Console.WriteLine("{0} percent complete", args.ProgressPercentage);
                progressBar.Fraction = (args.ProgressPercentage / 100);
            };

            client.DownloadFileCompleted += (s, args) => { Console.WriteLine("END"); };

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
            var retVal = false;

            if(filePath == null || fileName == null)
                return retVal;
            var fullPath = AddPathSeparator(filePath) + fileName;
            File.Delete(fullPath);
            retVal = true;

            return retVal;
        }

        public static string AddPathSeparator(string filePath)
        {
            string fullPath = null;

            if(filePath == null)
                return null;

            fullPath += filePath;
            if(!filePath.EndsWith(Path.PathSeparator.ToString()))
            {
                fullPath += Path.PathSeparator.ToString();
            }
            return fullPath;
        }
    }
}