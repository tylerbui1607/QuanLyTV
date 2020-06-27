using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Library_Management.DAL;
using Library_Management.DTO;

namespace Library_Management.BUS
{
    class BUS_TV
    {
        DAL_TV dalThanhVien = new DAL_TV();
        public DataTable GetThanhVien()
        {
            return dalThanhVien.GetTV();
        }
        public bool themThanhVien(DTO_ThanhVien tv)
        {
            return dalThanhVien.AddTV(tv);
        }

        public bool suaThanhVien(DTO_ThanhVien tv)
        {
            return dalThanhVien.suaThanhVien(tv);
        }

        public bool xoaThanhVien(int TV_ID)
        {
            return dalThanhVien.xoaThanhVien(TV_ID);
        }
    }
}
