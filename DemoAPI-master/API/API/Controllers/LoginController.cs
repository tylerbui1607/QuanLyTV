using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using API.BUS;
using API.DTO;
using API.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public bool Login([FromBody] DTO_NhanVien Nhanvien)
        {
            DAL_LOGIN login = new DAL_LOGIN();
            return login.CheckLogin(Nhanvien.UserName_NV, Nhanvien.PassWord_NV);
        }
    }
}