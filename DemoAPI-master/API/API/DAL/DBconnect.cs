using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace API.DAL
{
    public class DBConnect
    {
        protected
            SqlConnection connection = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
    }

}
