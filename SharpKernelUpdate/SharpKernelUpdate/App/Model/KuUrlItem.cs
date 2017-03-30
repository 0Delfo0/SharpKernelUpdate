using System.Collections.Generic;

namespace SharpKernelUpdate.App.Model
{
    public class KuUrlItem
    {
        public override string ToString()
        {
            return "KuUrlItem{" +
                   "fullName='" + FullName + '\'' +
                   ", splitName='" + string.Join(".", SplitName) + '\'' +
                   ", uri='" + Uri + '\'' +
                   ", filePath='" + FilePath + '\'' +
                   ", fileName='" + FileName + '\'' +
                   ", isReady=" + IsReady +
                   '}';
        }

        public string FullName { get; set; }

        public List<string> SplitName { get; set; }

        public string Uri { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public bool IsReady { get; set; }
    }
}