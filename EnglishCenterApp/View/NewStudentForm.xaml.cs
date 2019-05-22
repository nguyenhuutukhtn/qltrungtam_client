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
    /// Interaction logic for NewStudentForm.xaml
    /// </summary>
    public partial class NewStudentForm : Window
    {
        RadioButton genderRadioButton;

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        StudentBUS mStudentBUS;

        public NewStudentForm()
        {
            InitializeComponent();
            mStudentBUS = new StudentBUS();

            //Show current date
            tb_date.Text = DateTime.Today.ToShortDateString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            genderRadioButton = (RadioButton)sender;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            String name = tb_Name.Text;
            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập tên học viên.");
                return;
            }
            DateTime? birthday = Birthday_dp.SelectedDate;
            if (birthday == null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.");
                return;
            }
            if (genderRadioButton == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }
            String gender = genderRadioButton.Content.ToString();
            //String address = tb_Address.Text;
            //if (diaChi == "")
            //{
            //    MessageBox.Show("Vui lòng điền địa chỉ");
            //    return;
            //}

            String phoneNum = tb_PhoneNum.Text;
            //if (!Regex.Match(soDT, @"^(\d[0-9]{9,11})$").Success)
            if (phoneNum == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại", "Thông báo");
                return;
            }


            String email = Email_tb.Text;
            String school = tb_School.Text;
            int grade;
            if (int.TryParse(cb_Grade.Text,out grade))
            {
                grade = int.Parse(cb_Grade.Text);
            }
            String parentPhoneNum = tb_ParentPhoneNum.Text;
            String parentName = tb_ParentName.Text;

            Student st = new Student(0, name, birthday.ToString(), grade, gender, phoneNum, email, school, parentName, parentPhoneNum);

            if (!mStudentBUS.insertNewStudent(st))
            {
                MessageBox.Show("Thêm học viên thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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

            //#endregion

            //#region SaveThoiGianRanh
            //List<CheckBox> listChecked = mListThoiGianRanh.FindAll(i => i.IsChecked == true);

            //for (int i = 0; i < listChecked.Count; i++)
            //{
            //    String thuCa = listChecked[i].Name;
            //    ThoiGianRanh temp = new ThoiGianRanh(hv.MMaHocVien, thuCa.Substring(0, thuCa.IndexOf('_')), thuCa.Substring(thuCa.IndexOf('_') + 1));
            //    if (!mThoiGianRanhBUS.insertThoiGianRanh(temp))
            //    {
            //        MessageBox.Show("Insert Thoi Gian Ranh Failed.");
            //    }
            //}
            //#endregion

            //MessageBox.Show("Tiếp nhận học viên thành công", "New Age English");

            //#region Save ChiTietThiXepLop
            //if (mChiTietThiXL != null)
            //{
            //    mChiTietThiXL.MMaHocVien = hv.MMaHocVien;
            //    mChiTietThiXL.MChuongTrinhMongMuon = hv.MMaChuongTrinhMuonHoc;
            //    if (!(new ChiTietThiXepLopBUS().insertChiTietThiXepLop(mChiTietThiXL)))
            //        MessageBox.Show("Xếp lịch thi không thành công!", "Thông báo");
            //    else
            //        MessageBox.Show("Xếp lịch thi thành công", "Thông báo");
            //}
            //#endregion

            //#region Save ChiTietLopHoc
            //if (mChiTietLop != null)
            //{
            //    mChiTietLop.MMaHocVien = hv.MMaHocVien;
            //    mChiTietLop.MTinhTrangDongHocPhi = 0;
            //    mChiTietLop.MSoTienNo = new LopHocBUS().selectLopHoc(mChiTietLop.MMaLopHoc).MSoTien;
            //    if (!(new ChiTietLopHocBUS().insertChiTietLopHoc(mChiTietLop)))
            //        MessageBox.Show("Xếp lớp không thành công!", "Thông báo");
            //    else
            //        MessageBox.Show("Đã thêm học viên vào lớp " + mChiTietLop.MMaLopHoc, "Thông báo");
            //}
            //#endregion

            //if (!mHocVienBUS.insertHocVienNgayTiepNhan(hv, DateTime.Now))
            //    MessageBox.Show("Ghi nhận ngày lập phiếu thất bại!", "Thông báo");

            //resetComponent();

            ////Notify changes
            //DataChangedEventHandler handler = DataChanged;
            //if (handler != null)
            //{
            //    handler(this, new EventArgs());
            //}

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ChooseCourse_Click(object sender, RoutedEventArgs e)
        {
            //popup_xepLichThi.IsOpen = false;
            //popup_xepLop.IsOpen = true;

            //ThoiGianHocBUS thoiGianHocBus = new ThoiGianHocBUS();
            //if (mListLopDangMo == null)
            //{
            //    mListLopDangMo = new List<Lop_ThoiGianHoc>();
            //    foreach (LopHoc lop in MainWindow.listLopDangMo)
            //    {
            //        mListLopDangMo.Add(new Lop_ThoiGianHoc(lop, thoiGianHocBus.getThoiGianHocCuaLop(lop.MMaLop)));
            //    }
            //}

            //mListLopThoiGian = new List<Lop_ThoiGianHoc>();
            //List<CheckBox> listChecked = mListThoiGianRanh.FindAll(i => i.IsChecked == true);
            //List<Lop_ThoiGianHoc> listLopDungCTH = new List<Lop_ThoiGianHoc>();
            //foreach (Lop_ThoiGianHoc lop in mListLopDangMo)
            //{
            //    if (CTMuonHoc_cb.Text != "")
            //    {
            //        String maCTMuonHoc = mChuongTrinhBUS.getMaCTFromTenCT(CTMuonHoc_cb.SelectedValue.ToString());
            //        if (lop.LopHoc.MMaCTHoc.Equals(maCTMuonHoc))
            //        {
            //            listLopDungCTH.Add(lop);
            //            String thuCa;
            //            String thu;
            //            String ca;
            //            for (int i = 0; i < listChecked.Count; i++)
            //            {
            //                thuCa = listChecked[i].Name;
            //                thu = thuCa.Substring(0, thuCa.IndexOf('_'));
            //                ca = thuCa.Substring(thuCa.IndexOf('_') + 1);
            //                foreach (ThoiGianHoc tgh in lop.ListThoiGianHoc)
            //                {
            //                    if (tgh.MMaCa.Equals(ca) && tgh.MMaThu.Equals(thu))
            //                        lop.SoCaDungYeuCau++;
            //                }
            //            }
            //            if (lop.SoCaDungYeuCau > 0)
            //                mListLopThoiGian.Add(lop);
            //        }
            //    }
            //    else
            //    {
            //        String thuCa;
            //        String thu;
            //        String ca;
            //        for (int i = 0; i < listChecked.Count; i++)
            //        {
            //            thuCa = listChecked[i].Name;
            //            thu = thuCa.Substring(0, thuCa.IndexOf('_'));
            //            ca = thuCa.Substring(thuCa.IndexOf('_') + 1);
            //            foreach (ThoiGianHoc tgh in lop.ListThoiGianHoc)
            //            {
            //                if (tgh.MMaCa.Equals(ca) && tgh.MMaThu.Equals(thu))
            //                    lop.SoCaDungYeuCau++;
            //            }
            //        }
            //        if (lop.SoCaDungYeuCau > 0)
            //            mListLopThoiGian.Add(lop);
            //    }
            //}
            //if (mListLopThoiGian.Count > 0)
            //    lv_popup_xepLop.ItemsSource = mListLopThoiGian;
            //else if (listLopDungCTH.Count > 0)
            //    lv_popup_xepLop.ItemsSource = listLopDungCTH;
            //else
            //    lv_popup_xepLop.ItemsSource = mListLopDangMo;
            //lv_popup_xepLop.SelectedIndex = lv_xepLop_selectedIndex;
            //lv_popup_xepLop.Focus();
        }
    }
}
