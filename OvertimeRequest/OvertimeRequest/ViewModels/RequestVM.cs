using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class RequestVM
    {
        public string NIK { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string reason { get; set; }
  
    }
}
