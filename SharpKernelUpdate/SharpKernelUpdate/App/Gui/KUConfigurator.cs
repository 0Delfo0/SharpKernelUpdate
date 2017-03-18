using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Gui
{
    public class KUConfigurator
    {
        public const string baseUrl = "http://kernel.ubuntu.com/~kernel-ppa/mainline/";

        private static bool isOnlyStableVersion;
        private static bool is64Architecture;
        private static bool isLowLatency;
        private static KUUrlItem currentUrlItem;

        public static bool IsOnlyStableVersion { get => isOnlyStableVersion; set => isOnlyStableVersion = value; }
        public static bool Is64Architecture { get => is64Architecture; set => is64Architecture = value; }
        public static bool IsLowLatency { get => isLowLatency; set => isLowLatency = value; }
        internal static KUUrlItem CurrentUrlItem { get => currentUrlItem; set => currentUrlItem = value; }
    }
}
