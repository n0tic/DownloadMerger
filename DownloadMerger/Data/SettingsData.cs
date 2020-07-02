using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadMerger
{
    public class SettingsData
    {
        public string ffmpeg_location = "";
        public string output_location = "";
        public bool sequentialDownload = true, addPause = false;

        public SettingsData()
        {
            LoadSettingsData();
        }

        public void ResetSettings()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"SOFTWARE\DownloadMergerSettings");
            }
            catch (Exception) {  }
        }

        public void LoadSettingsData()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\DownloadMergerSettings");

                if (key != null)
                {
                    ffmpeg_location = key.GetValue("ffmpeg_location").ToString();
                    output_location = key.GetValue("output_location").ToString();

                    if (int.Parse(key.GetValue("SaveType").ToString()) == 1)
                        sequentialDownload = true;
                    else
                        sequentialDownload = false;

                    if (int.Parse(key.GetValue("AddPause").ToString()) == 1)
                        addPause = true;
                    else
                        addPause = false;

                    key.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Unknown error occured when loading settings. Try again..."); }
        }

        public void SaveSettingsData(string _ffmpeg_location, string _output_location, bool _sequentialDownload, bool _addPause)
        {
            ffmpeg_location = _ffmpeg_location;
            output_location = _output_location;
            sequentialDownload = _sequentialDownload;
            addPause = _addPause;

            SaveSettings();
        }

        private void SaveSettings()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\DownloadMergerSettings");

                if (key != null)
                {
                    key.SetValue("ffmpeg_location", ffmpeg_location, RegistryValueKind.String);
                    key.SetValue("output_location", output_location, RegistryValueKind.String);

                    int tmpSequentialDownload = 0;
                    if (sequentialDownload)
                        tmpSequentialDownload = 1;
                    else
                        tmpSequentialDownload = 0;

                    int tmpAddPause = 0;
                    if (addPause)
                        tmpAddPause = 1;
                    else
                        tmpAddPause = 0;

                    key.SetValue("SaveType", tmpSequentialDownload);
                    key.SetValue("AddPause", tmpAddPause);

                    key.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Unknown error occured when saving settings. Try again..."); }
        }
    }
}
