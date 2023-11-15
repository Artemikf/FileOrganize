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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FP_GWL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCross_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void btnCollapse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton is MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void btnOpenBrows_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            switch (clickedButton.Name)
            {
                case "btnGitProf":
                    OpenLinkBrows("https://github.com/Artemikf");
                    break;
                case "btnInst":
                    OpenLinkBrows("https://www.instagram.com/tema_3345/");
                    break;
                case "btnGitProj":
                    OpenLinkBrows("https://github.com/Artemikf/FileOrganize");
                    break;
                default:
                    break;
            }
        }
        private void OpenLinkBrows(string url)
        {
            try
            {
                System.Diagnostics.Process.Start("cmd", $"/c start {url}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
