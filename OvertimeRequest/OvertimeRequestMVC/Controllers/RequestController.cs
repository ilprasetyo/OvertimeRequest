using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCode SubmitRequest(RequestVM requestVM)
        {
            var httpClient = new HttpClient();

            var token = HttpContext.Session.GetString("JWToken");
            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);

            var NIK = jwt.Claims.First(c => c.Type == "unique_name").Value;
            requestVM.NIK = NIK;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            StringContent content = new StringContent(JsonConvert.SerializeObject(requestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44323/api/Request/RequestEmployee", content).Result;
            return result.StatusCode;
        }
    }
}
