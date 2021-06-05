using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            if (Request.Query.ContainsKey("Token"))
            {
                var token = Request.Query["Token"].ToString();
                ViewData["token"] = token;
                return View();
            }
            return NotFound();
        }

        public IActionResult ResetPasswordAPI(ResetVM reset)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(reset), Encoding.UTF8, "application/json");
            var result = client.PutAsync("https://localhost:44323/api/Account/ResetPassword", stringContent).Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(new { result });
            }
            else
            {
                return BadRequest(new { result });
            }
        }

        public IActionResult ForgotPasswordAPI(ForgotVM forgot)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(forgot), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44323/api/Account/ForgotPassword", stringContent).Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(new { result });
            }
            else
            {
                return BadRequest(new { result });
            }
        }

        public string LoginAPI(Login login)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44323/api/Account/Login", stringContent).Result;
            var token = result.Content.ReadAsStringAsync().Result;
            HttpContext.Session.SetString("JWToken", token);

            if (result.IsSuccessStatusCode)
            {
                var jwtReader = new JwtSecurityTokenHandler();
                var jwt = jwtReader.ReadJwtToken(token);

                var role = jwt.Claims.First(c => c.Type == "role").Value;
                if (role == "Manager")
                {
                    return Url.Action("Manager", "Home");
                }
                else if(role == "Admin")
                {
                    return Url.Action("Admin", "Home");
                }
                else if (role == "Payroll")
                {
                    return Url.Action("Payroll", "Home");
                }
                else
                {
                    return Url.Action("Index", "Home");
                }
            }
            else
            {
                return "Error";
                //return BadRequest(new { result });
            }
        }

        public string RegisterAPI(Register register)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44323/api/Account/Register", stringContent).Result;
            if (result.IsSuccessStatusCode)
            {
                //return Ok(new { result });
                return Url.Action("Index", "Authentication");
            }
            else
            {
                //return BadRequest(new { result });
                return "Error";
            }
        }


    }
}
