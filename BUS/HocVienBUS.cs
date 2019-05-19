using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    

    public class HocVienBUS
    {
        HocVienDAO mHocVienDAO;

        public HocVienBUS()
        {
            mHocVienDAO = new HocVienDAO();
        }

        public bool insertHocVien(HocVien hv)
        {
            return mHocVienDAO.insertHocVien(hv);
        }
    }

   
}
