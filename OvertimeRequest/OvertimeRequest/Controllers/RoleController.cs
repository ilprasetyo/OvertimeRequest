using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OvertimeRequest.Base;
using OvertimeRequest.Handlers;
using OvertimeRequest.Models;
using OvertimeRequest.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RoleController : BaseController<Role, RoleRepository, int>
    {
        private RoleRepository roleRepository;
        //private readonly SimpleAuthentication simpleAuthentication;
        //private readonly ILogger<RoleController> logger;


        public RoleController(RoleRepository roleRepository) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
            //this.simpleAuthentication = simpleAuthentication;
            //this.logger = logger;
        }

        //[HttpGet("CheckRole")]
        //public string CheckRole()
        //{
        //    var header = Request.Headers["Application"].ToString();
        //    var hedr = Request.Headers["Token"].ToString();
        //    var result = simpleAuthentication.Check(header, hedr);
        //    if (result)
        //    {
        //        return "Authorized";
        //    }

        //    return "Forbiden";
        //}
    }
}
