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
    /// Interaction logic for NewStudentForm.xaml
    /// </summary>
    public partial class NewStudentForm : Window
    {
        RadioButton mPhaiRadioButton;
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public NewStudentForm()
        {
            InitializeComponent();

            //Show current date
            tb_date.Text = DateTime.Today.ToShortDateString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mPhaiRadioButton = (RadioButton)sender;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            String ten = TenHocVien_tb.Text;
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên học viên.");
                return;
            }
            DateTime? ngaySinh = NgaySinhHV_dp.SelectedDate;
            if (ngaySinh == null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.");
                return;
            }
            if (mPhaiRadioButton == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }
            String phai = mPhaiRadioButton.Content.ToString();
            String diaChi = DiaChi_tb.Text;
            if (diaChi == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ");
                return;
            }

            String soDT = SoDT_tb.Text;
            //if (!Regex.Match(soDT, @"^(\d[0-9]{9,11})$").Success)
            if (soDT == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại", "Thông báo");
                return;
            }


            String email = Email_tb.Text;
            String truong = Truong_tb.Text;
            int lop;
            if (int.TryParse(Lop_cb.Text,out lop))
            {
                lop = int.Parse(Lop_cb.Text);
            }
            String sdtPhuHuynh = SDTPhuHuynh_tb.Text;
            String hoTenPhuHuynh = TenPhuHuynh_tb.Text;

            HocVien hv = new HocVien(0, ten, ngaySinh.ToString(), lop, phai, soDT, email, truong, sdtPhuHuynh, hoTenPhuHuynh);

            //if (!mHocVienBUS.insertHocVien(hv))
            //{
            //    MessageBox.Show("Thêm học viên thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
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
    }
}
