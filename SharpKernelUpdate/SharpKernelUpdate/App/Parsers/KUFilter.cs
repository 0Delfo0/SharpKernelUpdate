using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpKernelUpdate.App.Parsers
{
    class KUFilter
    {
        public static bool StableVersion(string value)
        {
            if (Program.Configurator.IsOnlyStableVersion)
            {
                if (value.IndexOf("rc", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool StableVersion(string[] values)
        {
            foreach (string s in values)
            {
                var isStableVersion = StableVersion(s);
                if (!isStableVersion)
                {
                    return false;
                }
            }
            return true;
        }

        public static string FormatFirst(string value)
        {
            return value.Trim('v');
        }

        public static IEnumerable<IGrouping<string, KUUrlItem>> GetListElements(int level, List<KUUrlItem> listUrlItem)
        {
            var p = from i in listUrlItem group i by i.SplitName[level];
            return p;
        }
    }
}
