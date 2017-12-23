using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Gui
{
    public class KuConfigurator
    {
        public const string BaseUrl = "http://kernel.ubuntu.com/~kernel-ppa/mainline/";

        public bool IsOnlyStableVersion { get; set; } = true;

        public bool Is64Architecture { get; set; } = true;

        public bool IsLowLatency { get; set; } = false;

        public KuUrlItem CurrentUrlItem { get; set; }
    }
}