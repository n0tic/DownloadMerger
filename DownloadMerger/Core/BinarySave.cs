using DownloadMerger.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMerger.Core
{
    public static class BinarySave
    {
        public static void WriteToBinaryFile(string filePath, Object objectToWrite, bool append = false)
        {
            if (filePath == "")
                filePath = @AppDomain.CurrentDomain.BaseDirectory + "\\data.dat";

            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static DMData ReadFromBinaryFile(string filePath)
        {
            if(filePath == "")
                filePath = @AppDomain.CurrentDomain.BaseDirectory + "\\data.dat";

            if (File.Exists(filePath))
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return (DMData)binaryFormatter.Deserialize(stream);
                }
            }
            else
                return null;
        }

        public static void ResetData(string filePath)
        {
            if (filePath == "")
                filePath = @AppDomain.CurrentDomain.BaseDirectory + "\\data.dat";

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
