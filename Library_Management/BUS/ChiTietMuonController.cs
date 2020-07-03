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
    class ChiTietMuonController
    {
        public async Task<bool> AddCTM(DTO_CTMUON ctm)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PostAsJsonAsync("https://localhost:5001/ChiTietMuon/AddCTM/", ctm).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<bool> UpdateCTM(DTO_CTMUON ctm)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PutAsJsonAsync("https://localhost:5001/ChiTietMuon/UpdateCTM/", ctm).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<DataTable> GetCTMTheoID(int ID)
        {
            DataTable dta = new DataTable();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/ChiTietMuon/GetCTM/" + ID.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                dta = await response.Content.ReadAsAsync<DataTable>();
            }
            return dta;
        }
    }
}
