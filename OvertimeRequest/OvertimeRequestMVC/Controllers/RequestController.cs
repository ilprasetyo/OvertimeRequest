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
        //public readonly ILogger<RequestController> logger;
        //public readonly RequestRepository requestRepository;
        //public readonly MyContext context;

        //List<GetRequestVM> request = new List<GetRequestVM>();
        //HttpClientHandler handler = new HttpClientHandler();

        //public RequestController(ILogger<RequestController> logger, RequestRepository requestRepository, MyContext context)
        //{
        //    this.logger = logger;
        //    this.requestRepository = requestRepository;
        //    this.context = context;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetHistoryRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = await client.GetAsync("https://localhost:44323/api/Request/GetHistroryRequest3");
                if (result.IsSuccessStatusCode)
                {

                    var history = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(history);
                    return Json(data);
                }
            }
            return Json(null);
        }

        //public async Task<List<GetRequestVM>> GetAllAct()
        //{
        //    var token = HttpContext.Session.GetString("JWToken");
        //    request = new List<GetRequestVM>();
        //    using (var httpClient = new HttpClient(handler))
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        using (var response = httpClient.GetAsync("https://localhost:44323/api/Request/GetHistoryRequest3").Result)
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            request = JsonConvert.DeserializeObject<List<GetRequestVM>>(apiResponse);
        //        }
        //    }
        //    return request;
        //}

        [HttpGet]
        [Route("HistoryByNIK")]
        public async Task<IActionResult> HistoryByNIK()
        {
            var client = new HttpClient();
            ViewBag.NIK = HttpContext.Session.GetString("NIK");

            var header = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var nik = ViewBag.NIK;

            //var definition = new { Message = "", Status = "", Token = "" };
            //var response = await httpClient.GetAsync("Request/HistoryByNIK/" + nik);
            //string apiResponse = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeAnonymousType(apiResponse, definition);
            //return new JsonResult(result);

            var response = await client.GetAsync("Request/GetHistoryRequest4/" + nik);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<GetRequest>>(apiResponse);
            return Json(data);
        }

        public List<object> GetActRequest()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token != null)
            {
                var result = new List<object>();
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var results = client.GetAsync("https://localhost:44323/api/Request/GetHistroryRequest3").Result;
                if (results.IsSuccessStatusCode)
                {
                    var act = results.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(act);
                    
                    for(int i = 0; i< data.Count; i++)
                    {
                        result.Add(new
                        {
                            RequestId = data[i].Id.Value,
                            NIK = data[i].NIK.Value,
                            Name = data[i].Name.Value,
                            ManagerId = data[i].ManagerId.Value,
                            StartHours = data[i].StartHours.Value,
                            EndHours = data[i].EndHours.Value,
                            Reason = data[i].Reason.Value,
                            Payroll = data[i].Payroll.Value,
                            Status = data[i].Status.Value
                        });
                    }
                    
                    return result;
                }
            }
            return null;
        }
    }
}
