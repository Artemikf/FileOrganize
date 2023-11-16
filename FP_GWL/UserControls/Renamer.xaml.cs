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
using Gwl.Search;
using FP_GWL.UserControls;

namespace FP_GWL.UserControls
{
    public partial class  Renamer: UserControl
    {
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private Finder finder;
        private readonly string[] fileMasks =
        {
            "*.jpg",
            "*.jpeg",
            "*.png",
            "*.gif"
        };


        public Renamer()
        {
            InitializeComponent();

            fbd = new System.Windows.Forms.FolderBrowserDialog();

            finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
        }

        private void openDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show(fbd.SelectedPath);
                t1.Text = fbd.SelectedPath;
                finder.FindFilesByMask(fbd.SelectedPath, fileMasks);
            }

        }
    }
}
