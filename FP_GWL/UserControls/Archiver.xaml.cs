using Gwl.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FP_GWL.UserControls
{
    public partial class Archiver : UserControl
    {
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private Finder finder;

        private string[] fileMasks;
        
        private List<string> selectedFileMasks = new List<string>();
        private readonly Dictionary<string, string> checkBoxMappings = new Dictionary<string, string>
        {
            { "cbxJpg", "*.jpg" },
            { "cbxJpeg", "*.jpeg" },
            { "cbxPng", "*.png" },
            { "cbxGif", "*.gif" },
            { "cbxDoc", "*.doc" },
            { "cbxaDocx", "*.docx" },
            { "cbxXls", "*.xls" },
            { "cbxXlsx", "*.xlsx" },
            { "cbxPpt", "*.ppt" },
            { "cbxPptx", "*.pptx" },
            { "cbxPdf", "*.pdf" },
            { "cbxTxt", "*.txt" },
            { "cbxMp3", "*.mp3" },
            { "cbxWav", "*.wav" },
            { "cbxMp4", "*.mp4" },
            { "cbxAvi", "*.avi" },
            { "cbxRar", "*.rar" },
            { "cbxZip", "*.zip" },
            { "cbxIso", "*.iso" },
            { "cbxHtmp", "*.html" },
            { "cbxPsd", "*.psd" },
            { "cbxTorrent", "*.torrent" },
            { "cbxCpp", "*.cpp" },
            { "cbxCs", "*.cs" },
            { "cbxExe", "*.exe" },
            { "cbxTmp", "*.tmp" },
            { "cbxLog", "*.log" },
            { "cbxJson", "*.json" }
        };

        public Archiver()
        {
            InitializeComponent();

            fbd = new System.Windows.Forms.FolderBrowserDialog();

            finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> selectedMasks = new List<string>();

            foreach (var mapping in checkBoxMappings)
            {
                CheckBox checkBox = FindName(mapping.Key) as CheckBox;

                if (checkBox != null && checkBox.IsChecked == true)
                    selectedMasks.Add(mapping.Value);
            }

            fileMasks = selectedMasks.ToArray();
        }

        private void openDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                finder.FindFilesByMask(fbd.SelectedPath, fileMasks);
            }
        }
    }
}
