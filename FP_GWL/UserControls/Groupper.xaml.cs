using Gwl.FilesGroupper;
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
    public partial class Groupper : UserControl
    {
        private readonly System.Windows.Forms.FolderBrowserDialog fbd;
        private readonly Finder finder;

        private string[]? fileMasks;

        private readonly List<string> selectedFileMasks = new List<string>(); // readonly
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
        private readonly List<string> foundFiles = new List<string>(); // readonly

        private readonly IGroupper groupper;
        
        public Groupper(IGroupper groupper)
        {
            InitializeComponent();

            fbd = new System.Windows.Forms.FolderBrowserDialog();

            finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);

            this.groupper = groupper;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            fileMasks = null;

            foundFiles.Clear();
            listBoxFiles.ItemsSource = null;

            List<string> selectedMasks = new List<string>();

            foreach (var mapping in checkBoxMappings)
            {
                CheckBox? checkBox = FindName(mapping.Key) as CheckBox;

                if (checkBox != null && checkBox.IsChecked == true)
                    selectedMasks.Add(mapping.Value);
            }

            fileMasks = selectedMasks.ToArray();
        }

        private void UpdateFileList()
        {
            foundFiles.Clear();

            foreach (var fileInfo in finder.Container.Files)
            {
                foundFiles.Add(fileInfo.FullName);
            }
            listBoxFiles.ItemsSource = foundFiles;
        }

        private void openDirectory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foundFiles.Clear();

                    finder.FindFilesByMask(fbd.SelectedPath, fileMasks);

                    UpdateFileList();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!\nВыберете сначала расширения файлов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearListbox_Click(object sender, RoutedEventArgs e)
        {
            clearMainWindow();
        }

        private void GroupperByMonthCreate_Click(object sender, RoutedEventArgs e)
        {
            if (fileMasks != null && !string.IsNullOrEmpty(fbd.SelectedPath))
            {
                groupper.GroupFilesByMonthYearCreate(fbd.SelectedPath, fileMasks);
                clearMainWindow();
                MessageBox.Show("Все успешно сгрупированно!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Укажите директорию и выберите расширения файлов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupperByYearCreate_Click(object sender, RoutedEventArgs e)
        {
            if (fileMasks != null && !string.IsNullOrEmpty(fbd.SelectedPath))
            {
                groupper.GroupFilesByYearCreate(fbd.SelectedPath, fileMasks);
                clearMainWindow();
                MessageBox.Show("Все успешно сгрупированно!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Укажите директорию и выберите расширения файлов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupperByMonthEdit_Click(object sender, RoutedEventArgs e)
        {
            if (fileMasks != null && !string.IsNullOrEmpty(fbd.SelectedPath))
            {
                groupper.GroupFilesByMonthYearEdit(fbd.SelectedPath, fileMasks);
                clearMainWindow();
                MessageBox.Show("Все успешно сгрупированно!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Укажите директорию и выберите расширения файлов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupperByYearEdit_Click(object sender, RoutedEventArgs e)
        {
            if (fileMasks != null && !string.IsNullOrEmpty(fbd.SelectedPath))
            {
                groupper.GroupFilesByYearEdit(fbd.SelectedPath, fileMasks);
                clearMainWindow();
                MessageBox.Show("Все успешно сгрупированно!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Укажите директорию и выберите расширения файлов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearMainWindow()
        {
            foreach (var checkBox in checkBoxMappings.Keys)
            {
                CheckBox? cb = FindName(checkBox) as CheckBox;
                if (cb != null)
                {
                    cb.IsChecked = false;
                }
            }

            fileMasks = null;

            foundFiles.Clear();

            listBoxFiles.ItemsSource = null;
        }
    }
}
