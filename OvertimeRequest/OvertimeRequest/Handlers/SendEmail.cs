using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OvertimeRequest.Handlers
{
    public class SendEmail
    {
        private readonly MyContext context;
        public SendEmail(MyContext context)
        {
            this.context = context;
        }

        public void SendEmailForgotPassword(string url, string token, Employee employee)
        {
            var parameter = context.Parameters.Find(1);


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(parameter.Name, parameter.Value);

            smtp.Send(parameter.Name, employee.Email, "Reset Password", $"Link Reset Password : {url}{token}");

        }
    }
}
