using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dynamix.Client.Services
{
    public class Request
    {
        public HttpClient client { get; }
        public Request()
        {
            if (client == null)
            {
                string base_url = Environment.GetEnvironmentVariable("RestApiUrl");
                if (base_url == null)
                {
                    base_url = "http://localhost:5000";
                }
                client = new HttpClient();
                client.BaseAddress = new Uri(base_url);
            }
        }
    }
}
