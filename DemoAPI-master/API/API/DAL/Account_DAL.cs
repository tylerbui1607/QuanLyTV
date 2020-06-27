using API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.DAL
{
    public class NhanVien_DAL
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PS7MU4U\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = null;
        public bool Login(NhanVien NhanVien)
        {
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT count(*) FROM NHAN_VIEN WHERE username ='" + NhanVien.UserName_NV + "' and password ='" + NhanVien.PassWord_NV + "'";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int ret = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return (ret > 0);
            }
            catch
            {
                return false;
            }
        }
        public bool Register(NhanVien NhanVien)
        {
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " FROM NHAN_VIEN WHERE username ='" + NhanVien.UserName_NV + "' and password ='" + NhanVien.PassWord_NV + "'";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int ret = Convert.ToInt32(cmd.ExecuteNonQuery());
                con.Close();
                return (ret > 0);
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetAllNhanVien()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHAN_VIEN";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                adp = new SqlDataAdapter(cmd);
                dt.TableName = "NhanViens";
                adp.Fill(dt);
                con.Close();
            }
            catch
            {

            }
            return dt;
        }
    }
}
