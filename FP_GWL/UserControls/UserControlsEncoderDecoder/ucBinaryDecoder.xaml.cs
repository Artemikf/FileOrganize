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

namespace FP_GWL.UserControls.UserControlsEncoderDecoder
{
    public partial class ucBinaryDecoder : UserControl
    {
        private EncDec? parent;

        public ucBinaryDecoder(EncDec parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                parent.ContentControlEncDec.Content = new EncDec();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
    }
}
