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
    class BUS_Book
    {
        DAL_Book dalBook = new DAL_Book();
        public DataTable loadBook()
        {
            return dalBook.GetBook();
        }
        public bool themBook(DTO_Book Book)
        {
            return dalBook.AddBook(Book);
        }

        public bool suaBook(DTO_Book Book)
        {
            return dalBook.UpdateBook(Book);
        }

    }
}
