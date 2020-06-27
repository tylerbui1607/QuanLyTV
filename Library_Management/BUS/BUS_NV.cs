using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management.DTO;
using Library_Management.DAL;
using System.Data;
namespace Library_Management.BUS
{
    class BUS_NV
    {
        DAL_NV dalNhanVien = new DAL_NV();
        public DataTable GetNhanVien()
        {
            return dalNhanVien.GetNV();
        }
        public bool themThanhVien(DTO_NhanVien nv)
        {
            return dalNhanVien.AddNV(nv);
        }

        public bool suaNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.SuaNhanVien(nv);
        }

        public bool xoaNhanVien(int NV_ID)
        {
            return dalNhanVien.DeleteNhanVien(NV_ID);
        }
    }
}
