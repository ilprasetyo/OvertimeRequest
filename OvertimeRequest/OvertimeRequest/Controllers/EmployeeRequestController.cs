using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest.Base;
using OvertimeRequest.Models;
using OvertimeRequest.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRequestController : BaseController<EmployeeRequest, EmployeeRequestRepository, int>
    {
        private EmployeeRequestRepository employeeRequestRepository;

        public EmployeeRequestController(EmployeeRequestRepository employeeRequestRepository) : base(employeeRequestRepository)
        {
            this.employeeRequestRepository = employeeRequestRepository;
        }
    }
}
