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
    /// Interaction logic for MainWindowGUI.xaml
    /// </summary>
    public partial class MainWindowGUI : Window
    {
        public MainWindowGUI()
        {
            InitializeComponent();
        }
        private void btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NewStudentForm studentForm = new NewStudentForm();
            studentForm.DataChanged += ThemHocVien_DataChanged; //Update danh sách học viên sau khi bấm lưu
            studentForm.ShowDialog();
        }


        private void ThemHocVien_DataChanged(object sender, EventArgs e)
        {
            //updateListHocVien();
            //upDateListHvNoHP();
        }
    }
}
