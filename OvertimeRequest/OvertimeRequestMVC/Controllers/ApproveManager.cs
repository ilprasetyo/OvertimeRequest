using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class ApproveManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Get(int Id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44323/api/Request/" + Id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }

        [HttpPost]
        public HttpStatusCode Approve(ApproveVM approveVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44323/api/Request/ApprovedManager", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode Reject(ApproveVM approveVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44323/api/Request/RejectManager", content).Result;
            return result.StatusCode;
        }
    }
}
