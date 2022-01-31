using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Journey.Business.Helpers
{
    public class HttpRequestHelper<TRequest, TResponse>
    where TResponse : class
    where TRequest : class
    {
        public async Task Get(string url)
        {

            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<TResponse> Post(string url,TRequest requestParams,string token)
        {
            try
            {
                string strPayload = JsonConvert.SerializeObject(requestParams);
                HttpContent requestParamsJson = new StringContent(strPayload, Encoding.UTF8, "application/json");

                var response = string.Empty;
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", token);

                HttpResponseMessage result = await client.PostAsync(url, requestParamsJson);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                    string responseBody = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<TResponse>(responseBody);
                    return data;
                }
                else
                {
                    throw new Exception("Post işlemi sırasında bir hata oluştu");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Post error : "+ex.Message);
                
            }
        }




    }
}
