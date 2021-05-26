using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_T_EmployeeRequest")]
    public class EmployeeRequest
    {
        [Key]
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Request Request { get; set; }
    }
}