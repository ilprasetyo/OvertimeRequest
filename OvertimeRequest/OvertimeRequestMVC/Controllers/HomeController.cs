using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OvertimeRequestMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult Payroll()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }

        public IActionResult GetProjectAdmins()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var token = HttpContext.Session.GetString("JWToken");


            if (token != null)
            {
                var jwtReader = new JwtSecurityTokenHandler();
                var jwt = jwtReader.ReadJwtToken(token);

                var email = jwt.Claims.First(c => c.Type == "unique_name").Value;
                ViewData["token"] = email;
                return View();
            }
            return Unauthorized();
        }

        public IActionResult GetRequest()
        {
            return View();
        }

        public string GetRequestAPI()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync("https://localhost:44323/api/Request").Result;
                if (result.IsSuccessStatusCode)
                {
                    var projects = result.Content.ReadAsStringAsync();
                    ViewData["projects"] = projects;
                    return Url.Action("GetRequest", "Home");
                }
            }
            return "Unauthorized";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<dynamic> GetHistoryRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync("https://localhost:44323/api/Request/GetHistroryRequest2").Result;
                if (result.IsSuccessStatusCode)
                {
                    var projects = result.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(projects);
                    return data;
                }
            }
            return null;
        }
    }
}

