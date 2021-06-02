using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Forget()
        {
            return View();
        }

        public IActionResult Registrasi()
        {
            return View();
        }
    }
}
