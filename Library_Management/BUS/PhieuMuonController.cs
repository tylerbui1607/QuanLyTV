using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management.BUS;
using Library_Management.DTO;
using System.Net.Http;
using System.Windows.Threading;
using System.Net;
using System.Data;

namespace Library_Management.BUS
{
    class PhieuMuonController
    {
        public async Task<bool> AddPM(DTO_PHIEUMUON pm)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PostAsJsonAsync("https://localhost:5001/PhieuMuon/AddPM/", pm).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<bool> UpdatePM(DTO_PHIEUMUON pm)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PutAsJsonAsync("https://localhost:5001/PhieuMuon/UpdatePM/", pm).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<DataTable> GetPMTheoID(int ID)
        {
            DataTable dta = new DataTable();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/PhieuMuon/GetPM/" + ID.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                dta = await response.Content.ReadAsAsync<DataTable>();
            }
            return dta;
        }
        public async Task<int> GetNewPM()
        {
            int str = 0;
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/PhieuMuon/GetNewPM").Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<int>();
            }
            return str;
        }
    }
}
