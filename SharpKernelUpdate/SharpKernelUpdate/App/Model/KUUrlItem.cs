using System.Collections.Generic;

namespace SharpKernelUpdate.App.Model
{
    public class KUUrlItem
    {
        string fullName;
        List<string> splitName;
        string uri;
        string filePath;
        string fileName;
        bool isReady;

        public override string ToString()
        {
            return "KUUrlItem{" +
                "fullName='" + FullName + '\'' +
                ", splitName='" + string.Join(".", SplitName) + '\'' +
                ", uri='" + Uri + '\'' +
                ", filePath='" + FilePath + '\'' +
                ", fileName='" + FileName + '\'' +
                ", isReady=" + IsReady +
                '}';
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public List<string> SplitName
        {
            get
            {
                return splitName;
            }

            set
            {
                splitName = value;
            }
        }

        public string Uri
        {
            get
            {
                return uri;
            }

            set
            {
                uri = value;
            }
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public bool IsReady
        {
            get
            {
                return isReady;
            }

            set
            {
                isReady = value;
            }
        }
    }
}
