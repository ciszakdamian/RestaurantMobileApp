using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantMobileApp.Models;

namespace RestaurantMobileApp.Services
{
    class RestService
    {
        HttpClient _client;

        public const string backendUrl = "https://pickyjanusz.azurewebsites.net/index.php";

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<Table> GetTable(int id)
        {
            Table table = null;
            try
            {
                string uri = backendUrl + "/tables/" + id;
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    table = JsonConvert.DeserializeObject<Table>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return table;
        }

        public async void PostOrder(object item)
        {
            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string uri = backendUrl + "/tables";
            HttpResponseMessage response = null;
            response = await _client.PostAsync(uri, content);
            
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task<Table[]> GetTableList()
        {
            Table[] tableList = null;
            try
            {
                string uri = backendUrl + "/tables";
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    tableList = JsonConvert.DeserializeObject<Table[]>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return tableList;
        }
    }
}
