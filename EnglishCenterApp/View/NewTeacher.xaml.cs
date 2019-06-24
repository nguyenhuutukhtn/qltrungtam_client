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
using System.Windows.Shapes;
using DTO;
namespace EnglishCenterApp.View
{
    /// <summary>
    /// Interaction logic for NewTeacher.xaml
    /// </summary>
    public partial class NewTeacher : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public NewTeacher()
        {
            InitializeComponent();
        }
        public NewTeacher(Staff teacher)
        {
            InitializeComponent();
            TenGV_tb.Text = teacher.Name;
            DiaChi_tb.Text = teacher.Address;
            SoDT_tb.Text = teacher.PhoneNum;
            tb_header.Text = "Sửa thông tin giảng viên";
            grid_headerBackground.Background = new SolidColorBrush(Color.FromRgb(239, 163, 0));
            
        }
        private void bt_exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sửa thành công");
            this.Close();
        }
    }
}
