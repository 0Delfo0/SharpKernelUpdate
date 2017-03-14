using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Parser
{
    class Filter
    {
        public static Boolean StableVersion(String Value)
        {
            if (Configurator.isOnlyStableVersion)
            {
                if (Value.IndexOf("rc", StringComparison.OrdinalIgnoreCase) >= 0)
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

        public static string FormatFirst(string value)
        {
            return value.Trim('v');
        }


        public static IEnumerable<IGrouping<string, UrlItem>> GetListElements(int level, List<UrlItem> listUrlItem)
        {
            var p = from i in listUrlItem group i by i.splitName[level];
            return p;
        }
    }
}
