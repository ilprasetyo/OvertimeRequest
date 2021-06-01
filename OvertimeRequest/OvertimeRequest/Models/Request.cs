using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Request")]
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartHours { get; set; }
        public DateTime EndHours { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int Payroll { get; set; }
        public ICollection<EmployeeRequest> EmployeeRequests { get; set; }
      
    }
}
