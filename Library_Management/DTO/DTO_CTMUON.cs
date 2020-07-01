using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Library_Management.DTO
{
    class DTO_CTMUON
    {
        private string iDPM;
        private string iDSACH;
        private string sL;
        private string checkTra;

        public string IDPM { get => iDPM; set => iDPM = value; }
        public string IDSACH { get => iDSACH; set => iDSACH = value; }
        public string SL { get => sL; set => sL = value; }
        public string CHECKTRA { get => checkTra; set => checkTra = value; }

        public DTO_CTMUON()
        { }

        public DTO_CTMUON(string idpm,string idsach,string sl,string checktra)
        {
            this.IDPM = idpm;
            this.IDSACH = idsach;
            this.SL = sl;
            this.CHECKTRA = checktra;
        }
    }
}
