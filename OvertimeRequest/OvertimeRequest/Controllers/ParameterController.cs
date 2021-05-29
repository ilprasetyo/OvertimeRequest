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
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ParameterController : BaseController<Parameter, ParameterRepository, int>
    {
        private ParameterRepository parameterRepository;

        public ParameterController(ParameterRepository parameterRepository) : base(parameterRepository)
        {
            this.parameterRepository = parameterRepository;
        }
    }
}
