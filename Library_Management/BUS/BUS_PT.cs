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
    class BUS_PT
    {
        DAL_PT dalphieutra = new DAL_PT();
        public DataTable GetPT(string idpm)
        {
            return dalphieutra.GetPT(idpm);
        }
        public bool addPT(DTO_PHIEUTRA pt)
        {
            return dalphieutra.AddPT(pt);
        }
    }
}
