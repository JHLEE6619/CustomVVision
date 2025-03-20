using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Create_model.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Create_model : Page
    {
        ObservableCollection<Models.Image> images = [];

        public Create_model()
        {
            InitializeComponent();
            addLabel();
            LV_image.ItemsSource = images;
        }

        private void btn_addLabel_Click(object sender, RoutedEventArgs e)
        {
            addLabel();
        }

        private void addLabel()
        {
            Models.Image image = new();
            images.Add(image);
        }

        private void btn_removeLabel_Click(object sender, RoutedEventArgs e)
        {
            int idx = LV_image.SelectedIndex;
            images.RemoveAt(idx);
        }

        private void btn_createModel_Click(object sender, RoutedEventArgs e)
        {
            Model model = new()
            {
                ModelId = TBox_modelId.Text,
                Classification = (bool)radio_binary.IsChecked ? false : true,
                Epoch = byte.Parse(TBox_epoch.Text),
                ColorType = (bool)radio_color.IsChecked ? (byte)1 : (byte)3,
                ImageWidth = uint.Parse(TBox_width.Text),
                ImageHeight = uint.Parse(TBox_height.Text)
            };


            Send_Message msg = new()
            {
                MsgId = (byte)Client.MsgId.CREATE_MODEL,
                UserInfo = new() { UserId = Client.UserId },
                ModelInfo = model,
                ImageInfo = images.ToList(),
            };
        }
    }
}
