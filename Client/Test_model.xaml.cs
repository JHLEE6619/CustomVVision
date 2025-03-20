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
using Client.Models;
using WindowsAPICodePack.Dialogs;

namespace Client
{
    /// <summary>
    /// Test_model.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Test_model : Page
    {
        public Test_model()
        {
            InitializeComponent();
        }

        private void btn_sel_image_Click(object sender, RoutedEventArgs e)
        {

            using CommonOpenFileDialog dialog = new()
            {
                IsFolderPicker = false,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TBlock_imageUri.Text = dialog.FileName;
                img_testImg.Source = new BitmapImage(new Uri(dialog.FileName));
            }


        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            Send_Message msg = new()
            {
                MsgId = (byte)_Client.MsgId.SEND_FILE
            };
        }
    }
}
