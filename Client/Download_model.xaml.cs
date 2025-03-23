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
    /// Download_model.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Download_model : Page
    {
        public Download_model()
        {
            InitializeComponent();
            LV_modelList.ItemsSource = Main_Client.ModelList;
            Main_Client.FilePath = TBlock_dir.Text;
        }

        private void btn_dir_sel_Click(object sender, RoutedEventArgs e)
        {
            using CommonOpenFileDialog dialog = new()
            {
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TBlock_dir.Text = dialog.FileName;
                Main_Client.FilePath = dialog.FileName;
            }


        }

        private async void btn_download_ClickAsync(object sender, RoutedEventArgs e)
        {
            int idx = LV_modelList.SelectedIndex;
            Send_Message msg = new()
            {
                MsgId = (byte)Main_Client.MsgId.DOWNLOAD_MODEL,
                ModelInfo = new() { ModelId = Main_Client.ModelList[idx] }
            };
            await Main_Client.Send_msgAsync(msg);
        }
    }
}
