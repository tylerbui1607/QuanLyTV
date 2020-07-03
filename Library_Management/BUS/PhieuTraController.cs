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
    class PhieuTraController
    {
        public async Task<bool> AddPT(DTO_PHIEUTRA pt)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PostAsJsonAsync("https://localhost:5001/PhieuTra/AddPT/", pt).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<DataTable> GetPTTheoID(int ID)
        {
            DataTable dta = new DataTable();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/PhieuTra/GetPT/" + ID.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                dta = await response.Content.ReadAsAsync<DataTable>();
            }
            return dta;
        }
    }
}
