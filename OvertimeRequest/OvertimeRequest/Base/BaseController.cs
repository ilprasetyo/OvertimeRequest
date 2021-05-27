using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OvertimeRequest.Repositories.Interface.IGenericRepository;

namespace OvertimeRequest.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
        
    {
    }
}
