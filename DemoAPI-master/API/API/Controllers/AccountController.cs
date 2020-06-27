using API.BUS;
using API.Model;
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
    public class AccountController:ControllerBase
    {
        [HttpGet]
        public DataTable Get()
        {
            Account_BUS account_BUS = new Account_BUS();
            return account_BUS.GetAllAccount();
        }
        [HttpPost]
        public bool Login([FromBody] NhanVien account)
        {
            Account_BUS account_BUS = new Account_BUS();
            return account_BUS.Login(account);
        }
    }
}
