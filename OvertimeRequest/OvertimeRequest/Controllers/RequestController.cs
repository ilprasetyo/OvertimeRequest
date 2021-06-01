using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OvertimeRequest.Base;
using OvertimeRequest.Context;
using OvertimeRequest.Handlers;
using OvertimeRequest.Models;
using OvertimeRequest.Repositories.Data;
using OvertimeRequest.Repositories.Interface;
using OvertimeRequest.Services;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    [Authorize(Roles = "Employee, Manager")]
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class RequestController : BaseController<Request, RequestRepository, int>
    {
        private RequestRepository requestRepository;
        private MyContext myContext;
        private readonly IConfiguration _configuration;
        private readonly IGenericDapper _dapper;

        public RequestController(RequestRepository requestRepository, MyContext myContext, IConfiguration configuration, IGenericDapper dapper) : base(requestRepository)
        {
            this.requestRepository = requestRepository;
            this.myContext = myContext;
            _configuration = configuration;
            _dapper = dapper;
        }

        [HttpPost("RequestEmployee")]
        public ActionResult RequestEmployee(RequestVM requestVM)
        {
           
            var getEmployee = myContext.Employees.Where(e => e.NIK == requestVM.NIK).FirstOrDefault();

           
                var dbprams = new DynamicParameters();
                dbprams.Add("NIK", requestVM.NIK, DbType.String);
                dbprams.Add("StartHours", requestVM.StartHours, DbType.DateTime);
                dbprams.Add("EndHours", requestVM.EndHours, DbType.DateTime);
                dbprams.Add("Reason", requestVM.Reason, DbType.String);

                var result = Task.FromResult(_dapper.Insert<int>("[dbo].[SP_OvertimeRequest]"
                    , dbprams,
                    commandType: CommandType.StoredProcedure));
                //send email
                var sendEmail = new SendEmail(myContext);
                sendEmail.SendEmailSubmitRequest(getEmployee);
            
                return Ok(new { Status = "Success", Message = "Request Has Been Sent, Check your email" });
        }


    }
}
