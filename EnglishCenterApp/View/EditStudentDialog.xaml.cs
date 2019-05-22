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
    /// Interaction logic for SuaHocVienDialog.xaml
    /// </summary>
    public partial class EditStudentDialog : Window
    {
        private Student student;

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public EditStudentDialog()
        {
            InitializeComponent();
        }
        public EditStudentDialog(Student st)
        {
            InitializeComponent();
            student = st;
            //mTrinhDoBUS = new TrinhDoBUS();
            //mChuongTrinhBUS = new ChuongTrinhHocBUS();
            //mHocVienBUS = new HocVienBUS();
           
            initTextBoxes();
        }

        public void initTextBoxes()
        {
            tb_Name.Text = student.Name;
            tb_PhoneNum.Text = student.PhoneNum;
            tb_School.Text = student.School;
            tb_Email.Text = student.Email;
            datePicker_Birthday.SelectedDate = Convert.ToDateTime(student.Birthday);
            //if (hocVien.MPhai.Equals("Nam"))
            //    rb_nam.IsChecked = true;
            //else if (hocVien.MPhai.Equals("Nữ"))
            //    rb_nu.IsChecked = true;
            //else if (hocVien.MPhai.Equals("Khác"))
            //    rb_khac.IsChecked = true;
           
        }
    }
}
