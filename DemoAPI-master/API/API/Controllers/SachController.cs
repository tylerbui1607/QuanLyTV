using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using API.BUS;
using API.DTO;
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
    public class SachController : ControllerBase
    {
        BUS_BOOK bus = new BUS_BOOK();

        [HttpGet]
        public DataTable GetBook()
        {
            return bus.GetBook();
        }

        [Route("FindBook/{ID}")]
        [HttpGet]
        public DataTable FindByID(int ID)
        {
            return bus.GetBookWithID(ID.ToString());
        }

        [Route("SearchBookVer2/{str}")]
        [HttpGet]
        public DataTable SearchByID(string str)
        {
            return bus.searchBookVer2(str);
        }
    }
}
