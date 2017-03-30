using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    internal interface IDowloaders
    {
        string DownloadHtmlString(string uri);
        bool DownloadFile(KuUrlItem urlItem);
        bool DownloadFile(string uri, string filePath, string fileName);
    }
}