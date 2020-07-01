﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Library_Management.DAL
{
    class DAL_PT :DBConnect
    {
        public DataTable GetPT(string idpm)
        {
            string query = "SELECT * FROM PHIEU_TRA WHERE IDPT =" + idpm;
            SqlDataAdapter adapt = new SqlDataAdapter(query, connection);
            DataTable DSPT = new DataTable();
            adapt.Fill(DSPT);
            return DSPT;
        }
        public bool AddPT(DTO.DTO_PHIEUTRA PT)
        {
            string SQL = "EXEC USP_INSERT_PT @IDPT , @IDTV , @IDNV , @NgayTra , @TienPhat";
            return DAL_EX.Instance.ExcuteReader(SQL, new object[] {PT.IDPT,
                                                                   PT.IDTV,
                                                                   PT.IDNV,
                                                                   PT.NgayTra,
                                                                   PT.TienPhat
            });
        }
    }
}
