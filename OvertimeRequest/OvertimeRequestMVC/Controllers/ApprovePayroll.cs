using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestMVC.Controllers
{
    public class ApprovePayroll : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
