using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OvertimeRequest.Base;
using OvertimeRequest.Context;
using OvertimeRequest.Models;
using OvertimeRequest.Repositories.Data;
using OvertimeRequest.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    //[Authorize(Roles = "Employee, Manager, Payroll")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department, DepartmentRepository, int>
    {

        private readonly DepartmentRepository departmentRepository;
        private readonly MyContext myContext;
        private readonly IConfiguration _configuration;
        private readonly IGenericDapper _dapper;

        public DepartmentController(DepartmentRepository departmentRepository, MyContext myContext, IConfiguration configuration, IGenericDapper dapper) : base(departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            this.myContext = myContext;
            _configuration = configuration;
            _dapper = dapper;
        }

        [HttpGet("GetPosition")]
        public List<dynamic> GetPosition()
        {
            string query = string.Format("select pos.Name as 'Name', dep.Name as 'Department' from TB_M_Position as pos inner join TB_M_Department as dep on dep.Id = pos.DepartmentId");

            List<dynamic> get = _dapper.GetAllNoParam<dynamic>(query, CommandType.Text);

            return get;
        }
        
        [HttpGet("GetRole")]
        public List<dynamic> GetRole()
        {
            string query = string.Format("select emp.NIK as 'NIK', emp.Name as 'Name', r.Name as 'Role' from TB_M_Employee as emp INNER JOIN TB_T_EmployeeRole as empR on empR.EmployeeNIK = emp.NIK inner join TB_M_Role as r on r.Id = empR.RoleId");

            List<dynamic> get = _dapper.GetAllNoParam<dynamic>(query, CommandType.Text);

            return get;
        }
    }
}
