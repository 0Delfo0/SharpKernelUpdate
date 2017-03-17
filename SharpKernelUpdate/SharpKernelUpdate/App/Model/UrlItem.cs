using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Model
{
	class UrlItem
	{
        private string fullName;
        private string[] splitName;
        private string uri;
        private string filePath;
        private string fileName;
        private bool isReady;

        public string FullName { get => fullName; set => fullName = value; }
        public string[] SplitName { get => splitName; set => splitName = value; }
        public string Uri { get => uri; set => uri = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public bool IsReady { get => isReady; set => isReady = value; }
    }
}
