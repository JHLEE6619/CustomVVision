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
            Request_modelListAsync();
            InitializeComponent();
            LV_modelList.ItemsSource = Main_Client.ModelList;
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
            }
        }

        private void btn_download_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task Request_modelListAsync()
        {
            Send_Message msg = new()
            {
                MsgId = (byte)Main_Client.MsgId.SHOW_MODEL_LIST,
                UserInfo = new() { UserId = Main_Client.UserId }
            };

            await Main_Client.Send_msgAsync(msg);
        }
    }
}
