using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeSalaryWebApp.Services
{
    public class WebApiCallerService
    {
        private readonly Uri baseUrl = new Uri(ConfigurationManager.AppSettings["WebApiUrl"]);
       
        public async Task<U> WebApiCallerPost<T, U>(string url, T data)
        {
            U result = default(U);
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseUrl;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage apiResponse = await client.PostAsJsonAsync(url, data);
                if (apiResponse.IsSuccessStatusCode)
                {
                     result = await apiResponse.Content.ReadAsAsync<U>();
                }
            }
            return result;
        }
    }
}