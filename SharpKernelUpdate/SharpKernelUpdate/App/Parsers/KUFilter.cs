using SharpKernelUpdate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpKernelUpdate.App.Parsers
{
    class KUFilter
    {
        private static string StableVersion_Filter_RC = "RC";
        private static string StableVersion_Filter_UNSTABLE = "UNSTABLE";

        private static List<string> CHAR_TO_REMOVE = new List<string> { "/" };

        public static List<string> Normalize(List<string> values)
        {
            var retList = new List<string>();

            try
            {
                if (values != null)
                {
                    int tmpLength = values.Count;

                    if (tmpLength > 1)
                    {
                        if (values[0].StartsWith("v", StringComparison.CurrentCultureIgnoreCase))
                        {
                            values[0] = FormatFirst(values[0]);

                            switch (tmpLength)
                            {
                                case 1:
                                    break;

                                case 2:
                                    retList.Add(values[0]);
                                    var prefix = values[1].Split('-');

                                    int prefixLength = prefix.Length;

                                    switch (prefixLength)
                                    {
                                        case 1:
                                            retList.Add(prefix[0]);
                                            retList.Add("0");
                                            break;

                                        default:
                                            retList.Add(prefix[0]);
                                            retList.Add("0-" + prefix[1]);
                                            break;
                                    }
                                    break;

                                case 3:
                                case 4:
                                    retList = values;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Program.LOG.Error("Normalize", e);
            }

            if (retList.Count > 0)
            {
                for (int i = 0; i < retList.Count; i++)
                {
                    foreach (var s in CHAR_TO_REMOVE)
                    {
                        retList[i] = retList[i].Replace(s, String.Empty);
                    }
                }
            }

            return retList;
        }

        public static bool StableVersion(List<string> values)
        {
            if (Program.Configurator.IsOnlyStableVersion)
            {
                foreach (var s in values)
                {
                    if (s.IndexOf(StableVersion_Filter_RC, StringComparison.OrdinalIgnoreCase) >= 0 || s.IndexOf(StableVersion_Filter_UNSTABLE, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        private static string FormatFirst(string value)
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
