using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Library_Management.DTO;
namespace Library_Management.DAL
{
    class DAL_Book : DBConnect
    {
        //Load danh sach SACH
        public DataTable GetBook()
        {
            string query = "SELECT * FROM SACH ";
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSBook = new DataTable();
            adapt.Fill(DSBook);
            return DSBook;
        }
        //Search
        public DataTable SearchBook(string str)
        {
            string query = "SELECT * FROM SACH WHERE Ten like " + "'%"+str+ "%'";
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSBook = new DataTable();
            adapt.Fill(DSBook);
            return DSBook;
        }
        /*Them Sach*/
        public bool AddBook(DTO_Book book)
        {

            string SQL = "EXEC USP_INSERT_SACH @IDSach , @IDTG , @IDNXB , @Ten , @TheLoai , @ViTri , @SL , @SLHienTai , @GiaSach ";
            return DAL_EX.Instance.ExcuteReader(SQL, new object[] {
                book.Book_ID,
                book.TacGia_ID,
                book.NXB_ID,
                book.TenSach,
                book.TheLoai,
                book.ViTri,
                book.SoLuong,
                book.SLHienTai,
                book.GiaSach
            });
        }

        /*Sua Sach*/
        public bool UpdateBook(DTO.DTO_Book book)
        {
            string SQL = "EXEC USP_UPDATE_SACH @IDSach , @IDTG , @IDNXB , @Ten , @TheLoai , @ViTri , @SL , @SLHienTai , @GiaSach ";
            return DAL_EX.Instance.ExcuteReader(SQL, new object[] {
                book.Book_ID,
                book.TacGia_ID,
                book.NXB_ID,
                book.TenSach,
                book.TheLoai,
                book.ViTri,
                book.SoLuong,
                book.SLHienTai,
                book.GiaSach
            });
        }

        public DataTable GetBookWithID(string id)
        {
            string query = "SELECT * FROM SACH WHERE IDSach ="+id;
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSBook = new DataTable();
            adapt.Fill(DSBook);
            return DSBook;
        }

        public DataTable GetBookVer2()
        {
            string query = "SELECT IDSach,Ten FROM SACH ";
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSBook = new DataTable();
            adapt.Fill(DSBook);
            return DSBook;
        }
        public DataTable SearchBookVer2(string str)
        {
            string query = "SELECT IDSach,Ten FROM SACH WHERE Ten like " + "'%" + str + "%'";
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSBook = new DataTable();
            adapt.Fill(DSBook);
            return DSBook;
        }
    }
}
