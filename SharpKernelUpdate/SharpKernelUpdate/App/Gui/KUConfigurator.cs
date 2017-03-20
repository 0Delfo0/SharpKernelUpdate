using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Gui
{
    public class KUConfigurator
    {
        public const string BaseUrl = "http://kernel.ubuntu.com/~kernel-ppa/mainline/";

        bool isOnlyStableVersion = true;
        bool is64Architecture = true;
        bool isLowLatency = false;
        KUUrlItem currentUrlItem;

        public bool IsOnlyStableVersion
        {
            get
            {
                return isOnlyStableVersion;
            }

            set
            {
                isOnlyStableVersion = value;
            }
        }

        public bool Is64Architecture
        {
            get
            {
                return is64Architecture;
            }

            set
            {
                is64Architecture = value;
            }
        }

        public bool IsLowLatency
        {
            get
            {
                return isLowLatency;
            }

            set
            {
                isLowLatency = value;
            }
        }

        public KUUrlItem CurrentUrlItem
        {
            get
            {
                return currentUrlItem;
            }

            set
            {
                currentUrlItem = value;
            }
        }
    }
}
