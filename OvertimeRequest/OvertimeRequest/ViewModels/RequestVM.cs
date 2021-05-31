using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class RequestVM
    {
        public string NIK { get; set; }
        public DateTime StartHours { get; set; }
        public DateTime EndHours { get; set; }
        public string Reason { get; set; }
  
    }
}
