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
    /// Interaction logic for NewCourseForm.xaml
    /// </summary>
    public partial class NewCourseForm : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        List<CheckBox> listTimeActive;
        List<String> time = new List<String>();

        List<Staff> listTeacher;
        public NewCourseForm()
        {
            InitializeComponent();
            listTeacher = new TeacherBUS().getListAllTeachers();
            cb_Teacher.ItemsSource = listTeacher;
            CreateTimeTableGrid();
        }

        private void CreateTimeTableGrid()
        {
            List<String> day = new List<String>();
            day.Add("Thứ 2");
            day.Add("Thứ 3");
            day.Add("Thứ 4");
            day.Add("Thứ 5");
            day.Add("Thứ 6");
            day.Add("Thứ 7");
            day.Add("Chủ nhật");


            time.Add("7:30-9:00");
            time.Add("9:00-10:30");
            time.Add("13:30-15:00");
            time.Add("15:30-17:00");
            time.Add("17:30-18:30");
            time.Add("19:00-20:30");

            for (int i = 0; i <= time.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                grid_timetable.RowDefinitions.Add(row);
            }
            for (int i = 0; i <= day.Count; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                grid_timetable.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < day.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = day[i];
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i + 1);
                grid_timetable.Children.Add(tb);
            }

            for (int i = 0; i < time.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = time[i];
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, i + 1);
                Grid.SetColumn(tb, 0);
                grid_timetable.Children.Add(tb);
                Border bd = new Border();
                Grid.SetRow(bd, i + 1);
                Grid.SetColumn(bd, 0);
                Grid.SetColumnSpan(bd, 8);
                bd.VerticalAlignment = VerticalAlignment.Bottom;
                bd.BorderBrush = Brushes.Gray;
                bd.BorderThickness = new Thickness(0.5);
                bd.Margin = new Thickness(10, 0, 10, 0);
                grid_timetable.Children.Add(bd);
            }

            listTimeActive = new List<CheckBox>();

            for (int i = 0; i < time.Count; i++)
            {
                for (int j = 0; j < day.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = "Day"+(j+2)+"Time"+i;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    listTimeActive.Add(cb);
                    Grid.SetRow(cb, i + 1);
                    Grid.SetColumn(cb, j + 1);
                    grid_timetable.Children.Add(cb);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDay, finishDay;
            try
            {
                startDay = (DateTime)dp_startDay.SelectedDate;
                finishDay = (DateTime)dp_finishDay.SelectedDate;
                if (finishDay.CompareTo(startDay) <= 0)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thời gian nhập vào không hợp lệ");
                return;
            }
            Course course = new Course();
            course.StartDay = startDay.ToString();
            course.Id = 0;
            course.FinishDay = finishDay.ToString();
            course.Name = tb_Name.Text;
            course.Type = cb_Type.Text;
            Staff teacher = cb_Teacher.SelectedItem as Staff;
            if (teacher != null)
            {
                course.Teacher = teacher.Name;
            }
           
            course.DiscountInfo = tb_Description.Text;
            int number;
            if (!int.TryParse(tb_Number.Text,out number))
            {
                MessageBox.Show("Số lượng học sinh nhập không hợp lệ");
            }
            else
            {
                course.StudentNumber = int.Parse(tb_Number.Text);
            }
            int fee;
            if (!int.TryParse(tb_Fee.Text, out fee))
            {
                MessageBox.Show("Học phí nhập không hợp lệ");
            }
            else
            {
                course.Fee = int.Parse(tb_Fee.Text);
            }

            TimeTable timetable = new TimeTable();
            timetable.course = course;

            List<String> listTimeSelected = getSelectedTime(time);
            timetable.listTime = listTimeSelected;

            bool result = new CourseBUS().addNewCourse(timetable);
            if (!result)
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau.");
                return;
            }
            else
            {
                MessageBox.Show("Tạo khóa học thành công");
            }
            DataChangedEventHandler handler = DataChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private List<string> getSelectedTime(List<String> time)
        {
            List<String> result = new List<String>();


            foreach (CheckBox cb in listTimeActive)
            {
                if (cb.IsChecked == true)
                {
                    String dayTime;
                    String name = cb.Name;
                    String position;
                    String day = name.Substring(3, 1);
                    if (day.Equals("2"))
                    {
                        day = "Thứ 2";
                    }
                    if (day.Equals("3"))
                    {
                        day = "Thứ 3";
                    }
                    if (day.Equals("4"))
                    {
                        day = "Thứ 4";
                    }
                    if (day.Equals("5"))
                    {
                        day = "Thứ 5";
                    }
                    if (day.Equals("6"))
                    {
                        day = "Thứ 6";
                    }
                    if (day.Equals("7"))
                    {
                        day = "Thứ 7";
                    }
                    if (day.Equals("8"))
                    {
                        day = "Chủ nhật";
                    }
                    position = name.Substring(8, name.Length - 8);
                    dayTime = day +": "+ time[int.Parse(position)];
                    result.Add(dayTime);
                }
            }
            return result;
        }
    }
}
