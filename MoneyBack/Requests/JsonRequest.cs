using MoneyBack.Bankier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Requests
{
    public class JsonRequest
    {
        public Dictionary<string, string> Arguments { get; set; } = new Dictionary<string, string>();
        public string WebPath { get; set; }
        public JsonRequest(string webPath)
        {
            WebPath = webPath;
        }

        public JsonRequest AddArgument(string key, string value)
        {
            Arguments.Add(key, value);
            return this;
        }

        public async Task<object> Get()
        {
            string url = WebPath;
            if (Arguments.Count > 0)
            {
                url += "?";
                url += string.Join("&", Arguments.Select(a => $"{a.Key}={a.Value}"));
            }
            var request = WebRequest.Create(url);

            var response = await request.GetResponseAsync();

            using(StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string content = await sr.ReadToEndAsync();

                return JsonConvert.DeserializeObject(content);
            }
        }
    }
}
