using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VeeamBackOfficeUnit.Test.HttpClientHandler
{
    public interface IHttpKramHandler
    {
        HttpResponseMessage Get(string url);
        Task<HttpResponseMessage> GetAsync(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> PostAsync(Uri url, HttpContent content);
    }

    public class HttpClientKramHandler : IHttpKramHandler
    {
        private HttpClient _client = new HttpClient();

        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage PostAsync(Uri url, HttpContent content)
        {
            return _client.PostAsync(url, content).Result;
        }

        async Task<HttpResponseMessage> IHttpKramHandler.PostAsync(Uri url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }
    }
}
