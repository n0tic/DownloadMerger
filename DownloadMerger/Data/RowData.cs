using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMerger
{
    [System.Serializable]
    public class RowData
    {
        public int number = 0;
        public string name = "";
        public string url = "";

        public RowData(int no, string _name, string _url)
        {
            number = no;
            name = _name;
            url = _url;
        }
    }
}
