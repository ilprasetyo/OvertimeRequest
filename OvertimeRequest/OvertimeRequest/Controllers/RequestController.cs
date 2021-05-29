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
    public class RequestController : BaseController<Request, RequestRepository, int>
    {
        private RequestRepository requestRepository;

        public RequestController(RequestRepository requestRepository) : base(requestRepository)
        {
            this.requestRepository = requestRepository;
        }
    }
}
