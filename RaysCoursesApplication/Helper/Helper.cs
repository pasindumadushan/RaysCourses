using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Helper
{
    public class HelperApi
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:59273/");

            return Client;
        }

        public HttpClient RequestHeader(HttpClient Client, string access_Token)
        {

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            Client.DefaultRequestHeaders.Accept.Add(contentType);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_Token);

            return Client;
        }
    }
}
