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
using BUS;

namespace EnglishCenterApp.View
{
    /// <summary>
    /// Interaction logic for SuaHocVienDialog.xaml
    /// </summary>
    public partial class EditStudentDialog : Window
    {
        private Student student;
        private RadioButton genderRadioButton;
        StudentBUS mStudentBUS;

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public EditStudentDialog()
        {
            InitializeComponent();
            mStudentBUS = new StudentBUS();
        }
        public EditStudentDialog(Student st)
        {
            mStudentBUS = new StudentBUS();
            InitializeComponent();
            student = st;
           
            initTextBoxes();
        }

        public void initTextBoxes()
        {
            tb_Name.Text = student.Name;
            tb_PhoneNum.Text = student.PhoneNum;
            tb_School.Text = student.School;
            tb_Email.Text = student.Email;
            datePicker_Birthday.SelectedDate = Convert.ToDateTime(student.Birthday);
            tb_ParentName.Text = student.ParentName;
            tb_ParentPhoneNum.Text = student.ParentPhoneNum;
            if (student.Gender.Equals("Nam"))
            {
                rb_Female.IsChecked = true;
                rb_Male.IsChecked = false;
            }
            else if (student.Gender.Equals("Nam"))
            {
                rb_Male.IsChecked = true;
                rb_Female.IsChecked = false;
            }
            cb_Grade.Text = student.Grade + "";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            genderRadioButton = (RadioButton)sender;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            String name = tb_Name.Text;
            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập tên học viên.", "Thông báo");
                return;
            }
            DateTime? birthday = datePicker_Birthday.SelectedDate;
            if (birthday == null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.", "Thông báo");
                return;
            }
           
            String gender = genderRadioButton.Content.ToString();
            String school = tb_School.Text;
            String phoneNum = tb_PhoneNum.Text;
            int grade;
            if (int.TryParse(cb_Grade.Text, out grade))
            {
                grade = int.Parse(cb_Grade.Text);
            }
            String email = tb_Email.Text;
            String parentName = tb_ParentName.Text;
            String parentPhoneNum = tb_ParentPhoneNum.Text;




            Student st = new Student(student.Id,name,birthday.ToString(),grade,gender,phoneNum,email,school,parentName,parentPhoneNum);

            if (!mStudentBUS.updateStudent(st))
            {
                MessageBox.Show("Cập nhật thông tin học viên thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Thông tin học viên đã được lưu lại", "Trung tâm Tú đẹp trai");

            }

            //notify change
            DataChangedEventHandler handler = DataChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
