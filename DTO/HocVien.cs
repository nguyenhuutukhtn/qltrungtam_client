using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocVien
    {
        public HocVien() { }

        public HocVien(int id, String HoTen, String NgaySinh, int Lop, String GioiTinh, String SDT, String Email, String Truong, String SDTPhuHuynh, String HoTenPhuHuynh)
        {
            this.id = id;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.Lop = Lop;
            this.GioiTinh = GioiTinh;
            this.SDT = SDT;
            this.Email = Email;
            this.Truong = Truong;
            this.SDTPhuHuynh = SDTPhuHuynh;
            this.HoTenPhuHuynh = HoTenPhuHuynh;
        }

        public int id { get; set; }
        public String HoTen { get; set; }
        public String NgaySinh { get; set; }
        public int Lop { get; set; }
        public String GioiTinh { get; set; }
        public String SDT { get; set; }
        public String Email { get; set; }
        public String Truong { get; set; }
        public String SDTPhuHuynh { get; set; }
        public String HoTenPhuHuynh { get; set; }
    }
}
