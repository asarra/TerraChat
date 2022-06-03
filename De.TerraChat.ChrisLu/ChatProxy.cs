using De.TerraChat.Base.Interfaces;
using De.TerraChat.Base.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace De.TerraChat.ChrisLu
{
    public class ChatProxy : IChatProxy
    {
        public string ApiBaseAddress { set; private get; } = "http://system11:5000";

        public void AddMessage(Message msg)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(ApiBaseAddress) })
            {
                msg.Id = 0;
                msg.DateCre = DateTime.Now;
                msg.User = null;
                var content = new StringContent(JsonSerializer.Serialize(msg), System.Text.Encoding.UTF8, "application/json");
                var response = client.PostAsync("/api/message",content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
//                Message[] dataMsg = JsonSerializer.Deserialize<Message[]>(json);
            }


        }

        public Message[] GetMessages()
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(ApiBaseAddress) })
            {
                var json = client.GetAsync("/api/message").Result.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var dataMsg = JsonSerializer.Deserialize<List<Message>>(json,options);
                return dataMsg.ToArray();
            }
        }

        public User GetUser(string name, string pwd)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(ApiBaseAddress) })
            {
                var resp = client.GetAsync($"/api/user?n={name}&p={pwd}").Result;
                if (resp.IsSuccessStatusCode)
                {
                    var json= resp.Content.ReadAsStringAsync().Result;
                    User dataUser = JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
                    return dataUser;
                }
                else
                {
                    return null;
                }
                
            }

       }
    }
}
