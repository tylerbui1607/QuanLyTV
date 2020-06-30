using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library_Management.DAL
{
    class DAL_PM : DBConnect
    {
        public DataTable GetPM(string idtv)
        {
            string query = "SELECT * FROM PHIEU_MUON WHERE IDTV ="+idtv;
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSPM = new DataTable();
            adapt.Fill(DSPM);
            return DSPM;
        }

        //public bool AddPM(DTO.DTO_PHIEUMUON PM)
        //{

        //}

        public bool suaPM(DTO.DTO_PHIEUMUON PM)
        {
            string SQL = "USP_UPDATE_PM @IDPM , @idtv , @idnv , @ngaymuon , @tra";
            return DAL_EX.Instance.ExcuteReader(SQL, new object[] {
                   PM.ID_PM,
                   PM.ID_TV,
                   PM.ID_NV,
                   PM.NgayMuon,
                   PM.Tra
            });
        }
    }
}
