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
    public class PositionController : BaseController<Position, PositionRepository, int>
    {
        private PositionRepository positionRepository;

        public PositionController(PositionRepository positionRepository) : base(positionRepository)
        {
            this.positionRepository = positionRepository;
        }
    }
}
