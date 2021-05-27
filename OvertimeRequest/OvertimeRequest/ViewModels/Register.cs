using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class Register
    {
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public StatusRequest Status { get; set; }
        
        public enum StatusRequest
        {
            Waiting,
            Approve,
            Reject
        }
    }
}
