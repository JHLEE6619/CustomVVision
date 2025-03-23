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
            InitializeComponent();
            LV_modelList.ItemsSource = Main_Client.ModelList;
        }

        private void Select_model(object sender, SelectionChangedEventArgs e)
        {
            if (LV_modelList.SelectedIndex == -1)
                return;
            int idx = LV_modelList.SelectedIndex;
            LV_modelList.SelectedItem = null;
            Test_model page = new(Main_Client.ModelList[idx]);
            Main_Client.test_model = page;
            this.NavigationService.Navigate(page);
        }
      
    }
}
