using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library_Management.DAL
{
    class DAL_CTM : DBConnect
    {
        public DataTable GetCTM(string idpm)
        {
            string query = "SELECT * FROM CTMUON WHERE IDPM =" + idpm;
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSCTM = new DataTable();
            adapt.Fill(DSCTM);
            return DSCTM;
        }

        public bool AddCTM(DTO.DTO_CTMUON CTM)
        {
            string SQL = "EXEC USP_INSERT_CTM @IDPM , @IDSach , @SL , @checktra";
            return DAL_EX.Instance.ExcuteReader(SQL, new object[] {CTM.IDPM,
                                                                   CTM.IDSACH,
                                                                   CTM.SL,
                                                                   CTM.CHECKTRA
                                                                        });
        }
        public bool suaCTM(DTO.DTO_CTMUON CTM)
        {
            string SQL = "USP_UPDATE_CTM @IDPM , @IDSach , @SL , @checktra";
            return DAL_EX.Instance.ExcuteReader(SQL, new object[] {
                   CTM.IDPM,
                   CTM.IDSACH,
                   CTM.SL,
                   CTM.CHECKTRA
            });
        }
    }
}
