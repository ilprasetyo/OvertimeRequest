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
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, int>
    {

        private readonly AccountRepository accountRepository;
        private readonly MyContext myContext;
        private readonly IConfiguration _configuration;
        private readonly IGenericDapper _dapper;

        public AccountController(AccountRepository accountRepository, MyContext myContext, IConfiguration configuration, IGenericDapper dapper) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
            _configuration = configuration;
            _dapper = dapper;
        }
        [HttpPost("Register")]
        public ActionResult Register(Register register)
        {
            var password = Hash.HashPassword(register.Password);
            var dbparams = new DynamicParameters();
            dbparams.Add("NIK", register.NIK, DbType.String);
            dbparams.Add("Name", register.Name, DbType.String);
            dbparams.Add("Email", register.Email, DbType.String);
            dbparams.Add("Password", password, DbType.String);
            dbparams.Add("BirthDate", register.BirthDate, DbType.DateTime);
            dbparams.Add("Gender", register.Gender, DbType.String);
            dbparams.Add("Phone", register.Phone, DbType.String);
            dbparams.Add("Address", register.Address, DbType.String);
            dbparams.Add("Status", register.Status, DbType.String);
            dbparams.Add("Position", register.Position, DbType.Int32);

            var result = Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Register]"
                , dbparams,
                commandType: CommandType.StoredProcedure));

            return Ok(new { Status = "Success", Message = "User has been registered successfully" });
        }


        [HttpPost("Login")]
        public ActionResult Login(Login login)
        {

            var dbprams = new DynamicParameters();
            dbprams.Add("Email", login.Email, DbType.String);
            dynamic result = _dapper.Get<dynamic>("[dbo].[SP_Login]"
            , dbprams,
            commandType: CommandType.StoredProcedure);

            if (BCrypt.Net.BCrypt.Verify(login.Password, result.Password))
            {

                //get token dari kelas jwt services
                var jwt = new JwtServices(_configuration);
                var token = jwt.GenerateSecurityToken(result.Name, result.Email, result.Role);
                return Ok(new { token });

            }

            return BadRequest("Gagal Login");
        }

        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(string email, string oldPassword, string newPassword)
        {
            try
            {
                var user = myContext.Accounts.SingleOrDefault(a => a.Employee.Email == email);
                var passwordCheck = Hash.ValidatePassword(oldPassword, user.Password);
                if (user != null && passwordCheck)
                {
                    var newPass = Hash.HashPassword(newPassword);
                    user.Password = newPass;
                    var save = myContext.SaveChanges();
                    if (save > 0)
                    {
                        return Ok("Password has been changed.");
                    }
                }
                return BadRequest("Your password is incorrect.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
            //return Ok();
        }

        [HttpPost("ForgotPassword")]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                //var email = Request.Headers["email"].ToString();
                var userExisting = myContext.Employees.SingleOrDefault(e => e.Email == email);
                //var role = context.Employees.SingleOrDefault(e => e.Id == userExisting.Id);
                string resetCode = Guid.NewGuid().ToString();
                if (userExisting.Email == email)
                {
                    var getEmployee = myContext.Employees.Where(e => e.NIK == userExisting.NIK).FirstOrDefault();
                    var jwt = new JwtServices(_configuration);
                    var token = jwt.GenerateSecurityToken(email);
                    string url = "https://localhost:44323/api/Account/ResetPassword?Token=";

                    //send email
                    var sendEmail = new SendEmail(myContext);
                    sendEmail.SendEmailForgotPassword(url, token, getEmployee);
                    return Ok("Check Your Email");
                }
                return BadRequest("Email not found.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }


        //[Authorize]
        [HttpPost]
        [Route("resetpassword")]
        public ActionResult ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                var userExisting = myContext.Employees.SingleOrDefault(e => e.Email == email);
                var passwordExisting = myContext.Accounts.SingleOrDefault(a => a.Employee.Email == email);
                if (userExisting.Email == email)
                {
                    if (newPassword == confirmPassword)
                    {
                        passwordExisting.Password = Hash.HashPassword(newPassword);
                        var save = myContext.SaveChanges();
                        if (save > 0)
                        {
                            return Ok("Your password has been changed.");
                        }
                    }
                    return BadRequest("Your confirmation password is incorrect.");
                }
                return BadRequest("Email not found.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            //return Ok();
        }

    }
}