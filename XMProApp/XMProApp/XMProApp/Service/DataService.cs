using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace XMProApp.Service
{
    public class DataService : IDataService
    {
        public async Task<dynamic> getDataFromService(string queryString)
        {
            var uri = new Uri(string.Format(queryString, string.Empty));

            HttpClient client = new HttpClient();

            dynamic data = null;

            try
            {
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    //data = JsonConvert.DeserializeObject(json);
                    data = json;
                }
            }
            catch (Exception ex)
            {
                
            }

            return data;

        }

        public async Task<bool> postDataToService(string URL, Object PostData)
        {
            bool _return = false;

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(string.Format(URL, string.Empty));

            var json = JsonConvert.SerializeObject(PostData);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);


            if (response.IsSuccessStatusCode)
            {
                _return = true;
            }

            return _return;
        }

        public async Task<bool> putDataToService(string URL, Object PostData)
        {
            bool _return = true;

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(string.Format(URL, string.Empty));

            var json = JsonConvert.SerializeObject(PostData);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            try
            {
                response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Put, uri) { Content = content }, HttpCompletionOption.ResponseHeadersRead);


                if (response.IsSuccessStatusCode)
                {
                    _return = true;
                }

            }
            catch
            {
                return true;
            }
            return _return;
        }


        public async Task<dynamic> getOdataDataFromService(string queryString)
        {
            var uri = new Uri(string.Format(queryString, string.Empty));

            HttpClient client = new HttpClient();

            dynamic data = null;

            try
            {
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    data = json;
                }
            }
            catch (Exception ex)
            {

            }

            return data;

        }

    }
}
