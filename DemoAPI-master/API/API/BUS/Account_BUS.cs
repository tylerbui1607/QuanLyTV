using API.DAL;
using API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.BUS
{
    public class Account_BUS
    {
        public bool Login(NhanVien account)
        {
            NhanVien_DAL NhanVien = new NhanVien_DAL();
            return NhanVien.Login(account);
        }
        public DataTable GetAllAccount()
        {
            NhanVien_DAL NhanVien = new NhanVien_DAL();
            return NhanVien.GetAllNhanVien();
        }
    }
}
