using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Cashrewards.Funtional.Test.Mock
{
    public static class MockHelper
    {
        public const string BaseUrl = "http://localhost";

        private const string MEDIA_TYPE_JSON = "application/json";

        public static HttpRequestMessage CreateHttpRequestMessage(
            string url,
            HttpMethod httpMethod,
            object body = null)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

            httpRequestMessage.Headers.Add("Accept", MEDIA_TYPE_JSON);

            if (body != null)
            {
                var serializedBody = JsonConvert.SerializeObject(body);
                var stringContent = new StringContent(serializedBody, Encoding.UTF8, MEDIA_TYPE_JSON);
                httpRequestMessage.Content = stringContent;
            }

            return httpRequestMessage;
        }
    }
}
