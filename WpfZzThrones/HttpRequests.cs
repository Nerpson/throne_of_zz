using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfZzThrones.Models;

namespace WpfZzThrones
{
    public class HttpRequests
    {
        private static HttpRequests _instance;

        public static HttpRequests Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpRequests();
                }
                return _instance;
            }
        }

        private HttpRequests()
        {
            // dummy constructor.
        }

        public async Task<List<CharacterDto>> GetCharacters()
        {
            string result = await GetHttpResult("Characters");

            return JsonConvert.DeserializeObject<List<CharacterDto>>(result);
        }

        public void PostCharacter(CharacterDto character)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(character), Encoding.UTF8, "application/json");

            PostHttpRequest("Characters", httpContent);
        }

        public async Task<string> GetHttpResult(string model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3716/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
                HttpResponseMessage response = await client.GetAsync("api/" + model);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    return temp;
                }
            }

            return null;
        }

        public async void PostHttpRequest(string model, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3716/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
                HttpResponseMessage response = await client.PostAsync("api/" + model, content);
            }
        }
    }
}
