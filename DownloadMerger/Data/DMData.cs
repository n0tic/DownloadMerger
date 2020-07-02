using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadMerger.Data
{
    [System.Serializable]
    public class DMData
    {
        public List<CollectionData> collectionData = new List<CollectionData>();

        public void AddCollection(int id, string name, string path)
        {
            CollectionData cd = new CollectionData(id, name, path);
            collectionData.Add(cd);
        }

        public CollectionData GetCollectionData(int index)
        {
            if (collectionData.Count > 0)
            {
                foreach (CollectionData cd in collectionData)
                {
                    if (cd.collectionID == index)
                    {
                        return cd;
                    }
                }
            }

            return null;
        }

        public int GetTotalRows()
        {
            int tmpInt = 0;

            foreach (CollectionData cd in collectionData)
            {
                foreach(RowData rd in cd.rowData)
                {
                    tmpInt++;
                }
            }

            return tmpInt;
        }

        public void AddRowData(int id, string name, string url, int collectionDataID)
        {
            if (collectionData.Count > 0)
            {
                foreach (CollectionData cd in collectionData)
                {
                    if (cd.collectionID == collectionDataID)
                    {
                        cd.AddRowData(id, name, url);
                        break;
                    }
                }
            }
        }

        public void BuildCollectionHolderList(MainForm mf)
        {
            if(collectionData.Count > 0)
            {
                foreach (CollectionData cd in collectionData)
                {
                    mf.CollectionsHolder.Items.Add(cd.collectionName);
                }
            }
        }
    }
}
