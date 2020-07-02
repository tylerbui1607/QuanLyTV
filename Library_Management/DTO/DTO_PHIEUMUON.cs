﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Library_Management.DTO
{
    class DTO_PHIEUMUON
    {
        private string iD_PM;
        private string iD_TV;
        private string iD_NV;
        private DateTime ngayMuon;
        private string tra;

        public string ID_PM { get => iD_PM; set => iD_PM = value; }
        public string ID_TV { get => iD_TV; set => iD_TV = value; }
        public string ID_NV { get => iD_NV; set => iD_NV = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public string Tra { get => tra; set => tra = value; }

        public DTO_PHIEUMUON()
        {

        }
        public DTO_PHIEUMUON(string idtv, string idnv, DateTime NgayMuon, string tra)
        {
            this.ID_TV = idtv;
            this.ID_NV = idnv;
            this.NgayMuon = NgayMuon;
            this.Tra = tra;
        }
        public DTO_PHIEUMUON(string idpm,string tra)
        {
            this.ID_PM = idpm;
            this.Tra = tra;
        }
        public DTO_PHIEUMUON(string idpm,string idtv, string idnv, DateTime NgayMuon, string tra)
        {
            this.ID_PM = idpm;
            this.ID_TV = idtv;
            this.ID_NV = idnv;
            this.NgayMuon = NgayMuon;
            this.Tra = tra;
        }
    }
}
