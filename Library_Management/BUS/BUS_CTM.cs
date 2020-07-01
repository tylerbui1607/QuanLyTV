using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Library_Management.DAL;
using Library_Management.DTO;

namespace Library_Management.BUS
{
    class BUS_CTM
    {
        DAL_CTM dalctmuon = new DAL_CTM();

        public DataTable GetCTM(string idpm)
        {
            return dalctmuon.GetCTM(idpm);
        }
        public bool addCTM(DTO_CTMUON ctm)
        {
            return dalctmuon.AddCTM(ctm);
        }
        public bool suaCTM(DTO_CTMUON ctm)
        {
            return dalctmuon.suaCTM(ctm);
        }
    }
}
