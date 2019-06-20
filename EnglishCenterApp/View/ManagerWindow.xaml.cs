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
using System.Globalization;

namespace EnglishCenterApp.View
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public static List<Student> listAllStudent;
        public static List<Student> listFilterStudent;
        public static List<Course> listOpeningCourse;
        public static List<Course> listAllCourse;

        private DateTime currentDate;
        private List<String> listTime = new List<String>();
        public ManagerWindow()
        {
            InitializeComponent();
            listAllStudent = new StudentBUS().getAllStudent();
            tb_numberOfNewStudent.Text = listAllStudent.Count.ToString();
            tb_home_NumberOfStudent.Text = listAllStudent.Count.ToString();
            updateListAllCourse();
            updateOpeningCourse();

            currentDate = DateTime.Today;
            initTimeTable();
            fillTimetable();
        }

        private void initTimeTable()
        {
            listTime.Add("7:30-9:00");
            listTime.Add("9:00-10:30");
            listTime.Add("13:30-15:00");
            listTime.Add("15:30-17:00");
            listTime.Add("17:30-18:30");
            listTime.Add("19:00-20:30");

            grid_TimeTable.RowDefinitions.Add(new RowDefinition());
            foreach(String time in listTime)
            {
                grid_TimeTable.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 8; i++)
            {
                grid_TimeTable.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void fillTimetable()
        {
            grid_TimeTable.Children.Clear();
            
           

            for (int i = 0; i < listTime.Count; i++)
            {
                TextBlock tbTime = new TextBlock();
                tbTime.Text = listTime[i].ToString();
                tbTime.Foreground = Brushes.Black;
                tbTime.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                tbTime.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                tbTime.FontSize = 15;
                tbTime.TextAlignment = TextAlignment.Center;
                tbTime.Padding = new Thickness(5, 0, 5, 0);
                tbTime.Background = new SolidColorBrush(Color.FromRgb(226, 224, 224));
                Grid.SetColumn(tbTime,i);
                Grid.SetRow(tbTime, 0);
                grid_TimeTable.Children.Add(tbTime);
            }

            String today = currentDate.ToString("dddd", new CultureInfo("en-US"));
            tb_currentDate.Text = today + ", " + currentDate.ToShortDateString();
        }

        private void updateListAllCourse()
        {
            listAllCourse = new CourseBUS().getListAllCourse();
            lv_tabCourse_listCourse.ItemsSource = listAllCourse;
    
        }

        private void updateOpeningCourse()
        {
            
        }

        private void btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NewStudentForm studentForm = new NewStudentForm();
            studentForm.DataChanged += AddStudent_DataChanged; //Update danh sách học viên sau khi bấm lưu
            studentForm.ShowDialog();
        }


        private void AddStudent_DataChanged(object sender, EventArgs e)
        {
            updateListStudent();
            //upDateListHvNoHP();
        }

        private void updateListStudent()
        {
            listAllStudent = new StudentBUS().getAllStudent();
            lv_listStudent.ItemsSource = listAllStudent;
            tb_numberOfNewStudent.Text = listAllStudent.Count.ToString();
            tb_home_NumberOfStudent.Text = listAllStudent.Count.ToString();
        }

        private void btn_ShowAllStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentBUS hv = new StudentBUS();
            listAllStudent = new StudentBUS().getAllStudent();
            lv_listStudent.ItemsSource = listAllStudent;
        }
        private void btn_ShowStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            popup_StudentDetail.IsOpen = false;
            Button button = sender as Button;
            Student student = button.DataContext as Student;

            tb_popup_studentName.Text = student.Name;
            tb_popup_studentGender.Text = student.Gender;
            tb_popup_studentBirthDay.Text = student.Birthday;
            tb_popup_studentEmail.Text = student.Email;
            tb_popup_studentPhoneNum.Text = student.PhoneNum;
            tb_popup_studentSchool.Text = student.School;
            if (student.Grade != null)
                tb_popup_studentGrade.Text = student.Grade + "";
            else
                tb_popup_studentGrade.Text = "";
            tb_popup_studentId.Text = student.Id + "";
            tb_popup_studentParentName.Text = student.ParentName;
            tb_popup_studentParentPhoneNum.Text = student.ParentPhoneNum;
            popup_StudentDetail.IsOpen = true;

        }

        private void btn_editStudent_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Student student = button.DataContext as Student;
            EditStudentDialog editDialog = new EditStudentDialog(student);
            editDialog.DataChanged += AddStudent_DataChanged;
            editDialog.ShowDialog();
        }

        private void btn_JumpToStudentTab_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btn_AddCourse_Click(object sender, RoutedEventArgs e)
        {
            NewCourseForm courseForm = new NewCourseForm();
            courseForm.DataChanged += AddCourse_DataChanged;
            courseForm.ShowDialog();
        }

        private void AddCourse_DataChanged(object sender, EventArgs e)
        {
            updateListAllCourse();
            updateOpeningCourse();
        }

        private void btn_filterStudent_Click(object sender, RoutedEventArgs e)
        {
            listFilterStudent = new List<Student>();
            if (tb_filterStudent_studentId.Text != "" && tb_filterStudent_studentName.Text.Equals(""))
            {
                if (tb_filterStudent_studentId.Text != "")
                {

                    foreach (Student st in listAllStudent)
                    {
                        if ((st.Id + "").Contains(tb_filterStudent_studentId.Text))
                        {
                            listFilterStudent.Add(st);
                        }
                    }

                    lv_listStudent.ItemsSource = listFilterStudent;
                }
            }
            else if (tb_filterStudent_studentName.Text != "" && tb_filterStudent_studentId.Text.Equals(""))
            {
                for (int i = 0; i < listAllStudent.Count; i++)
                {
                    if (listAllStudent[i].Name.Contains(tb_filterStudent_studentName.Text.ToString()))
                    {
                        listFilterStudent.Add(listAllStudent[i]);
                    }
                }

                lv_listStudent.ItemsSource = listFilterStudent;
            }
            else if (tb_filterStudent_studentName.Text != "" && tb_filterStudent_studentId.Text != "")
            {
                for (int i = 0; i < listAllStudent.Count; i++)
                {
                    if (listAllStudent[i].Name.Contains(tb_filterStudent_studentName.Text.ToString()) && (listAllStudent[i].Id + "").Contains(tb_filterStudent_studentId.Text))
                    {
                        listFilterStudent.Add(listAllStudent[i]);
                    }
                    lv_listStudent.ItemsSource = listFilterStudent;
                }
            }

           
        }
    }
}
