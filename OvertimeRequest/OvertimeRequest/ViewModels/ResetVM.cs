using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class ResetVM
    {
        public string email { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
