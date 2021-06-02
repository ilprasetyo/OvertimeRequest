using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCode Register(Register register)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44323/api/Account/Register", content).Result;
            return result.StatusCode;
        }

        [HttpPost]
        public HttpStatusCode ForgotPassword(ForgotVM forgotVM)
        {
            var url = "https://localhost:44323/api/Account/ForgotPassword";
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(forgotVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(url, content).Result;
            return result.StatusCode;
        }

        [HttpPost]
        public HttpStatusCode ResetPassword(ResetVM resetVM)
        {
            var url = "https://localhost:44323/api/Account/ResetPassword";
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(resetVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(url, content).Result;
            return result.StatusCode;
        }

        [HttpPost]
        public HttpStatusCode Login(Login login)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44323/api/Account/Login", content).Result;
            return result.StatusCode;
        }


    }
}
