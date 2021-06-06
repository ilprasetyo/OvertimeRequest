using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OvertimeRequest.Context;
using OvertimeRequest.Models;
using OvertimeRequest.Repositories.Data;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class RequestController : Controller
    {
        public readonly ILogger<RequestController> logger;
        public readonly RequestRepository requestRepository;
        public readonly MyContext context;

        List<GetRequestVM> request = new List<GetRequestVM>();
        HttpClientHandler handler = new HttpClientHandler();

        public RequestController(ILogger<RequestController> logger, RequestRepository requestRepository, MyContext context)
        {
            this.logger = logger;
            this.requestRepository = requestRepository;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IList<GetRequestVM> GetHistoryRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync("https://localhost:44323/api/Request/GetHistroryRequest2").Result;
                if (result.IsSuccessStatusCode)
                {
                    var history = result.Content.ReadAsStringAsync().Result;
                    IList<GetRequestVM> data = JsonConvert.DeserializeObject<IList<GetRequestVM>>(history);
                    return data;
                }
            }
            return null;
        }

        public async Task<List<GetRequestVM>> GetAllAct()
        {
            var token = HttpContext.Session.GetString("JWToken");
            request = new List<GetRequestVM>();
            using (var httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = httpClient.GetAsync("https://localhost:44323/api/Request/GetHistoryRequest3").Result)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    request = JsonConvert.DeserializeObject<List<GetRequestVM>>(apiResponse);
                }
            }
            return request;
        }

        public IList<dynamic> GetActRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync("https://localhost:44323/api/Request/GetHistoryRequest3").Result;
                if (result.IsSuccessStatusCode)
                {
                    var act = result.Content.ReadAsStringAsync().Result;
                    List<dynamic> data = JsonConvert.DeserializeObject<List<dynamic>>(act);
                    return data;
                }
            }
            return null;
        }
    }
}
