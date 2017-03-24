using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Parsers.Downloaders
{
    interface IDowloaders
    {
        string DownloadHtmlString(string uri);
        bool DownloadFile(KUUrlItem urlItem);
        bool DownloadFile(string uri, string filePath, string fileName);
    }
}
