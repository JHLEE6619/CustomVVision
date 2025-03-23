using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class LabelItem : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Create_model.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Create_model : Page
    {
        public ObservableCollection<LabelItem> Labels { get; set; } = [];

        public Create_model()
        {
            InitializeComponent();
            DataContext = this;
            addLabel();
        }

        private void btn_addLabel_Click(object sender, RoutedEventArgs e)
        {
            addLabel();
        }

        private void addLabel()
        {
            Labels.Add(new LabelItem() { Name ="새 레이블" });
        }

        private void btn_removeLabel_Click(object sender, RoutedEventArgs e)
        {
            int idx = LV_image.SelectedIndex;
            Labels.RemoveAt(idx);
        }

        private async void btn_createModel_ClickAsync(object sender, RoutedEventArgs e)
        {
            Model model = new()
            {
                ModelId = TBox_modelId.Text,
                Classification = (bool)radio_binary.IsChecked ? false : true,
                Epoch = byte.Parse(TBox_epoch.Text),
                ColorType = (bool)radio_color.IsChecked ? (byte)3 : (byte)1,
                ImageWidth = uint.Parse(TBox_width.Text),
                ImageHeight = uint.Parse(TBox_height.Text)
            };

            List<string> labelList = [];
            foreach(var label in Labels)
            {
                labelList.Add(label.Name);
            }


            Send_Message msg = new()
            {
                MsgId = (byte)Main_Client.MsgId.CREATE_MODEL,
                UserInfo = new() { UserId = Main_Client.UserId },
                ModelInfo = model,
                Labels = labelList
            };

            await Main_Client.Send_msgAsync(msg);
        }

        private void btn_fileSeletion_Click(object sender, RoutedEventArgs e)
        {
            using CommonOpenFileDialog dialog = new()
            {
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //TBlock_imgUri.Text = dialog.FileName;
            }
        }
    }
}
