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
namespace Library_Management.DAL
{
    class ThanhVienController
    {
        public async Task<bool> AddThanhVien(DTO_ThanhVien ThanhVien)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PostAsJsonAsync("https://localhost:5001/ThanhVien/AddTV/", ThanhVien).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }         
            return str;
        }
        public async Task<bool> UpdateThanhVien(DTO_ThanhVien ThanhVien)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response = client.PutAsJsonAsync("https://localhost:5001/ThanhVien/UpdateTV", ThanhVien).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<bool> DeleteThanhVien(int ID)
        {
            bool str = false;
            HttpClient client = new HttpClient();
            var response =  client.DeleteAsync("https://localhost:5001/ThanhVien/DeleteTV/"+ID.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }
            return str;
        }
        public async Task<DataTable> GetThanhVien()
        {
            DataTable dta = new DataTable();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/ThanhVien").Result;
            if (response.IsSuccessStatusCode)
            {
                dta = await response.Content.ReadAsAsync<DataTable>();
            }
            return dta;
        }

        public async Task<DataTable> GetThanhVienTheoID(int ID)
        {
            DataTable dta = new DataTable();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/ThanhVien/SearchTV/"+ID.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                dta = await response.Content.ReadAsAsync<DataTable>();
            }
            return dta;
        }
    }
}
