using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class Request
    {
        public DateTime StartHours { get; set; }
        public DateTime EndHours { get; set; }
        public string Reason { get; set; }
        public StatusRequest Status { get; set; }
        public int Payroll { get; set; }
        public int Quota { get; set; }
        public enum StatusRequest
        {
            Waiting,
            Approve,
            Reject
        }
    }
}
