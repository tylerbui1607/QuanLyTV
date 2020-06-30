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
    class BUS_PM
    {
        DAL_PM dalphieumuon = new DAL_PM();

        public DataTable GetPM(string idtv)
        {
            return dalphieumuon.GetPM(idtv);
        }
        public bool suaPM(DTO_PHIEUMUON pm)
        {
            return dalphieumuon.suaPM(pm);
        }
    }
}
