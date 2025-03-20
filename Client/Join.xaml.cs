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
    /// Join.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Join : Page
    {
        public Join()
        {
            InitializeComponent();
        }

        private void Btn_submit_click(object sender, RoutedEventArgs e)
        {
            JoinAsync(); // 회원가입 예외 처리 없음
            MessageBox.Show("회원가입 성공");
            Login login = new();
            this.NavigationService.Navigate(login);
        }

        private async Task JoinAsync()
        {
            User user = new()
            {
                UserId = TBox_userId.Text,
                Pw = TBox_pw.Text,
                UserName = TBox_userName.Text
            };

            Send_Message msg = new()
            {
                MsgId = (byte)_Client.MsgId.JOIN,
                UserInfo = user
            };

            await _Client.Send_msgAsync(msg);
        }
    }
}
