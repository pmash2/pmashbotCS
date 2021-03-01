using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pmashbotCS.Helpers
{
    public static class TodayMessagePoster
    {
        public static async Task PostMessage(string endpoint, string msg)
        {
            var postMsg = new PostTodayMsg()
            {
                Message = msg
            };

            var json = JsonConvert.SerializeObject(postMsg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            await client.PostAsync(endpoint + MagicStrings.TodayHub, data);
        }
    }

    public class PostTodayMsg
    {
        public string Message { get; set; }
    }
}
