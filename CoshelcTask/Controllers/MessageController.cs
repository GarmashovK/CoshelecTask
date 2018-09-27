using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoshelcTask.Controllers
{
    public class MessageController : Controller
    {
        private string url = "https://api.pushover.net/1/messages.json";
        [HttpGet]
        [Route("message/send")]
        public string Send(string app_token, string user_key, string msg) {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
               { "token", app_token },
               { "user", user_key },
                {"message", msg }
            };
            var content = new FormUrlEncodedContent(values);
            var post = client.PostAsync(url, content);
            post.Wait();

            var resp = post.Result;
            if (resp.StatusCode == HttpStatusCode.OK)
                return "Message is sent!";
            else
                return "Message is not sent. Something gone wrong!";
        }
    }
}