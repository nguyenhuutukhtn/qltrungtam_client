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

namespace EnglishCenterApp.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public ManagerWindow mainWindow = new ManagerWindow();
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không đúng.");
                return;
            }
            if (tbPass.Password == "")
            {
                MessageBox.Show("Mật khẩu không đúng.");
                return;
            }
            else
            {
                mainWindow.Show();
                this.Close();
            }
            
            

        }
    }
}
