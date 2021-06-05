using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IList<dynamic> GetHistoryRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync("https://localhost:44323/api/Request/GetHistroryRequest3").Result;
                if (result.IsSuccessStatusCode)
                {
                    var history = result.Content.ReadAsStringAsync().Result;
                    IList<dynamic> data = JsonConvert.DeserializeObject<IList<dynamic>>(history);
                    return data;
                }
            }
            return null;
        }
        
        public IList<dynamic> GetActRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync("https://localhost:44323/api/Request/GetActualRequest2").Result;
                if (result.IsSuccessStatusCode)
                {
                    var act = result.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(act);
                    return data;
                }
            }
            return null;
        }
    }
}
