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

namespace Client
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : Page
    {
        //Client clnt;
        // private readonly object thisLock = new();

        public Home()
        {
            InitializeComponent();
            Request_modelListAsync();
        }

        private void btn_create_model_Click(object sender, RoutedEventArgs e)
        {
            Create_model create_Model = new();
            this.NavigationService.Navigate(create_Model);
        }

        private void btn_test_model_Click(object sender, RoutedEventArgs e)
        {
            Request_modelListAsync();
            Main_Client.TestResult = "";
            Test_model_selection page = new();
            this.NavigationService.Navigate(page);
        }

        private void btn_download_model_Click(object sender, RoutedEventArgs e)
        {
            Request_modelListAsync();
            Download_model download_Model = new();
            this.NavigationService.Navigate(download_Model);
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
