using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTP_ht1.Models;
using System.Net;
using Newtonsoft.Json;
using System.Net.Sockets;

namespace HTTP_ht1.Services
{
    internal class StartService
    {
        private string _url = "https://reqres.in/";

        public async Task GetHttp()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                HttpResponseMessage message = await client.GetAsync("api/users?page=2");

                if (message.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("get");

                    string content = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
        }

        public async Task PostHttp()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                CreateRequest request = new CreateRequest
                {
                    Name = "morpheus",
                    Job = "leader"
                };

                string serialized = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(serialized, Encoding.Unicode, "application/json");

                HttpResponseMessage message = await client.PostAsync("api/users", content);

                if (message.StatusCode == HttpStatusCode.Created)
                {
                    Console.WriteLine("post");
                    string cont = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(cont);

                    //CreateUser user = JsonConvert.DeserializeObject<CreateUser>(cont);
                    //Console.WriteLine(user!.Name);
                }


            }
        }

        public async Task PutHttp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                CreateRequest request = new CreateRequest
                {
                    Name = "morpheus",
                    Job = "zion resident"
                };

                string serialized = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(serialized, Encoding.Unicode, "application/json");

                HttpResponseMessage message = await client.PutAsync("api/users/2", content);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("put");
                    string cont = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(cont);
                }
            }
        }

        public async Task DeleteHttp()
        {
            using (var client = new HttpClient())
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token; 

                client.BaseAddress = new Uri(_url);

                Task.Delay(3000);

                var response =  await client.DeleteAsync("api/users/2", token);

                if (response.IsSuccessStatusCode)
                {
                    Console.Write("deleted");
                }
            }
        }
    }
}
