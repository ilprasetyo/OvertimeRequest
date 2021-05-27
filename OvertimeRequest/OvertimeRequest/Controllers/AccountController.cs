using Dapper;
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
        public ActionResult ChangePassword()
        {

            var email = Request.Headers["Email"].ToString();
            var CurrentPassword = Request.Headers["CurrentPassword"].ToString();
            var NewPassword = Request.Headers["NewPassword"].ToString();
            var VerifyPassword = Request.Headers["VerifyPassword"].ToString();
            var cek = myContext.Accounts.Where(account => account.Employee.Email == email).FirstOrDefault();

            if (cek == null || !BCrypt.Net.BCrypt.Verify(CurrentPassword, cek.Password))
            {

                return NotFound("Gagal");

            }
            else if (NewPassword != VerifyPassword)
            {
                return BadRequest("Password Baru dan Verify Password Berbeda");
            }
            else
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(NewPassword);
                cek.Password = passwordHash;
                var result = accountRepository.Put(cek) > 0 ? (ActionResult)Ok("Data berhasil diupdate") : BadRequest("Data gagal diupdate");
                return result;
            }
        }

        [HttpPost("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            var email = Request.Headers["Email"].ToString();
            var getUser = myContext.Accounts.Where(e => e.Employee.Email == email).FirstOrDefault();
            string resetCode = Guid.NewGuid().ToString();
            if (getUser == null)
            {
                return NotFound("Email salah");
            }
            else
            {
                var getEmployee = myContext.Employees.Where(e => e.NIK == getUser.NIK).FirstOrDefault();
                var jwt = new JwtServices(_configuration);
                var token = jwt.GenerateSecurityToken(email);
                string url = "https://localhost:44323/api/Account/ResetPassword?Token=";

                //send email
                var sendEmail = new SendEmail(myContext);
                sendEmail.SendEmailForgotPassword(url, token, getEmployee);
                return Ok("Check Your Email");

            }

        }


        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword()
        {
            string token = Request.Query["Token"].ToString();

            var jwt = new JwtSecurityTokenHandler();

            var jwtRead = jwt.ReadJwtToken(token);

            var NewPassword = Request.Headers["NewPassword"].ToString();
            var VerifyPassword = Request.Headers["VerifyPassword"].ToString();

            if (NewPassword == VerifyPassword)
            {
                var email = jwtRead.Claims.First(email => email.Type == "email").Value;
                var cek = myContext.Accounts.Where(account => account.Employee.Email == email).FirstOrDefault();
                if (cek == null)
                {
                    return NotFound("Email Salah");
                }
                else
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(NewPassword);
                    cek.Password = passwordHash;

                    //update
                    var result = accountRepository.Put(cek) > 0 ? (ActionResult)Ok("Data berhasil diupdate") : BadRequest("Data gagal diupdate");
                    return result;
                }

            }

            else
            {
                return BadRequest("Password tidak sesuai");
            }

        }

    }
}
