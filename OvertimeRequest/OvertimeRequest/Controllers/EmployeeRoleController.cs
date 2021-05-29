using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController<EmployeeRole, EmployeeRoleRepository, int>
    {
        private EmployeeRoleRepository employeeRoleRepository;

        public EmployeeRoleController(EmployeeRoleRepository employeeRoleRepository) : base(employeeRoleRepository)
        {
            this.employeeRoleRepository = employeeRoleRepository;
        }
    }
}
