using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Employee()
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
        public IActionResult Department()
        {
            return View();
        }
        public IActionResult Position()
        {
            return View();
        }
        public IActionResult Role()
        {
            return View();
        }
    }
}
