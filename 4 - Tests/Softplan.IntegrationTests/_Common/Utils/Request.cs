using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.IntegrationTests._Common.Utils
{
    public class Request
    {
        public readonly HttpClient Client;

        public Request(HttpClient client) => Client = client;

        public async Task<(HttpResponseMessage response, TResult result)> GetAsync<TResult>(Uri uri, dynamic query = null) where TResult : class
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{uri}?{GetUrlString(query)}"),
                Method = HttpMethod.Get
            };

            var response = await Client.SendAsync(request);
            return await GetResultAsync<TResult>(response);
        }

        public async Task<(HttpResponseMessage response, TResult result)> PostAsync<TResult>(Uri uri, dynamic data, dynamic query = null) where TResult : class
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.Default, "application/json");

            var response = await Client.PostAsync(new Uri($"{uri}?{GetUrlString(query)}"), content);
            return await GetResultAsync<TResult>(response);
        }

        public async Task<(HttpResponseMessage response, TResult result)> PutAsync<TResult>(Uri uri, dynamic data, dynamic query = null) where TResult : class
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.Default, "application/json");

            var response = await Client.PutAsync(new Uri($"{uri}?{GetUrlString(query)}"), content);
            return await GetResultAsync<TResult>(response);
        }

        public async Task<(HttpResponseMessage response, TResult result)> DeleteAsync<TResult>(Uri uri, dynamic query = null) where TResult : class
        {
            var response = await Client.DeleteAsync(new Uri($"{uri}?{GetUrlString(query)}"));
            return await GetResultAsync<TResult>(response);
        }

        #region Private Methods

        private async Task<(HttpResponseMessage response, TResult result)> GetResultAsync<TResult>(HttpResponseMessage response) where TResult : class
        {
            var json = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<TResult>(json);
                return (response, result);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not deserialize object. Current JSON: {json}", e);
            }
        }

        private string GetUrlString(object data = null)
        {
            if (data == null) return string.Empty;
            var props = data
                .GetType().GetProperties()
                .Where(p => p.GetValue(data) != null)
                .Select(p => $"{p.Name}={ConvertObjectToString(p.GetValue(data))}");
            return string.Join("&", props);
        }

        #endregion
    }
}
