using System;
using System.Collections.Generic;
using System.Linq;
using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate.App.Parsers
{
    internal class KuFilter
    {
        private const string StableVersionFilterRc = "RC";
        private const string StableVersionFilterUnstable = "UNSTABLE";

        private static readonly List<string> CharToRemove = new List<string> {"/"};

        public static List<string> Normalize(List<string> values)
        {
            var retList = new List<string>();

            try
            {
                if(values != null)
                {
                    var tmpLength = values.Count;

                    if(tmpLength > 1)
                    {
                        if(values[0].StartsWith("v", StringComparison.CurrentCultureIgnoreCase))
                        {
                            values[0] = FormatFirst(values[0]);

                            switch(tmpLength)
                            {
                                case 1:
                                    break;

                                case 2:
                                    retList.Add(values[0]);
                                    var prefix = values[1].Split('-');
                                    var prefixLength = prefix.Length;
                                    switch(prefixLength)
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
            catch(Exception e)
            {
                Program.Log.Error("Normalize", e);
            }

            if(retList.Count <= 0)
                return retList;
            for(var i = 0; i < retList.Count; i++)
            {
                foreach(var s in CharToRemove)
                {
                    retList[i] = retList[i].Replace(s, String.Empty);
                }
            }

            return retList;
        }

        public static bool StableVersion(List<string> values)
        {
            if(Program.Configurator.IsOnlyStableVersion)
            {
                foreach(var s in values)
                {
                    if(s.IndexOf(StableVersionFilterRc, StringComparison.OrdinalIgnoreCase) >= 0 || s.IndexOf(
                           StableVersionFilterUnstable, StringComparison.OrdinalIgnoreCase) >= 0)
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

        public static IEnumerable<IGrouping<string, KuUrlItem>> GetListElements(int level,
            IEnumerable<KuUrlItem> listUrlItem)
        {
            var p = from i in listUrlItem group i by i.SplitName[level];
            return p;
        }
    }
}