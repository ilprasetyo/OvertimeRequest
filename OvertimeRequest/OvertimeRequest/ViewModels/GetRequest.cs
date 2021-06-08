using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class GetRequest
    {
        public string NIK { get; set; }
        public string Name { get; set; }
        public string ManagerId { get; set; }
        public DateTime StartHours { get; set; }
        public DateTime EndHours { get; set; }
        public string Reason { get; set; }
        public int Payroll { get; set; }
        public string Status { get; set; }
    }
}
