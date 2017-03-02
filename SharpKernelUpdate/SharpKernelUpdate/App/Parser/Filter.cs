using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Parser
{
    class Filter
    {
        private Boolean IsOnlyStableVersion(Boolean IsOnlyStableVersion, String Value)
        {
            if (IsOnlyStableVersion)
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

    }
}
