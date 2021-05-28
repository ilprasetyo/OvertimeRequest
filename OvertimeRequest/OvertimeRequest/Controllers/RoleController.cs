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
    public class RoleController : BaseController<Role, RoleRepository, int>
    {
        private RoleRepository roleRepository;

        public RoleController(RoleRepository roleRepository) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
        }
    }
}
