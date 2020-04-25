using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taxi.Common.Models;

namespace Taxi.Common.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                string url = $"{servicePrefix}{controller}/{plaque}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {

                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.NotFound:
                            return new Response
                            {
                                IsSuccess = false,
                                Message = "No se encontró ese numero de placa",
                            };
                        default:
                            return new Response
                            {
                                IsSuccess = false,
                                Message = result,
                            };
                    }
                }

                TaxiResponse model = JsonConvert.DeserializeObject<TaxiResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
