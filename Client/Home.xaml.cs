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
            //clnt.ConnectServer();
            //clnt.Send_msgAsync(Login(Client.UserId));

        }


        //private Send_Message Login(string userId)
        //{
        //    Send_Message msg = new() { MsgId = (byte)Client.MsgId.LOGIN, UserId = userId };
        //    return msg;
        //}


        private void btn_create_model_Click(object sender, RoutedEventArgs e)
        {
            Create_model create_Model = new();
            this.NavigationService.Navigate(create_Model);
        }

        private void btn_test_model_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_download_model_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
