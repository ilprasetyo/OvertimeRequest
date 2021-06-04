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
    //[Authorize(Roles = "Employee, Manager, Payroll")]
    [Route("api/[controller]")]
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
            var getManager = myContext.Employees.Where(e => e.NIK == getEmployee.ManagerId).FirstOrDefault();
            
            var dbprams = new DynamicParameters();
            dbprams.Add("NIK", requestVM.NIK, DbType.String);
            dbprams.Add("start", requestVM.start, DbType.DateTime);
            dbprams.Add("end", requestVM.end, DbType.DateTime);
            dbprams.Add("reason", requestVM.reason, DbType.String);

            var result = Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Request]"
                , dbprams,
                commandType: CommandType.StoredProcedure));
            //send email
            var sendEmail = new SendEmail(myContext);
            sendEmail.SendEmailSubmitRequest(getEmployee);
            sendEmail.SendEmailRequestToManager(getManager, getEmployee);
            return Ok(new { Status = "Success", Message = "Request Has Been Sent, Check your email" });
        }
        
        [HttpPost("ApproveManager")]
        public ActionResult ApproveManager(ResponseVM responseVM)
        {
           
            var getEmployee = myContext.Employees.Where(e => e.NIK == responseVM.NIK).FirstOrDefault();
            var getPayroll = myContext.Employees.Where(e => e.NIK.Contains("EMP04012105")).FirstOrDefault();
            
            var dbprams = new DynamicParameters();
            dbprams.Add("RequestId", responseVM.RequestId, DbType.Int32);
            dbprams.Add("NIK", responseVM.NIK, DbType.String);

            var result = Task.FromResult(_dapper.Insert<dynamic>("[dbo].[SP_ApproveManager]"
                , dbprams,
                commandType: CommandType.StoredProcedure));
            //send email
            var sendEmail = new SendEmail(myContext);
            sendEmail.SendEmailApproveManager(getPayroll, getEmployee);
            return Ok(new { Status = "Success", Message = "Request Has Been Sent, Check your email" });
        }

        [HttpPost("RejectManager")]
        public ActionResult RejectManager(ResponseVM responseVM)
        {

            var getEmployee = myContext.Employees.Where(e => e.NIK == responseVM.NIK).FirstOrDefault();

            var dbprams = new DynamicParameters();
            dbprams.Add("RequestId", responseVM.RequestId, DbType.Int32);
            dbprams.Add("NIK", responseVM.NIK, DbType.String);

            var result = Task.FromResult(_dapper.Insert<dynamic>("[dbo].[SP_RejectManager]"
                , dbprams,
                commandType: CommandType.StoredProcedure));
            //send email
            var sendEmail = new SendEmail(myContext);
            sendEmail.SendEmailReject(getEmployee);
            return Ok(new { Status = "Success", Message = "Request Has Been Sent, Check your email" });
        }
        
        [HttpPost("ApprovePayroll")]
        public ActionResult ApprovePayroll(ApproveVM approveVM)
        {
           
            var getEmployee = myContext.Employees.Where(e => e.NIK == approveVM.NIK).FirstOrDefault();
            
            var dbprams = new DynamicParameters();
            dbprams.Add("RequestId", approveVM.RequestId, DbType.Int32);
            dbprams.Add("NIK", approveVM.NIK, DbType.String);
            dbprams.Add("start", approveVM.start, DbType.DateTime);
            dbprams.Add("end", approveVM.end, DbType.DateTime);

            var result = Task.FromResult(_dapper.Insert<dynamic>("[dbo].[SP_ApprovePayroll]"
                , dbprams,
                commandType: CommandType.StoredProcedure));
            //send email
            var sendEmail = new SendEmail(myContext);
            sendEmail.SendEmailApprovePayroll(getEmployee);
            return Ok(new { Status = "Success", Message = "Request Has Been Sent, Check your email" });
        }

        [HttpPost("RejectPayroll")]
        public ActionResult RejectPayroll(ResponseVM responseVM)
        {

            var getEmployee = myContext.Employees.Where(e => e.NIK == responseVM.NIK).FirstOrDefault();

            var dbprams = new DynamicParameters();
            dbprams.Add("RequestId", responseVM.RequestId, DbType.Int32);
            dbprams.Add("NIK", responseVM.NIK, DbType.String);

            var result = Task.FromResult(_dapper.Insert<dynamic>("[dbo].[SP_RejectPayroll]"
                , dbprams,
                commandType: CommandType.StoredProcedure));
            //send email
            var sendEmail = new SendEmail(myContext);
            sendEmail.SendEmailReject(getEmployee);
            return Ok(new { Status = "Success", Message = "Request Has Been Sent, Check your email" });
        }
        [HttpPost("GetApproveManager")]
        public List<dynamic> GetApproveManager(GetVM getVM)
        {
            var getEmployee = myContext.Employees.Where(e => e.NIK == getVM.NIK).FirstOrDefault();

            var dbprams = new DynamicParameters();
            dbprams.Add("ManagerId", getVM.NIK, DbType.String);

            List<dynamic> result = _dapper.GetAll<dynamic>("[dbo].[SP_GetApproveManager]"
               , dbprams,
               commandType: CommandType.StoredProcedure);

            return result;
        }

        [HttpPost("GetApprovePayroll")]
        public List<dynamic> GetApprovePayroll(GetVM getVM)
        {
            var getEmployee = myContext.Employees.Where(e => e.NIK == getVM.NIK).FirstOrDefault();

            var dbprams = new DynamicParameters();
            dbprams.Add("ManagerId", getVM.NIK, DbType.String);

            List<dynamic> result = _dapper.GetAll<dynamic>("[dbo].[SP_GetApprovePayroll]"
               , dbprams,
               commandType: CommandType.StoredProcedure);

            return result;
        }

        [HttpPost("GetHistroryRequest")]
        public List<dynamic> GetHistoryRequest(GetVM getVM)
        {
            var getEmployee = myContext.Employees.Where(e => e.NIK == getVM.NIK).FirstOrDefault();

            var dbprams = new DynamicParameters();
            dbprams.Add("NIK", getVM.NIK, DbType.String);

            List<dynamic> result = _dapper.Get<dynamic>("[dbo].[SP_GetHistoryRequest]"
               , dbprams,
               commandType: CommandType.StoredProcedure);

            return result;
        }

        [HttpPost("GetRequestActual")]
        public List<dynamic> GetRequestActual(GetVM getVM)
        {
            var getEmployee = myContext.Employees.Where(e => e.NIK == getVM.NIK).FirstOrDefault();

            var dbprams = new DynamicParameters();
            dbprams.Add("NIK", getVM.NIK, DbType.String);

            List<dynamic> result = _dapper.GetAll<dynamic>("[dbo].[SP_GetRequestAct]"
               , dbprams,
               commandType: CommandType.StoredProcedure);

            return result;
        }


    }
}
