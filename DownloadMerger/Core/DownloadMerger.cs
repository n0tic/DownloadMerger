using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMerger
{
    public class DownloadMerger
    {
        public static string softwareName = "DownloadMerger";

        public static string authorRealName = "Victor R";
        public static string authorName = "N0tiC";
        public static string authorContact = "contact@bytevaultstudio.se";

        public static int majorVersion = 0;
        public static int minorVersion = 0;
        public static int buildVersion = 1;
        public static BuildTypes buildType = BuildTypes.Alpha;

        public enum BuildTypes
        {
            Alpha,
            Beta,
            Normal
        }

        public static string GetVersion() { return majorVersion.ToString() + "." + minorVersion.ToString() + "." + buildVersion.ToString() + " " + buildType.ToString(); }

        public static string GetContact() { return authorContact; }
    }
}
