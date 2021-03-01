using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;
using pmashbotCS.Helpers;

namespace pmashbotCS.Helpers
{
    public static class MessagePoster
    {
        public static async Task PostMessage(string endpoint, ChatMessage msg)
        {
            var postMsg = new PostMsg(){
                User = msg.DisplayName,
                Message = msg.Message
            };

            var json = JsonConvert.SerializeObject(postMsg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44399/chatmessage";
            using var client = new HttpClient();

            var response = await client.PostAsync(endpoint + MagicStrings.MessageHub, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }

    public class PostMsg
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
