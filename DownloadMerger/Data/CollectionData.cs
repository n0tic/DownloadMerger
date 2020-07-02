using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadMerger.Data
{
    [System.Serializable]
    public class CollectionData
    {
        public int collectionID = 0;
        public string collectionName = "";
        public string collectionOutputLocationPath = "";
        public List<RowData> rowData = new List<RowData>();

        public CollectionData(int id, string name, string outputPath)
        {
            collectionID = id;
            collectionName = name;
            collectionOutputLocationPath = outputPath;
        }

        public void AddRowData(int id, string name, string url)
        {
            rowData.Add(new RowData(id, name, url));
        }
    }
}
