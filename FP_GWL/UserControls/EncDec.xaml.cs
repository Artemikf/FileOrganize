using FP_GWL.UserControls.UserControlsEncoderDecoder;
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
    public partial class EncDec : UserControl
    {
        public EncDec()
        {
            InitializeComponent();
        }

        private void btnBinaryEnDe_Click(object sender, RoutedEventArgs e)
        {
            ContentControlEncDec.Content = null;

            if (sender == btnBinaryEn)
            {
                ContentControlEncDec.Content = new ucBinaryEncoder(this); 
            }
            else if (sender == btnBinaryDe)
            {
                ContentControlEncDec.Content = new ucBinaryDecoder(this);
            }


        }
    }
}
