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
    /// Test_model_selection.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Test_model_selection : Page
    {
        
        public Test_model_selection()
        {
            Request_modelListAsync();
            InitializeComponent();
            LV_modelList.ItemsSource = Main_Client.ModelList;
        }

        private void Select_model(object sender, SelectionChangedEventArgs e)
        {
            if (LV_modelList.SelectedIndex == -1)
                return;
            int idx = LV_modelList.SelectedIndex;
            LV_modelList.SelectedItem = null;
            Test_model model = new(Main_Client.ModelList[idx]);
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
