﻿using System;
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
using System.Text.RegularExpressions;

namespace EnglishCenterApp.View
{
    /// <summary>
    /// Interaction logic for MainWindowGUI.xaml
    /// </summary>
    public partial class ReceptionistWindow : Window
    {
        public static List<Student> listAllStudent;
        public static List<Student> listFilterStudent;

        public ReceptionistWindow()
        {
            InitializeComponent();

            listAllStudent = new StudentBUS().getAllStudent();
            tb_numberOfNewStudent.Text = listAllStudent.Count.ToString();
            tb_home_NumberOfStudent.Text = listAllStudent.Count.ToString();
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

        private void btn_filterStudent_Click(object sender, RoutedEventArgs e)
        {
            listFilterStudent = new List<Student>();
            if (tb_filterStudent_studentId.Text != ""&& tb_filterStudent_studentName.Text.Equals(""))
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
            else if (tb_filterStudent_studentName.Text != ""&& tb_filterStudent_studentId.Text.Equals(""))
            {
                for(int i=0;i<listAllStudent.Count;i++)
                {
                    if (listAllStudent[i].Name.Contains(tb_filterStudent_studentName.Text.ToString()))
                    {
                        listFilterStudent.Add(listAllStudent[i]);
                    }
                }

                lv_listStudent.ItemsSource = listFilterStudent;
            }
            else if (tb_filterStudent_studentName.Text != "" && tb_filterStudent_studentId.Text!="")
            {
                for (int i = 0; i < listAllStudent.Count; i++)
                {
                    if (listAllStudent[i].Name.Contains(tb_filterStudent_studentName.Text.ToString())&&(listAllStudent[i].Id+"").Contains(tb_filterStudent_studentId.Text))
                    {
                        listFilterStudent.Add(listAllStudent[i]);
                    }
                    lv_listStudent.ItemsSource = listFilterStudent;
                }
            }
               
            //    else
            //    {
            //        foreach (HocVien hv in listAllStudent)
            //        {
            //            if ((Regex.IsMatch(ConvertToUnSign(hv.MTenHocVien), ConvertToUnSign(tb_filterHV_ten.Text), RegexOptions.IgnoreCase))
            //            && (hv.MSdt.Contains(tb_filterHV_sdt.Text))
            //            && (Regex.IsMatch(hv.MEmail, tb_filterHV_email.Text)))
            //            {
            //                listFilterHv.Add(new HocVien_Lop(hv, lopBus.getLopMoiNhatByMaHV(hv.MMaHocVien)));
            //            }
            //        }

            //        if (tb_filterHV_ten.Text != "" || tb_filterHV_sdt.Text != "" || tb_filterHV_email.Text != "")
            //            lv_dsHocVien.ItemsSource = listFilterHv;
            //        else
            //            lv_dsHocVien.ItemsSource = listHvDangHocWLop;
            //    }

            //}
            ////else
            ////{
            //    List<HocVien> listFilter = new List<HocVien>();
            //    if (tb_filterHV_maHv.Text != "")
            //    {
            //        foreach (HocVien hv in listFilterHv)
            //        {
            //            if (hv.HocVien.MMaHocVien.Contains(tb_filterHV_maHv.Text))
            //                listFilter.Add(hv);
            //        }
            //        lv_dsHocVien.ItemsSource = listFilter;
            //    }
            //    else
            //    {
            //        foreach (HocVien_Lop hv in listFilterHv)
            //        {
            //            if ((Regex.IsMatch(ConvertToUnSign(hv.HocVien.MTenHocVien), ConvertToUnSign(tb_filterHV_ten.Text), RegexOptions.IgnoreCase))
            //                && (hv.HocVien.MSdt.Contains(tb_filterHV_sdt.Text))
            //                && (Regex.IsMatch(hv.HocVien.MEmail, tb_filterHV_email.Text)))
            //            {
            //                listFilter.Add(hv);
            //            }

            //            if (tb_filterHV_ten.Text != "" || tb_filterHV_sdt.Text != "" || tb_filterHV_email.Text != "")
            //                lv_dsHocVien.ItemsSource = listFilter;
            //            else
            //                lv_dsHocVien.ItemsSource = listFilterHv;
            //        }
            //    }
            //}
        }
    }
}
