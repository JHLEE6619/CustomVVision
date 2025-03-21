using System;
using System.Collections.Generic;
using System.IO;
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

        public Test_model(string modelId)
        {
            InitializeComponent();
            TBlock_modelId.Text = modelId;
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

        private async void btn_test_ClickAsync(object sender, RoutedEventArgs e)
        {
            byte[]? TestImg = Read_testImg(TBlock_imageUri.Text);
            if (TestImg != null)
            {
                Send_Message msg = new()
                {
                    MsgId = (byte)Main_Client.MsgId.TEST_MODEL,
                    ModelInfo = new() { ModelId = TBlock_modelId.Text },
                    TestImage = TestImg
                };
                await Main_Client.Send_msgAsync(msg);
            }
            else
            {
                MessageBox.Show("파일이 없습니다.");
            }
        }

        private byte[]? Read_testImg(string imgDir)
        {
            // FileInfo 생성
            var file = new FileInfo(imgDir);
            // 파일이 존재하는지
            if (file.Exists)
            {
                // 바이너리 버퍼
                byte[] binary = new byte[file.Length];
                // 파일 IO 생성
                using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    // 파일을 IO로 읽어온다.
                    stream.Read(binary, 0, binary.Length);
                }
                return binary;
            }
            else
                return null;
        }
    }
}
