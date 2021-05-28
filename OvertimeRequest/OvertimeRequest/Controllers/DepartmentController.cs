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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department, DepartmentRepository, int>
    {

        private DepartmentRepository departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository) : base(departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
    }
}
