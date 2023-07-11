using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace myWebApp
{
    public static class Webhook
    {
        public static async Task SayHiAsync(string WebhookURL, string Source)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var response = await client.GetAsync($"{WebhookURL}?_source={Source}");
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
}